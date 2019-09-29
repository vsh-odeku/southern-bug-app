using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SouthernBug.App.Model.GUI_Items.Repr
{
    public class DayAndMonthItemsRepr : ItemsRepr
    {
        public const string Sm = "Sm";
        private readonly int[] Days28 = {5, 10, 15, 20, 25, 28};

        private readonly int[] Days31 = {5, 10, 15, 20, 25, 31};

        public DayAndMonthItemsRepr(ComboBox comboBox) : base(comboBox)
        {
        }

        public static string CreateDayMonth(int dayNumber, int monthNumber)
        {
            return WithZero(dayNumber) + "_" + WithZero(monthNumber);
        }

        protected override void FillModel()
        {
            GenerateMonth(1, "січня", Days31);
            GenerateMonth(2, "лютого", Days28);
            GenerateMonth(3, "березня", Days31);
            GenerateMonth(4, "квітня", 5, 10);

            model.Add("максимальні снігозапаси води в сніговому покриві Sm", Sm);
        }

        private void GenerateMonth(int monthNumber, string monthPostfix, params int[] days)
        {
            foreach (var dayNumber in days)
            {
                var key = dayNumber + " " + monthPostfix;
                var value = CreateDayMonth(dayNumber, monthNumber);

                model.Add(key, value);
            }
        }

        private static string WithZero(int number)
        {
            var str = number.ToString();
            return WithZero(str);
        }

        private static string WithZero(string str)
        {
            if (str.Length == 1) str = "0" + str;
            return str;
        }

        public static string QMM_to_MM(string QMM)
        {
            return QMM.Substring(1);
        }

        public static string DD_MM_to_LDD_MM(string DD_MM)
        {
            var dict = new Dictionary<string, string>
            {
                {"05_01", "L31_12"},
                {"10_01", "L10_01"},
                {"15_01", "L10_01"},
                {"20_01", "L20_01"},
                {"25_01", "L20_01"},
                {"31_01", "L31_01"},

                {"05_02", "L31_01"},
                {"10_02", "L10_02"},
                {"15_02", "L10_02"},
                {"20_02", "L20_02"},
                {"25_02", "L20_02"},
                {"28_02", "L28_02"},

                {"05_03", "L28_02"},
                {"10_03", "L10_03"},
                {"15_03", "L10_03"},
                {"20_03", "L20_03"},
                {"25_03", "L20_03"},
                {"31_03", "L31_03"},

                {"05_04", "L31_03"},
                {"10_04", "L10_04"}
            };

            return dict[DD_MM];
        }

        public static int DD_MM_to_D(string DD_MM)
        {
            var dict = new Dictionary<string, int>
            {
                {"05_01", -26},
                {"10_01", -21},
                {"15_01", -16},
                {"20_01", -11},
                {"25_01", -6},
                {"31_01", 0},

                {"05_02", 5},
                {"10_02", 10},
                {"15_02", 15},
                {"20_02", 20},
                {"25_02", 25},
                {"28_02", 28},

                {"05_03", 33},
                {"10_03", 38},
                {"15_03", 43},
                {"20_03", 48},
                {"25_03", 53},
                {"31_03", 59},

                {"05_04", 64},
                {"10_04", 69}
            };

            return dict[DD_MM];
        }
    }
}