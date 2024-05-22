namespace Theatre.DataProcessor
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using Theatre.Data;
    using Theatre.Data.Models;
    using Theatre.Data.Models.Enums;
    using Theatre.DataProcessor.ImportDto;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfulImportPlay
            = "Successfully imported {0} with genre {1} and a rating of {2}!";

        private const string SuccessfulImportActor
            = "Successfully imported actor {0} as a {1} character!";

        private const string SuccessfulImportTheatre
            = "Successfully imported theatre {0} with #{1} tickets!";

        public static string ImportPlays(TheatreContext context, string xmlString)
        {
            StringBuilder sb = new StringBuilder();
            XmlRootAttribute xmlRoot = new XmlRootAttribute("Plays");
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportPlayDto[]), xmlRoot);

            using StringReader sr = new StringReader(xmlString);

            ImportPlayDto[] playDtos = (ImportPlayDto[])xmlSerializer.Deserialize(sr);

            HashSet<Play> validPlays = new HashSet<Play>();

            foreach (ImportPlayDto playDto in playDtos)
            {
                if (!IsValid(playDto))
                {
                    sb.AppendLine("Invalid data!");
                    continue;
                }

                if (!TimeSpan.TryParseExact(playDto.Duration, "c", CultureInfo.InvariantCulture, out TimeSpan duration))
                {
                    sb.AppendLine("Invalid data!");
                    continue;
                }

                if (duration.Hours < 1)
                {
                    sb.AppendLine("Invalid data!");
                    continue;
                }

                if(!Enum.TryParse(typeof(Genre), playDto.Genre, out object genre))
                {
                    sb.AppendLine("Invalid data!");
                    continue;
                }

                Play play = new Play()
                {
                    Title = playDto.Title,
                    Duration = duration,
                    Rating = playDto.Rating,
                    Genre = (Genre)genre,
                    Description = playDto.Description,
                    Screenwriter = playDto.Screenwriter
                };

                validPlays.Add(play);
                sb.AppendLine($"Successfully imported {play.Title} with genre {play.Genre} and a rating of {play.Rating}!");
            }

            context.Plays.AddRange(validPlays);
            context.SaveChanges();
            
            return sb.ToString().TrimEnd();
        }

        public static string ImportCasts(TheatreContext context, string xmlString)
        {
            StringBuilder sb = new StringBuilder();
            XmlRootAttribute xmlRoot = new XmlRootAttribute("Casts");
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportCastDto[]), xmlRoot);
            
            using StringReader sr = new StringReader(xmlString);

            ImportCastDto[] castDtos = (ImportCastDto[])xmlSerializer.Deserialize(sr);

            HashSet<Cast> validCasts = new HashSet<Cast>();

            foreach (ImportCastDto castDto in castDtos)
            {
                if (!IsValid(castDto))
                {
                    sb.AppendLine("Invalid data!");
                    continue;
                }

                Cast cast = new Cast()
                {
                    FullName = castDto.FullName,
                    IsMainCharacter = castDto.IsMainCharacter,
                    PhoneNumber = castDto.PhoneNumber,
                    PlayId = castDto.PlayId
                };

                validCasts.Add(cast);
                sb.AppendLine($"Successfully imported actor {cast.FullName} as a {(cast.IsMainCharacter ? "main" : "lesser")} character!");
            }

            context.AddRange(validCasts);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportTtheatersTickets(TheatreContext context, string jsonString)
        {
            StringBuilder sb = new StringBuilder();

            ImportTheatreDto[] theatreDtos = JsonConvert.DeserializeObject<ImportTheatreDto[]>(jsonString);

            HashSet<Theatre> validTheatres = new HashSet<Theatre>();

            foreach (ImportTheatreDto theatreDto in theatreDtos)
            {
                if (!IsValid(theatreDto))
                {
                    sb.AppendLine("Invalid data!");
                    continue;
                }

                HashSet<Ticket> validTickets = new HashSet<Ticket>();
                foreach (ImportTicketDto ticketDto in theatreDto.Tickets)
                {
                    if (!IsValid(ticketDto))
                    {
                        sb.AppendLine("Invalid data!");
                        continue;
                    }

                    //if (!context.Plays.Any(p => p.Id == ticketDto.PlayId))
                    //{
                    //    sb.AppendLine("Invalid data!");
                    //    continue;
                    //}

                    Ticket ticket = new Ticket()
                    {
                        Price = ticketDto.Price,
                        RowNumber = ticketDto.RowNumber,
                        PlayId = ticketDto.PlayId
                    };

                    validTickets.Add(ticket);
                }

                Theatre theatre = new Theatre()
                {
                    Name = theatreDto.Name,
                    NumberOfHalls = theatreDto.NumberOfHalls,
                    Director = theatreDto.Director,
                    Tickets = validTickets
                };

                validTheatres.Add(theatre);
                sb.AppendLine($"Successfully imported theatre {theatre.Name} with #{theatre.Tickets.Count} tickets!");
            }

            context.Theatres.AddRange(validTheatres);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }


        private static bool IsValid(object obj)
        {
            var validator = new ValidationContext(obj);
            var validationRes = new List<ValidationResult>();

            var result = Validator.TryValidateObject(obj, validator, validationRes, true);
            return result;
        }
    }
}
