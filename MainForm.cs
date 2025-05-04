using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PairGameKeyboard
{
    public partial class MainForm : Form
    {
        private int rows, cols;
        private Button firstBtn = null;
        private bool busy = false;
        private Random rnd = new Random();
        private int currentRow = 0, currentCol = 0;

        public MainForm(int rows, int cols)
        {
            this.rows = rows;
            this.cols = cols;
            InitializeComponent();
            this.KeyPreview = true;
            this.KeyDown += MainForm_KeyDown;
            StartGame();
            FocusCell(0, 0);
        }

        private void StartGame()
        {
            var colors = new List<Color>();
            for (int i = 0; i < (rows * cols) / 2; i++)
            {
                Color c = Color.FromArgb(rnd.Next(256), rnd.Next(256), rnd.Next(256));
                colors.Add(c);
                colors.Add(c);
            }
            colors = colors.OrderBy(x => rnd.Next()).ToList();

            tableLayoutPanel1.Controls.Clear();
            tableLayoutPanel1.RowCount = rows;
            tableLayoutPanel1.ColumnCount = cols;
            tableLayoutPanel1.ColumnStyles.Clear();
            tableLayoutPanel1.RowStyles.Clear();
            for (int i = 0; i < cols; i++) tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f / cols));
            for (int i = 0; i < rows; i++) tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100f / rows));

            int idx = 0;
            for (int r = 0; r < rows; r++)
            {
                for (int c = 0; c < cols; c++)
                {
                    var btn = new Button
                    {
                        Dock = DockStyle.Fill,
                        BackColor = Color.Gray,
                        Tag = colors[idx++],
                        FlatStyle = FlatStyle.Flat,
                        TabStop = false
                    };
                    btn.Click += (s, e) => HandleClick(s as Button);
                    btn.Margin = new Padding(1);
                    tableLayoutPanel1.Controls.Add(btn, c, r);
                }
            }
        }

        private async void HandleClick(Button btn)
        {
            if (busy || btn == null || btn.BackColor != Color.Gray) return;
            btn.BackColor = (Color)btn.Tag;
            if (firstBtn == null)
            {
                firstBtn = btn;
            }
            else
            {
                busy = true;
                await Task.Delay(500);
                if (btn.Tag.Equals(firstBtn.Tag))
                {
                    btn.Enabled = firstBtn.Enabled = false;
                }
                else
                {
                    btn.BackColor = firstBtn.BackColor = Color.Gray;
                }
                firstBtn = null;
                busy = false;
                if (tableLayoutPanel1.Controls.Cast<Button>().All(b => !b.Enabled))
                {
                    MessageBox.Show("Ви перемогли!", "Гра завершена");
                    StartGame();
                    currentRow = currentCol = 0;
                }
            }
        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Space)
            {
                HandleClick(GetButton(currentRow, currentCol));
                return;
            }
            switch (e.KeyCode)
            {
                case Keys.Up: currentRow = Math.Max(0, currentRow - 1); break;
                case Keys.Down: currentRow = Math.Min(rows - 1, currentRow + 1); break;
                case Keys.Left: currentCol = Math.Max(0, currentCol - 1); break;
                case Keys.Right: currentCol = Math.Min(cols - 1, currentCol + 1); break;
                default: return;
            }
            FocusCell(currentRow, currentCol);
        }

        private void FocusCell(int r, int c) => GetButton(r, c)?.Focus();

        private Button GetButton(int r, int c) => tableLayoutPanel1.GetControlFromPosition(c, r) as Button;
    }
}
