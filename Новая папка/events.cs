using System;

namespace Project56
{
    public class events
    {
        private static Random rand;

        public class buttons_to_create
        {
            public string text;
            public string condition_out;
            public string type;
        } 
        public static void check_events()
        {
            rand = new Random();
            check_weather();
            Rilan_bridge_closed();
            open_inventory();

        }

        public static void check_weather()
        {
            if (Form1.quests["weather"] == "Дождь" && Form1.location_now.types["open air"]==1)
            {
                Form1.info.AppendText("Все небо заволокло тучами, и, кажется, в ближайшее время дождь не собирается заканчиваться." +
                                       " Если не найти быстро укрытия, можно очень быстро промокнуть и замерзнуть. \n");
                if (rand.Next(0, 100) < 5)
                {
                    Form1.quests["weather"] = "Облачно";
                    Form1.info.AppendText("Грозовые тучи уходят, сверкнув напоследок молнией, и наступает тишина. О прошедшем" +
                                          " дожде напоминают многочисленные лужи. Постепенно становится теплее. \n");
                    return;
                }
                return;
            }
            if (Form1.quests["weather"] == "Облачно" && Form1.location_now.types["open air"]==1)
            {
                Form1.info.AppendText("Серое и скучное небо, серые и скучные облака до горизонта, но, к счастью, дождя нет, и " +
                                      "непонятно, собирается ли он идти в ближайшее время. \n");
                if (rand.Next(0, 100) < 10)
                {
                    Form1.quests["weather"] = "Дождь";
                    Form1.info.AppendText("С темного серого неба начинают падать крупные капли. Все небо заволокло тучами, и, " +
                                          "кажется, в ближайшее время он не собирается заканчиваться. С каждой минутой становится " +
                                          "холоднее. \n");
                    return;
                }
                if (rand.Next(0, 100) < 5)
                {
                    Form1.quests["weather"] = "Ясно";
                    Form1.info.AppendText("Тучи уходят, оставляя после себя легкую сырость в воздухе. \n");
                    return;
                }
                return;
            }
            if (Form1.quests["weather"] == "Ясно" && Form1.location_now.types["open air"]==1)
            {
                Form1.info.AppendText("Ясное, голубое небо. Иногда проплывают редкие облака, и можно долго угадывать, " +
                                      "на что они похожи. \n");
                if (rand.Next(0, 100) < 5)
                {
                    Form1.quests["weather"] = "Облачно";
                    Form1.info.AppendText("Резко подул ветер. Небо начало заволакивать грустными темными тучами до горизонта. \n");
                    return;
                }
                return;
            }
        }

        public static void open_inventory()
        {
            if (Form1.quests["inventory open"]=="closed")
            {
                Form1.buttons_to_create_count++;
                Form1.buttons_to_create[Form1.buttons_to_create_count] = new buttons_to_create();
                Form1.buttons_to_create[Form1.buttons_to_create_count].text = "Открыть сумку";
                Form1.buttons_to_create[Form1.buttons_to_create_count].condition_out = "Открыть сумку";
                Form1.buttons_to_create[Form1.buttons_to_create_count].type = "quest";
            }
            if (Form1.quests["inventory open"]=="open")
            {
                Form1.buttons_to_create_count++;
                Form1.buttons_to_create[Form1.buttons_to_create_count] = new buttons_to_create();
                Form1.buttons_to_create[Form1.buttons_to_create_count].text = "Закрыть сумку";
                Form1.buttons_to_create[Form1.buttons_to_create_count].condition_out = "Закрыть сумку";
                Form1.buttons_to_create[Form1.buttons_to_create_count].type = "quest";
                
                Form1.info.AppendText("В сумке лежит: ");
                foreach (var item in Form1.inventory)
                {
                    Form1.info.AppendText(item.Value+" "+item.Key+", ");
                }
                Form1.info.AppendText("\n");
            }
        }
        
        public static void Rilan_bridge_closed()
        {
            if ( (Form1.location_now.name == "Мост к Академии") && (Convert.ToInt32(Form1.variables["time"])>=1320
                                                                    ||Convert.ToInt32(Form1.variables["time"])<=360) 
                                                                &&(Form1.quests["Rilan_bridge_closed"]=="none"))
            {
                Form1.variables["state"] = "Dialog";
                Form1.info.AppendText("-Мост закрыт, приходи завтра. - Говорит ближайший стражник.");
                
                Form1.buttons_to_create_count++;
                Form1.buttons_to_create[Form1.buttons_to_create_count] = new buttons_to_create();
                Form1.buttons_to_create[Form1.buttons_to_create_count].text = "Хорошо, я, пожалуй, пойду.";
                Form1.buttons_to_create[Form1.buttons_to_create_count].condition_out = "Rilan_bridge_closed.Уйти";
                Form1.buttons_to_create[Form1.buttons_to_create_count].type = "quest";
                
                Form1.buttons_to_create_count++;
                Form1.buttons_to_create[Form1.buttons_to_create_count] = new buttons_to_create();
                Form1.buttons_to_create[Form1.buttons_to_create_count].text = "Не, хочу забаговаться";
                Form1.buttons_to_create[Form1.buttons_to_create_count].condition_out = "Rilan_bridge_closed.Баг";
                Form1.buttons_to_create[Form1.buttons_to_create_count].type = "quest";
            }
        }
        

    }
}