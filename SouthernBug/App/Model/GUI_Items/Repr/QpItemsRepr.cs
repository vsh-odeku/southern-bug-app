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
            model.Add("Влажность почвы W 0-100", Wj);
            model.Add("Декабрь", Q12);
            model.Add("Январь", Q01);
            model.Add("Февраль", Q02);
            model.Add("Март", Q03);
            model.Add("Перед половодьем", QPB);
        }
    }
}