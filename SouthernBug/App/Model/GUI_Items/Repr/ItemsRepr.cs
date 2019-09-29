using System;
using System.Collections.Specialized;
using System.Windows.Forms;

namespace SouthernBug.App.Model.GUI_Items.Repr
{
    public abstract class ItemsRepr
    {
        private readonly ComboBox comboBox;
        protected readonly object Data;

        protected OrderedDictionary model = new OrderedDictionary();

        protected ItemsRepr(ComboBox comboBox, object data = null)
        {
            this.comboBox = comboBox;
            Data = data;
            comboBox.DropDownStyle = ComboBoxStyle.DropDownList;

            FillModel();
            InitComboBox();
            SubscribeEvents();
        }

        public string SelectedValue => (string) model[comboBox.SelectedIndex];

        public event Action<ItemsRepr> SelectedItemChanged = delegate { };

        protected abstract void FillModel();

        private void InitComboBox()
        {
            AddItemsToComboBox();
            SetFirstItemSelected();
        }

        private void AddItemsToComboBox()
        {
            foreach (string key in model.Keys) comboBox.Items.Add(key);
        }

        private void SetFirstItemSelected()
        {
            if (model.Count > 0) comboBox.SelectedIndex = 0;
        }

        private void SubscribeEvents()
        {
            comboBox.SelectedIndexChanged += (sender, e) => SelectedItemChanged(this);
        }
    }
}