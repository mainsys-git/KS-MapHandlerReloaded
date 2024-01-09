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
            this.cblMaps.SelectedIndexChanged += this.cblMaps_SelectedIndexChanged;
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

            if (this.cblMaps.Items.Count >= 0)
            {
                this.cblMaps.Items.Clear();
            }
            for (int i = 0; i < this.myMaps.Length; i++)
            {
                this.mapName = Path.GetFileName(this.myMaps[i].ToString());
                this.cblMaps.Items.Add(this.mapName);
                this.CheckMap(this.mapName, i);
            }
        }

        private void CheckMap(string _mapname, int i)
        {
            if (_mapname.StartsWith("0_"))
            {
                string item = _mapname.Remove(0, 2);
                this.cblMaps.Items.RemoveAt(i);
                this.cblMaps.Items.Add(item);
                this.cblMaps.SetSelected(i, true);
                this.cblMaps.SetItemChecked(i, true);
            }
        }

        private void RenameMap(string oldName, string newName)
        {
            string oldKspPath = this.bundlePath + oldName;
            string newKspPath = this.bundlePath + newName;
            if (File.Exists(oldKspPath))
            {
                File.Move(oldKspPath, newKspPath);
            }

            string oldJpgName = Path.ChangeExtension(oldName, ".jpg");
            string newJpgName = Path.ChangeExtension(newName, ".jpg");
            string oldJpgPath = this.bundlePath + oldJpgName;
            string newJpgPath = this.bundlePath + newJpgName;

            if (File.Exists(oldJpgPath))
            {
                File.Move(oldJpgPath, newJpgPath);
            }
        }


        private void cblMaps_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cblMaps.CheckedItems.Count > 0)
            {
                this.cblMaps.SetItemChecked(this.cblMaps.CheckedIndices[0], false);
            }
            this.previewSelected();
        }

        private void previewSelected()
        {
            string selectedMapName = this.cblMaps.SelectedItem.ToString();

            string jpgName = selectedMapName.StartsWith("0_") ? selectedMapName.Remove(0, 2) : selectedMapName;
            string imagePath = Path.ChangeExtension(this.bundlePath + jpgName, ".jpg");

            if (!File.Exists(imagePath))
            {
                imagePath = Path.ChangeExtension(this.bundlePath + "0_" + jpgName, ".jpg");
            }

            this.showMapName.Text = jpgName;
            this.mapPreview.ImageLocation = imagePath;
        }

        private void lblSetPath_Clicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form2 f = new Form2();
            f.ShowDialog();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (0 < cblMaps.Items.Count && 0 >= 0)
            {
                cblMaps.SelectedIndex = 0;
                previewSelected();
            }

            return;
        }

        private void lblCredits_Clicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form3 f = new Form3();
            f.ShowDialog();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < this.myMaps.Length; i++)
            {
                this.mapName = Path.GetFileName(this.myMaps[i].ToString());
                if (this.mapName.StartsWith("0_"))
                {
                    this.RenameMap(this.mapName, this.mapName.Remove(0, 2));
                }
            }
            if (this.cblMaps.CheckedItems.Count > 0)
            {
                this.mapName = this.cblMaps.SelectedItem.ToString();
                string newName = this.mapName.Insert(0, "0_");
                this.RenameMap(this.mapName, newName);
            }
            this.statusLabel.Text = this.mapName + " is now active.";
            this.GetMaps();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            SetPath();
            this.GetMaps();
            this.statusLabel.Text = "Maplist updated.";
        }
    }
}
