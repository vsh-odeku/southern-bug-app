using System.Windows.Forms;

namespace SouthernBug.App.Model.GUI_Items.Repr
{
    public class YearItemsRepr : ItemsRepr
    {
        public YearItemsRepr(ComboBox comboBox) : base(comboBox)
        {
        }

        protected override void FillModel()
        {
            for (var i = 2000; i <= 2099; i++)
            {
                var value = i.ToString();
                model.Add(value, value);
            }
        }
    }
}