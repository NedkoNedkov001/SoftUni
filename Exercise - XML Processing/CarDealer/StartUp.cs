using CarDealer.Data;
using CarDealer.DTO.Import;
using CarDealer.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace CarDealer
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            CarDealerContext context = new CarDealerContext();

            //ResetDatabase(context);
            string inputXml = File.ReadAllText("../../..//Datasets/suppliers.xml");
            Console.WriteLine(ImportSuppliers(context, inputXml));

        }

        private static void ResetDatabase(CarDealerContext context)
        {
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
            System.Console.WriteLine("Successfully created!");
        }

        public static string ImportSuppliers(CarDealerContext context, string inputXml)
        {
            XmlRootAttribute xmlRoot = new XmlRootAttribute("Suppliers");
            XmlSerializer serializer = new XmlSerializer(typeof(ImportSupplierDto[]), xmlRoot);

            using StringReader stringReader = new StringReader(inputXml);
            ImportSupplierDto[] dtos = (ImportSupplierDto[])serializer.Deserialize(stringReader);

            ICollection<Supplier> suppliers = new HashSet<Supplier>();
            foreach (ImportSupplierDto dto in dtos)
            {
                Supplier s = new Supplier()
                {
                    Name = dto.Name,
                    IsImporter = bool.Parse(dto.IsImporter)
                };
                suppliers.Add(s);
            }

            context.Suppliers.AddRange(suppliers);
            context.SaveChanges();

            return $"Successfully imported {suppliers.Count}";
        }
    }
}