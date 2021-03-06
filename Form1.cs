using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.CodeAnalysis.CSharp.Scripting;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;


namespace Project56
 {
     public partial class Form1 : Form
     {
         public Form1()
         {
             InitializeComponent();
             WindowState = FormWindowState.Maximized;
             info = new RichTextBox();
             stats = new RichTextBox();
             rand = new Random();
             
         }
         private void Form1_Load(object sender, EventArgs e)
         {
             Controls.Clear();
             //инициализация всего
             initialize_all();
             //создание всей статистики
             create_all_info();
             //создание кнопок событий
             create_buttons();
             //создание графики
             create_graphics();
         }
         private void initialize_all()
         {
             //Размеры поля
             Graphics g = CreateGraphics();
             g.Clear(BackColor);
             /*
             for (int i = 0; i <= numbers_height; i++)
             {
                 g.DrawLine(new Pen(Color.Gray, 2.0f), 0, (size_height*i), size_width*numbers_width, (size_height*i));
             }
             for (int i = 0; i <= numbers_width; i++)
             {
                 g.DrawLine(new Pen(Color.Gray, 2.0f), (size_width*i), 0, (size_width*i), size_height*numbers_height);
             }*/
 
             //
             size_width = (Width - 15) / numbers_width;
             size_height = (Height - 20) / numbers_height;
             info.Location = new Point(5 * size_width, 1 * size_height);
             info.Size = new Size(12 * size_width, 10 * size_height);
             info.ReadOnly = true;
             Controls.Add(info);
             stats.Location = new Point(0 * size_width, 1 * size_height);
             stats.Size = new Size(4 * size_width, 22 * size_height);
             stats.ReadOnly = true;
             Controls.Add(stats);

             location_image = new PictureBox();
             location_image.SizeMode = PictureBoxSizeMode.StretchImage;
             location_image.Location = new Point(size_width * 17, size_height * 1);
             location_image.Size = new Size(size_width * 13, size_height * 13);
             Controls.Add(location_image);
             
             buttons = new Button[16];
             for (int i = 0; i < 16; i++)
             {
                 buttons[i] = new Button();
                 buttons[i].Visible = false;
             }
         }
         public void update()
         {
             for(int i=1;i<16;i++)
             {
                 buttons[i].Visible = false;
             }
             create_all_info();
             create_buttons();
             create_graphics();
         }
         private void create_all_info()
         {
             buttons_to_create =new List<KeyValuePair<string, List<string>>>();
             
             read_data_file();
             read_states();
         }
         private void read_data_file()
         {
             variables = deserializer.Deserialize<Dictionary<string, string>>(File.ReadAllText("data/data.yaml"));
             
             //Special for time
             variables["time"] = Convert.ToString(Convert.ToInt32(variables["time"]) % 1440);
             variables["time hours"] = Convert.ToString(Convert.ToInt32(variables["time"]) / 60);
             variables["time minutes"] = Convert.ToString(Convert.ToInt32(variables["time"]) % 60);
             if (variables["time minutes"].Length == 1)
             {
                 variables["time minutes"] = "0" + variables["time minutes"];
             }
             if (variables["time hours"].Length == 1)
             {
                 variables["time hours"] = "0" + variables["time hours"];
             }
             //Special for Info
             variables["info"] = "";
         }
         private void read_states()
         {
             states = deserializer.Deserialize<List<string>>(File.ReadAllText("data/states.yaml"));
             variables["state"] = states.Last();
         }
         private void add_stats()
         {
             stats.AppendText("Time\n");
             stats.AppendText(variables["time hours"] + ":" + variables["time minutes"] + "\n");
             stats.AppendText("\n");
             
             stats.AppendText(player_now.types["Полное имя"]+"\n");
             stats.AppendText(player_now.chars["Здоровье"]+"/"+player_now.chars["ЗдоровьеМакс"]+" HP"+"\n");
             stats.AppendText(player_now.chars["Мана"]+"/"+player_now.chars["МанаМакс"]+" MP"+"\n");
             stats.AppendText("\n");
             stats.AppendText("\n");
             stats.AppendText("Текущая экипировка\n");
             if (player_now.types.ContainsKey("Голова")) stats.AppendText("Голова - " + player_now.types["Голова"]+"\n");
             if (player_now.types.ContainsKey("Тело")) stats.AppendText("Тело - " + player_now.types["Тело"]+"\n");
             if (player_now.types.ContainsKey("Руки")) stats.AppendText("Руки - " + player_now.types["Руки"]+"\n");
             if (player_now.types.ContainsKey("Ноги")) stats.AppendText("Ноги - " + player_now.types["Ноги"]+"\n");
             if (player_now.types.ContainsKey("Обувь")) stats.AppendText("Обувь - " + player_now.types["Обувь"]+"\n");
         }
         private void create_buttons()
         {
             //количество уже созданных кнопок
             button_count = 0;
             //считывание игрока
             read_players();
             //считывание локации
             read_location();
             //считывание евентов
             add_info();
             add_stats();
             //создание кнопок локаций
             if (variables["state"] == "none")
             {
                 create_buttons_location();
             }
             create_other_buttons();
         }
         public static void save_to_data()
         {
             var result = serializer.Serialize(variables);
             StreamWriter data_file_writer = new StreamWriter("data/data.yaml");
             data_file_writer.WriteLine(result);
             data_file_writer.Close();
             
             result = serializer.Serialize(states);
             data_file_writer = new StreamWriter("data/states.yaml");
             data_file_writer.WriteLine(result);
             data_file_writer.Close();
         }
         public static void save_to_players()
         {
             var result = serializer.Serialize(players);
             StreamWriter data_file_writer = new StreamWriter("data/players.yaml");
             data_file_writer.WriteLine(result);
             data_file_writer.Close();
         }
         private static void read_players()
         {
             players = deserializer.Deserialize<List<Players.player_class>>(File.ReadAllText("data/players.yaml"));

             foreach (var _player in players)
             {
                 if (_player.types["Полное имя"] == variables["player"])
                 {
                     player_now = _player;
                     break;
                 }
             }
         }
         private void read_location()
         {
             location_now = new Locations.location_class();
             location_now = Locations.get_location(variables["current location"]);
             info.AppendText(location_now.Name + "\n");
             info.AppendText(location_now.Info + "\n");
         }
         private void add_info()
         {
             read_quests();
             check_quests();
             info.AppendText(variables["info"]+"\n");
             
             info.AppendText("В этом месте "+variables["NPC count"]+" Человек рядом"+"\n");
             
         }
         private void create_buttons_location()
         {
             foreach (var location_out in location_now.LocationsOut)
             {
                 create_button(location_out.ButtonText,
                     location_out.Condition,
                     location_out.VariablesChange);
             }
         }
         private void create_other_buttons()
         {
             foreach (var _button in buttons_to_create)
             {
                 create_button(_button.Key,"",_button.Value);
             }
         }
         private void create_button(string text, string condition_out, List<string> variables_change)
         {
             if (check_condition(condition_out))
             {
                 button_count++;
                 buttons[button_count].Visible = true;
                 buttons[button_count].Text = text;
                 buttons[button_count].Size = new Size(6 * size_width, 1 * size_height);
                 buttons[button_count].Location = new Point(5 * size_width, (11 + button_count) * size_height);
                 buttons[button_count].TabIndex = button_count;
                 button_change_variables[button_count]=new List<string>();
                 foreach (var variable_change in variables_change)
                 {
                     button_change_variables[button_count].Add(variable_change);
                 }

                 buttons[button_count].Click -= button_reaction;
                 buttons[button_count].Click += button_reaction;
                 Controls.Add(buttons[button_count]);
             }
         }
         private void button_reaction(object sender, EventArgs e)
         {
             Button button = sender as Button;
             info.Clear();
             stats.Clear();
             variables["location before"] = location_now.FullName;
             variables["location before name"] = location_now.Name;
             
             if (button_change_variables[button.TabIndex].Contains("Equip"))
             {
                 Players.equip(button_change_variables[button.TabIndex][1],
                     button_change_variables[button.TabIndex][2],
                     button_change_variables[button.TabIndex][3]);
                 save_to_players();
                 save_to_data();
                 update();
                 return;
             }
             
             if (button_change_variables[button.TabIndex].Contains("Unequip"))
             {
                 Players.unequip(button_change_variables[button.TabIndex][1],
                     button_change_variables[button.TabIndex][2],
                     button_change_variables[button.TabIndex][3]);
                 save_to_players();
                 save_to_data();
                 update();
                 return;
             }
             
             if (button_change_variables[button.TabIndex].Contains("Open Inv"))
             {
                 states.Add("Inventory Open");
                 save_to_players();
                 save_to_data();
                 update();
                 return;
             }
             
             if (button_change_variables[button.TabIndex].Contains("Close Inv"))
             {
                 states.RemoveAt(states.Count-1);
                 save_to_players();
                 save_to_data();
                 update();
                 return;
             }
             
             if (button_change_variables[button.TabIndex].Contains("Open Menu"))
             {
                 states.Add("Open Menu");
                 save_to_players();
                 save_to_data();
                 update();
                 return;
             }
             
             if (button_change_variables[button.TabIndex].Contains("Close Menu"))
             {
                 states.RemoveAt(states.Count-1);
                 save_to_players();
                 save_to_data();
                 update();
                 return;
             }
             
             if (button_change_variables[button.TabIndex].Contains("Save Game"))
             {
                 var result = serializer.Serialize(players);
                 StreamWriter data_file_writer = new StreamWriter("data/saves/1/players.yaml");
                 data_file_writer.WriteLine(result);
                 data_file_writer.Close();
                 result = serializer.Serialize(variables);
                 data_file_writer = new StreamWriter("data/saves/1/data.yaml");
                 data_file_writer.WriteLine(result);
                 data_file_writer.Close();
                 result = serializer.Serialize(states);
                 data_file_writer = new StreamWriter("data/saves/1/states.yaml");
                 data_file_writer.WriteLine(result);
                 data_file_writer.Close();
                 save_to_players();
                 save_to_data();
                 update();
                 return;
             }
             
             if (button_change_variables[button.TabIndex].Contains("Load Game"))
             {
                 variables = deserializer.Deserialize<Dictionary<string, string>>(File.ReadAllText("data/saves/1/data.yaml"));
                 players = deserializer.Deserialize<List<Players.player_class>>(File.ReadAllText("data/saves/1/players.yaml"));
                 states = deserializer.Deserialize<List<string>>(File.ReadAllText("data/saves/1/states.yaml"));

                 save_to_players();
                 save_to_data();
                 update();
                 return;
             }
             
             if (button_change_variables[button.TabIndex].Contains("Reset"))
             {
                 variables = deserializer.Deserialize<Dictionary<string, string>>(File.ReadAllText("data/saves/reset/data.yaml"));
                 players = deserializer.Deserialize<List<Players.player_class>>(File.ReadAllText("data/saves/reset/players.yaml"));
                 states = deserializer.Deserialize<List<string>>(File.ReadAllText("data/saves/reset/states.yaml"));

                 save_to_players();
                 save_to_data();
                 update();
                 return;
             }
             
             if (button_change_variables[button.TabIndex].Contains("Open Hero Menu"))
             {
                 states.Add("Open Hero Menu");
                 save_to_players();
                 save_to_data();
                 update();
                 return;
             }
             
             if (button_change_variables[button.TabIndex].Contains("Close Hero Menu"))
             {
                 states.RemoveAt(states.Count-1);
                 save_to_players();
                 save_to_data();
                 update();
                 return;
             }
             
             foreach (var variable_change in button_change_variables[button.TabIndex])
             {
                 ReWrite(variable_change);
             }
             
             if (variables["current location"] != variables["location before"])
             {
                 location_now = Locations.get_location(variables["current location"]);
                 foreach (var variable_change in location_now.VariablesChange)
                 {
                     ReWrite(variable_change);
                 }
             }
             
             save_to_players();
             save_to_data();
             update();
         }
         private void create_graphics()
         {
             create_background_picture();
         }
         private void create_background_picture()
         {
             int random_count = 0;
             int random_value = 0;
             if (location_now.Name == variables["location before name"])
             {
                 location_image.Image = Image.FromFile("data/images/locations/"+ variables["image path"]+"/"+variables["random image"]+".png");
                 return;
             }
             while (random_count < 100)
             {
                 random_count++;
                 random_value = rand.Next(1, 20);
                 if (File.Exists("data/images/locations/"+variables["image path"]+"/"+random_value+".png"))
                 {
                     variables["random image"] = random_value.ToString();
                     location_image.Image = Image.FromFile("data/images/locations/"+ variables["image path"]+"/"+random_value+".png");
                     return;
                 }
             }
             random_value = 0;
             while (random_value < 100)
             {
                 random_value++;
                 if (File.Exists("data/images/locations/"+ variables["image path"]+"/"+random_value+".png"))
                 {
                     variables["random image"] = random_value.ToString();
                     location_image.Image = Image.FromFile("data/images/locations/"+ variables["image path"]+"/"+random_value+".png");
                     return;
                 }
             }
             if (File.Exists("data/images/locations/Sample.png"))
             {
                 location_image.Image = Image.FromFile("data/images/locations/Sample.png");
             }
         }
         private void read_quests()
         {
             var events_file = deserializer.Deserialize<List<string>>(File.ReadAllText("data/quests/events.yaml"));
             variables_copy=new Dictionary<string, string>();
             foreach (var variable in variables)
             {
                 variables_copy.Add(variable.Key,variable.Value);
             }
             
             foreach (var event_file_name in events_file)
             {
                 var _event_file = deserializer.Deserialize<List<Locations.event_class>>(File.ReadAllText("data/quests/"+event_file_name));
                 foreach (var _event in _event_file)
                 {
                     if (check_condition(_event.Condition))
                     {
                         foreach (var variable_change in _event.VariablesChange)
                         {
                             ReWrite_copy(variable_change);
                         }
                         foreach (var button in _event.EventButtons)
                         {
                             create_button(button.ButtonText,button.Condition,button.VariablesChange);
                         }
                     }
                 }
             }

             variables=new Dictionary<string, string>();
             foreach (var variable in variables_copy)
             {
                 variables.Add(variable.Key,variable.Value);
             }
         }
         private void check_quests()
         {
             Players.check_inventory();
             Players.open_hero_info();
             Players.hero_info_buttons();
             Players.NPC_count();
             Players.open_menu();
             
             
             Quests.repare_time();
         }
         //Размеры поля(клеток)
         public int numbers_width = 30;
         public int numbers_height = 25;
         public int size_width;
         public int size_height;
         //Текстовое поле(информация, текст)
         public static RichTextBox info;
         //Текстовое поле(статы)
         public static RichTextBox stats;
         //Количество уже созданных кнопок, чтобы создавать следущую на новом месте
         public static int button_count;
         //Текущий игрок
         public static Players.player_class player_now;
         //Текущая локация
         public static Locations.location_class location_now;
         //Картинка
         public PictureBox location_image;
         //Переменные ["Name"]=value
         public static Dictionary<string, string> variables = new Dictionary<string, string>();
         //Копия переменных для events
         public static Dictionary<string,string> variables_copy = new Dictionary<string, string>();
         //вроде переходы по кнопкам
         public static List<string>[] button_change_variables = new List<string>[102];
         //игрок+нпс
         public static List<Players.player_class> players = new List<Players.player_class>();
         //public static events.buttons_to_create[] buttons_to_create = new events.buttons_to_create[102];
         //Рандом
         public static Random rand;
         //кнопки для создания, buttons_to_create - через Ж с костылями для каждого
         public static List<KeyValuePair<string, List<string>>> buttons_to_create =new List<KeyValuePair<string, List<string>>>();
         //все кнопки
         private static Button[] buttons;
         //Состояния
         public static List<string> states = new List<string>();

         static IDeserializer deserializer = new YamlDotNet.Serialization.DeserializerBuilder()
             .WithNamingConvention(CamelCaseNamingConvention.Instance)
             .Build();

         static ISerializer serializer = new SerializerBuilder()
             .WithNamingConvention(CamelCaseNamingConvention.Instance)
             .Build();


         public bool check_condition(string input)
         {
             if (input == null || input == "")
             {
                 return true;
             }
             return ParseBool(ConvertBool(input));
         }
         public string ConvertBool(string input)
         {
             string result = "";
             string variable = "";
             for (int i = 0; i < input.Length; i++)
             {
                 char symbol = input[i];

                 if (symbol == '<' && char.IsLetter(input[i+1]))
                 {
                     i++;
                     symbol = input[i];
                     while (symbol!='>')
                     {
                         variable += symbol;
                         i++;
                         symbol = input[i];
                     }

                     if (variable=="rand")
                     {
                         result += rand.Next(0, 100).ToString();
                         variable = "";
                         continue;
                     }
                     if(char.IsLetter(variables[variable][0]))
                     {
                         result += "\""+variables[variable]+"\"";
                     }
                     else
                     {
                         result += variables[variable];
                     }
                     variable = "";
                     continue;
                 }

                 result += symbol;
                
             }

             return result;
         }
         public void ReWrite(string input)
         {
             string result = "";
             string variable = "";
             string toVariable = "";
             int i;
             for (i = 0; i < input.Length; i++)
             {
                 char symbol = input[i];
                 if (symbol == '=')
                 {
                     i++;
                     break;
                 }
                 if (symbol == '<')
                 {
                     i++;
                     symbol = input[i];
                     while (symbol!='>')
                     {
                         variable += symbol;
                         i++;
                         symbol = input[i];
                     }
                     toVariable += variable;
                     variable = "";
                 }
             }
             bool flag_string = false;
             bool found_pr = false;
             for (; i < input.Length; i++)
             {
                 char symbol = input[i];
                 if (symbol == '"')
                 {
                     found_pr = true;
                     continue;
                 }
                 if (symbol == ' '&&found_pr==false)
                 {
                     continue;
                 }
                 if (symbol == '\\' && input[i + 1] == 'n')
                 {
                     found_pr = true;
                     i++;
                     result += "\n";
                     continue;
                 }
                 if (symbol == '<')
                 {
                     found_pr = true;
                     i++;
                     symbol = input[i];

                     while (symbol!='>')
                     {
                         variable += symbol;
                         i++;
                         symbol = input[i];
                     }
                     
                     foreach (var _symbol in variables[variable])
                     {
                         if (char.IsLetter(_symbol))
                         {
                             flag_string = true;
                         }
                     }
                     result += variables[variable];
                     variable = "";
                     continue;
                 }
                 if (char.IsLetter(symbol))
                 {
                     found_pr = true;
                     flag_string = true;
                 }
                 result += symbol;
             }

             if (flag_string)
             {
                 variables[toVariable] = result;
                 return;
             }
             variables[toVariable] = ParseDouble(result).ToString();
         }
         public void ReWrite_copy(string input)
         {
             string result = "";
             string variable = "";
             string toVariable = "";
             int i;
             for (i = 0; i < input.Length; i++)
             {
                 char symbol = input[i];
                 if (symbol == '=')
                 {
                     i++;
                     break;
                 }
                 if (symbol == '<')
                 {
                     i++;
                     symbol = input[i];
                     while (symbol!='>')
                     {
                         variable += symbol;
                         i++;
                         symbol = input[i];
                     }
                     toVariable += variable;
                     variable = "";
                 }
             }
             bool flag_string = false;
             bool found_pr = false;
             for (; i < input.Length; i++)
             {
                 char symbol = input[i];
                 if (symbol == '"')
                 {
                     found_pr = true;
                     continue;
                 }
                 if (symbol == ' '&&found_pr==false)
                 {
                     continue;
                 }
                 if (symbol == '\\' && input[i + 1] == 'n')
                 {
                     found_pr = true;
                     i++;
                     result += "\n";
                     continue;
                 }
                 if (symbol == '<')
                 {
                     found_pr = true;
                     i++;
                     symbol = input[i];
                     while (symbol!='>')
                     {
                         variable += symbol;
                         i++;
                         symbol = input[i];
                     }
                     foreach (var _symbol in variables[variable])
                     {
                         if (char.IsLetter(_symbol))
                         {
                             flag_string = true;
                         }
                     }

                     result += variables_copy[variable];
                     variable = "";
                     continue;
                 }
                 if (char.IsLetter(symbol))
                 {
                     found_pr = true;
                     flag_string = true;
                 }
                 result += symbol;
             }
             if (flag_string)
             {
                 variables_copy[toVariable] = result;
                 return;
             }
             variables_copy[toVariable] = ParseDouble(result).ToString();
         }
         static bool ParseBool(string expression)
         {
             return CSharpScript.EvaluateAsync<bool>(expression).Result;
         }
         static double ParseDouble(string expression)
         {
             return CSharpScript.EvaluateAsync<double>(expression).Result;
         }
 
     }
 }