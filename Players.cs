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
            if (Form1.variables["state"] == "open menu")
            {
                List<string> variables_change = new List<string>();
                variables_change.Add("close_menu_reaction");
                Form1.buttons_to_create.Add(new KeyValuePair<string, List<string>>("Закрыть меню",variables_change));
            }
            //закрыть меню
            if (Form1.variables["state"] != "open menu")
            {
                List<string> variables_change = new List<string>();
                variables_change.Add("open_menu_reaction");
                Form1.buttons_to_create.Add(new KeyValuePair<string, List<string>>("Открыть меню", variables_change));
            }
            //Сохранить
            if (Form1.variables["state"] == "open menu")
            {
                List<string> variables_change = new List<string>();
                variables_change.Add("Save Game");
                Form1.buttons_to_create.Add(new KeyValuePair<string, List<string>>("Сохранить", variables_change));
            }
            //Загрузить
            if (Form1.variables["state"] == "open menu")
            {
                List<string> variables_change = new List<string>();
                variables_change.Add("Load Game");
                Form1.buttons_to_create.Add(new KeyValuePair<string, List<string>>("Загрузить", variables_change));
            }
            //Сброс
            if (Form1.variables["state"] == "open menu")
            {
                List<string> variables_change = new List<string>();
                variables_change.Add("Reset");
                Form1.buttons_to_create.Add(new KeyValuePair<string, List<string>>("Сброс", variables_change));
            }
        }
        //КВЕСТ - проверить инвентарь
        public static void check_inventory()
        {
            //открыть инвентарь
            if (Form1.variables["state"] == "none")
            {
                List<string> variables_change = new List<string>();
                variables_change.Add("button_open_inv");
                Form1.buttons_to_create.Add(new KeyValuePair<string, List<string>>("Открыть сумку",variables_change));
            }
            //закрыть
            if (Form1.variables["state"] == "inventory open")
            {
                Form1.info.AppendText("В сумке лежит:\n");
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
                variables_change.Add("button_close_inv");
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
                        details.Add("button_equip_reaction");
                        details.Add(Form1.player_now.types["Полное имя"]);
                        details.Add(item.name);
                        //если обувь
                        if (item.types.Contains("Обувь"))
                        {
                            details.Add("Обувь");
                        }
                        Form1.buttons_to_create.Add(
                            new KeyValuePair<string, List<string>>(
                                "Надеть "+item.name+" ()",
                                details));
                    }
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
    }
}