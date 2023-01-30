namespace Heroes.Models.Map
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Contracts;
    using Heroes;

    public class Map : IMap
    {
        public string Fight(ICollection<IHero> players)
        {
            var knights = new List<Knight>();

            var barbarians = new List<Barbarian>();

            foreach (var player in players)
            {
                if (player.IsAlive)
                {
                    if (player is Knight knight)
                    {
                        knights.Add(knight);
                    }
                    else if (player is Barbarian barbarian)
                    {
                        barbarians.Add(barbarian);
                    }
                    else
                    {
                        throw new InvalidOperationException("Invalid player type.");
                    }
                }
            }

            var continueBattle = true;

            while (continueBattle)
            {
                var allKnightsAreDead = true;
                var allBarbariansAreDead = true;

                int aliveKnights = 0;
                int aliveBarbarians = 0;

                foreach (var knight in knights)
                {
                    if (knight.IsAlive)
                    {
                        allKnightsAreDead = false;
                        aliveKnights++;

                        foreach (var barbarian in barbarians.Where(b => b.IsAlive))
                        {
                           var weaponDmg = knight.Weapon.DoDamage();

                           barbarian.TakeDamage(weaponDmg);
                        }
                    }
                }

                foreach (var barbarian in barbarians)
                {
                    if (barbarian.IsAlive)
                    {
                        allBarbariansAreDead = false;
                        aliveBarbarians++;

                        foreach (var knight in knights.Where(k => k.IsAlive))
                        {
                            var weaponDmg = barbarian.Weapon.DoDamage();

                            knight.TakeDamage(weaponDmg);
                        }
                    }
                }

                if (allKnightsAreDead)
                {
                    int deadBarbarians = barbarians.Count - aliveBarbarians;

                    return $"The barbarians took {deadBarbarians} casualties but won the battle.";
                }

                if (allBarbariansAreDead)
                {
                    int deadKnights = knights.Count - aliveKnights;
                    return $"The knights took {deadKnights} casualties but won the battle.";
                }
            }

            throw new ArgumentException("The map fight logic has a bug.");
        }
    }
}
