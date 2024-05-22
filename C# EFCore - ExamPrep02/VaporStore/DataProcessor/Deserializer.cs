namespace VaporStore.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using Data;
    using Newtonsoft.Json;
    using VaporStore.Data.Models;
    using VaporStore.Data.Models.Enums;
    using VaporStore.DataProcessor.Dto.Import;

    public static class Deserializer
    {
        public static string ImportGames(VaporStoreDbContext context, string jsonString)
        {
            StringBuilder sb = new StringBuilder();

            ImportGameDto[] gameDtos = JsonConvert.DeserializeObject<ImportGameDto[]>(jsonString);

            List<Game> games = new List<Game>();
            List<Developer> developers = new List<Developer>();
            List<Genre> genres = new List<Genre>();
            List<Tag> tags = new List<Tag>();

            foreach (ImportGameDto gameDto in gameDtos)
            {
                if (!IsValid(gameDto))
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

                DateTime releaseDate;
                bool isReleaseDateValid = DateTime.TryParseExact(gameDto.ReleaseDate, "yyyy-MM-dd",
                    CultureInfo.InvariantCulture, DateTimeStyles.None, out releaseDate);

                if (!isReleaseDateValid)
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

                if (gameDto.Tags.Length == 0)
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

                Game g = new Game()
                {
                    Name = gameDto.Name,
                    Price = gameDto.Price,
                    ReleaseDate = releaseDate
                };

                Developer gameDev = developers
                    .FirstOrDefault(d => d.Name == gameDto.Developer);

                if (gameDev == null)
                {
                    Developer newGameDev = new Developer()
                    {
                        Name = gameDto.Developer
                    };
                    developers.Add(newGameDev);

                    g.Developer = newGameDev;
                }
                else
                {
                    g.Developer = gameDev;
                }

                Genre gameGenre = genres
                    .FirstOrDefault(g => g.Name == gameDto.Genre);

                if (gameGenre == null)
                {
                    Genre newGenre = new Genre()
                    {
                        Name = gameDto.Genre
                    };

                    genres.Add(newGenre);
                    g.Genre = newGenre;
                }
                else
                {
                    g.Genre = gameGenre;
                }

                foreach (string tagName in gameDto.Tags)
                {
                    if (String.IsNullOrEmpty(tagName))
                    {
                        continue;
                    }

                    Tag gameTag = tags
                        .FirstOrDefault(t => t.Name == tagName);

                    if (gameTag == null)
                    {
                        Tag newGameTag = new Tag()
                        {
                            Name = tagName
                        };

                        tags.Add(newGameTag);
                        g.GameTags.Add(new GameTag()
                        {
                            Game = g,
                            Tag = newGameTag
                        });
                    }
                    else
                    {
                        g.GameTags.Add(new GameTag()
                        {
                            Game = g,
                            Tag = gameTag
                        });
                    }
                }

                if (g.GameTags.Count == 0)
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

                games.Add(g);
                sb.AppendLine($"Added {g.Name} ({g.Genre.Name}) with {g.GameTags.Count} tags");
            }

            context.Games.AddRange(games);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportUsers(VaporStoreDbContext context, string jsonString)
        {
            StringBuilder sb = new StringBuilder();

            ImportUserDto[] userDtos = JsonConvert.DeserializeObject<ImportUserDto[]>(jsonString);

            HashSet<User> users = new HashSet<User>();

            foreach (ImportUserDto userDto in userDtos)
            {
                bool hasInvalidCard = false;
                if (!IsValid(userDto))
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

                User user = new User()
                {
                    FullName = userDto.FullName,
                    Username = userDto.Username,
                    Email = userDto.Email,
                    Age = userDto.Age
                };

                HashSet<Card> userCards = new HashSet<Card>();

                foreach (ImportCardDto cardDto in userDto.Cards)
                {
                    string[] validTypes = new string[] { "Debit", "Credit" };

                    if (!IsValid(cardDto) || validTypes.Any(t => t == cardDto.Type) == false)
                    {
                        hasInvalidCard = true;
                        continue;
                    }

                    Card card = new Card()
                    {
                        Cvc = cardDto.CVC,
                        Number = cardDto.Number,
                        Type = cardDto.Type == "Debit" ? CardType.Debit : CardType.Credit
                    };

                    user.Cards.Add(card);
                }

                if (hasInvalidCard)
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

                users.Add(user);
                sb.AppendLine($"Imported {userDto.Username} with {userDto.Cards.Length} cards");
            }
            context.Users.AddRange(users);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportPurchases(VaporStoreDbContext context, string xmlString)
        {
            StringBuilder sb = new StringBuilder();

            XmlRootAttribute xmlRoot = new XmlRootAttribute("Purchases");
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportPurchaseDto[]), xmlRoot);

            using StringReader sr = new StringReader(xmlString);

            ImportPurchaseDto[] purchaseDtos = (ImportPurchaseDto[])xmlSerializer.Deserialize(sr);

            HashSet<Purchase> purchases = new HashSet<Purchase>();

            foreach (ImportPurchaseDto purchaseDto in purchaseDtos)
            {
                if (!IsValid(purchaseDto))
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

                bool isDateValid = DateTime.TryParseExact(purchaseDto.Date,
                    "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime date);

                if (!isDateValid)
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

                if (!Enum.TryParse(typeof(PurchaseType), purchaseDto.Type, out object purchaseType))
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

                Card card = context.Cards.FirstOrDefault(c => c.Number == purchaseDto.Card);

                if (card == null)
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

                Game game = context.Games.FirstOrDefault(g => g.Name == purchaseDto.Title);

                if (game == null)
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

                Purchase purchase = new Purchase()
                {
                    Date = date,
                    ProductKey = purchaseDto.Key,
                    Type = (PurchaseType)purchaseType,
                    Card = card,
                    Game = game
                };

                purchases.Add(purchase);
                sb.AppendLine($"Imported {purchase.Game.Name} for {purchase.Card.User.Username}");
            }
            context.Purchases.AddRange(purchases);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}