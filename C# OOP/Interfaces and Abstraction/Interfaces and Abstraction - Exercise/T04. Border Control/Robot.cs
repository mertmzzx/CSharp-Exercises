﻿namespace BorderControl
{
    using Interfaces;
    public class Robot : IAI, IIdentifiable
    {
        public Robot(string model, string id)
        {
            this.Model = model;
            this.Id = id;
        }

        public string Model { get; set; }
        public string Id { get; set; }
    }
}
