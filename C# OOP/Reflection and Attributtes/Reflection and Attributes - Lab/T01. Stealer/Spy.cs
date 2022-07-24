namespace Stealer
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Text;

    public class Spy
    {
        private string classToInvestigate;
        private string[] fieldsToInvestigate;

        public string StealFieldInfo(string className, params string[] fields)
        {
            Type classType = Type.GetType(className);

            FieldInfo[] fieldsUnderInvestigation = classType.GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);

            Object classInstance = Activator.CreateInstance(classType, new object[] { });

            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Class under investigation: {className}");

            foreach (var field in fieldsUnderInvestigation.Where(f => fields.Contains(f.Name)))
            {
                sb.AppendLine($"{field.Name} = {field.GetValue(classInstance)}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
