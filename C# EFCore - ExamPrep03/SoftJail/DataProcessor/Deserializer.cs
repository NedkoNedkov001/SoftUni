namespace SoftJail.DataProcessor
{

    using Data;
    using Newtonsoft.Json;
    using SoftJail.Data.Models;
    using SoftJail.Data.Models.Enums;
    using SoftJail.DataProcessor.ImportDto;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;

    public class Deserializer
    {
        public static string ImportDepartmentsCells(SoftJailDbContext context, string jsonString)
        {
            StringBuilder sb = new StringBuilder();
            ImportDepartmentDto[] departmentDtos = JsonConvert.DeserializeObject<ImportDepartmentDto[]>(jsonString);

            HashSet<Department> validDepartments = new HashSet<Department>();

            foreach (ImportDepartmentDto departmentDto in departmentDtos)
            {
                if (!IsValid(departmentDto))
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

                HashSet<Cell> cells = new HashSet<Cell>();
                bool hasInvalidCells = false;
                foreach (ImportCellDto cellDto in departmentDto.Cells)
                {
                    if (!IsValid(cellDto))
                    {
                        hasInvalidCells = true;
                        break;
                    }

                    Cell cell = new Cell()
                    {
                        CellNumber = cellDto.CellNumber,
                        HasWindow = cellDto.HasWindow
                    };

                    cells.Add(cell);
                }

                if (hasInvalidCells)
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

                Department department = new Department()
                {
                    Name = departmentDto.Name,
                    Cells = cells
                };

                validDepartments.Add(department);
                sb.AppendLine($"Imported {departmentDto.Name} with {departmentDto.Cells.Count} cells");
            }

            context.Departments.AddRange(validDepartments);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportPrisonersMails(SoftJailDbContext context, string jsonString)
        {
            StringBuilder sb = new StringBuilder();

            ImportPrisonerDto[] prisonerDtos = JsonConvert.DeserializeObject<ImportPrisonerDto[]>(jsonString);
            HashSet<Prisoner> validPrisoners = new HashSet<Prisoner>();

            foreach (ImportPrisonerDto prisonerDto in prisonerDtos)
            {
                if (!IsValid(prisonerDto))
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

                bool isIncarcerationDateValid = DateTime.TryParseExact(prisonerDto.IncarcerationDate,
                    "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime IncarcerationDate);

                if (!isIncarcerationDateValid)
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }


                DateTime? releaseDate = null;
                if (!string.IsNullOrEmpty(prisonerDto.ReleaseDate))
                {
                    bool isReleaseDateValid = DateTime.TryParseExact(prisonerDto.ReleaseDate,
                        "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles .None, out DateTime releaseDateValue);

                    if (!isReleaseDateValid)
                    {
                        sb.AppendLine("Invalid Data");
                        continue;
                    }
                    releaseDate = releaseDateValue;
                }

                HashSet<Mail> mails = new HashSet<Mail>();
                bool hasInvalidMail = false;
                foreach (ImportMailDto mailDto in prisonerDto.Mails)
                {
                    if (!IsValid(mailDto))
                    {
                        hasInvalidMail = true;
                        break;
                    }

                    Mail mail = new Mail()
                    {
                        Description = mailDto.Description,
                        Sender = mailDto.Sender,
                        Address = mailDto.Address
                    };

                    mails.Add(mail);
                }

                if (hasInvalidMail)
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

                Prisoner prisoner = new Prisoner()
                {
                    FullName = prisonerDto.FullName,
                    Nickname = prisonerDto.Nickname,
                    Age = prisonerDto.Age,
                    IncarcerationDate = IncarcerationDate,
                    ReleaseDate = releaseDate,
                    Bail = prisonerDto.Bail,
                    CellId = prisonerDto.CellId,
                    Mails = mails
                };

                validPrisoners.Add(prisoner);
                sb.AppendLine($"Imported {prisoner.FullName} {prisoner.Age} years old");
            }

            context.Prisoners.AddRange(validPrisoners);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportOfficersPrisoners(SoftJailDbContext context, string xmlString)
        {
            StringBuilder sb = new StringBuilder();
            XmlRootAttribute xmlRoot = new XmlRootAttribute("Officers");
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportOfficerDto[]), xmlRoot);

            using StringReader sr = new StringReader(xmlString);

            ImportOfficerDto[] officerDtos = (ImportOfficerDto[])xmlSerializer.Deserialize(sr);

            HashSet<Officer> validOfficers = new HashSet<Officer>();

            foreach (ImportOfficerDto officerDto in officerDtos)
            {
                if (!IsValid(officerDto))
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

                if (!Enum.TryParse(typeof(Position), officerDto.Position, out object position))
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

                if (!Enum.TryParse(typeof(Weapon), officerDto.Weapon, out object weapon))
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

                Officer officer = new Officer()
                {
                    FullName = officerDto.Name,
                    Salary = officerDto.Money,
                    Position = (Position)position,
                    Weapon = (Weapon)weapon,
                    DepartmentId = officerDto.DepartmentId,
                    OfficerPrisoners = officerDto.Prisoners.Select(x => new OfficerPrisoner
                    {
                        PrisonerId = x.Id
                    })
                    .ToList()
                };

                validOfficers.Add(officer);
                sb.AppendLine($"Imported {officer.FullName} ({officer.OfficerPrisoners.Count} prisoners)");
            }

            context.Officers.AddRange(validOfficers);
            context.SaveChanges();


            return sb.ToString().TrimEnd();

        }

        private static bool IsValid(object obj)
        {
            var validationContext = new System.ComponentModel.DataAnnotations.ValidationContext(obj);
            var validationResult = new List<ValidationResult>();

            bool isValid = Validator.TryValidateObject(obj, validationContext, validationResult, true);
            return isValid;
        }
    }
}