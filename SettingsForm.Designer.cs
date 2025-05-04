namespace PairGameKeyboard
{
    partial class SettingsForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.ComboBox comboBoxSize;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Label label;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.comboBoxSize = new System.Windows.Forms.ComboBox();
            this.buttonOK = new System.Windows.Forms.Button();
            this.label = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label
            // 
            this.label.Text = "Виберіть розмір поля:";
            this.label.Location = new System.Drawing.Point(12, 15);
            this.label.Size = new System.Drawing.Size(120, 23);
            // 
            // comboBoxSize
            // 
            this.comboBoxSize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxSize.Location = new System.Drawing.Point(138, 12);
            this.comboBoxSize.Size = new System.Drawing.Size(100, 24);
            // 
            // buttonOK
            // 
            this.buttonOK.Text = "Грати";
            this.buttonOK.Location = new System.Drawing.Point(80, 50);
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // SettingsForm
            // 
            this.ClientSize = new System.Drawing.Size(260, 90);
            this.Controls.Add(this.comboBoxSize);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.label);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Name = "SettingsForm";
            this.Text = "Налаштування гри";
            this.ResumeLayout(false);
        }
    }
}
