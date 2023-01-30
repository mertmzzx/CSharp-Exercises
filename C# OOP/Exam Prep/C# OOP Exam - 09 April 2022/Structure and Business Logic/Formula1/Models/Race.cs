namespace Formula1.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Contracts;
    using Utilities;

    public class Race : IRace
    {
        private string name;
        private int laps;

        public Race(string name, int laps)
        {
            this.RaceName = name;
            this.NumberOfLaps = laps;
            this.TookPlace = false;
            this.Pilots = new List<IPilot>();
        }

        public string RaceName
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < 5)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidRaceName, value));
                }

                this.name = value;
            }
        }

        public int NumberOfLaps
        {
            get => this.laps;
            private set
            {
                if (value < 1)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidLapNumbers, value));
                }

                this.laps = value;
            }
        }
        public bool TookPlace { get; set; }
        public ICollection<IPilot> Pilots { get; }
        public void AddPilot(IPilot pilot) => this.Pilots.Add(pilot);

        public string RaceInfo()
        {
            StringBuilder sb= new StringBuilder();

            string tookPlace = this.TookPlace ? "Yes" : "No";

            sb.AppendLine($"The {this.RaceName} race has:")
                .AppendLine($"Participants: {this.Pilots.Count}")
                .AppendLine($"Number of laps: {this.NumberOfLaps}")
                .AppendLine($"Took place: {tookPlace}");

            return sb.ToString();
        }
    }
}
