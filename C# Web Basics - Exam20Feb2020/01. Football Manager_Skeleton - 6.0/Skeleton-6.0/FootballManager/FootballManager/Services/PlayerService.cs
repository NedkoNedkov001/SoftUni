using FootballManager.Contracts;
using FootballManager.Data.Common;
using FootballManager.Data.Models;
using FootballManager.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballManager.Services
{
    public class PlayerService : IPlayerService
    {
        private readonly IRepository repo;
        public PlayerService(IRepository _repo)
        {
            repo = _repo;
        }

        public void AddPlayer(PlayerAddViewModel model, string userId)
        {
            User user = repo.All<User>()
                .FirstOrDefault(u => u.Id == userId);

            Player player = new Player()
            {
                FullName = model.FullName,
                ImageUrl = model.ImageUrl,
                Position = model.Position,
                Speed = model.Speed,
                Endurance = model.Endurance,
                Description = model.Description,
            };

            repo.Add(player);
            repo.SaveChanges();
            AddPlayerToUser(player.Id.ToString(), userId);

        }

        public (bool isAdded, string error) ValidateAdd(string playerId, string userId)
        {
            bool isAdded = true;
            StringBuilder errors = new StringBuilder();

            User user = repo.All<User>()
                .Where(u => u.Id == userId)
                .Include(u => u.UserPlayers)
                .FirstOrDefault();

            Player player = repo.All<Player>()
                .FirstOrDefault(p => p.Id == int.Parse(playerId));

            if (user == null)
            {
                isAdded = false;
                errors.AppendLine("Invalid user.");
            }
            if (player == null)
            {
                isAdded = false;
                errors.AppendLine("Invalid player.");
            }
            if (user != null &&
                player != null &&
                user.UserPlayers.Any(p => p.PlayerId == int.Parse(playerId)))
            {
                isAdded = false;
                errors.AppendLine("Player already in collection.");
            }

            return (isAdded, errors.ToString());
        }

        public IEnumerable<PlayerListViewModel> GetAllPlayers()
        {
            return repo.All<Player>()
                .Select(p => new PlayerListViewModel()
                {
                    ImageUrl = p.ImageUrl,
                    Description = p.Description,
                    FullName = p.FullName,
                    Position = p.Position,
                    Speed = p.Speed.ToString(),
                    Endurance = p.Endurance.ToString(),
                    PlayerId = p.Id.ToString()
                });
        }

        public (bool isValid, string error) ValidateModel(PlayerAddViewModel model)
        {
            bool isValid = true;
            StringBuilder errors = new StringBuilder();

            if (string.IsNullOrWhiteSpace(model.FullName) ||
                model.FullName.Length < 5 ||
                model.FullName.Length > 80)
            {
                isValid = false;
                errors.AppendLine("Player's full name must be between 5 and 80 characters.");
            }

            if (string.IsNullOrWhiteSpace(model.ImageUrl))
            {
                isValid = false;
                errors.AppendLine("Player must have an image.");
            }

            if (model.Speed < 0 || model.Speed > 10)
            {
                isValid = false;
                errors.AppendLine("Speed must be between 0 and 10.");
            }

            if (model.Endurance < 0 || model.Endurance > 10)
            {
                isValid = false;
                errors.AppendLine("Endurance must be between 0 and 10.");
            }

            if (string.IsNullOrWhiteSpace(model.Description) ||
                model.Description.Length < 5 ||
                model.Description.Length > 200)
            {
                isValid = false;
                errors.AppendLine("Description must be between 5 and 200 characters.");
            }

            return (isValid, errors.ToString());
        }

        public void AddPlayerToUser(string playerId, string userId)
        {
            User user = repo.All<User>()
                .FirstOrDefault(u => u.Id == userId);

            Player player = repo.All<Player>()
                .FirstOrDefault(p => p.Id == int.Parse(playerId));

            user.UserPlayers.Add(new UserPlayer
            {
                User = user,
                UserId = userId,
                Player = player,
                PlayerId = int.Parse(playerId)
            });

            repo.SaveChanges();
        }

        public IEnumerable<PlayerListViewModel> GetUserPlayers(string userId)
        {
            User user = repo.All<User>()
                .Where(u => u.Id == userId)
                .Include(u => u.UserPlayers)
                .ThenInclude(up => up.Player)
                .FirstOrDefault();

            return user
                .UserPlayers
                .Select(p => new PlayerListViewModel()
                {
                    ImageUrl = p.Player.ImageUrl,
                    Description = p.Player.Description,
                    FullName = p.Player.FullName,
                    Position = p.Player.Position,
                    Speed = p.Player.Speed.ToString(),
                    Endurance = p.Player.Endurance.ToString(),
                    PlayerId = p.Player.Id.ToString()
                })
                .ToList();
                
        }

        public (bool isValid, string error) ValidateRemove(string playerId, string userId)
        {
            bool isAdded = true;
            StringBuilder errors = new StringBuilder();

            User user = repo.All<User>()
                .Where(u => u.Id == userId)
                .Include(u => u.UserPlayers)
                .FirstOrDefault();

            Player player = repo.All<Player>()
                .FirstOrDefault(p => p.Id == int.Parse(playerId));

            if (user == null)
            {
                isAdded = false;
                errors.AppendLine("Invalid user.");
            }
            if (player == null)
            {
                isAdded = false;
                errors.AppendLine("Invalid player.");
            }
            if (user != null &&
                player != null &&
                !user.UserPlayers.Any(p => p.PlayerId == int.Parse(playerId)))
            {
                isAdded = false;
                errors.AppendLine("Player not in collection.");
            }

            return (isAdded, errors.ToString());
        }

        public void RemovePlayerFromUser(string playerId, string userId)
        {
            User user = repo.All<User>()
                .Where(u => u.Id == userId)
                .Include(u => u.UserPlayers)
                .FirstOrDefault();

            //Player player = repo.All<Player>()
            //    .FirstOrDefault(p => p.Id == int.Parse(playerId));

            //UserPlayer playerToRemove = new UserPlayer()
            //{
            //    UserId = userId,
            //    User = user,
            //    PlayerId = int.Parse(playerId),
            //    Player = player
            //};

            user.UserPlayers.Remove(user.UserPlayers.FirstOrDefault(p => p.PlayerId == int.Parse(playerId)));

            repo.SaveChanges();
        }
    }
}
