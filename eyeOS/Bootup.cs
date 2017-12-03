using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eyeOS
{
    
    public partial class Bootup : Form
    {
        private int timer = 0;
        public Bootup()
        {
            InitializeComponent();
            
            biosLoader.Size = this.Size;
            biosLoader.Location = this.Location;
            biosLoader.Show();
            



        }

        private void checker_Tick(object sender, EventArgs e)
        {
            timer++;
            if(timer == 3)
            {
                biosLoader.Hide();
                playLoadingScreen();
            }
            if (axWindowsMediaPlayer1.playState == WMPLib.WMPPlayState.wmppsStopped)
            {
                checker.Enabled = false;
                bootup_form boot = new bootup_form();
                boot.ShowDialog();
                this.Close();
            }
        }

        private void playLoadingScreen()
        {
            string RunningPath = AppDomain.CurrentDomain.BaseDirectory;
            string FileName = string.Format("{0}Resources\\INTRO.mp4", System.IO.Path.GetFullPath(System.IO.Path.Combine(RunningPath, @"..\..\")));
            this.axWindowsMediaPlayer1.uiMode = "none";
            this.axWindowsMediaPlayer1.Size = this.Size;
            this.axWindowsMediaPlayer1.Location = this.Location;
            this.axWindowsMediaPlayer1.settings.setMode("loop", false);
            this.axWindowsMediaPlayer1.URL = FileName;
        }
    }
}
