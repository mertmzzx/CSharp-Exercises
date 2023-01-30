namespace Heroes.Core
{
    using System;
    using System.Linq;
    using System.Text;
    using Contracts;
    using Models.Contracts;
    using Models.Heroes;
    using Models.Map;
    using Models.Weapons;
    using Repositories;
    using Repositories.Contracts;

    public class Controller : IController
    {
        private readonly IRepository<IHero> heroes;
        private readonly IRepository<IWeapon> weapons;

        public Controller()
        {
            this.heroes = new HeroRepository();
            this.weapons = new WeaponRepository();
        }
        public string CreateHero(string type, string name, int health, int armour)
        {
            if (this.heroes.FindByName(name) != null)
            {
                throw new InvalidOperationException($"The hero {name} already exists.");
            }

            IHero hero = type switch
            {
                nameof(Knight) => new Knight(name, health, armour),
                nameof(Barbarian) => new Barbarian(name, health, armour),
                _ => throw new InvalidOperationException("Invalid hero type.")
            };

            this.heroes.Add(hero);

            var heroAlias = type == nameof(Knight)
                ? $"Sir {hero.Name}"
                : $"{nameof(Barbarian)} {hero.Name}";

            return $"Successfully added {heroAlias} to the collection.";
        }

        public string CreateWeapon(string type, string name, int durability)
        {
            if (this.weapons.FindByName(name) != null)
            {
                throw new InvalidOperationException($"The weapon {name} already exists.");
            }

            IWeapon weapon = type switch
            {
                nameof(Mace) => new Mace(name, durability),
                nameof(Claymore) => new Claymore(name, durability),
                _ => throw new InvalidOperationException("Invalid weapon type.")
            };

            this.weapons.Add(weapon);

            return $"A {type.ToLower()} {name} is added to the collection.";
        }


        public string AddWeaponToHero(string weaponName, string heroName)
        {
            var hero = this.heroes.FindByName(heroName);
            var weapon = this.weapons.FindByName(weaponName);

            if (this.heroes.FindByName(heroName) == null)
            {
                throw new InvalidOperationException($"Hero {heroName} does not exist.");
            }
            if (this.weapons.FindByName(weaponName) == null)
            {
                throw new InvalidOperationException($"Weapon {weaponName} does not exist.");
            }

            if (hero.Weapon != null)
            {
                throw new InvalidOperationException($"Hero {heroName} is well-armed.");
            }

            hero.AddWeapon(weapon);
            this.weapons.Remove(weapon);

            var weaponType = weapon.GetType().Name.ToLower();

            return $"Hero {heroName} can participate in battle using a {weaponType}.";
        }

        public string StartBattle()
        {
            var map = new Map();

            var heroesReadyForBattle = this.heroes
                .Models
                .Where(h => h.IsAlive && h.Weapon != null)
                .ToList();

            return map.Fight(heroesReadyForBattle);
        }

        public string HeroReport()
        {
            StringBuilder sb = new StringBuilder();

            var sortedHeroes = this.heroes
                .Models
                .OrderBy(h => h.GetType().Name)
                .ThenByDescending(h => h.Health)
                .ThenBy(h => h.Name);

            foreach (var hero in sortedHeroes)
            {
                sb.AppendLine(hero.ToString());
            }

            return sb.ToString().Trim();
        }
    }
}
