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
        private const int WINDOW_WIDTH = 610;

        private const string TITLE_MODE_D1 = "Вибір декади для температури повітря";
        private const string TITLE_MODE_D2 = "Вибір дати випуску прогнозу дати проходження максимальних витрат (рівнів) води Qm";

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
            switch (mode) {
                case Mode.D1:
                    InitD1Mode();
                    break;
                case Mode.D2:
                    InitD2Mode();
                    break;
                default:
                    throw new Exception("Unknown mode: " + mode);
            }
        }

        private void InitD1Mode()
        {
            Size = new Size(WINDOW_WIDTH, 230);
            Text = labelTitle.Text = TITLE_MODE_D1;
            kdItemsRepr = new DecadeItemsRepr(KdComboBox,
                "Визначення декади от дати Sm+1 декада");
            kddItemsRepr = new DecadeItemsRepr(KddComboBox, "???");
            groupBoxKD.Text = "Вибір декади, що настає за датою Sm";
            groupBoxKD.SetBounds(48, 56, 536, 84);
            groupBoxKDD.Visible = false;
            D2VariantComboBox.Visible = false;
        }

        private void InitD2Mode()
        {
            Text = labelTitle.Text = TITLE_MODE_D2;
            kdItemsRepr = new DecadeItemsRepr(KdComboBox,
                "Визначення декади від дати максимальних снігозапасів Sm+1 декада");
            kddItemsRepr = new DecadeItemsRepr(KddComboBox,
                "Визначення декади від дати початку водопілля DB +1 декада");
            groupBoxKD.Text = "Вибір декади, що настає за датою максимальних снігозапасів Sm";
            groupBoxKDD.Text = "Вибір декади, що настає за датою початку водопілля DB";
        }

        private void InitUi()
        {
            d2VariantItemsRepr = new D2VariantItemsRepr(D2VariantComboBox);
            d2VariantItemsRepr.SelectedItemChanged += UpdateD2Variant;
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