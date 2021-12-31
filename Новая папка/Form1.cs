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
        }

        public void Form1_Load(object sender, EventArgs e)
        {
            Controls.Clear();
            //создание всей статистики
            create_all_info();
            //создание кнопок событий
            create_buttons();
            //создание графики
            create_graphics();
        }

        private void create_all_info()
        {
            //Размеры поля
            Graphics g = CreateGraphics();
            g.Clear(BackColor);
            size_width = (Width - 15) / numbers_width;
            size_height = (Height - 20) / numbers_height;
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
            info.Location = new Point(5 * size_width, 1 * size_height);
            info.Size = new Size(12 * size_width, 10 * size_height);
            info.ReadOnly = true;
            //info.BorderStyle = BorderStyle.None;
            Controls.Add(info);

            stats.Location = new Point(0 * size_width, 1 * size_height);
            stats.Size = new Size(4 * size_width, 22 * size_height);
            stats.ReadOnly = true;
            //info.BorderStyle = BorderStyle.None;
            Controls.Add(stats);
            stats.Clear();


            //считывание основной информации
            read_data_file();

            add_stats();
        }

        private void read_data_file()
        {
            StreamReader file = new StreamReader("data/data.txt");
            string data_string = file.ReadLine();
            while (data_string != "END")
            {
                if (data_string == "current location")
                {
                    // [current location] = N
                    variables[data_string] = file.ReadLine();
                    data_string = file.ReadLine();
                    data_string = file.ReadLine();
                }

                if (data_string == "time")
                {
                    // [time] = hours*60 + minutes
                    variables["time"] = Convert.ToString(Convert.ToInt32(file.ReadLine()) % 1440);
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

                    data_string = file.ReadLine();
                    data_string = file.ReadLine();
                }

                if (data_string == "state")
                {
                    // [state] = type
                    variables["state"] = file.ReadLine();
                    data_string = file.ReadLine();
                    data_string = file.ReadLine();
                }
            }

            file.Close();
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
            if (variables["state"] == "none" && quests["inventory open"] == "closed")
            {
                create_buttons_location();
            }
            add_event_buttons();
        }

        private void save_to_data()
        {
            StreamWriter data_file_writer = new StreamWriter("data/data.txt");
            data_file_writer.WriteLine("current location");
            data_file_writer.WriteLine(variables["current location"]);
            data_file_writer.WriteLine();
            data_file_writer.WriteLine("time");
            data_file_writer.WriteLine(variables["time"]);
            data_file_writer.WriteLine();
            data_file_writer.WriteLine("state");
            data_file_writer.WriteLine(variables["state"]);
            data_file_writer.WriteLine();
            data_file_writer.WriteLine("END");
            data_file_writer.Close();
        }

        private void read_location()
        {
            location_now = new Locations.location_class();
            location_now = Locations.get_location(variables["current location"]);
            info.Clear();
            info.AppendText(location_now.name + "\n");
            info.AppendText(location_now.info + "\n");
        }

        private void add_info()
        {
            read_quests();
            read_items();
            buttons_to_create_count = 0;
            events.check_events();
        }

        private void add_event_buttons()
        {
            for (int i = 1; i <= buttons_to_create_count; i++)
            {
                create_button(buttons_to_create[i].text,
                    buttons_to_create[i].condition_out,
                    buttons_to_create[i].type);
            }
        }
        
        private void create_buttons_location()
        {
            for (int i = 1; i <= location_now.location_out_number; i++)
            {
                int location_out = i;
                create_button(location_now.location_out_text[location_out],
                    location_now.condition_out[location_out],
                    "location");
            }
        }

        public void create_button(string text, string condition_out, string type)
        {
            button_count++;
            Button button = new Button();
            button.Text = text;
            button.Size = new Size(6 * size_width, 1 * size_height);
            button.Location = new Point(5 * size_width, (11 + button_count) * size_height);
            button.TabIndex = button_count;
            if (type == "location")
            {
                button.Click += button_location_reaction;
            }

            if (type == "quest")
            {
                button.Click += button_quest_reaction;
            }

            button_information[button_count] = condition_out;
            Controls.Add(button);
        }

        private void button_location_reaction(object sender, EventArgs e)
        {
            Button button = sender as Button;
            if (conditions.check_condition(button_information[button.TabIndex]))
            {
                variables_change.change(button_information[button.TabIndex]);
                save_to_data();
                save_quests();
                save_items();
                Form1_Load(sender, e);
            }
        }

        private void button_quest_reaction(object sender, EventArgs e)
        {
            Button button = sender as Button;
            if (conditions.check_condition(button_information[button.TabIndex]))
            {
                variables_change.change(button_information[button.TabIndex]);
                save_to_data();
                save_quests();
                save_items();
                Form1_Load(sender, e);
            }
        }

        private void create_graphics()
        {
            location_image = new PictureBox();
            location_image.Image = Image.FromFile("data/images/locations/" + location_now.name + ".png");
            location_image.SizeMode = PictureBoxSizeMode.StretchImage;
            location_image.Location = new Point(size_width * 17, size_height * 1);
            location_image.Size = new Size(size_width * 13, size_height * 13);
            Controls.Add(location_image);
        }

        private void read_quests()
        {
            StreamReader file = new StreamReader("data/quests.txt");
            string quest_string = file.ReadLine();
            while (quest_string != "END")
            {
                quests[quest_string] = file.ReadLine();
                quest_string = file.ReadLine();
            }
            file.Close();
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

        private void save_quests()
        {
            StreamWriter quests_file_writer = new StreamWriter("data/quests.txt");
            foreach (var quest_pair in quests)
            {
                quests_file_writer.WriteLine(quest_pair.Key);
                quests_file_writer.WriteLine(quest_pair.Value);
            }
            quests_file_writer.WriteLine("END");
            quests_file_writer.Close();
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
        //Активные/Все квесты
        public static Dictionary<string, string> quests = new Dictionary<string, string>();
        //вроде переходы по кнопкам
        public static Dictionary<int, string> button_information = new Dictionary<int, string>();
        //инвентарь
        public static Dictionary<string, int> inventory = new Dictionary<string, int>();
        //количество кнопок для создания и их переходы
        public static int buttons_to_create_count;
        public static events.buttons_to_create[] buttons_to_create = new events.buttons_to_create[102];
        
        
        
        
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
            
            for (; i < input.Length; i++)
            {
                char symbol = input[i];
                if (symbol == ' ')
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
                result += symbol;
            }

            variables[toVariable] = ParseDouble(result).ToString();
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