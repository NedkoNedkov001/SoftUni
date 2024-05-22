using FootballManager.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballManager.Contracts
{
    public interface IPlayerService
    {
        (bool isValid, string error) ValidateModel(PlayerAddViewModel model);
        void AddPlayer(PlayerAddViewModel model, string userId);
        IEnumerable<PlayerListViewModel> GetAllPlayers();
        (bool isAdded, string error) ValidateAdd(string playerId, string userId);
        void AddPlayerToUser(string playerId, string userId);
        IEnumerable<PlayerListViewModel> GetUserPlayers(string userId);
        (bool isValid, string error) ValidateRemove(string playerId, string userId);
        void RemovePlayerFromUser(string playerId, string userId);
    }
}
