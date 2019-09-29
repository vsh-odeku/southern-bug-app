using System;
using System.Windows.Forms;

namespace SouthernBug.App.Model.GUI_Items.Controller
{
    public class ComboBoxController
    {
        private readonly Func<ComboBox, bool> changeController;
        private readonly ComboBox comboBox;
        private int prevIndex;

        public ComboBoxController(ComboBox comboBox, Func<ComboBox, bool> changeController)
        {
            this.comboBox = comboBox;
            this.changeController = changeController;

            Initialize();
        }

        private void Initialize()
        {
            comboBox.DropDownStyle = ComboBoxStyle.DropDownList;

            comboBox.Enter += Event_Enter;
            comboBox.SelectionChangeCommitted += Event_SelectionChangeCommitted;
            comboBox.MouseWheel += PreventComboboxMouseWheel;
        }

        private void Event_Enter(object sender, EventArgs e)
        {
            prevIndex = comboBox.SelectedIndex;
        }

        private void Event_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (!changeController(comboBox)) comboBox.SelectedIndex = prevIndex;
        }

        void PreventComboboxMouseWheel(object sender, MouseEventArgs e)
        {
           ((HandledMouseEventArgs)e).Handled = true;
        }
    }
}