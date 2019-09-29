using System;
using System.Drawing;
using System.Windows.Forms;
using SouthernBug.App.Model.GUI_Items.Repr;

namespace SouthernBug.App.Window.Calculations
{
    public partial class CalculationExtraArgsForm : Form
    {
        public enum Mode
        {
            D1,
            D2
        }

        private const int WINDOW_HEIGHT = 270;

        private const int WINDOW_WIDTH_MODE_D1 = 340;
        private const int WINDOW_WIDTH_MODE_D2 = 645;

        private DecadeItemsRepr kddItemsRepr;
        private DecadeItemsRepr kdItemsRepr;
        private D2VariantItemsRepr d2VariantItemsRepr;

        public CalculationExtraArgsForm(Mode mode)
        {
            InitializeComponent();
            InitMode(mode);
            InitUi();
        }

        public bool ResultUserPressedOk { get; private set; }

        public string ResultD2Variant { get; private set; }

        public string ResultKd { get; private set; }
        public string ResultKdd { get; private set; }

        private void InitMode(Mode mode)
        {
            var width = mode == Mode.D1
                ? WINDOW_WIDTH_MODE_D1
                : WINDOW_WIDTH_MODE_D2;

            D2VariantComboBox.Visible = mode == Mode.D2;

            Size = new Size(width, WINDOW_HEIGHT);
        }

        private void InitUi()
        {
            d2VariantItemsRepr = new D2VariantItemsRepr(D2VariantComboBox);
            d2VariantItemsRepr.SelectedItemChanged += UpdateD2Variant;

            kdItemsRepr = new DecadeItemsRepr(KdComboBox, "Декада Sm+1");
            kddItemsRepr = new DecadeItemsRepr(KddComboBox, "Декада DB+1");

            UpdateD2Variant(d2VariantItemsRepr);
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            ResultUserPressedOk = true;

            ResultD2Variant = d2VariantItemsRepr.SelectedValue;

            ResultKd = kdItemsRepr.SelectedValue;
            ResultKdd = kddItemsRepr.SelectedValue;

            Close();
        }

        private void UpdateD2Variant(ItemsRepr repr)
        {
            bool leftGroupEnabled = repr.SelectedValue == D2VariantItemsRepr.Var1DateSm;

            groupBoxKD.Enabled = leftGroupEnabled;
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            ResultUserPressedOk = false;
            Close();
        }
    }
}