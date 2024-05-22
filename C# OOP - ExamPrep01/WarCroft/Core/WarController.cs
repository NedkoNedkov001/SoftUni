using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WarCroft.Constants;
using WarCroft.Entities.Characters;
using WarCroft.Entities.Characters.Contracts;
using WarCroft.Entities.Items;

namespace WarCroft.Core
{
    public class WarController
    {
        private readonly IList<Character> playersParty;
        private readonly Stack<Item> itemsPool;
        public WarController()
        {
            this.playersParty = new List<Character>();
            this.itemsPool = new Stack<Item>();
        }

        public string JoinParty(string[] args)
        {
            string characterType = args[0];
            string characterName = args[1];

            switch (characterType)
            {
                case "Warrior":
                    playersParty.Add(new Warrior(characterName));
                    break;
                case "Priest":
                    playersParty.Add(new Priest(characterName));
                    break;
                default:
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidCharacterType, characterType));
            }
            return string.Format(SuccessMessages.JoinParty, characterName);
        }

        public string AddItemToPool(string[] args)
        {
            string itemType = args[0];
            switch (itemType)
            {
                case "HealthPotion":
                    itemsPool.Push(new HealthPotion());
                    break;
                case "FirePotion":
                    itemsPool.Push(new FirePotion());
                    break;
                default:
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidItem, itemType));
            }
            return string.Format(SuccessMessages.AddItemToPool, itemType);
        }

        public string PickUpItem(string[] args)
        {
            if (itemsPool.Count == 0)
            {
                throw new InvalidOperationException(ExceptionMessages.ItemPoolEmpty);
            }

            string characterName = args[0];
            var character = playersParty.FirstOrDefault(x => x.Name == characterName);
            if (character == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, characterName));
            }

            var itemToAdd = itemsPool.Pop();
            character.Bag.AddItem(itemToAdd);
            return string.Format(SuccessMessages.PickUpItem, characterName, itemToAdd.GetType().Name);
        }

        public string UseItem(string[] args)
        {
            string characterName = args[0];
            string itemName = args[1];

            var character = playersParty.FirstOrDefault(x => x.Name == characterName);
            if (character == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, characterName));
            }

            character.UseItem(character.Bag.GetItem(itemName));

            return string.Format(SuccessMessages.UsedItem, characterName, itemName);
        }

        public string GetStats()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var character in playersParty
                .OrderByDescending(x => x.IsAlive)
                .ThenByDescending(x => x.Health))
            {
                string status;
                if (character.IsAlive)
                {
                    status = "Alive";
                }
                else
                {
                    status = "Dead";
                }
                sb.AppendLine($"{character.Name} - HP: {character.Health}/{character.BaseHealth}, AP: {character.Armor}/{character.BaseArmor}, Status: {status}");
            }
            return sb.ToString().TrimEnd();
        }

        public string Attack(string[] args)
        {
            string attackerName = args[0];
            string receiverName = args[1];
            Character attacker = playersParty.FirstOrDefault(x => x.Name == attackerName);
            if (attacker == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, attackerName));
            }
            Character receiver = playersParty.FirstOrDefault(x => x.Name == receiverName);
            if (receiver == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, receiverName));
            }
            if (attacker.GetType().Name != "Warrior")
            {
                throw new ArgumentException(string.Format(ExceptionMessages.AttackFail, attackerName));
            }
            Warrior warrior = attacker as Warrior;
            warrior.Attack(receiver);

            StringBuilder sb = new StringBuilder();
            sb.AppendLine(string.Format(
                SuccessMessages.AttackCharacter,
                attackerName, receiverName, attacker.AbilityPoints,
                receiverName, receiver.Health, receiver.BaseHealth,
                receiver.Armor, receiver.BaseArmor));
            if (!receiver.IsAlive)
            {
                sb.AppendLine($"{receiverName} is dead!");
            }
            return sb.ToString().TrimEnd();
        }

        public string Heal(string[] args)
        {
            string healerName = args[0];
            string receiverName = args[1];
            Character healer = playersParty.FirstOrDefault(x => x.Name == healerName);
            if (healer == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, healerName));
            }
            Character receiver = playersParty.FirstOrDefault(x => x.Name == receiverName);
            if (receiver == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, receiverName));
            }

            if (healer.GetType().Name != "Priest")
            {
                throw new ArgumentException(string.Format(ExceptionMessages.HealerCannotHeal, healerName));
            }
            Priest priest = healer as Priest;
            priest.Heal(receiver);

            return string.Format(
                SuccessMessages.HealCharacter, 
                healerName, receiverName, healer.AbilityPoints,
                receiverName, receiver.Health);
        }
    }
}
