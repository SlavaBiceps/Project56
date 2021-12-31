using System;

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
            //locations
            if (variable_change_number == "Зайти в темный переулок")
            {
                Form1.variables["current location"] = "Темный переулок";
                Form1.variables["time"] = Convert.ToString(Convert.ToInt32(Form1.variables["time"])+2);
            }
            if (variable_change_number == "Улица Рыбная")
            {
                Form1.variables["current location"] = "Улица Рыбная";
                Form1.variables["time"] = Convert.ToString(Convert.ToInt32(Form1.variables["time"])+1);
            }
            if (variable_change_number == "Улица Рыбная2")
            {
                Form1.variables["current location"] = "Улица Рыбная2";
                Form1.variables["time"] = Convert.ToString(Convert.ToInt32(Form1.variables["time"])+1);
            }
            if (variable_change_number == "Улица Рыбная3")
            {
                Form1.variables["current location"] = "Улица Рыбная3";
                Form1.variables["time"] = Convert.ToString(Convert.ToInt32(Form1.variables["time"])+1);
            }
            if (variable_change_number == "Улица Рыбная4")
            {
                Form1.variables["current location"] = "Улица Рыбная4";
                Form1.variables["time"] = Convert.ToString(Convert.ToInt32(Form1.variables["time"])+1);
            }
            if (variable_change_number == "Улица Трех Кинжалов")
            {
                Form1.variables["current location"] = "Улица Трех Кинжалов";
                Form1.variables["time"] = Convert.ToString(Convert.ToInt32(Form1.variables["time"])+1);
            }
            if (variable_change_number == "Улица Трех Кинжалов2")
            {
                Form1.variables["current location"] = "Улица Трех Кинжалов2";
                Form1.variables["time"] = Convert.ToString(Convert.ToInt32(Form1.variables["time"])+1);
            }
            if (variable_change_number == "Улица Трех Кинжалов3")
            {
                Form1.variables["current location"] = "Улица Трех Кинжалов3";
                Form1.variables["time"] = Convert.ToString(Convert.ToInt32(Form1.variables["time"])+1);
            }
            if (variable_change_number == "Улица Трех Кинжалов4")
            {
                Form1.variables["current location"] = "Улица Трех Кинжалов4";
                Form1.variables["time"] = Convert.ToString(Convert.ToInt32(Form1.variables["time"])+1);
            }
            if (variable_change_number == "Улица Трех Кинжалов5")
            {
                Form1.variables["current location"] = "Улица Трех Кинжалов5";
                Form1.variables["time"] = Convert.ToString(Convert.ToInt32(Form1.variables["time"])+1);
            }
            if (variable_change_number == "Улица Морозная")
            {
                Form1.variables["current location"] = "Улица Морозная";
                Form1.variables["time"] = Convert.ToString(Convert.ToInt32(Form1.variables["time"])+1);
            }
            if (variable_change_number == "Улица Морозная2")
            {
                Form1.variables["current location"] = "Улица Морозная2";
                Form1.variables["time"] = Convert.ToString(Convert.ToInt32(Form1.variables["time"])+1);
            }
            if (variable_change_number == "Улица Морозная3")
            {
                Form1.variables["current location"] = "Улица Морозная3";
                Form1.variables["time"] = Convert.ToString(Convert.ToInt32(Form1.variables["time"])+1);
            }
            if (variable_change_number == "Улица Морозная4")
            {
                Form1.variables["current location"] = "Улица Морозная4";
                Form1.variables["time"] = Convert.ToString(Convert.ToInt32(Form1.variables["time"])+1);
            }
            if (variable_change_number == "Улица Морозная5")
            {
                Form1.variables["current location"] = "Улица Морозная5";
                Form1.variables["time"] = Convert.ToString(Convert.ToInt32(Form1.variables["time"])+1);
            }
            if (variable_change_number == "Улица Морозная6")
            {
                Form1.variables["current location"] = "Улица Морозная6";
                Form1.variables["time"] = Convert.ToString(Convert.ToInt32(Form1.variables["time"])+1);
            }
            if (variable_change_number == "Улица Зларис")
            {
                Form1.variables["current location"] = "Улица Зларис";
                Form1.variables["time"] = Convert.ToString(Convert.ToInt32(Form1.variables["time"])+1);
            }
            if (variable_change_number == "Улица Зларис2")
            {
                Form1.variables["current location"] = "Улица Зларис2";
                Form1.variables["time"] = Convert.ToString(Convert.ToInt32(Form1.variables["time"])+1);
            }
            if (variable_change_number == "Улица Зларис3")
            {
                Form1.variables["current location"] = "Улица Зларис3";
                Form1.variables["time"] = Convert.ToString(Convert.ToInt32(Form1.variables["time"])+1);
            }
            if (variable_change_number == "Улица Зларис4")
            {
                Form1.variables["current location"] = "Улица Зларис4";
                Form1.variables["time"] = Convert.ToString(Convert.ToInt32(Form1.variables["time"])+1);
            }
            if (variable_change_number == "Улица Зларис5")
            {
                Form1.variables["current location"] = "Улица Зларис5";
                Form1.variables["time"] = Convert.ToString(Convert.ToInt32(Form1.variables["time"])+1);
            }
            if (variable_change_number == "Улица Цветочная")
            {
                Form1.variables["current location"] = "Улица Цветочная";
                Form1.variables["time"] = Convert.ToString(Convert.ToInt32(Form1.variables["time"])+1);
            }
            if (variable_change_number == "Улица Цветочная2")
            {
                Form1.variables["current location"] = "Улица Цветочная2";
                Form1.variables["time"] = Convert.ToString(Convert.ToInt32(Form1.variables["time"])+1);
            }
            if (variable_change_number == "Улица Цветочная3")
            {
                Form1.variables["current location"] = "Улица Цветочная3";
                Form1.variables["time"] = Convert.ToString(Convert.ToInt32(Form1.variables["time"])+1);
            }
            if (variable_change_number == "Улица Цветочная4")
            {
                Form1.variables["current location"] = "Улица Цветочная4";
                Form1.variables["time"] = Convert.ToString(Convert.ToInt32(Form1.variables["time"])+1);
            }
            if (variable_change_number == "Улица Цветочная5")
            {
                Form1.variables["current location"] = "Улица Цветочная5";
                Form1.variables["time"] = Convert.ToString(Convert.ToInt32(Form1.variables["time"])+1);
            }
            if (variable_change_number == "Площадь Рилана")
            {
                Form1.variables["current location"] = "Площадь Рилана";
                Form1.variables["time"] = Convert.ToString(Convert.ToInt32(Form1.variables["time"])+2);
            }
            if (variable_change_number == "Торговая площадь Рилана")
            {
                Form1.variables["current location"] = "Торговая площадь Рилана";
                Form1.variables["time"] = Convert.ToString(Convert.ToInt32(Form1.variables["time"])+2);
            }
            if (variable_change_number == "Торговая площадь Рилана2")
            {
                Form1.variables["current location"] = "Торговая площадь Рилана2";
                Form1.variables["time"] = Convert.ToString(Convert.ToInt32(Form1.variables["time"])+2);
            }
            if (variable_change_number == "Ветренная Аллея")
            {
                Form1.variables["current location"] = "Ветренная Аллея";
                Form1.variables["time"] = Convert.ToString(Convert.ToInt32(Form1.variables["time"])+1);
            }
            if (variable_change_number == "Ветренная Аллея2")
            {
                Form1.variables["current location"] = "Ветренная Аллея2";
                Form1.variables["time"] = Convert.ToString(Convert.ToInt32(Form1.variables["time"])+1);
            }
            if (variable_change_number == "Ветренная Аллея3")
            {
                Form1.variables["current location"] = "Ветренная Аллея3";
                Form1.variables["time"] = Convert.ToString(Convert.ToInt32(Form1.variables["time"])+1);
            }
            if (variable_change_number == "Ветренная Аллея4")
            {
                Form1.variables["current location"] = "Ветренная Аллея4";
                Form1.variables["time"] = Convert.ToString(Convert.ToInt32(Form1.variables["time"])+1);
            }
            if (variable_change_number == "Улица Новой Надежды")
            {
                Form1.variables["current location"] = "Улица Новой Надежды";
                Form1.variables["time"] = Convert.ToString(Convert.ToInt32(Form1.variables["time"])+1);
            }
            if (variable_change_number == "Улица Новой Надежды2")
            {
                Form1.variables["current location"] = "Улица Новой Надежды2";
                Form1.variables["time"] = Convert.ToString(Convert.ToInt32(Form1.variables["time"])+1);
            }
            if (variable_change_number == "Улица Новой Надежды3")
            {
                Form1.variables["current location"] = "Улица Новой Надежды3";
                Form1.variables["time"] = Convert.ToString(Convert.ToInt32(Form1.variables["time"])+1);
            }
            if (variable_change_number == "Рынок")
            {
                Form1.variables["current location"] = "Рынок";
                Form1.variables["time"] = Convert.ToString(Convert.ToInt32(Form1.variables["time"])+2);
            }
            if (variable_change_number == "Переулок Колсо")
            {
                Form1.variables["current location"] = "Переулок Колсо";
                Form1.variables["time"] = Convert.ToString(Convert.ToInt32(Form1.variables["time"])+1);
            }
            if (variable_change_number == "Переулок Колсо2")
            {
                Form1.variables["current location"] = "Переулок Колсо2";
                Form1.variables["time"] = Convert.ToString(Convert.ToInt32(Form1.variables["time"])+1);
            }
            if (variable_change_number == "Переулок Колсо3")
            {
                Form1.variables["current location"] = "Переулок Колсо3";
                Form1.variables["time"] = Convert.ToString(Convert.ToInt32(Form1.variables["time"])+1);
            }
            if (variable_change_number == "Переулок Солко")
            {
                Form1.variables["current location"] = "Переулок Солко";
                Form1.variables["time"] = Convert.ToString(Convert.ToInt32(Form1.variables["time"])+1);
            }
            if (variable_change_number == "Переулок Солко2")
            {
                Form1.variables["current location"] = "Переулок Солко2";
                Form1.variables["time"] = Convert.ToString(Convert.ToInt32(Form1.variables["time"])+1);
            }
            if (variable_change_number == "Переулок Солко3")
            {
                Form1.variables["current location"] = "Переулок Солко3";
                Form1.variables["time"] = Convert.ToString(Convert.ToInt32(Form1.variables["time"])+1);
            }
            if (variable_change_number == "Южная Эллада")
            {
                Form1.variables["current location"] = "Южная Эллада";
                Form1.variables["time"] = Convert.ToString(Convert.ToInt32(Form1.variables["time"])+1);
            }
            if (variable_change_number == "Южная Эллада2")
            {
                Form1.variables["current location"] = "Южная Эллада2";
                Form1.variables["time"] = Convert.ToString(Convert.ToInt32(Form1.variables["time"])+1);
            }
            if (variable_change_number == "Южная Эллада3")
            {
                Form1.variables["current location"] = "Южная Эллада3";
                Form1.variables["time"] = Convert.ToString(Convert.ToInt32(Form1.variables["time"])+1);
            }
            if (variable_change_number == "Южная Эллада4")
            {
                Form1.variables["current location"] = "Южная Эллада4";
                Form1.variables["time"] = Convert.ToString(Convert.ToInt32(Form1.variables["time"])+1);
            }
            if (variable_change_number == "Южная Эллада5")
            {
                Form1.variables["current location"] = "Южная Эллада5";
                Form1.variables["time"] = Convert.ToString(Convert.ToInt32(Form1.variables["time"])+1);
            }
            if (variable_change_number == "Южная Эллада6")
            {
                Form1.variables["current location"] = "Южная Эллада6";
                Form1.variables["time"] = Convert.ToString(Convert.ToInt32(Form1.variables["time"])+1);
            }
            if (variable_change_number == "Южная Эллада7")
            {
                Form1.variables["current location"] = "Южная Эллада7";
                Form1.variables["time"] = Convert.ToString(Convert.ToInt32(Form1.variables["time"])+1);
            }
            if (variable_change_number == "Южная Эллада8")
            {
                Form1.variables["current location"] = "Южная Эллада8";
                Form1.variables["time"] = Convert.ToString(Convert.ToInt32(Form1.variables["time"])+1);
            }
            if (variable_change_number == "Южная Эллада9")
            {
                Form1.variables["current location"] = "Южная Эллада9";
                Form1.variables["time"] = Convert.ToString(Convert.ToInt32(Form1.variables["time"])+1);
            }
            if (variable_change_number == "Южная Эллада10")
            {
                Form1.variables["current location"] = "Южная Эллада10";
                Form1.variables["time"] = Convert.ToString(Convert.ToInt32(Form1.variables["time"])+1);
            }
            if (variable_change_number == "Южная Эллада11")
            {
                Form1.variables["current location"] = "Южная Эллада11";
                Form1.variables["time"] = Convert.ToString(Convert.ToInt32(Form1.variables["time"])+1);
            }
            if (variable_change_number == "Южная Эллада12")
            {
                Form1.variables["current location"] = "Южная Эллада12";
                Form1.variables["time"] = Convert.ToString(Convert.ToInt32(Form1.variables["time"])+1);
            }
            if (variable_change_number == "Порт Рилана")
            {
                Form1.variables["current location"] = "Порт Рилана";
                Form1.variables["time"] = Convert.ToString(Convert.ToInt32(Form1.variables["time"])+2);
            }
            if (variable_change_number == "Базар Рилана")
            {
                Form1.variables["current location"] = "Базар Рилана";
                Form1.variables["time"] = Convert.ToString(Convert.ToInt32(Form1.variables["time"])+2);
            }
            if (variable_change_number == "Таверна Пьяный Дракон")
            {
                Form1.variables["current location"] = "Таверна Пьяный Дракон";
                Form1.variables["time"] = Convert.ToString(Convert.ToInt32(Form1.variables["time"])+5);
            }
            if (variable_change_number == "Мост к Академии")
            {
                Form1.variables["current location"] = "Мост к Академии";
                Form1.variables["time"] = Convert.ToString(Convert.ToInt32(Form1.variables["time"])+2);
            }
            if (variable_change_number == "Мост к Академии2")
            {
                Form1.variables["current location"] = "Мост к Академии2";
                Form1.variables["time"] = Convert.ToString(Convert.ToInt32(Form1.variables["time"])+3);
            }
            if (variable_change_number == "Мост к Академии3")
            {
                Form1.variables["current location"] = "Мост к Академии3";
                Form1.variables["time"] = Convert.ToString(Convert.ToInt32(Form1.variables["time"])+3);
            }
            if (variable_change_number == "Мост к Академии4")
            {
                Form1.variables["current location"] = "Мост к Академии4";
                Form1.variables["time"] = Convert.ToString(Convert.ToInt32(Form1.variables["time"])+3);
            }
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