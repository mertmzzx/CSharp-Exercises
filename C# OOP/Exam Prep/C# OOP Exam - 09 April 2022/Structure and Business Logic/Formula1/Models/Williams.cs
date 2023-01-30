namespace Formula1.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Williams : FormulaOneCar
    {
        public Williams(string model, int Horsepower, double engineDisplacement) 
            : base(model, Horsepower, engineDisplacement)
        {
        }
    }
}
