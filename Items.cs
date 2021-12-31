using System.Collections.Generic;

namespace Project56
{
    public class Items
    {
        public class item
        {
            public string name;
            public string info;
            public int price;
            public int weight;
            public List<string> types;
        }

        public item get_item(string item_name)
        {
            item item = new item();
            if (item_name == "Золото")
            {
                item.name = "Золото";
                item.info = "Золотые монеты, принимают во всех уголках мира.";
                item.price = 1;
                item.weight = 1;
                item.types.Add("Драгоценность");
            }

            return item;
        }
        /*
         * Старинный меч
         * *описание*
         * Прочность - 100
         * Стоимость - 50 золота
         * Типы - Оружие - ближний бой
         *
         * Книга "Искра"
         * *описание*
         * Прочность - 100
         * Стоимость - 1000 золота
         * Типы - Предмет - книга
         */
    }
}