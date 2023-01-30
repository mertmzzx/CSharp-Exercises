namespace PlanetWars.Models.Planets
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Contracts;
    using MilitaryUnits.Contracts;
    using Utilities.Messages;
    using Weapons.Contracts;

    public class Planet : IPlanet
    {
        private string name;
        private double budget;
        private double militaryPower;
        private readonly ICollection<IMilitaryUnit> units;
        private readonly ICollection<IWeapon> weapons;

        public Planet(string name, double budget)
        {
            this.Name = name;
            this.Budget = budget;
            this.units = new List<IMilitaryUnit>();
            this.weapons = new List<IWeapon>();
        }

        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidPlanetName);
                }

                this.name = value;
            }
        }

        public double Budget
        {
            get => this.budget;
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidBudgetAmount);
                }

                this.budget = value;
            }
        }

        public double MilitaryPower => CalculateMilitaryPower(this.units, this.weapons);
        public IReadOnlyCollection<IMilitaryUnit> Army => (IReadOnlyCollection<IMilitaryUnit>)this.units;
        public IReadOnlyCollection<IWeapon> Weapons => (IReadOnlyCollection<IWeapon>)this.weapons;

        public void AddUnit(IMilitaryUnit unit)
        {
            this.units.Add(unit);
            this.Budget -= unit.Cost;
        }

        public void AddWeapon(IWeapon weapon)
        {
            this.weapons.Add(weapon);
            this.Budget -= weapon.Price;
        }

        public void TrainArmy()
        {
            foreach (var unit in units)
            {
                unit.IncreaseEndurance();
            }

            this.Budget -= 1.25;
        }

        public void Spend(double amount)
        {
            if (amount > this.Budget)
            {
                throw new InvalidOperationException(ExceptionMessages.UnsufficientBudget);
            }

            this.Budget -= amount;
        }

        public void Profit(double amount) => this.Budget += amount;

        public string PlanetInfo()
        {
            StringBuilder sb = new StringBuilder();

            string forces = this.Army.Count > 0 ? string.Join(", ", Army.Select(x => x.GetType().Name)) : "No units";
            string combatEquipment = this.Weapons.Count > 0 ? string.Join(", ", Weapons.Select(x => x.GetType().Name)) : "No weapons";

            sb.AppendLine($"Planet: {this.Name}")
                .AppendLine($"--Budget: {this.Budget} billion QUID")
                .AppendLine($"--Forces: {forces}")
                .AppendLine($"--Combat equipment: {combatEquipment}")
                .AppendLine($"--Military power: {this.MilitaryPower}");

            return sb.ToString().Trim();
        }

        private double CalculateMilitaryPower(ICollection<IMilitaryUnit> units, ICollection<IWeapon> weapons)
        {
            double armyPowerSum = units.Sum(x => x.EnduranceLevel);
            double weaponPowerSum = weapons.Sum(x => x.DestructionLevel);
            double totalAmount = armyPowerSum + weaponPowerSum;

            if (units.Any(x => x.GetType().Name == "AnonymousImpactUnit"))
            {
                totalAmount += totalAmount * 0.3;
            }

            if (weapons.Any(x => x.GetType().Name == "NuclearWeapon"))
            {
                totalAmount += totalAmount * 0.45;
            }

            return Math.Round(totalAmount, 3);
        }
    }
}
