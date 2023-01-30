namespace PlanetWars.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Numerics;
    using System.Text;
    using Contracts;
    using Models.MilitaryUnits;
    using Models.MilitaryUnits.Contracts;
    using Models.Planets;
    using Models.Planets.Contracts;
    using Models.Weapons;
    using Models.Weapons.Contracts;
    using Repositories;
    using Utilities.Messages;

    public class Controller : IController
    {
        private readonly PlanetRepository planetRepository;

        public Controller()
        {
            this.planetRepository = new PlanetRepository();
        }

        public string CreatePlanet(string name, double budget)
        {
            if (planetRepository.FindByName(name) != null)
            {
                return string.Format(OutputMessages.ExistingPlanet, name);
            }

            IPlanet planet = new Planet(name, budget);
            this.planetRepository.AddItem(planet);
            return string.Format(OutputMessages.NewPlanet, name);
        }

        public string AddUnit(string unitTypeName, string planetName)
        {
            if (planetRepository.FindByName(planetName) == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.UnexistingPlanet, planetName));
            }

            IPlanet planet = planetRepository.FindByName(planetName);
            IMilitaryUnit unit;

            if (planet.Army.Any(x => x.GetType().Name == unitTypeName))
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.UnitAlreadyAdded, unitTypeName, planetName));
            }

            if (unitTypeName == "StormTroopers")
            {
                unit = new StormTroopers();
            }
            else if (unitTypeName == "SpaceForces")
            {
                unit = new SpaceForces();
            }
            else if (unitTypeName == "AnonymousImpactUnit")
            {
                unit = new AnonymousImpactUnit();
            }
            else
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.ItemNotAvailable, unitTypeName));
            }

            if (planet.Budget > unit.Cost)
            {
                planet.AddUnit(unit);
                return string.Format(OutputMessages.UnitAdded, unitTypeName, planetName);
            }

            return "Budget too low!";
        }

        public string AddWeapon(string planetName, string weaponTypeName, int destructionLevel)
        {
            if (planetRepository.FindByName(planetName) == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.UnexistingPlanet, planetName));
            }

            IPlanet planet = planetRepository.FindByName(planetName);
            IWeapon weapon;

            if (planet.Weapons.Any(x => x.GetType().Name == weaponTypeName))
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.WeaponAlreadyAdded, weaponTypeName, planetName));
            }

            if (weaponTypeName == "SpaceMissiles")
            {
                weapon = new SpaceMissiles(destructionLevel);
            }
            else if (weaponTypeName == "NuclearWeapon")
            {
                weapon = new NuclearWeapon(destructionLevel);
            }
            else if (weaponTypeName == "BioChemicalWeapon")
            {
                weapon = new BioChemicalWeapon(destructionLevel);
            }
            else
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.ItemNotAvailable, weaponTypeName));
            }

            if (planet.Budget > weapon.Price)
            {
                planet.AddWeapon(weapon);
                return string.Format(OutputMessages.WeaponAdded, planetName, weaponTypeName);
            }

            return "Budget too low!";
        }

        public string SpecializeForces(string planetName)
        {
            if (planetRepository.FindByName(planetName) == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.UnexistingPlanet, planetName));
            }

            IPlanet planet = planetRepository.FindByName(planetName);

            if (planet.Army.Count == 0)
            {
                throw new InvalidOperationException(ExceptionMessages.NoUnitsFound);
            }

            planet.TrainArmy();
            return string.Format(OutputMessages.ForcesUpgraded, planetName);
        }

        public string SpaceCombat(string planetOne, string planetTwo)
        {
            IPlanet planet1 = planetRepository.FindByName(planetOne);
            IPlanet planet2 = planetRepository.FindByName(planetTwo);

            if (planet1.MilitaryPower == planet2.MilitaryPower)
            {
                if (planet1.Weapons.Any(x => x.GetType().Name == "NuclearWeapon") &&
                    planet2.Weapons.Any(x => x.GetType().Name == "NuclearWeapon"))
                {
                    planet1.Spend(planet1.Budget / 2);
                    planet2.Spend(planet2.Budget / 2);

                    return OutputMessages.NoWinner;
                }
                else if (planet1.Weapons.Any(x => x.GetType().Name == "NuclearWeapon") ||
                         planet2.Weapons.Any(x => x.GetType().Name == "NuclearWeapon"))
                {
                    if (planet1.Weapons.Any(x => x.GetType().Name == "NuclearWeapon"))
                    {
                        planet1.Spend(planet1.Budget / 2);
                        planet1.Profit(planet2.Budget / 2);
                        planet1.Spend(planet2.Army.Sum(x => x.Cost) + planet2.Weapons.Sum(x => x.Price));
                        this.planetRepository.RemoveItem(planetTwo);

                        return string.Format(OutputMessages.WinnigTheWar, planetOne, planetTwo);
                    }
                    else if (planet2.Weapons.Any(x => x.GetType().Name == "NuclearWeapon"))
                    {
                        planet2.Spend(planet2.Budget / 2);
                        planet2.Profit(planet1.Budget / 2);
                        planet2.Spend(planet1.Army.Sum(x => x.Cost) + planet1.Weapons.Sum(x => x.Price));
                        this.planetRepository.RemoveItem(planetOne);

                        return string.Format(OutputMessages.WinnigTheWar, planetTwo, planetOne);
                    }
                }
            }
            else if (planet1.MilitaryPower > planet2.MilitaryPower)
            {
                planet1.Spend(planet1.Budget / 2);
                planet1.Profit(planet2.Budget / 2);
                planet1.Spend(planet2.Army.Sum(x => x.Cost) + planet2.Weapons.Sum(x => x.Price));
                this.planetRepository.RemoveItem(planetTwo);

                return string.Format(OutputMessages.WinnigTheWar, planetOne, planetTwo);
            }
            else if (planet2.MilitaryPower > planet1.MilitaryPower)
            {
                planet2.Spend(planet2.Budget / 2);
                planet2.Profit(planet1.Budget / 2);
                planet2.Spend(planet1.Army.Sum(x => x.Cost) + planet1.Weapons.Sum(x => x.Price));
                this.planetRepository.RemoveItem(planetOne);

                return string.Format(OutputMessages.WinnigTheWar, planetTwo, planetOne);
            }

            planet1.Spend(planet1.Budget / 2);
            planet2.Spend(planet2.Budget / 2);
            return OutputMessages.NoWinner;
        }

        public string ForcesReport()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var planet in planetRepository.Models.OrderByDescending(x => x.MilitaryPower).ThenBy(x => x.Name))
            {
                sb.AppendLine(planet.PlanetInfo());
            }

            return sb.ToString().Trim();
        }
    }
}
