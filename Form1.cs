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
         private void update()
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
             stats.Clear();
             info.Clear();
             
             read_data_file();
 
             add_stats();
         }
         private void read_data_file()
         {
             var deserializer = new YamlDotNet.Serialization.DeserializerBuilder()
                 .WithNamingConvention(CamelCaseNamingConvention.Instance)
                 .Build();
            
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
         private void add_stats()
         {
             stats.AppendText("Time\n");
             stats.AppendText(variables["time hours"] + ":" + variables["time minutes"] + "\n");
         }
         private void create_buttons()
         {
             //количество уже созданных кнопок
             button_count = 0;
             //считывание локации
             read_location();
             //считывание евентов
             add_info();
             //создание кнопок локаций
             if (variables["state"] == "none" && variables["inventory open"] == "closed")
             {
                 create_buttons_location();
             }
             add_event_buttons();
         }
         private void save_to_data()
         {
             var serializer = new SerializerBuilder()
                 .WithNamingConvention(CamelCaseNamingConvention.Instance)
                 .Build();
             var result = serializer.Serialize(variables);
             StreamWriter data_file_writer = new StreamWriter("data/data.yaml");
             data_file_writer.WriteLine(result);
             data_file_writer.Close();
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
             read_items();
             events.check_events();
             
             info.AppendText(variables["info"]);
         }
         private void add_event_buttons()
         {
             /*
             for (int i = 1; i <= buttons_to_create_count; i++)
             {
                 create_button(buttons_to_create[i].text,
                     buttons_to_create[i].condition_out,
                     buttons_to_create[i].type);
             }
             */
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
             foreach (var variable_change in button_change_variables[button.TabIndex])
             {
                 ReWrite(variable_change);
             }
             save_to_data();
             save_items();
             update();
         }
         private void create_graphics()
         {
             
             if (File.Exists("data/images/locations/" + location_now.Name + ".png"))
             {
                 
                 location_image.Image = Image.FromFile("data/images/locations/" + location_now.Name + ".png");
             }
             else
             {
                 if (File.Exists("data/images/locations/Sample.png"))
                 {
                     location_image.Image = Image.FromFile("data/images/locations/Sample.png");
                 }
             }
             
         }
         private void read_quests()
         {
             var deserializer = new YamlDotNet.Serialization.DeserializerBuilder()
                 .WithNamingConvention(CamelCaseNamingConvention.Instance)
                 .Build();
            
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
         private void read_items()
         {
             StreamReader file = new StreamReader("data/items.txt");
             string item_string = file.ReadLine();
             while (item_string != "END")
             {
                 inventory[item_string] = Convert.ToInt32(file.ReadLine());
                 item_string = file.ReadLine();
             }
             file.Close();
         }
         private void save_items()
         {
             StreamWriter items_file_writer = new StreamWriter("data/items.txt");
             foreach (var item in inventory)
             {
                 items_file_writer.WriteLine(item.Key);
                 items_file_writer.WriteLine(item.Value);
             }
             items_file_writer.WriteLine("END");
             items_file_writer.Close();
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
         public int button_count;
         //Текущая локация
         public static Locations.location_class location_now;
         //Картинка
         public PictureBox location_image;
         //Переменные ["Name"]=value
         public static Dictionary<string, string> variables = new Dictionary<string, string>();
         //Копия переменных для events
         public static Dictionary<string,string> variables_copy = new Dictionary<string, string>();
         //Активные/Все квесты
         public static Dictionary<string, string> quests = new Dictionary<string, string>();
         //вроде переходы по кнопкам
         public static List<string>[] button_change_variables = new List<string>[102];
         //инвентарь
         public static Dictionary<string, int> inventory = new Dictionary<string, int>();
         //public static events.buttons_to_create[] buttons_to_create = new events.buttons_to_create[102];
         private static Random rand;
         //
         private Button[] buttons;



         public bool check_condition(string input)
         {
             if (input == null)
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
                 if (symbol == ' ')
                 {
                     continue;
                 }

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
             for (; i < input.Length; i++)
             {
                 char symbol = input[i];
                 if (symbol == ' '&&flag_string==false)
                 {
                     continue;
                 }
                 if (symbol == '"')
                 {
                     continue;
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
                     result += variables[variable];
                     variable = "";
                     continue;
                 }
                 if (char.IsLetter(symbol))
                 {
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
             for (; i < input.Length; i++)
             {
                 char symbol = input[i];
                 if (symbol == ' '&&flag_string==false)
                 {
                     continue;
                 }
                 if (symbol == '"')
                 {
                     continue;
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
                     result += variables[variable];
                     variable = "";
                     continue;
                 }
                 if (char.IsLetter(symbol))
                 {
                     flag_string = true;
                 }
                 result += symbol;
             }

             if (flag_string)
             {
                 variables[toVariable] = result;
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