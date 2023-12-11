using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KS_MapHandlerReloaded
{
    public partial class Form2 : MetroFramework.Forms.MetroForm
    {
        public Form2()
        {
            InitializeComponent();
            metroTextBox1.ButtonClick += MetroTextBox1_ButtonClick;
        }

        private void MetroTextBox1_ButtonClick(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                Properties.Settings.Default.UserPath = dialog.SelectedPath + "\\";
                Debug.WriteLine(Properties.Settings.Default.UserPath);
                Properties.Settings.Default.Save();
                this.Close();
            }
            else
            {
                MessageBox.Show("Invalid folder..", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }
    }
}
