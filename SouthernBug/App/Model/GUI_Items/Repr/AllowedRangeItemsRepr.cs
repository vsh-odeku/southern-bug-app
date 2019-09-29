using System.Windows.Forms;

namespace SouthernBug.App.Model.GUI_Items.Repr
{
    internal class AllowedRangeItemsRepr : ItemsRepr
    {
        public const string Standard = "Standard";
        public const string Percent10 = "Percent10";
        public const string Percent20 = "Percent20";

        public AllowedRangeItemsRepr(ComboBox comboBox) : base(comboBox)
        {
        }

        protected override void FillModel()
        {
            model.Add("В 10%-му діапазоні", Percent10);
            model.Add("В 20%-му діапазоні", Percent20);
            model.Add("В 25%-му діапазоні", Standard);
        }
    }
}