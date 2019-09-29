using System.Windows.Forms;

namespace SouthernBug.App.Model.GUI_Items.Repr
{
    public class QpItemsRepr : ItemsRepr
    {
        public const string Wj = "Wj";
        public const string Q12 = "Q12";
        public const string Q01 = "Q01";
        public const string Q02 = "Q02";
        public const string Q03 = "Q03";
        public const string QPB = "QPB";

        public QpItemsRepr(ComboBox comboBox) : base(comboBox)
        {
        }

        protected override void FillModel()
        {
            model.Add("запаси вологи в ґрунті W 0-100 см перед водопіллям", Wj);
            model.Add("середня витрата води в грудні", Q12);
            model.Add("середня витрата води в січні", Q01);
            model.Add("середня витрата води в лютому", Q02);
            model.Add("середня витрата води в березні", Q03);
            model.Add("витрата води перед початком водопілля", QPB);
        }
    }
}