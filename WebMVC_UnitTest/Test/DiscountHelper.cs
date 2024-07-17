using System;

namespace WebMVC_UnitTest.Test
{
    public class DiscountHelper : IDiscountHelper
    {
        public DiscountHelper()
        {
        }

        // цена больше 1000 -> 10%
        // цена от 100 до 1000 -> 5%
        // цена меньше 100 -> 0
        // цена меньше 0 -> ошибка
        public decimal Dicsount(decimal price)
        {
            if (price < 0)
            {
                throw new ArgumentOutOfRangeException();
            }
            else if (price > 1000)
            {
                return price * 0.9m;
            }
            else if (price >= 100)
            {
                return price * 0.95m;
            }
            return price;
        }
    }
}