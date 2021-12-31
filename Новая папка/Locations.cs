using System.Collections.Generic;

namespace Project56
{
    public class Locations
    {
        
        public class location_class
        {
            public string name;
            public string info;
            public int location_out_number;
            public string[] condition_out = new string[1000];
            public string[] location_out_text = new string[1000];
            public string[] variables_change = new string[1000];
            //офк менять на лист, идиот на Славе

            public Dictionary<string, int> types = new Dictionary<string, int>()
            {
                ["open air"]=0,
            };

        }

        private static location_class location;
        private static int i;
        private static string location_number;
        public static location_class get_location(string get_location_number)
        {
            i = 0;
            location_number = get_location_number;
            location = new location_class();
            Rilan();
            return location;
        }

        public static void Rilan()
        {
            if (location_number == "Темный переулок")
            {
                location.name = "Темный переулок";
                location.info = "Вы находитесь в узком, неосвещенном переулке на незнакомой улице," +
                                " с обеих сторон от места, в котором вы стоите находятся гладкие каменные стены трехэтажных домов." +
                                "Повсюду был мусор, разбросанные старые газеты и доски - по всей видимости от сломанного деревянного" +
                                " ящика. В центре переулка находилась огромная лужа, а в конце переулка виднеется более освещенная часть" +
                                " города\n";
                location.location_out_number = 1;
                
                location.location_out_text[1] = "Улица Рыбная";
                location.condition_out[1] = "Улица Рыбная";
                location.variables_change[1] = "Улица Рыбная";

                location.types["open air"] = 1;
            }
            if (location_number == "Улица Рыбная")
            {
                location.name = "Улица Рыбная";
                location.info = "Улица Рыбная - гласила табличка на ближайшем здании. Здесь было достаточно нелюдно, хотя улица находилась" +
                                "совсем недалеко от крупной торговой площади Рилана. Отсюда можно попасть на торговую площадь, пройти " +
                                "дальше по улице, или вернуться назад.\n";
                location.location_out_number = 3;
                
                location.location_out_text[1] = "Зайти в темный переулок";
                location.condition_out[1] = "Зайти в темный переулок";
                location.variables_change[1] = "Зайти в темный переулок";
                
                location.location_out_text[2] = "Торговая площадь Рилана";
                location.condition_out[2] = "Торговая площадь Рилана";
                location.variables_change[2] = "Торговая площадь Рилана";
                
                location.location_out_text[3] = "Улица Рыбная, на запад";
                location.condition_out[3] = "Улица Рыбная2";
                location.variables_change[3] = "Улица Рыбная2";
                
                location.types["open air"] = 1;
            }
            if (location_number == "Улица Рыбная2")
            {
                location.name = "Улица Рыбная";
                location.info = "Улица Рыбная - гласила табличка на ближайшем здании. Здесь было достаточно нелюдно, хотя улица находилась" +
                                "совсем недалеко от крупной торговой площади Рилана. Отсюда можно пройти дальше по улице, " +
                                "или вернуться назад.\n";
                location.location_out_number = 2;
                
                location.location_out_text[1] = "Улица Рыбная, на восток";
                location.condition_out[1] = "Улица Рыбная";
                location.variables_change[1] = "Улица Рыбная";
                
                location.location_out_text[2] = "Улица Рыбная, на запад";
                location.condition_out[2] = "Улица Рыбная3";
                location.variables_change[2] = "Улица Рыбная3";
                
                location.types["open air"] = 1;
            }
            if (location_number == "Улица Рыбная3")
            {
                location.name = "Улица Рыбная";
                location.info = "Улица Рыбная - гласила табличка на ближайшем здании. Здесь было достаточно нелюдно, хотя улица находилась" +
                                "совсем недалеко от крупной торговой площади Рилана. Отсюда можно пройти дальше по улице, " +
                                "или вернуться назад.\n";
                location.location_out_number = 2;
                
                location.location_out_text[1] = "Улица Рыбная, на восток";
                location.condition_out[1] = "Улица Рыбная2";
                location.variables_change[1] = "Улица Рыбная2";
                
                location.location_out_text[2] = "Улица Рыбная, на запад";
                location.condition_out[2] = "Улица Рыбная4";
                location.variables_change[2] = "Улица Рыбная4";
                
                location.types["open air"] = 1;
            }
            if (location_number == "Улица Рыбная4")
            {
                location.name = "Улица Рыбная";
                location.info = "Улица Рыбная - гласила табличка на ближайшем здании. Здесь было достаточно нелюдно, хотя улица находилась" +
                                "совсем недалеко от крупной торговой площади Рилана. Тупик. Отсюда можно только вернуться назад. \n" +
                                "Так же тут расположена таверна. Старое, облезлое здание, ничем не отличающееся от всех других в этом районе, " +
                                "за исключением того, что окон тут было слишком много, да и на здании весела покосившаяся вывеска " +
                                "'Пьяный Дракон'. Дракон был красным и толстым, словно он был самым желанным гостем этой таверны.\n";
                location.location_out_number = 2;
                
                location.location_out_text[1] = "Улица Рыбная, на запад";
                location.condition_out[1] = "Улица Рыбная3";
                location.variables_change[1] = "Улица Рыбная3";
                
                location.location_out_text[2] = "Таверна Пьяный Дракон";
                location.condition_out[2] = "Таверна Пьяный Дракон";
                location.variables_change[2] = "Таверна Пьяный Дракон";
                
                location.types["open air"] = 1;
            }
            if (location_number == "Улица Трех Кинжалов")
            {
                location.name = "Улица Трех Кинжалов";
                location.info = "Улица Трех Кинжалов - \n";
                
                i++;
                location.location_out_text[i] = "Торговая площадь Рилана";
                location.condition_out[i] = "Торговая площадь Рилана";
                location.variables_change[i] = "Торговая площадь Рилана";
                
                i++;
                location.location_out_text[i] = "Улица Трех Кинжалов, на восток";
                location.condition_out[i] = "Улица Трех Кинжалов2";
                location.variables_change[i] = "Улица Трех Кинжалов2";

                location.location_out_number = i;
                
                location.types["open air"] = 1;
            }
            if (location_number == "Улица Трех Кинжалов2")
            {
                location.name = "Улица Трех Кинжалов";
                location.info = "Улица Трех Кинжалов - \n";
                
                i++;
                location.location_out_text[i] = "Улица Трех Кинжалов, на запад";
                location.condition_out[i] = "Улица Трех Кинжалов";
                location.variables_change[i] = "Улица Трех Кинжалов";
                
                i++;
                location.location_out_text[i] = "Улица Трех Кинжалов, на восток";
                location.condition_out[i] = "Улица Трех Кинжалов3";
                location.variables_change[i] = "Улица Трех Кинжалов3";
                
                location.location_out_number = i;
                
                location.types["open air"] = 1;
            }
            if (location_number == "Улица Трех Кинжалов3")
            {
                location.name = "Улица Трех Кинжалов";
                location.info = "Улица Трех Кинжалов - \n";
                
                i++;
                location.location_out_text[i] = "Улица Трех Кинжалов, на запад";
                location.condition_out[i] = "Улица Трех Кинжалов2";
                location.variables_change[i] = "Улица Трех Кинжалов2";
                
                i++;
                location.location_out_text[i] = "Улица Трех Кинжалов, на восток";
                location.condition_out[i] = "Улица Трех Кинжалов4";
                location.variables_change[i] = "Улица Трех Кинжалов4";
                
                location.location_out_number = i;
                
                location.types["open air"] = 1;
            }
            if (location_number == "Улица Трех Кинжалов4")
            {
                location.name = "Улица Трех Кинжалов";
                location.info = "Улица Трех Кинжалов - \n";
                
                i++;
                location.location_out_text[i] = "Улица Трех Кинжалов, на запад";
                location.condition_out[i] = "Улица Трех Кинжалов3";
                location.variables_change[i] = "Улица Трех Кинжалов3";
                
                i++;
                location.location_out_text[i] = "Улица Трех Кинжалов, на восток";
                location.condition_out[i] = "Улица Трех Кинжалов5";
                location.variables_change[i] = "Улица Трех Кинжалов5";
                
                location.location_out_number = i;
                
                location.types["open air"] = 1;
            }
            if (location_number == "Улица Трех Кинжалов5")
            {
                location.name = "Улица Трех Кинжалов";
                location.info = "Улица Трех Кинжалов - \n";
                
                i++;
                location.location_out_text[i] = "Улица Трех Кинжалов, на запад";
                location.condition_out[i] = "Улица Трех Кинжалов4";
                location.variables_change[i] = "Улица Трех Кинжалов4";

                i++;
                location.location_out_text[i] = "Порт Рилана";
                location.condition_out[i] = "Порт Рилана";
                location.variables_change[i] = "Порт Рилана";

                location.location_out_number = i;
                
                location.types["open air"] = 1;
            }
            if (location_number == "Улица Морозная")
            {
                location.name = "Улица Морозная";
                location.info = "Улица Морозная - \n";
                
                i++;
                location.location_out_text[i] = "Улица Морозная, на север";
                location.condition_out[i] = "Улица Морозная2";
                location.variables_change[i] = "Улица Морозная2";
                
                i++;
                location.location_out_text[i] = "Порт Рилана";
                location.condition_out[i] = "Порт Рилана";
                location.variables_change[i] = "Порт Рилана";

                location.location_out_number = i;
                
                location.types["open air"] = 1;
            }
            if (location_number == "Улица Морозная2")
            {
                location.name = "Улица Морозная";
                location.info = "Улица Морозная - \n";
                
                i++;
                location.location_out_text[i] = "Улица Морозная, на север";
                location.condition_out[i] = "Улица Морозная3";
                location.variables_change[i] = "Улица Морозная3";
                
                i++;
                location.location_out_text[i] = "Улица Морозная, на юг";
                location.condition_out[i] = "Улица Морозная";
                location.variables_change[i] = "Улица Морозная";
                
                location.location_out_number = i;
                
                location.types["open air"] = 1;
            }
            if (location_number == "Улица Морозная3")
            {
                location.name = "Улица Морозная";
                location.info = "Улица Морозная - \n";
                
                i++;
                location.location_out_text[i] = "Улица Морозная, на север";
                location.condition_out[i] = "Улица Морозная4";
                location.variables_change[i] = "Улица Морозная4";
                
                i++;
                location.location_out_text[i] = "Улица Морозная, на юг";
                location.condition_out[i] = "Улица Морозная2";
                location.variables_change[i] = "Улица Морозная2";
                
                location.location_out_number = i;
                
                location.types["open air"] = 1;
            }
            if (location_number == "Улица Морозная4")
            {
                location.name = "Улица Морозная";
                location.info = "Улица Морозная - \n";
                
                i++;
                location.location_out_text[i] = "Улица Морозная, на север";
                location.condition_out[i] = "Улица Морозная5";
                location.variables_change[i] = "Улица Морозная5";
                
                i++;
                location.location_out_text[i] = "Улица Морозная, на юг";
                location.condition_out[i] = "Улица Морозная3";
                location.variables_change[i] = "Улица Морозная3";

                location.location_out_number = i;
                
                location.types["open air"] = 1;
            }
            if (location_number == "Улица Морозная5")
            {
                location.name = "Улица Морозная";
                location.info = "Улица Морозная - \n";
                
                i++;
                location.location_out_text[i] = "Улица Морозная, на север";
                location.condition_out[i] = "Улица Морозная6";
                location.variables_change[i] = "Улица Морозная6";
                
                i++;
                location.location_out_text[i] = "Улица Морозная, на юг";
                location.condition_out[i] = "Улица Морозная4";
                location.variables_change[i] = "Улица Морозная4";

                location.location_out_number = i;
                
                location.types["open air"] = 1;
            }
            if (location_number == "Улица Зларис")
            {
                location.name = "Улица Зларис";
                location.info = "Улица Зларис - \n";
                
                i++;
                location.location_out_text[i] = "Улица Зларис, на север";
                location.condition_out[i] = "Улица Зларис2";
                location.variables_change[i] = "Улица Зларис2";
                
                i++;
                location.location_out_text[i] = "Порт Рилана";
                location.condition_out[i] = "Порт Рилана";
                location.variables_change[i] = "Порт Рилана";

                location.location_out_number = i;
                
                location.types["open air"] = 1;
            }
            if (location_number == "Улица Зларис2")
            {
                location.name = "Улица Зларис";
                location.info = "Улица Зларис - \n";
                
                i++;
                location.location_out_text[i] = "Улица Зларис, на север";
                location.condition_out[i] = "Улица Зларис3";
                location.variables_change[i] = "Улица Зларис3";
                
                i++;
                location.location_out_text[i] = "Улица Зларис, на юг";
                location.condition_out[i] = "Улица Зларис";
                location.variables_change[i] = "Улица Зларис";

                location.location_out_number = i;
                
                location.types["open air"] = 1;
            }
            if (location_number == "Улица Зларис3")
            {
                location.name = "Улица Зларис";
                location.info = "Улица Зларис - \n";
                
                i++;
                location.location_out_text[i] = "Улица Зларис, на север";
                location.condition_out[i] = "Улица Зларис4";
                location.variables_change[i] = "Улица Зларис4";
                
                i++;
                location.location_out_text[i] = "Улица Зларис, на юг";
                location.condition_out[i] = "Улица Зларис2";
                location.variables_change[i] = "Улица Зларис2";

                location.location_out_number = i;
                
                location.types["open air"] = 1;
            }
            if (location_number == "Улица Зларис4")
            {
                location.name = "Улица Зларис";
                location.info = "Улица Зларис - \n";
                
                i++;
                location.location_out_text[i] = "Улица Зларис, на север";
                location.condition_out[i] = "Улица Зларис5";
                location.variables_change[i] = "Улица Зларис5";
                
                i++;
                location.location_out_text[i] = "Улица Зларис, на юг";
                location.condition_out[i] = "Улица Зларис3";
                location.variables_change[i] = "Улица Зларис3";

                location.location_out_number = i;
                
                location.types["open air"] = 1;
            }
            if (location_number == "Улица Зларис5")
            {
                location.name = "Улица Зларис";
                location.info = "Улица Зларис - \n";
                
                i++;
                location.location_out_text[i] = "Улица Зларис, на юг";
                location.condition_out[i] = "Улица Зларис4";
                location.variables_change[i] = "Улица Зларис4";

                location.location_out_number = i;
                
                location.types["open air"] = 1;
            }
            if (location_number == "Улица Цветочная")
            {
                location.name = "Улица Цветочная";
                location.info = "Улица Цветочная - \n";
                
                i++;
                location.location_out_text[i] = "Улица Цветочная, на юг";
                location.condition_out[i] = "Улица Цветочная2";
                location.variables_change[i] = "Улица Цветочная2";
                
                i++;
                location.location_out_text[i] = "Порт Рилана";
                location.condition_out[i] = "Порт Рилана";
                location.variables_change[i] = "Порт Рилана";

                location.location_out_number = i;
                
                location.types["open air"] = 1;
            }
            if (location_number == "Улица Цветочная2")
            {
                location.name = "Улица Цветочная";
                location.info = "Улица Цветочная - \n";
                
                i++;
                location.location_out_text[i] = "Улица Цветочная, на юг";
                location.condition_out[i] = "Улица Цветочная3";
                location.variables_change[i] = "Улица Цветочная3";
                
                i++;
                location.location_out_text[i] = "Улица Цветочная, на север";
                location.condition_out[i] = "Улица Цветочная";
                location.variables_change[i] = "Улица Цветочная";

                location.location_out_number = i;
                
                location.types["open air"] = 1;
            }
            if (location_number == "Улица Цветочная3")
            {
                location.name = "Улица Цветочная";
                location.info = "Улица Цветочная - \n";
                
                i++;
                location.location_out_text[i] = "Улица Цветочная, на юг";
                location.condition_out[i] = "Улица Цветочная4";
                location.variables_change[i] = "Улица Цветочная4";
                
                i++;
                location.location_out_text[i] = "Улица Цветочная, на север";
                location.condition_out[i] = "Улица Цветочная2";
                location.variables_change[i] = "Улица Цветочная2";

                location.location_out_number = i;
                
                location.types["open air"] = 1;
            }
            if (location_number == "Улица Цветочная4")
            {
                location.name = "Улица Цветочная";
                location.info = "Улица Цветочная - \n";
                
                i++;
                location.location_out_text[i] = "Улица Цветочная, на юг";
                location.condition_out[i] = "Улица Цветочная5";
                location.variables_change[i] = "Улица Цветочная5";
                
                i++;
                location.location_out_text[i] = "Улица Цветочная, на север";
                location.condition_out[i] = "Улица Цветочная3";
                location.variables_change[i] = "Улица Цветочная3";
                
                i++;
                location.location_out_text[i] = "Улица Новой Надежды";
                location.condition_out[i] = "Улица Новой Надежды";
                location.variables_change[i] = "Улица Новой Надежды";

                location.location_out_number = i;
                
                location.types["open air"] = 1;
            }
            if (location_number == "Улица Цветочная5")
            {
                location.name = "Улица Цветочная";
                location.info = "Улица Цветочная - \n";
                
                i++;
                location.location_out_text[i] = "Улица Цветочная, на север";
                location.condition_out[i] = "Улица Цветочная4";
                location.variables_change[i] = "Улица Цветочная4";
                
                i++;
                location.location_out_text[i] = "Южная Эллада";
                location.condition_out[i] = "Южная Эллада";
                location.variables_change[i] = "Южная Эллада";


                location.location_out_number = i;
                
                location.types["open air"] = 1;
            }
            if (location_number == "Торговая площадь Рилана")
            {
                location.name = "Торговая площадь Рилана, север";
                location.info = "Здесь было шумно, даже слишком. Все занимались привычными делами - кто-то кричал и продавал товар, " +
                                "кто-то кричал и покупал. Найти здесь можно было все, что угодно. Продавались всевозможные магические " +
                                "и не очень вещи: амулеты для повышения стойкости духа, кольца 'интеллекта', зачарованные доспехи " +
                                "и многое другое.\n";
                
                i++;
                location.location_out_text[i] = "Улица Рыбная";
                location.condition_out[i] = "Улица Рыбная";
                location.variables_change[i] = "Улица Рыбная";
                
                i++;
                location.location_out_text[i] = "Улица Трех Кинжалов";
                location.condition_out[i] = "Улица Трех Кинжалов";
                location.variables_change[i] = "Улица Трех Кинжалов";
                
                i++;
                location.location_out_text[i] = "Площадь Рилана";
                location.condition_out[i] = "Площадь Рилана";
                location.variables_change[i] = "Площадь Рилана";
                
                location.location_out_number = i;
                
                location.types["open air"] = 1;
            }
            if (location_number == "Торговая площадь Рилана2")
            {
                location.name = "Торговая площадь Рилана, юг";
                location.info = "Торговая площадь Рилана - \n";
                
                i++;
                location.location_out_text[i] = "Площадь Рилана";
                location.condition_out[i] = "Площадь Рилана";
                location.variables_change[i] = "Площадь Рилана";

                location.location_out_number = i;
                
                location.types["open air"] = 1;
            }
            if (location_number == "Площадь Рилана")
            {
                location.name = "Площадь Рилана";
                location.info = "Площадь Рилана - \n";
                
                i++;
                location.location_out_text[i] = "Торговая площадь Рилана, на юг";
                location.condition_out[i] = "Торговая площадь Рилана2";
                location.variables_change[i] = "Торговая площадь Рилана2";
                
                i++;
                location.location_out_text[i] = "Торговая площадь Рилана, на север";
                location.condition_out[i] = "Торговая площадь Рилана";
                location.variables_change[i] = "Торговая площадь Рилана";

                location.location_out_number = i;
                
                location.types["open air"] = 1;
            }
            if (location_number == "Ветренная Аллея")
            {
                location.name = "Ветренная Аллея";
                location.info = "Ветренная Аллея - \n";
                
                i++;
                location.location_out_text[i] = "Ветренная Аллея, на юг";
                location.condition_out[i] = "Ветренная Аллея2";
                location.variables_change[i] = "Ветренная Аллея2";
                
                i++;
                location.location_out_text[i] = "Порт Рилана";
                location.condition_out[i] = "Порт Рилана";
                location.variables_change[i] = "Порт Рилана";

                location.location_out_number = i;
                
                location.types["open air"] = 1;
            }
            if (location_number == "Ветренная Аллея2")
            {
                location.name = "Ветренная Аллея";
                location.info = "Ветренная Аллея - \n";
                
                i++;
                location.location_out_text[i] = "Ветренная Аллея, на юг";
                location.condition_out[i] = "Ветренная Аллея3";
                location.variables_change[i] = "Ветренная Аллея3";
                
                i++;
                location.location_out_text[i] = "Ветренная Аллея, на север";
                location.condition_out[i] = "Ветренная Аллея";
                location.variables_change[i] = "Ветренная Аллея";

                location.location_out_number = i;
                
                location.types["open air"] = 1;
            }
            if (location_number == "Ветренная Аллея3")
            {
                location.name = "Ветренная Аллея";
                location.info = "Ветренная Аллея - \n";
                
                i++;
                location.location_out_text[i] = "Ветренная Аллея, на юг";
                location.condition_out[i] = "Ветренная Аллея4";
                location.variables_change[i] = "Ветренная Аллея4";
                
                i++;
                location.location_out_text[i] = "Ветренная Аллея, на север";
                location.condition_out[i] = "Ветренная Аллея2";
                location.variables_change[i] = "Ветренная Аллея2";

                location.location_out_number = i;
                
                location.types["open air"] = 1;
            }
            if (location_number == "Ветренная Аллея4")
            {
                location.name = "Ветренная Аллея";
                location.info = "Ветренная Аллея - \n";
                
                i++;
                location.location_out_text[i] = "Рынок";
                location.condition_out[i] = "Рынок";
                location.variables_change[i] = "Рынок";
                
                i++;
                location.location_out_text[i] = "Ветренная Аллея, на север";
                location.condition_out[i] = "Ветренная Аллея3";
                location.variables_change[i] = "Ветренная Аллея3";

                location.location_out_number = i;
                
                location.types["open air"] = 1;
            }
            if (location_number == "Улица Новой Надежды")
            {
                location.name = "Улица Новой Надежды";
                location.info = "Улица Новой Надежды - \n";
                
                i++;
                location.location_out_text[i] = "Улица Новой Надежды, на запад";
                location.condition_out[i] = "Улица Новой Надежды2";
                location.variables_change[i] = "Улица Новой Надежды2";
                
                i++;
                location.location_out_text[i] = "Улица Цветочная";
                location.condition_out[i] = "Улица Цветочная4";
                location.variables_change[i] = "Улица Цветочная4";

                location.location_out_number = i;
                
                location.types["open air"] = 1;
            }
            if (location_number == "Улица Новой Надежды2")
            {
                location.name = "Улица Новой Надежды";
                location.info = "Улица Новой Надежды - \n";
                
                i++;
                location.location_out_text[i] = "Улица Новой Надежды, на запад";
                location.condition_out[i] = "Улица Новой Надежды3";
                location.variables_change[i] = "Улица Новой Надежды3";
                
                i++;
                location.location_out_text[i] = "Улица Новой Надежды, на восток";
                location.condition_out[i] = "Улица Новой Надежды";
                location.variables_change[i] = "Улица Новой Надежды";

                location.location_out_number = i;
                
                location.types["open air"] = 1;
            }
            if (location_number == "Улица Новой Надежды3")
            {
                location.name = "Улица Новой Надежды";
                location.info = "Улица Новой Надежды - \n";

                i++;
                location.location_out_text[i] = "Рынок";
                location.condition_out[i] = "Рынок";
                location.variables_change[i] = "Рынок";
                
                i++;
                location.location_out_text[i] = "Улица Новой Надежды, на восток";
                location.condition_out[i] = "Улица Новой Надежды2";
                location.variables_change[i] = "Улица Новой Надежды2";

                location.location_out_number = i;
                
                location.types["open air"] = 1;
            }
            if (location_number == "Южная Эллада")
            {
                location.name = "Южная Эллада";
                location.info = "Южная Эллада - \n";
                
                i++;
                location.location_out_text[i] = "Улица Цветочная";
                location.condition_out[i] = "Улица Цветочная5";
                location.variables_change[i] = "Улица Цветочная5";
                
                i++;
                location.location_out_text[i] = "Южная Эллада, на юг";
                location.condition_out[i] = "Южная Эллада2";
                location.variables_change[i] = "Южная Эллада2";

                location.location_out_number = i;
                
                location.types["open air"] = 1;
            }
            if (location_number == "Южная Эллада2")
            {
                location.name = "Южная Эллада";
                location.info = "Южная Эллада - \n";
                
                i++;
                location.location_out_text[i] = "Южная Эллада, на север";
                location.condition_out[i] = "Южная Эллада";
                location.variables_change[i] = "Южная Эллада";
                
                i++;
                location.location_out_text[i] = "Южная Эллада, на юг";
                location.condition_out[i] = "Южная Эллада3";
                location.variables_change[i] = "Южная Эллада3";

                location.location_out_number = i;
                
                location.types["open air"] = 1;
            }
            if (location_number == "Южная Эллада3")
            {
                location.name = "Южная Эллада";
                location.info = "Южная Эллада - \n";
                
                i++;
                location.location_out_text[i] = "Южная Эллада, на север";
                location.condition_out[i] = "Южная Эллада2";
                location.variables_change[i] = "Южная Эллада2";
                
                i++;
                location.location_out_text[i] = "Южная Эллада, на юг";
                location.condition_out[i] = "Южная Эллада4";
                location.variables_change[i] = "Южная Эллада4";

                location.location_out_number = i;
                
                location.types["open air"] = 1;
            }
            if (location_number == "Южная Эллада4")
            {
                location.name = "Южная Эллада";
                location.info = "Южная Эллада - \n";
                
                i++;
                location.location_out_text[i] = "Южная Эллада, на север";
                location.condition_out[i] = "Южная Эллада3";
                location.variables_change[i] = "Южная Эллада3";
                
                i++;
                location.location_out_text[i] = "Южная Эллада, на юго-запад";
                location.condition_out[i] = "Южная Эллада5";
                location.variables_change[i] = "Южная Эллада5";
                
                i++;
                location.location_out_text[i] = "Переулок Солко";
                location.condition_out[i] = "Переулок Солко3";
                location.variables_change[i] = "Переулок Солко3";

                location.location_out_number = i;
                
                location.types["open air"] = 1;
            }
            if (location_number == "Южная Эллада5")
            {
                location.name = "Южная Эллада";
                location.info = "Южная Эллада - \n";
                
                i++;
                location.location_out_text[i] = "Южная Эллада, на северо-восток";
                location.condition_out[i] = "Южная Эллада4";
                location.variables_change[i] = "Южная Эллада4";
                
                i++;
                location.location_out_text[i] = "Южная Эллада, на юго-запад";
                location.condition_out[i] = "Южная Эллада6";
                location.variables_change[i] = "Южная Эллада6";

                location.location_out_number = i;
                
                location.types["open air"] = 1;
            }
            if (location_number == "Южная Эллада6")
            {
                location.name = "Южная Эллада";
                location.info = "Южная Эллада - \n";
                
                i++;
                location.location_out_text[i] = "Южная Эллада, на северо-восток";
                location.condition_out[i] = "Южная Эллада5";
                location.variables_change[i] = "Южная Эллада5";
                
                i++;
                location.location_out_text[i] = "Южная Эллада, на юго-запад";
                location.condition_out[i] = "Южная Эллада7";
                location.variables_change[i] = "Южная Эллада7";

                location.location_out_number = i;
                
                location.types["open air"] = 1;
            }
            if (location_number == "Южная Эллада7")
            {
                location.name = "Южная Эллада";
                location.info = "Южная Эллада - \n";
                
                i++;
                location.location_out_text[i] = "Южная Эллада, на северо-восток";
                location.condition_out[i] = "Южная Эллада6";
                location.variables_change[i] = "Южная Эллада6";
                
                i++;
                location.location_out_text[i] = "Южная Эллада, на запад";
                location.condition_out[i] = "Южная Эллада8";
                location.variables_change[i] = "Южная Эллада8";

                location.location_out_number = i;
                
                location.types["open air"] = 1;
            }
            if (location_number == "Южная Эллада8")
            {
                location.name = "Южная Эллада";
                location.info = "Южная Эллада - \n";
                
                i++;
                location.location_out_text[i] = "Южная Эллада, на восток";
                location.condition_out[i] = "Южная Эллада7";
                location.variables_change[i] = "Южная Эллада7";
                
                i++;
                location.location_out_text[i] = "Южная Эллада, на запад";
                location.condition_out[i] = "Южная Эллада9";
                location.variables_change[i] = "Южная Эллада9";

                location.location_out_number = i;
                
                location.types["open air"] = 1;
            }
            if (location_number == "Южная Эллада9")
            {
                location.name = "Южная Эллада";
                location.info = "Южная Эллада - \n";
                
                i++;
                location.location_out_text[i] = "Южная Эллада, на восток";
                location.condition_out[i] = "Южная Эллада8";
                location.variables_change[i] = "Южная Эллада8";
                
                i++;
                location.location_out_text[i] = "Южная Эллада, на запад";
                location.condition_out[i] = "Южная Эллада10";
                location.variables_change[i] = "Южная Эллада10";

                location.location_out_number = i;
                
                location.types["open air"] = 1;
            }
            if (location_number == "Южная Эллада10")
            {
                location.name = "Южная Эллада";
                location.info = "Южная Эллада - \n";
                
                i++;
                location.location_out_text[i] = "Южная Эллада, на восток";
                location.condition_out[i] = "Южная Эллада9";
                location.variables_change[i] = "Южная Эллада9";
                
                i++;
                location.location_out_text[i] = "Южная Эллада, на северо-запад";
                location.condition_out[i] = "Южная Эллада11";
                location.variables_change[i] = "Южная Эллада11";

                location.location_out_number = i;
                
                location.types["open air"] = 1;
            }
            if (location_number == "Южная Эллада11")
            {
                location.name = "Южная Эллада";
                location.info = "Южная Эллада - \n";
                
                i++;
                location.location_out_text[i] = "Южная Эллада, на юго-восток";
                location.condition_out[i] = "Южная Эллада10";
                location.variables_change[i] = "Южная Эллада10";
                
                i++;
                location.location_out_text[i] = "Южная Эллада, на запад";
                location.condition_out[i] = "Южная Эллада12";
                location.variables_change[i] = "Южная Эллада12";

                location.location_out_number = i;
                
                location.types["open air"] = 1;
            }
            if (location_number == "Южная Эллада12")
            {
                location.name = "Южная Эллада";
                location.info = "Южная Эллада - \n";
                
                i++;
                location.location_out_text[i] = "Южная Эллада, на восток";
                location.condition_out[i] = "Южная Эллада11";
                location.variables_change[i] = "Южная Эллада11";

                location.location_out_number = i;
                
                location.types["open air"] = 1;
            }
            if (location_number == "Рынок")
            {
                location.name = "Рынок";
                location.info = "Рынок - \n";
                
                i++;
                location.location_out_text[i] = "Ветренная Аллея";
                location.condition_out[i] = "Ветренная Аллея4";
                location.variables_change[i] = "Ветренная Аллея4";
                
                i++;
                location.location_out_text[i] = "Улица Новой Надежды";
                location.condition_out[i] = "Улица Новой Надежды3";
                location.variables_change[i] = "Улица Новой Надежды3";
                
                i++;
                location.location_out_text[i] = "Переулок Колсо";
                location.condition_out[i] = "Переулок Колсо";
                location.variables_change[i] = "Переулок Колсо";

                location.location_out_number = i;
                
                location.types["open air"] = 1;
            }
            if (location_number == "Базар Рилана")
            {
                location.name = "Базар Рилана";
                location.info = "Базар Рилана - \n";
                
                i++;
                location.location_out_text[i] = "Переулок Колсо";
                location.condition_out[i] = "Переулок Колсо3";
                location.variables_change[i] = "Переулок Колсо3";
                
                i++;
                location.location_out_text[i] = "Переулок Солко";
                location.condition_out[i] = "Переулок Солко";
                location.variables_change[i] = "Переулок Солко";
                
                location.location_out_number = i;
                
                location.types["open air"] = 1;
            }
            if (location_number == "Переулок Колсо")
            {
                location.name = "Переулок Колсо";
                location.info = "Переулок Колсо - \n";
                
                i++;
                location.location_out_text[i] = "Рынок";
                location.condition_out[i] = "Рынок";
                location.variables_change[i] = "Рынок";
                
                i++;
                location.location_out_text[i] = "Переулок Колсо, юго-запад";
                location.condition_out[i] = "Переулок Колсо2";
                location.variables_change[i] = "Переулок Колсо2";

                location.location_out_number = i;
                
                location.types["open air"] = 1;
            }
            if (location_number == "Переулок Колсо2")
            {
                location.name = "Переулок Колсо";
                location.info = "Переулок Колсо - \n";
                
                i++;
                location.location_out_text[i] = "Переулок Колсо, северо-восток";
                location.condition_out[i] = "Переулок Колсо";
                location.variables_change[i] = "Переулок Колсо";
                
                i++;
                location.location_out_text[i] = "Переулок Колсо, юго-запад";
                location.condition_out[i] = "Переулок Колсо3";
                location.variables_change[i] = "Переулок Колсо3";

                location.location_out_number = i;
                
                location.types["open air"] = 1;
            }
            if (location_number == "Переулок Колсо3")
            {
                location.name = "Переулок Колсо";
                location.info = "Переулок Колсо - \n";
                
                i++;
                location.location_out_text[i] = "Переулок Колсо, северо-восток";
                location.condition_out[i] = "Переулок Колсо2";
                location.variables_change[i] = "Переулок Колсо2";
                
                i++;
                location.location_out_text[i] = "Базар Рилана";
                location.condition_out[i] = "Базар Рилана";
                location.variables_change[i] = "Базар Рилана";
                
                location.location_out_number = i;
                
                location.types["open air"] = 1;
            }
            if (location_number == "Переулок Солко")
            {
                location.name = "Переулок Солко";
                location.info = "Переулок Солко - \n";
                
                i++;
                location.location_out_text[i] = "Базар Рилана";
                location.condition_out[i] = "Базар Рилана";
                location.variables_change[i] = "Базар Рилана";
                
                i++;
                location.location_out_text[i] = "Переулок Солко, северо-восток";
                location.condition_out[i] = "Переулок Солко2";
                location.variables_change[i] = "Переулок Солко2";

                location.location_out_number = i;
                
                location.types["open air"] = 1;
            }
            if (location_number == "Переулок Солко2")
            {
                location.name = "Переулок Солко";
                location.info = "Переулок Солко - \n";
                
                i++;
                location.location_out_text[i] = "Переулок Колсо, юго-запад";
                location.condition_out[i] = "Переулок Солко";
                location.variables_change[i] = "Переулок Солко";
                
                i++;
                location.location_out_text[i] = "Переулок Солко, северо-восток";
                location.condition_out[i] = "Переулок Солко3";
                location.variables_change[i] = "Переулок Солко3";

                location.location_out_number = i;
                
                location.types["open air"] = 1;
            }
            if (location_number == "Переулок Солко3")
            {
                location.name = "Переулок Солко";
                location.info = "Переулок Солко - \n";
                
                i++;
                location.location_out_text[i] = "Южная Эллада";
                location.condition_out[i] = "Южная Эллада4";
                location.variables_change[i] = "Южная Эллада4";
                
                i++;
                location.location_out_text[i] = "Переулок Солко, юго-запад";
                location.condition_out[i] = "Переулок Солко";
                location.variables_change[i] = "Переулок Солко";
                
                location.location_out_number = i;
                
                location.types["open air"] = 1;
            }
            if (location_number == "Порт Рилана")
            {
                location.name = "Порт Рилана";
                location.info = "Порт Рилана - крупнейший порт всего восточного побережья\n";
                
                i++;
                location.location_out_text[i] = "Улица Трех Кинжалов";
                location.condition_out[i] = "Улица Трех Кинжалов5";
                location.variables_change[i] = "Улица Трех Кинжалов5";
                
                i++;
                location.location_out_text[i] = "Улица Морозная";
                location.condition_out[i] = "Улица Морозная";
                location.variables_change[i] = "Улица Морозная";
                
                i++;
                location.location_out_text[i] = "Улица Зларис";
                location.condition_out[i] = "Улица Зларис";
                location.variables_change[i] = "Улица Зларис";
                
                i++;
                location.location_out_text[i] = "Улица Цветочная";
                location.condition_out[i] = "Улица Цветочная";
                location.variables_change[i] = "Улица Цветочная";
                
                i++;
                location.location_out_text[i] = "Ветренная Аллея";
                location.condition_out[i] = "Ветренная Аллея";
                location.variables_change[i] = "Ветренная Аллея";
                
                i++;
                location.location_out_text[i] = "Мост к Академии";
                location.condition_out[i] = "Мост к Академии";
                location.variables_change[i] = "Мост к Академии";

                location.location_out_number = i;
                
                location.types["open air"] = 1;
            }
            if (location_number == "Таверна Пьяный Дракон")
            {
                location.name = "Таверна Пьяный Дракон";
                location.info = "Даже несмотря на достаточно далекое расположение от центра города, здесь " +
                                "было полно народу.\n";
                location.location_out_number = 1;
                
                location.location_out_text[1] = "Выйти на улицу";
                location.condition_out[1] = "Улица Рыбная4";
                location.variables_change[1] = "Улица Рыбная4";
                
            }
            if (location_number == "Мост к Академии")
            {
                location.name = "Мост к Академии";
                location.info = "Красивый мост, у входа стоят 2 стражника \n";

                i++;
                location.location_out_text[i] = "Порт Рилана";
                location.condition_out[i] = "Порт Рилана";
                location.variables_change[i] = "Порт Рилана";
                
                i++;
                location.location_out_text[i] = "Мост, на восток";
                location.condition_out[i] = "Мост к Академии2";
                location.variables_change[i] = "Мост к Академии2";
                
                location.location_out_number = i;
                
                location.types["open air"] = 1;
            }
            if (location_number == "Мост к Академии2")
            {
                location.name = "Мост к Академии";
                location.info = "Мост к Академии \n";

                i++;
                location.location_out_text[i] = "Мост, на восток";
                location.condition_out[i] = "Мост к Академии3";
                location.variables_change[i] = "Мост к Академии3";
                
                i++;
                location.location_out_text[i] = "Мост, на запад";
                location.condition_out[i] = "Мост к Академии";
                location.variables_change[i] = "Мост к Академии";
                
                location.location_out_number = i;
                
                location.types["open air"] = 1;
            }
            if (location_number == "Мост к Академии3")
            {
                location.name = "Мост к Академии";
                location.info = "Мост к Академии \n";

                i++;
                location.location_out_text[i] = "Мост, на восток";
                location.condition_out[i] = "Мост к Академии4";
                location.variables_change[i] = "Мост к Академии4";
                
                i++;
                location.location_out_text[i] = "Мост, на запад";
                location.condition_out[i] = "Мост к Академии2";
                location.variables_change[i] = "Мост к Академии2";
                
                location.location_out_number = i;
                
                location.types["open air"] = 1;
            }
            if (location_number == "Мост к Академии4")
            {
                location.name = "Мост к Академии";
                location.info = "Мост к Академии \n";

                i++;
                location.location_out_text[i] = "Мост, на восток";
                location.condition_out[i] = "Мост к Академии4";
                location.variables_change[i] = "Мост к Академии4";
                
                i++;
                location.location_out_text[i] = "Мост, на запад";
                location.condition_out[i] = "Мост к Академии4";
                location.variables_change[i] = "Мост к Академии4";
                
                location.location_out_number = i;
                
                location.types["open air"] = 1;
            }
        }
        
        
    }
}