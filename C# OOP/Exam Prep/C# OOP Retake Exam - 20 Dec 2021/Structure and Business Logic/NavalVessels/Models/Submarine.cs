namespace NavalVessels.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Contracts;

    public class Submarine : Vessel, ISubmarine
    {
        private const double InitialArmorThickness = 200.00;

        public Submarine(string name, double mainWeaponCaliber, double speed) 
            : base(name, mainWeaponCaliber, speed, InitialArmorThickness)
        {
            this.SubmergeMode = false;
        }

        public override void RepairVessel()
        {
            if (this.ArmorThickness < InitialArmorThickness)
            {
                this.ArmorThickness = InitialArmorThickness;
            }
        }

        public bool SubmergeMode { get; private set; }
        public void ToggleSubmergeMode()
        {
            if (SubmergeMode)
            {
                this.SubmergeMode = false;
                this.MainWeaponCaliber -= 40.00;
                this.Speed += 4;
            }
            else
            {
                this.SubmergeMode = true;
                this.MainWeaponCaliber += 40.00;
                this.Speed -= 4;
            }
        }

        public override string ToString()
        {
            string submergeMode = this.SubmergeMode ? "ON" : "OFF";

            return base.ToString() + $" *Sonar mode: {submergeMode}".TrimEnd();
        }
    }
}
