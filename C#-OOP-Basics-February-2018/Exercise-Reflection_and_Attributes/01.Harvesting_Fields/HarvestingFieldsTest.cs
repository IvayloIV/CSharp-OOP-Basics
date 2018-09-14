 namespace P01_HarvestingFields
{
    using System;
    using System.Linq;
    using System.Reflection;

    public class HarvestingFieldsTest
    {
        public static void Main()
        {
            var classType = typeof(HarvestingFields);
            FieldInfo[] allFields = classType
            .GetFields(BindingFlags.Static | BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);

            string command;
            while ((command = Console.ReadLine()) != "HARVEST")
            {
                FieldInfo[] filteredFields = GetFilteredFields(command, allFields);
                PrintFields(filteredFields);
            }
        }

        private static void PrintFields(FieldInfo[] filteredFields)
        {
            foreach (FieldInfo field in filteredFields)
            {
                var fieldAttr = field.Attributes.ToString().ToLower();
                if (fieldAttr == "family")
                {
                    fieldAttr = "protected";
                }
                Console.WriteLine($"{fieldAttr} {field.FieldType.Name} {field.Name}");
            }
        }

        private static FieldInfo[] GetFilteredFields(string command, FieldInfo[] allFields)
        {
            switch (command)
            {
                case "private":
                    return allFields.Where(a => a.IsPrivate).ToArray();
                case "protected":
                    return allFields.Where(a => a.IsFamily).ToArray();
                case "public":
                    return allFields.Where(a => a.IsPublic).ToArray();
                case "all":
                    return allFields;
                default:
                    throw new ArgumentException("Invalid type!");
            }
        }
    }
}