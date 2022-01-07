using System.Collections.Generic;
using System.IO;
using YamlDotNet.Serialization.NamingConventions;

namespace Project56
{
    public class Locations
    {
        public class location_out
        {
            public string ButtonText { get; set; }
            public string Condition { get; set; }
            public List<string> VariablesChange { get; set; }
        
        }
        public class location_class
        {
            public string FullName { get; set; }
            public string Name { get; set; }
            public string Info { get; set; }
            public List<string> VariablesChange { get; set; }
            public List<location_out> LocationsOut { get; set; }
        }
        public class event_class
        {
            public string Name { get; set; }
            public string Condition { get; set; }
            public List<string> VariablesChange { get; set; }
            public List<location_out> EventButtons { get; set; }
        }

        private static location_class location;
        private static int i;
        private static string location_number;
        public static location_class get_location(string get_location_number)
        {
            var deserializer = new YamlDotNet.Serialization.DeserializerBuilder()
                .WithNamingConvention(CamelCaseNamingConvention.Instance)
                .Build();
            
            var locations = deserializer.Deserialize<List<location_class>>(File.ReadAllText("data/locations.yaml"));
            
            foreach (var location in locations)
            {
                if (location.FullName == get_location_number)
                {
                    return location;
                }
            }

            location_class result = new location_class();
            result.FullName = "ERROR";
            result.Name = "NONE";
            result.Info = "NONE";
            return result;
        }
        
    }
}