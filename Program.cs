using System;
using System.Windows.Forms;

namespace PairGameKeyboard
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            using (var settings = new SettingsForm())
            {
                if (settings.ShowDialog() == DialogResult.OK)
                {
                    Application.Run(new MainForm(settings.Rows, settings.Cols));
                }
            }
        }
    }
}
