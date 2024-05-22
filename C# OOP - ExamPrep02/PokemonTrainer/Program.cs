using System;
using System.Collections.Generic;
using System.Linq;

namespace PokemonTrainer
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<Trainer> trainers = new List<Trainer>();

            while (true)
            {
                string[] input = Console.ReadLine().Split();

                if (input[0] == "Tournament")
                {
                    break;
                }

                string trainerName = input[0];
                string pokemonName = input[1];
                string pokemonElement = input[2];
                int pokemonHealth = int.Parse(input[3]);

                if (!trainers.Any(x => x.Name == trainerName))
                {
                    trainers.Add(new Trainer(trainerName));
                }

                Trainer currentTrainer = trainers.Find(t => t.Name == trainerName);
                currentTrainer.Pokemon.Add(new Pokemon(pokemonName, pokemonElement, pokemonHealth));
            }

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "End")
                {
                    break;
                }

                foreach (Trainer trainer in trainers)
                {
                    if (trainer.Pokemon.Any(pokemon => pokemon.Element == input))
                    {
                        trainer.Badges++;
                    }
                    else
                    {
                        for (int i = 0; i < trainer.Pokemon.Count; i++)
                        {
                            trainer.Pokemon[i].Health -= 10;
                            if (trainer.Pokemon[i].Health <= 0)
                            {
                                trainer.Pokemon.RemoveAt(i);
                                i--;
                            }
                        }
                    }
                }
            }

            foreach (var trainer in trainers.OrderByDescending(trainer => trainer.Badges))
            {
                Console.WriteLine($"{trainer.Name} {trainer.Badges} {trainer.Pokemon.Count}");
            }
        }
    }
}
