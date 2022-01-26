using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using YamlDotNet.Serialization.NamingConventions;

namespace Project56
{
    public class Players
    {
        //вещь
        public class item_class
        {
            public string name;
            public string info;
            public int price;
            public int size;
            public int weight;
            public List<string> types;
            public Dictionary<string, int> effects;
        }
        //описание существа
        public class player_class
        {
            public Dictionary<string, string> types;
            public Dictionary<string, int> chars;
            public Dictionary<string, int> inv;
        }
        
        
        //получить все о предмете по названию
        public static item_class get_item(string get_name)
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
        
        
        //КВЕСТ - открыть меню персонажа
        public static void open_menu()
        {
            //открыть меню
            if (Form1.variables["state"] == "Open Menu")
            {
                List<string> variables_change = new List<string>();
                variables_change.Add("Close Menu");
                Form1.buttons_to_create.Add(new KeyValuePair<string, List<string>>("Закрыть",variables_change));
            }
            //закрыть меню
            if (Form1.variables["state"] != "Open Menu")
            {
                List<string> variables_change = new List<string>();
                variables_change.Add("Open Menu");
                Form1.buttons_to_create.Add(new KeyValuePair<string, List<string>>("Настройки", variables_change));
            }
            //Сохранить
            if (Form1.variables["state"] == "Open Menu")
            {
                List<string> variables_change = new List<string>();
                variables_change.Add("Save Game");
                Form1.buttons_to_create.Add(new KeyValuePair<string, List<string>>("Сохранить", variables_change));
            }
            //Загрузить
            if (Form1.variables["state"] == "Open Menu")
            {
                List<string> variables_change = new List<string>();
                variables_change.Add("Load Game");
                Form1.buttons_to_create.Add(new KeyValuePair<string, List<string>>("Загрузить", variables_change));
            }
            //Сброс
            if (Form1.variables["state"] == "Open Menu")
            {
                List<string> variables_change = new List<string>();
                variables_change.Add("Reset");
                Form1.buttons_to_create.Add(new KeyValuePair<string, List<string>>("Сброс(не работает)", variables_change));
            }
        }
        
        //КВЕСТ - проверить инвентарь
        public static void check_inventory()
        {
            //открыть инвентарь
            if (Form1.variables["state"] == "none")
            {
                List<string> variables_change = new List<string>();
                variables_change.Add("Open Inv");
                Form1.buttons_to_create.Add(new KeyValuePair<string, List<string>>("Открыть сумку",variables_change));
            }
            //закрыть
            if (Form1.variables["state"] == "Inventory Open")
            {
                Form1.info.AppendText("У меня есть:\n");
                foreach (var thing in Form1.player_now.inv)
                {
                    if (thing.Value != 0)
                    {
                        var item = get_item(thing.Key);
                        Form1.info.AppendText(item.name+ " - " + item.info + " " +thing.Value + 
                                              ", (вес-" + thing.Value * item.weight + ")" + "\n");
                    }
                }
                
                List<string> variables_change = new List<string>();
                variables_change.Add("Close Inv");
                Form1.buttons_to_create.Add(new KeyValuePair<string, List<string>>("Закрыть сумку",variables_change));
                //создает кнопки к предметам
                check_inventory_buttons_effects();
            }
        }
        //эффекты инвентаря
        public static void check_inventory_buttons_effects()
        {
            foreach (var _item in Form1.player_now.inv)
            {
                if (_item.Value != 0)
                {
                    item_class item = new item_class();
                    item = get_item(_item.Key);
                    //надеть одежду
                    if (item.types.Contains("Одежда"))
                    {
                        List<string> details = new List<string>();
                        details.Add("Equip");
                        details.Add(Form1.player_now.types["Полное имя"]);
                        details.Add(item.name);
                        //если Обувь
                        if (item.types.Contains("Обувь"))
                        {
                            details.Add("Обувь");
                        }
                        //если Голова
                        if (item.types.Contains("Голова"))
                        {
                            details.Add("Голова");
                        }
                        //если Руки
                        if (item.types.Contains("Руки"))
                        {
                            details.Add("Руки");
                        }
                        //если Ноги
                        if (item.types.Contains("Ноги"))
                        {
                            details.Add("Ноги");
                        }
                        //если Тело
                        if (item.types.Contains("Тело"))
                        {
                            details.Add("Тело");
                        }
                        Form1.buttons_to_create.Add(
                            new KeyValuePair<string, List<string>>(
                                "Надеть "+item.name+" ()",
                                details));
                    }
                }
            }
        }
        
        //КВЕСТ - проверить персонажа
        public static void open_hero_info()
        {
            if (Form1.variables["state"] == "none")
            {
                List<string> variables_change = new List<string>();
                variables_change.Add("Open Hero Menu");
                Form1.buttons_to_create.Add(new KeyValuePair<string, List<string>>("Открыть Меню Персонажа", variables_change));
            }
            if (Form1.variables["state"] == "Open Hero Menu")
            {
                List<string> variables_change = new List<string>();
                variables_change.Add("Close Hero Menu");
                Form1.buttons_to_create.Add(new KeyValuePair<string, List<string>>("Закрыть Меню Персонажа", variables_change));
            }
        }
        //Снять экипировку
        public static void hero_info_buttons()
        {
            if (Form1.variables["state"] == "Open Hero Menu" || Form1.variables["state"] == "Inventory Open")
            {
                if (Form1.player_now.types["Голова"] != "Ничего")
                {
                    List<string> variables_change = new List<string>();
                    variables_change.Add("Unequip");
                    variables_change.Add(Form1.player_now.types["Полное имя"]);
                    variables_change.Add(Form1.player_now.types["Голова"]);
                    variables_change.Add("Голова");
                    Form1.buttons_to_create.Add(new KeyValuePair<string, List<string>>
                        ("Снять - " + Form1.player_now.types["Голова"], variables_change));
                }
                if (Form1.player_now.types["Тело"] != "Ничего")
                {
                    List<string> variables_change = new List<string>();
                    variables_change.Add("Unequip");
                    variables_change.Add(Form1.player_now.types["Полное имя"]);
                    variables_change.Add(Form1.player_now.types["Тело"]);
                    variables_change.Add("Тело");
                    Form1.buttons_to_create.Add(new KeyValuePair<string, List<string>>
                        ("Снять - " + Form1.player_now.types["Тело"], variables_change));
                }
                if (Form1.player_now.types["Руки"] != "Ничего")
                {
                    List<string> variables_change = new List<string>();
                    variables_change.Add("Unequip");
                    variables_change.Add(Form1.player_now.types["Полное имя"]);
                    variables_change.Add(Form1.player_now.types["Руки"]);
                    variables_change.Add("Руки");
                    Form1.buttons_to_create.Add(new KeyValuePair<string, List<string>>
                        ("Снять - " + Form1.player_now.types["Руки"], variables_change));
                }
                if (Form1.player_now.types["Ноги"] != "Ничего")
                {
                    List<string> variables_change = new List<string>();
                    variables_change.Add("Unequip");
                    variables_change.Add(Form1.player_now.types["Полное имя"]);
                    variables_change.Add(Form1.player_now.types["Ноги"]);
                    variables_change.Add("Ноги");
                    Form1.buttons_to_create.Add(new KeyValuePair<string, List<string>>
                        ("Снять - " + Form1.player_now.types["Ноги"], variables_change));
                }
                if (Form1.player_now.types["Обувь"] != "Ничего")
                {
                    List<string> variables_change = new List<string>();
                    variables_change.Add("Unequip");
                    variables_change.Add(Form1.player_now.types["Полное имя"]);
                    variables_change.Add(Form1.player_now.types["Обувь"]);
                    variables_change.Add("Обувь");
                    Form1.buttons_to_create.Add(new KeyValuePair<string, List<string>>
                        ("Снять - " + Form1.player_now.types["Обувь"], variables_change));
                }
            }
        }
        
        //надеть 
        public static void equip(string name, string thing, string to)
        {
            player_class player = new player_class();
            foreach (var _player in Form1.players)
            {
                if (_player.types["Полное имя"] == name)
                {
                    player = _player;
                    break;
                }
            }
            if (player.inv.ContainsKey(thing))
            {
                if (player.types.ContainsKey(to))
                {
                    if (player.types[to] != "Ничего")
                    {
                        Form1.info.AppendText("Вы сняли " + player.types[to]+"\n");
                        Form1.info.AppendText("Вы надели " + thing+"\n");
                        player.inv[thing]--;
                        player.inv[player.types[to]]++;
                        player.types[to] = thing;
                    }
                    else
                    {
                        Form1.info.AppendText("Вы надели " + thing+"\n");
                        player.inv[thing]--;
                        player.types[to] = thing;
                    }
                }
                else
                {
                    Form1.info.AppendText("Вы надели " + thing+"\n");
                    player.inv[thing]--;
                    player.types[to] = thing;
                }
            }
            else
            {
                Form1.info.AppendText("Вы надели " + thing+"\n");
                player.inv[thing]--;
                player.types[to] = thing;
            }
            
            Form1.info.AppendText("\n");
        }
        //снять
        public static void unequip(string name, string thing, string from)
        {
            player_class player = new player_class();
            foreach (var _player in Form1.players)
            {
                if (_player.types["Полное имя"] == name)
                {
                    player = _player;
                    break;
                }
            }
            if (player.types.ContainsKey(from) && player.types[from] != "Ничего")
            {
                Form1.info.AppendText("Вы сняли " + player.types[from]);
                if (player.inv.ContainsKey(thing))
                {
                    player.inv[thing]++;
                }
                else
                {
                    player.inv[thing] = 1;
                }
                player.types[from] = "Ничего";
            }
            else
            {
                Form1.info.AppendText("У вас такого нет - " + thing + "\n");
            }
        }
        
        
        
        //NPC
        //На локации
        public static void NPC_count()
        {
            if (Form1.variables["time"] == Form1.variables["previous time"])
            {
                return;
            }
            //День
            if (Form1.variables["image type"] == "basic bad street" && Form1.variables["day time"] == "День")
            {
                Form1.variables["NPC count"] = Form1.rand.Next(0, 3).ToString();
            }
            if (Form1.variables["image type"] == "basic street" && Form1.variables["day time"] == "День")
            {
                Form1.variables["NPC count"] = Form1.rand.Next(4, 7).ToString();
            }
            if (Form1.variables["image type"] == "basic market" && Form1.variables["day time"] == "День")
            {
                Form1.variables["NPC count"] = Form1.rand.Next(15, 20).ToString();
            }
            if (Form1.variables["image type"] == "basic square" && Form1.variables["day time"] == "День")
            {
                Form1.variables["NPC count"] = Form1.rand.Next(10, 15).ToString();
            }
            
            //Ночь
            if (Form1.variables["image type"] == "basic bad street" && Form1.variables["day time"] == "Ночь")
            {
                Form1.variables["NPC count"] = Form1.rand.Next(0, 2).ToString();
            }
            if (Form1.variables["image type"] == "basic street" && Form1.variables["day time"] == "Ночь")
            {
                Form1.variables["NPC count"] = Form1.rand.Next(0, 3).ToString();
            }
            if (Form1.variables["image type"] == "basic market" && Form1.variables["day time"] == "Ночь")
            {
                Form1.variables["NPC count"] = Form1.rand.Next(0, 4).ToString();
            }
            if (Form1.variables["image type"] == "basic square" && Form1.variables["day time"] == "Ночь")
            {
                Form1.variables["NPC count"] = Form1.rand.Next(0, 5).ToString();
            }
        }
        
    }
}