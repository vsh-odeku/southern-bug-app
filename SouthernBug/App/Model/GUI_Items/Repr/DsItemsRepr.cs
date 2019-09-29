using System.Windows.Forms;

namespace SouthernBug.App.Model.GUI_Items.Repr
{
    public class DsItemsRepr : ItemsRepr
    {
        public const string CalcDs = "CalcDs";
        public const string TakeDs = "TakeDs";

        public DsItemsRepr(ComboBox comboBox) : base(comboBox)
        {
        }

        protected override void FillModel()
        {
            model.Add("Розрахувати dS", CalcDs);
            model.Add("Прийняти dS із таблиці OPER_INFO_HYDRO", TakeDs);
        }
    }
}