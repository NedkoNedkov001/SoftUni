using System;
using System.Collections.Generic;
using System.Linq;

namespace TheBattleOfTheFiveArmies
{
    class Program
    {
        static void Main(string[] args)
        {
            //Input
            int armyArmor = int.Parse(Console.ReadLine());
            int rows = int.Parse(Console.ReadLine());
            char[][] map = new char[rows][];

            //Fill map
            for (int row = 0; row < rows; row++)
            {
                string currRow = Console.ReadLine();
                map[row] = new char[currRow.Length];
                for (int col = 0; col < currRow.Length; col++)
                {
                    map[row][col] = currRow[col];
                }
            }

            //Keep orcArmies positions
            List<KeyValuePair<int, int>> orcArmies = new List<KeyValuePair<int, int>>();

            //Find player
            KeyValuePair<int, int> playerPosition = new KeyValuePair<int, int>();
            playerPosition = FindPlayer(map);

            //Find Mordor
            KeyValuePair<int, int> mordorPosition = new KeyValuePair<int, int>();
            mordorPosition = FindMordor(map);

            //Turns
            bool gameIsActive = true;
            while (gameIsActive)
            {
                //Input command
                string[] inputCommand = Console.ReadLine()
                    .Split()
                    .ToArray();
                string direction = inputCommand[0];
                int OrcsRow = int.Parse(inputCommand[1]);
                int OrcsCol = int.Parse(inputCommand[2]);

                //Spawn Orcs
                map[OrcsRow][OrcsCol] = 'O';
                orcArmies = FindOrcArmies(map, orcArmies);

                //Move army
                if (direction == "up")
                {
                    if (playerPosition.Key > 0)
                    {
                        map[playerPosition.Key][playerPosition.Value] = '-';
                        map[playerPosition.Key - 1][playerPosition.Value] = 'A';
                        playerPosition = FindPlayer(map);
                    }
                    armyArmor -= 1;
                }
                else if (direction == "down")
                {
                    if (playerPosition.Key < map.GetLength(0) - 1)
                    {
                        map[playerPosition.Key][playerPosition.Value] = '-';
                        map[playerPosition.Key + 1][playerPosition.Value] = 'A';
                        playerPosition = FindPlayer(map);
                    }
                    armyArmor -= 1;
                }
                else if (direction == "left")
                {
                    if (playerPosition.Value > 0)
                    {
                        map[playerPosition.Key][playerPosition.Value] = '-';
                        map[playerPosition.Key][playerPosition.Value - 1] = 'A';
                        playerPosition = FindPlayer(map);
                    }
                    armyArmor -= 1;
                }
                else if (direction == "right")
                {
                    if (playerPosition.Value < map.GetLength(0) - 1)
                    {
                        map[playerPosition.Key][playerPosition.Value] = '-';
                        map[playerPosition.Key][playerPosition.Value + 1] = 'A';
                        playerPosition = FindPlayer(map);
                    }
                    armyArmor -= 1;
                }
                if (CheckIfArmyEncountersOrcs(playerPosition, orcArmies))
                {
                    armyArmor = ArmyFight(map, playerPosition, armyArmor);
                }
                else if (CheckIfArmyReachedMordor(playerPosition, mordorPosition))
                {
                    gameIsActive = false;
                    Console.WriteLine($"The army managed to free the Middle World! Armor left: {armyArmor}");
                    map[playerPosition.Key][playerPosition.Value] = '-';
                    PrintMap(map);
                }
                if (armyArmor <= 0)
                {
                    OutOfArmor(map, playerPosition);
                    gameIsActive = false;
                }
                //
                //PrintMap(map);
                //Console.WriteLine(armyArmor);
                //
            }
        }

        private static void OutOfArmor(char[][] map, KeyValuePair<int, int> playerPosition)
        {
            int fightRow = playerPosition.Key;
            int fightCol = playerPosition.Value;

            map[fightRow][fightCol] = 'X';
                Console.WriteLine($"The army was defeated at {fightRow};{fightCol}.");
                PrintMap(map);
        }

        private static bool CheckIfArmyReachedMordor(KeyValuePair<int, int> playerPosition, KeyValuePair<int, int> mordorPosition)
        {
            if (playerPosition.Key == mordorPosition.Key && playerPosition.Value == mordorPosition.Value)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private static KeyValuePair<int, int> FindMordor(char[][] map)
        {
            KeyValuePair<int, int> mordorPosition = new KeyValuePair<int, int>();
            for (int row = 0; row < map.GetLength(0); row++)
            {
                for (int col = 0; col < map[row].GetLength(0); col++)
                {
                    if (map[row][col] == 'M')
                    {
                        mordorPosition = new KeyValuePair<int, int>(row, col);
                        return mordorPosition;
                    }
                }
            }
            return mordorPosition;
        }
        private static int ArmyFight(char[][] map, KeyValuePair<int, int> playerPosition, int armyArmor)
        {

            armyArmor -= 2;
            return armyArmor;
        }
        private static void PrintMap(char[][] map)
        {
            for (int row = 0; row < map.GetLength(0); row++)
            {
                Console.WriteLine(map[row]);
            }
        }
        private static bool CheckIfArmyEncountersOrcs(KeyValuePair<int, int> playerPosition, List<KeyValuePair<int, int>> orcArmies)
        {
            int playerRow = playerPosition.Key;
            int playerCol = playerPosition.Value;

            foreach (var orcArmy in orcArmies)
            {
                if (orcArmy.Key == playerRow && orcArmy.Value == playerCol)
                {
                    return true;
                }
            }
            return false;
        }
        private static List<KeyValuePair<int, int>> FindOrcArmies(char[][] map, List<KeyValuePair<int, int>> orcArmies)
        {
            orcArmies.Clear();
            for (int row = 0; row < map.GetLength(0); row++)
            {
                for (int col = 0; col < map[row].GetLength(0); col++)
                {
                    if (map[row][col] == 'O')
                    {
                        orcArmies.Add(new KeyValuePair<int, int>(row, col));
                    }
                }
            }
            return orcArmies;
        }
        private static KeyValuePair<int, int> FindPlayer(char[][] map)
        {
            KeyValuePair<int, int> playerPosition = new KeyValuePair<int, int>();
            for (int row = 0; row < map.GetLength(0); row++)
            {
                for (int col = 0; col < map[row].GetLength(0); col++)
                {
                    if (map[row][col] == 'A')
                    {
                        playerPosition = new KeyValuePair<int, int>(row, col);
                        return playerPosition;
                    }
                }
            }
            return playerPosition;
        }
    }
}
