using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Trainer> trainers = new List<Trainer>();
            string data;

            while ((data = Console.ReadLine()) != "Tournament")
            {
                string[] tokens = data.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string trainerName = tokens[0];
                string pokemonName = tokens[1];
                string pokemonEl = tokens[2];
                int pokemonHealth = int.Parse(tokens[3]);

                Pokemon pokemon = new Pokemon(pokemonName, pokemonEl, pokemonHealth);
                Trainer trainer = trainers.FirstOrDefault(x => x.Name == trainerName);

                if (trainer == null)
                {
                    trainers.Add(new Trainer(trainerName, pokemon));
                }
                else
                {
                    trainer.pokemonCollection.Add(pokemon);
                }
            }

            while ((data = Console.ReadLine()) != "End")
            {
                foreach (var trainer in trainers)
                {
                    if (trainer.pokemonCollection.FirstOrDefault(x => x.Element == data) != null)
                    {
                        trainer.Badges++;
                    }
                    else
                    {
                        RemoveOrUpdate(trainer);
                    }
                }
            }

            foreach (var trainer in trainers.OrderByDescending(x => x.Badges))
            {
                Console.WriteLine(trainer);
            }
        }

        static void RemoveOrUpdate(Trainer trainer)
        {
            foreach (var pokemon in trainer.pokemonCollection)
            {
                pokemon.Health -= 10;

                if (trainer.pokemonCollection.Count == 0)
                {
                    break;
                }
            }

            trainer.pokemonCollection = trainer.pokemonCollection.Where(x => x.Health > 0).ToList();
        }
    }
}
