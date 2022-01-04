using System;
using System.Security.Cryptography;

namespace Project56
{
    public class variables_change
    {
        private static string variable_change_number;
        public static void change(string get_variable_change_number)
        {
            variable_change_number = get_variable_change_number;
            Rilan();
            //инвентарь
            if (variable_change_number == "Открыть сумку")
            {
                Form1.quests["inventory open"] = "open";
                Form1.variables["time"] = Convert.ToString(Convert.ToInt32(Form1.variables["time"])+1);
            }
            if (variable_change_number == "Закрыть сумку")
            {
                Form1.quests["inventory open"] = "closed";
                Form1.variables["time"] = Convert.ToString(Convert.ToInt32(Form1.variables["time"])+1);
            }
        }

        public static void Rilan()
        {
            //quests and events
            if (variable_change_number == "Rilan_bridge_closed.Уйти")
            {
                Form1.variables["current location"] = "Порт Рилана";
                Form1.variables["time"] = Convert.ToString(Convert.ToInt32(Form1.variables["time"])+1);
                Form1.variables["state"] = "none";
            }
            if (variable_change_number == "Rilan_bridge_closed.Баг")
            {
                Form1.variables["current location"] = "Порт Рилана";
                Form1.variables["time"] = Convert.ToString(Convert.ToInt32(Form1.variables["time"])+1);
            }
        }
    }
}