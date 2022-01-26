using System.Collections.Generic;
using System.Linq;

namespace Project56
{
    public class Quests
    {
        public static void Main_Quests()
        {
            Find_Academy_Quest();
        }
        
        //КВЕСТ - найти Академию
        public static void Find_Academy_Quest()
        {
            if (!Form1.variables.ContainsKey("Find_Academy_Quest"))
            {
                Form1.variables["Find_Academy_Quest"] = "none";
            }
            
        }

        public static void repare_time()
        {
            Form1.variables["previous time"] = Form1.variables["time"];
        }
    }
}