using System.Collections.Generic;
using System.IO;
using YamlDotNet.Serialization.NamingConventions;

namespace Project56
{
    public class Players
    {
        public class item_class
        {
            public string name;
            public string info;
            public int price;
            public int weight;
            public List<string> types;
        }
        public class player_class
        {
            public string name;
            public string location;
            public int hp;
            public int mana;
            public Dictionary<string, int> inv;
        }
        public item_class get_item(string get_name)
        {
            var deserializer = new YamlDotNet.Serialization.DeserializerBuilder()
                            .WithNamingConvention(CamelCaseNamingConvention.Instance)
                            .Build();
            var items = deserializer.Deserialize<List<item_class>>(File.ReadAllText("data/items.yaml"));
            foreach (var item in items)
            {
                if (item.name == get_name)
                {
                    return item;
                }
            }
            return new item_class();
        }
        
        public static void check_inventory()
        {
            //открыть инвентарь
            if (Form1.variables["state"] == "none")
            {
                List<string> variables_change = new List<string>();
                variables_change.Add("<state> = inventory open");
                Form1.buttons_to_create.Add(new KeyValuePair<string, List<string>>("Открыть сумку",variables_change));
            }
            //закрыть
            if (Form1.variables["state"] == "inventory open")
            {
                Form1.info.AppendText("В сумке лежит:\n");
                foreach (var thing in Form1.player_now.inv)
                {
                    Form1.info.AppendText(thing.Key + ", " + thing.Value + "\n");
                }
                
                List<string> variables_change = new List<string>();
                variables_change.Add("<state> = none");
                Form1.buttons_to_create.Add(new KeyValuePair<string, List<string>>("Закрыть сумку",variables_change));
            }
        }
    }
}