using System.Text;
using System.Windows.Forms;

namespace SouthernBug.App.Model.GUI_Items.Repr
{
    internal class DecadeItemsRepr : ItemsRepr
    {
        public static readonly string[] MonthNames =
        {
            "нулября", "января", "февраля", "марта", "апреля"
        };

        public const string OptCalc = "OptCalc";

        public DecadeItemsRepr(ComboBox comboBox, string calcOptName)
            : base(comboBox, calcOptName)
        {
        }

        protected override void FillModel()
        {
            for (var month = 1; month <= 4; month++)
            for (var decade = 1; decade <= 3; decade++)
                model.Add(CreateDecadeValue(month, decade),
                    CreateDecadeName(month, decade));

            var calcOptName = (string)Data;
            model.Add($"Рассчитать {calcOptName}", OptCalc);
        }

        private string CreateDecadeName(int month, int decade)
        {
            var sb = new StringBuilder();
            sb.Append('T').Append(month).Append(decade);

            return sb.ToString();
        }

        private string CreateDecadeValue(int month, int decade)
        {
            var sb = new StringBuilder();
            for (var i = 0; i < decade; i++) sb.Append('I');
            sb.Append(" декада ").Append(MonthNames[month]);

            return sb.ToString();
        }
    }
}