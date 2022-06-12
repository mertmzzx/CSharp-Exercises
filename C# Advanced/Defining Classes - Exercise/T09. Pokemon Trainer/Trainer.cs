using System.Collections.Generic;

namespace DefiningClasses
{
    public class Trainer
    {
        

        public Trainer(string name, Pokemon pokemon)
        {
            this.Name = name;
            this.Badges = 0;
            this.pokemonCollection.Add(pokemon);
        }

        public string Name { get; set; }
        public int Badges { get; set; }
        public List<Pokemon> pokemonCollection { get; set; } = new List<Pokemon>();

        public override string ToString()
        {
            return $"{Name} {Badges} {pokemonCollection.Count}";
        }
    }
}
