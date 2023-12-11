using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KS_MapHandlerReloaded
{
    public partial class Form1 : MetroFramework.Forms.MetroForm
    {
        private string bundlePath = Properties.Settings.Default.UserPath;
        private string[] myMaps {  get; set; }
        private string mapName {  get; set; }
        public Form1()
        {
            InitializeComponent();
            SetPath();
            GetMaps();
            this.checkedListBox1.SelectedIndexChanged += this.checkedListBox1_SelectedIndexChanged;
            this.MaximizeBox = false;
        }

        private void SetPath()
        {
            if (Properties.Settings.Default.StartetFirstTime)
            {
                Properties.Settings.Default.UserPath = $"C:\\Users\\{Environment.UserName}\\Documents\\Kingspray Graffiti\\Bundles\\";
                Properties.Settings.Default.StartetFirstTime = false;
                Properties.Settings.Default.Save();
            }
            else
            {
                bundlePath = Properties.Settings.Default.UserPath;
            }
            this.statusLabel.Text = "Ready.";
        }

        private void GetMaps()
        {
            this.myMaps = Directory.GetFiles(this.bundlePath, "*.ksp");

            if (this.checkedListBox1.Items.Count >= 0)
            {
                this.checkedListBox1.Items.Clear();
            }
            for (int i = 0; i < this.myMaps.Length; i++)
            {
                this.mapName = Path.GetFileName(this.myMaps[i].ToString());
                this.checkedListBox1.Items.Add(this.mapName);
                this.CheckMap(this.mapName, i);
            }
        }

        private void CheckMap(string _mapname, int i)
        {
            if (_mapname.StartsWith("0_"))
            {
                string item = _mapname.Remove(0, 2);
                this.checkedListBox1.Items.RemoveAt(i);
                this.checkedListBox1.Items.Add(item);
                this.checkedListBox1.SetSelected(i, true);
                this.checkedListBox1.SetItemChecked(i, true);
            }
        }

        private void RenameMap(string oldName, string newName)
        {
            File.Move(this.bundlePath + oldName, this.bundlePath + newName);
        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.checkedListBox1.CheckedItems.Count > 0)
            {
                this.checkedListBox1.SetItemChecked(this.checkedListBox1.CheckedIndices[0], false);
            }
            this.previewSelected();
        }

        private void previewSelected()
        {
            this.showMapName.Text = this.checkedListBox1.SelectedItem.ToString();
            this.mapPreview.ImageLocation = Path.ChangeExtension(this.bundlePath + this.checkedListBox1.SelectedItem.ToString(), ".jpg");
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form2 f = new Form2();
            f.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (0 < checkedListBox1.Items.Count && 0 >= 0)
            {
                checkedListBox1.SelectedIndex = 0;
                previewSelected();
            }

            return;
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form3 f = new Form3();
            f.ShowDialog();
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < this.myMaps.Length; i++)
            {
                this.mapName = Path.GetFileName(this.myMaps[i].ToString());
                if (this.mapName.StartsWith("0_"))
                {
                    this.RenameMap(this.mapName, this.mapName.Remove(0, 2));
                }
            }
            if (this.checkedListBox1.CheckedItems.Count > 0)
            {
                this.mapName = this.checkedListBox1.SelectedItem.ToString();
                string newName = this.mapName.Insert(0, "0_");
                this.RenameMap(this.mapName, newName);
            }
            this.statusLabel.Text = this.mapName + " is now active.";
            this.GetMaps();
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            SetPath();
            this.GetMaps();
            this.statusLabel.Text = "Maplist updated.";
        }
    }
}
