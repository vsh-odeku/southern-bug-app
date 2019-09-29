using System.Windows.Forms;

namespace SouthernBug.App.Model.GUI_Items.Repr
{
    public class NormItemsRepr : ItemsRepr
    {
        public const string AboveNorm = "AboveNorm";
        public const string NearNorm = "NearNorm";
        public const string BelowNorm = "BelowNorm";

        public NormItemsRepr(ComboBox comboBox) : base(comboBox)
        {
        }

        protected override void FillModel()
        {
            model.Add("Очікуються близько норми", NearNorm);
            model.Add("Очікуються вище норми", AboveNorm);
            model.Add("Очікуються нижче норми", BelowNorm);
        }
    }
}