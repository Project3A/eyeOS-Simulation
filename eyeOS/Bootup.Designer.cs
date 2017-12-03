namespace eyeOS
{
    partial class Bootup
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Bootup));
            this.axWindowsMediaPlayer1 = new AxWMPLib.AxWindowsMediaPlayer();
            this.pageSetupDialog1 = new System.Windows.Forms.PageSetupDialog();
            this.checker = new System.Windows.Forms.Timer(this.components);
            this.biosLoader = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.axWindowsMediaPlayer1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.biosLoader)).BeginInit();
            this.SuspendLayout();
            // 
            // axWindowsMediaPlayer1
            // 
            this.axWindowsMediaPlayer1.Enabled = true;
            this.axWindowsMediaPlayer1.Location = new System.Drawing.Point(12, 2);
            this.axWindowsMediaPlayer1.Name = "axWindowsMediaPlayer1";
            this.axWindowsMediaPlayer1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axWindowsMediaPlayer1.OcxState")));
            this.axWindowsMediaPlayer1.Size = new System.Drawing.Size(655, 319);
            this.axWindowsMediaPlayer1.TabIndex = 1;
            // 
            // checker
            // 
            this.checker.Enabled = true;
            this.checker.Interval = 1000;
            this.checker.Tick += new System.EventHandler(this.checker_Tick);
            // 
            // biosLoader
            // 
            this.biosLoader.Image = global::eyeOS.Properties.Resources.bios;
            this.biosLoader.Location = new System.Drawing.Point(245, 66);
            this.biosLoader.Name = "biosLoader";
            this.biosLoader.Size = new System.Drawing.Size(13, 13);
            this.biosLoader.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.biosLoader.TabIndex = 2;
            this.biosLoader.TabStop = false;
            // 
            // Bootup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(747, 372);
            this.Controls.Add(this.biosLoader);
            this.Controls.Add(this.axWindowsMediaPlayer1);
            this.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Bootup";
            this.Text = "Bootup";
            this.TransparencyKey = System.Drawing.Color.Transparent;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.axWindowsMediaPlayer1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.biosLoader)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private AxWMPLib.AxWindowsMediaPlayer axWindowsMediaPlayer1;
        private System.Windows.Forms.PageSetupDialog pageSetupDialog1;
        private System.Windows.Forms.Timer checker;
        private System.Windows.Forms.PictureBox biosLoader;
    }
}