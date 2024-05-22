namespace Theatre.DataProcessor
{
    using Newtonsoft.Json;
    using System;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using Theatre.Data;
    using Theatre.DataProcessor.ExportDto;

    public class Serializer
    {
        public static string ExportTheatres(TheatreContext context, int numbersOfHalls)
        {
            var result = context
                .Theatres
                .ToArray()
                
                .Where(t => t.NumberOfHalls >= numbersOfHalls &&
                       t.Tickets.Count >= 20)

                .Select(t => new
                {
                    Name = t.Name,
                    Halls = t.NumberOfHalls,

                    TotalIncome = t.Tickets
                        .Where(ticket => ticket.RowNumber >= 1 &&
                                         ticket.RowNumber <= 5)
                        .Sum(ticket => ticket.Price),

                    Tickets = t.Tickets
                        .Where(ticket => ticket.RowNumber >= 1 &&
                                         ticket.RowNumber <= 5)
                        .Select(ticket => new
                        {
                            Price = decimal.Parse(ticket.Price.ToString("F2")),
                            RowNumber = ticket.RowNumber
                        })
                        .OrderByDescending(ticket => ticket.Price)
                })
                .OrderByDescending(t => t.Halls)
                .ThenBy(t => t.Name)
                .ToList();
                

            string jsonResult = JsonConvert.SerializeObject(result, Formatting.Indented);

            return jsonResult;
        }

        public static string ExportPlays(TheatreContext context, double rating)
        {
            StringBuilder sb = new StringBuilder();

            XmlRootAttribute xmlRoot = new XmlRootAttribute("Plays");
            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ExportPlayDto[]), xmlRoot);

            using StringWriter sw = new StringWriter(sb);

            ExportPlayDto[] plays = context
                .Plays
                .ToArray()
                .Where(p => p.Rating <= rating)
                .Select(p => new ExportPlayDto 
                {
                    Title = p.Title,
                    Duration = p.Duration.ToString("c"),
                    Rating = (p.Rating == 0 ? "Premier" : $"{p.Rating}"),
                    Genre = p.Genre,
                    Actors = p.Casts
                        .Where(a => a.IsMainCharacter == true)
                        .Select(a => new ExportActorDto
                        {
                            FullName = a.FullName,
                            MainCharacter = $"Plays main character in '{p.Title}'."
                        })
                        .OrderByDescending(a => a.FullName)
                        .ToArray()
                })
                .OrderBy(p => p.Title)
                .ThenByDescending(p => p.Genre)
                .ToArray();

            xmlSerializer.Serialize(sw, plays, namespaces);

            return sb.ToString().TrimEnd();
        }
    }
}
