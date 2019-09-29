using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SouthernBug.App.Model
{
    public class Decade
    {
        public int Month { get; }
        public int Number { get; }

        private static readonly Decade MinDecade = new Decade(1, 1);
        private static readonly Decade MaxDecade = new Decade(4, 3);
        private static readonly int[] AllowedNumbers = {1, 2, 3};

        private Decade(int month, int number)
        {
            this.Month = month;
            this.Number = number;
        }

        public Decade Next()
        {
            switch (Number)
            {
                case 1:
                case 2:
                    return From(Month, Number + 1);
                case 3:
                    return From(Month + 1, 1);
                default:
                    throw new Exception("Декада сломалась");
            }
        }

        public override string ToString()
        {
            return $"T{Month}{Number}";
        }

        public static Decade From(int month, int number)
        {
            if (month > MaxDecade.Month)
            {
                return MaxDecade;
            }
            else if (month < MinDecade.Month)
            {
                return MinDecade;
            }

            if (!AllowedNumbers.Contains(number))
            {
                throw new Exception("Неправильный формат декады");
            }

            return  new Decade(month, number);
        }

        public static Decade From(DateTime dateTime)
        {
            var decadeN = (dateTime.Day - 1) / 10 + 1;
            if (decadeN > 3) decadeN = 3;

            return From(dateTime.Month, decadeN);
        }
    }
}
