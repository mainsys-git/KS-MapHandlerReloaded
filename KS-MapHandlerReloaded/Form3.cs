using MetroFramework.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KS_MapHandlerReloaded
{
    public partial class Form3 : MetroFramework.Forms.MetroForm
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            ShowCredits();
        }

        private void ShowCredits(string projectName = "KS Map Handler")
        {
            MetroTextBox textBox = new MetroTextBox();
            textBox.Theme = MetroFramework.MetroThemeStyle.Dark;
            textBox.Style = MetroFramework.MetroColorStyle.Purple;
            textBox.ForeColor = Color.White;
            textBox.Multiline = true;
            textBox.ReadOnly = true;
            textBox.ScrollBars = ScrollBars.Vertical;
            textBox.Dock = DockStyle.Fill;

            textBox.Text += $"Credits for {projectName}:\r\n";
            textBox.Text += "Developed by: Mainsys + Glappk\r\n";

            Controls.Add(textBox);
        }

    }
}
