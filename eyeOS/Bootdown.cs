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

namespace eyeOS
{
    public partial class Bootdown : Form
    {
        private int timer = 0;
        private string textDisplay = "";

        public Bootdown(string textDisplay)
        {
            InitializeComponent();
            timer = 0;
            this.textDisplay = textDisplay;
            label1.Text = this.textDisplay;
        }

        private void Bootdown_Load(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.Hide();
            label1.Left = (this.Width / 2) - (label1.Width / 2);
            label1.Top = (this.Height / 2) - (label1.Height / 2);
        }

        private void checker_Tick(object sender, EventArgs e)
        {
            if (this.textDisplay == "Shutting Down...")
            {
                timer++;
                if (timer == 2)
                {
                    label1.Hide();
                    axWindowsMediaPlayer1.Show();
                    playLoadingScreen();
                }
                if (axWindowsMediaPlayer1.playState == WMPLib.WMPPlayState.wmppsStopped)
                {
                    checker.Enabled = false;
                    Application.Exit();
                    Application.SetSuspendState(PowerState.Suspend, true, true);
                }
            }else
            {
                timer++;
                if (timer == 2)
                {
                    label1.Hide();
                    axWindowsMediaPlayer1.Show();
                    playLoadingScreen();
                }
                if (axWindowsMediaPlayer1.playState == WMPLib.WMPPlayState.wmppsStopped)
                {
                    checker.Enabled = false;
                    Bootup boot = new Bootup();
                    boot.ShowDialog();
                    this.Close();
                }
            }
            
        }

        private void playLoadingScreen()
        {
            string RunningPath = AppDomain.CurrentDomain.BaseDirectory;
            string FileName = string.Format("{0}Resources\\shutdown.mp4", System.IO.Path.GetFullPath(System.IO.Path.Combine(RunningPath, @"..\..\")));
            this.axWindowsMediaPlayer1.uiMode = "none";
            this.axWindowsMediaPlayer1.Size = this.Size;
            this.axWindowsMediaPlayer1.Location = this.Location;
            this.axWindowsMediaPlayer1.settings.setMode("loop", false);
            this.axWindowsMediaPlayer1.URL = FileName;
        }
    }
}
