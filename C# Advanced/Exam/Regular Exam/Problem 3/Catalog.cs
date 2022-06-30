using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Renovators
{
    public class Catalog
    {
        public Catalog(string name, int neededRenovators, string project)
        {
            Collection = new List<Renovator>();
            Name = name;
            NeededRenovators = neededRenovators;
            Project = project;
        }

        public List<Renovator> Collection { get; set; }
        public int Count => Collection.Count;
        public string Name { get; set; }
        public int NeededRenovators { get; set; }
        public string Project { get; set; }

        public string AddRenovator(Renovator renovator)
        {
            if (Count < NeededRenovators)
            {
                if (renovator.Name != null && renovator.Type != null)
                {
                    if (renovator.Rate < 350)
                    {
                        Collection.Add(renovator);
                        return $"Successfully added {renovator.Name} to the catalog.";
                    }
                    else
                    {
                        return "Invalid renovator's rate.";
                    }
                }
                else
                {
                    return "Invalid renovator's information.";
                }
            }

            return "Renovators are no more needed.";
        }

        public bool RemoveRenovator(string name)
        {
            foreach (var renovator in Collection)
            {
                if (renovator.Name == name)
                {
                    Collection.Remove(renovator);
                    return true;
                } 
            }

            return false;
        }

        public int RemoveRenovatorBySpecialty(string type)
        {

            //int count = 0;
            //foreach (var renovator in Collection)
            //{
            //    if (renovator.Type == type)
            //    {
            //        Collection.Remove(renovator);
            //        count++;
            //    }
            //}

            //if (count > 0)
            //{
            //    return count;
            //}

            var ren = Collection.FindAll(renovator => renovator.Type == type);
            int count = ren.Count;

            foreach (var renovator in ren)
            {
                Collection.Remove(renovator);
            }

            if (ren != null)
            {
                return count;
            }

            return 0;
        }

        public Renovator HireRenovator(string name)
        {
            Renovator hired = null;
            foreach (var renovator in Collection)
            {
                if (renovator.Name == name)
                {
                    renovator.Hired = true;
                    hired = renovator;
                }
            }

            if (hired != null)
            {
                return hired;
            }

            return null;
        }

        public List<Renovator> PayRenovators(int days)
        {
            List<Renovator> haveBeenWorking = new List<Renovator>();

            foreach (var renovator in Collection)
            {
                if (renovator.Days >= days)
                {
                    haveBeenWorking.Add(renovator);
                }   
            }

            return haveBeenWorking;
        }

        public string Report()
        {
            List<Renovator> availableRenovators = new List<Renovator>();

            foreach (var renovator in Collection)
            {
                if (!renovator.Hired)
                {
                    availableRenovators.Add(renovator);
                }   
            }

            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Renovators available for Project {Project}:");
            sb.AppendLine(string.Join(Environment.NewLine, availableRenovators));

            return sb.ToString().TrimEnd();
        }
    }
}
