using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SouthernBug.App.Model.GUI_Items
{
    public class RadioGroup
    {
        private readonly Control container;
        private readonly List<RadioButton> items = new List<RadioButton>();

        public RadioGroup(Control container)
        {
            this.container = container;
            container.Controls.Clear();
        }

        public Func<RadioButton, bool> ChangeController { get; set; }

        public RadioButton this[int index] => items[index];

        public void AddRadioButton(RadioButton radio)
        {
            radio.AutoCheck = false;
            radio.Click += Radio_Click;

            items.Add(radio);
            container.Controls.Add(radio);
        }

        private void Radio_Click(object sender, EventArgs e)
        {
            var radio = (RadioButton) sender;

            if (radio.Checked)
                return;

            if (ChangeController == null || ChangeController(radio)) CheckRadioButton(radio);
        }

        private void CheckRadioButton(RadioButton checkedButton)
        {
            foreach (var radio in items) radio.Checked = radio == checkedButton;
        }
    }
}