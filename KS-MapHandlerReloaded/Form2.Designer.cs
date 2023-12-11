namespace KS_MapHandlerReloaded
{
    partial class Form2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tbPath = new MetroFramework.Controls.MetroTextBox();
            this.SuspendLayout();
            // 
            // tbPath
            // 
            // 
            // 
            // 
            this.tbPath.CustomButton.Image = null;
            this.tbPath.CustomButton.Location = new System.Drawing.Point(250, 1);
            this.tbPath.CustomButton.Name = "";
            this.tbPath.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.tbPath.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.tbPath.CustomButton.TabIndex = 1;
            this.tbPath.CustomButton.Text = "...";
            this.tbPath.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.tbPath.CustomButton.UseSelectable = true;
            this.tbPath.Lines = new string[0];
            this.tbPath.Location = new System.Drawing.Point(24, 64);
            this.tbPath.MaxLength = 32767;
            this.tbPath.Name = "tbPath";
            this.tbPath.PasswordChar = '\0';
            this.tbPath.PromptText = "Path";
            this.tbPath.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.tbPath.SelectedText = "";
            this.tbPath.SelectionLength = 0;
            this.tbPath.SelectionStart = 0;
            this.tbPath.ShortcutsEnabled = true;
            this.tbPath.ShowButton = true;
            this.tbPath.Size = new System.Drawing.Size(272, 23);
            this.tbPath.Style = MetroFramework.MetroColorStyle.Purple;
            this.tbPath.TabIndex = 0;
            this.tbPath.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.tbPath.UseSelectable = true;
            this.tbPath.UseStyleColors = true;
            this.tbPath.WaterMark = "Path";
            this.tbPath.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.tbPath.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(319, 118);
            this.Controls.Add(this.tbPath);
            this.Name = "Form2";
            this.Resizable = false;
            this.ShadowType = MetroFramework.Forms.MetroFormShadowType.AeroShadow;
            this.Style = MetroFramework.MetroColorStyle.Purple;
            this.Text = "Choose";
            this.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.Load += new System.EventHandler(this.Form2_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Controls.MetroTextBox tbPath;
    }
}