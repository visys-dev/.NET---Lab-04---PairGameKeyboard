using System;
using System.Windows.Forms;

namespace PairGameKeyboard
{
    public partial class SettingsForm : Form
    {
        public int Rows { get; private set; }
        public int Cols { get; private set; }

        public SettingsForm()
        {
            InitializeComponent();
            comboBoxSize.Items.AddRange(new object[] { "4x4", "6x6", "8x8" });
            comboBoxSize.SelectedIndex = 0;
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            var parts = comboBoxSize.SelectedItem.ToString().Split('x');
            Rows = int.Parse(parts[0]);
            Cols = int.Parse(parts[1]);
            if ((Rows * Cols) % 2 != 0)
            {
                MessageBox.Show("Кількість клітинок має бути парною!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
