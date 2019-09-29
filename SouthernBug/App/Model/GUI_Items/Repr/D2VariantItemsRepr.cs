using System.Text;
using System.Windows.Forms;

namespace SouthernBug.App.Model.GUI_Items.Repr
{
    internal class D2VariantItemsRepr : ItemsRepr
    {
        public const string Var1DateSm = "Var1DateSm";
        public const string Var1DateSm_Name = "У дату максимальних снігозапасів Sm";

        public const string Var2DateDb = "Var2DateDb";
        public const string Var2DateDb_Name = "У дату початку водопілля DB";

        public D2VariantItemsRepr(ComboBox comboBox) : base(comboBox)
        {
        }

        protected override void FillModel()
        {
            model.Add(Var1DateSm_Name, Var1DateSm);
            model.Add(Var2DateDb_Name, Var2DateDb);
        }
    }
}