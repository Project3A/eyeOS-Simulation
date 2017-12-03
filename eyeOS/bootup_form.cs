using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eyeOS
{
    public partial class bootup_form : Form
    {
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;

                return cp;
            }
        }

        Random rnd = new Random();
        private int PupilRadius = 88;
        private int EyeBallRadius = 140;
        private int pupilStyle = 0;
        private int randomEye = 100;
        private bool sizeBool = false;
        private bool randBool = false;
        private int eyeLocationX = 0;
        private int eyeLocationY = 0;
        private int maxEyeLocationX = 0;
        private int maxEyeLocationY = 0;
        private int minEyeLocationX = 0;
        private int minEyeLocationY = 0;
        private static int minPupilRadius = 40;
        private static int maxPupilRadius = 88;
        private static int minEyeBallRadius = 70;
        private static int maxEyeBallRadius = 140;
        private bool toggleEye = false;
        private int toggleCount = 0;


        public bootup_form()
        {
            InitializeComponent();
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            maxEyeLocationX = -(this.Width / 2) + 75;
            maxEyeLocationY = (this.Height / 2) - 75;
        }


        private void bootup_form_load(object sender, EventArgs e)
        {
            this.TopMost = false;
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;

            this.panelEye.Paint += panelEye_Paint;

            panelEye.Size = this.Size;


            resetPosition();
            flowStartMenu1.Hide();
            flowStartMenu.Hide();
            flowShutdown.Hide();

            
        }


        private void resetPosition()
        {
            panelEye.Left = (this.ClientSize.Width - panelEye.Width) / 2;
            panelEye.Top = (this.ClientSize.Height - panelEye.Height) / 2;

            icon_bottom.Left = (this.ClientSize.Width - icon_bottom.Width) / 2;
            icon_bottom.Top = (this.ClientSize.Height - icon_bottom.Height) / 2 + (this.ClientSize.Height - icon_bottom.Height) / 3;

            icon_top.Left = (this.ClientSize.Width - icon_top.Width) / 2;
            icon_top.Top = (this.ClientSize.Height - icon_top.Height) / 2 - (this.ClientSize.Height - icon_top.Height) / 3;

            icon_left.Left = (this.ClientSize.Width - icon_left.Width) / 2 - (this.ClientSize.Width - icon_left.Width) / 3;
            icon_left.Top = (this.ClientSize.Height - icon_left.Height) / 2;

            icon_right.Left = (this.ClientSize.Width - icon_right.Width) / 2 + (this.ClientSize.Width - icon_right.Width) / 3;
            icon_right.Top = (this.ClientSize.Height - icon_right.Height) / 2;

            icon_topLeft.Left = (this.ClientSize.Width - icon_topLeft.Width) / 2 - (this.ClientSize.Width - icon_topLeft.Width) / 5;
            icon_topLeft.Top = (this.ClientSize.Height - icon_topLeft.Height) / 2 - (this.ClientSize.Height - icon_topLeft.Width) / 4;

            icon_topRight.Left = (this.ClientSize.Width - icon_topRight.Width) / 2 + (this.ClientSize.Width - icon_topRight.Width) / 5;
            icon_topRight.Top = (this.ClientSize.Height - icon_topRight.Height) / 2 - (this.ClientSize.Height - icon_topRight.Width) / 4;

            icon_bottomLeft.Left = (this.ClientSize.Width - icon_bottomLeft.Width) / 2 - (this.ClientSize.Width - icon_bottomLeft.Width) / 5;
            icon_bottomLeft.Top = (this.ClientSize.Height - icon_bottomLeft.Height) / 2 + (this.ClientSize.Height - icon_bottomLeft.Width) / 4;

            icon_bottomRight.Left = (this.ClientSize.Width - icon_bottomRight.Width) / 2 + (this.ClientSize.Width - icon_bottomRight.Width) / 5;
            icon_bottomRight.Top = (this.ClientSize.Height - icon_bottomRight.Height) / 2 + (this.ClientSize.Height - icon_bottomRight.Width) / 4;

            shutdown_btn.Left = (this.ClientSize.Width/2 - shutdown_btn.Width/2) ;
            shutdown_btn.Top = (this.ClientSize.Height/2 - shutdown_btn.Height/2);

            flowShutdown.Left = (this.ClientSize.Width / 2 - flowShutdown.Width / 2);
            flowShutdown.Top = (0);

            flowStartMenu.Left = (this.ClientSize.Width / 2 - flowStartMenu.Width / 2);
            flowStartMenu.Top = (this.ClientSize.Height / 3 - flowStartMenu.Height / 2);

            flowStartMenu1.Left = (this.ClientSize.Width / 2 - flowStartMenu1.Width / 2);
            flowStartMenu1.Top = (this.ClientSize.Height - flowStartMenu1.Height);

        }

        private void iconHide()
        {
            icon_bottom.Visible = false;
            icon_left.Visible = false;
            icon_right.Visible = false;
            icon_top.Visible = false;
            icon_bottomLeft.Visible = false;
            icon_bottomRight.Visible = false;
            icon_topLeft.Visible = false;
            icon_topRight.Visible = false;
        }
        private void iconShow()
        {
            icon_bottom.Visible = true;
            icon_left.Visible = true;
            icon_right.Visible = true;
            icon_top.Visible = true;
            icon_bottomLeft.Visible = true;
            icon_bottomRight.Visible = true;
            icon_topLeft.Visible = true;
            icon_topRight.Visible = true;
        }


        private void timer1_Tick(object sender, EventArgs e)
        {
            int x = 100;
            panelEye.Invalidate();
            pupilStyle += 2;
            if (toggleEye == true)
            {
                timer1.Interval = 10;
                testBtn.Visible = false;
                if (toggleCount % 2 == 1)
                {
                    iconHide();
                    if (eyeLocationX > maxEyeLocationX + 20)
                    {
                        eyeLocationX -= 20;
                    }
                    if (eyeLocationY < maxEyeLocationY - 10)
                    {
                        eyeLocationY += 10;
                    }
                    if (PupilRadius > minPupilRadius)
                    {
                        PupilRadius -= 5;
                    }
                    if (EyeBallRadius > minEyeBallRadius)
                    {
                        EyeBallRadius -= 5;
                    }
                    if (eyeLocationX <= (maxEyeLocationX + 20) && eyeLocationY >= (maxEyeLocationY - 10))
                    {
                        flowStartMenu.Show();
                        flowStartMenu1.Show();
                        flowShutdown.Show();
                        toggleEye = false;
                    }
                }else if(toggleCount % 2 == 0)
                {
                    flowStartMenu.Hide();
                    flowShutdown.Hide();
                    flowStartMenu1.Hide();
                    if (eyeLocationX < minEyeLocationX - 20)
                    {
                        eyeLocationX += 20;
                    }
                    if (eyeLocationY > minEyeLocationY + 10)
                    {
                        eyeLocationY -= 10;
                    }
                    if (PupilRadius < maxPupilRadius)
                    {
                        PupilRadius += 5;
                    }
                    if (EyeBallRadius < maxEyeBallRadius)
                    {
                        EyeBallRadius += 5;
                    }
                    if (eyeLocationX >= (minEyeLocationX - 20) && eyeLocationY <= (maxEyeLocationY + 10))
                    {
                        iconShow();
                        toggleEye = false;
                        eyeLocationX = 0;
                        eyeLocationY = 0;
                    }
                }
            }else
            {
                testBtn.Visible = true;
                timer1.Interval = 100;
                if (randBool == true)
                {

                }
                else
                {
                    x = rnd.Next(1, 101);
                }
                if (x == 5)
                {
                    randomEye = 1;
                    x = 100;
                    randBool = !randBool;
                }

                if (randomEye <= 10)
                {
                    randomEye++;
                    if (sizeBool == true)
                    {
                        PupilRadius -= 2;
                    }
                    else
                    {
                        PupilRadius += 2;
                    }

                    if (randomEye == 10)
                    {
                        sizeBool = !sizeBool;
                        randBool = !randBool;
                    }

                }
            }

            

            
           
        }

        private void mouseDoubleClick_OpenApp(object sender, MouseEventArgs e)
        {
            PictureBox pb = sender as PictureBox;
            try
            {
                switch (pb.Name)
                {
                    case "icon_top":
                        Process.Start("notepad.exe");
                        Console.WriteLine("Top");
                        break;
                    case "icon_topRight":
                        Process.Start("cmd.exe");
                        Console.WriteLine("Top Right");
                        break;
                    case "icon_right":
                        Process.Start("photoshop.exe");
                        Console.WriteLine("Right");
                        break;
                    case "icon_bottomRight":
                        Process.Start("WINWORD.exe");
                        Console.WriteLine("Bottom Right");
                        break;
                    case "icon_bottom":
                        Process.Start("POWERPNT.exe");
                        Console.WriteLine("Bottom");
                        break;
                    case "icon_bottomLeft":
                        Process.Start("mspaint.exe");
                        Console.WriteLine("Bottom Left");
                        break;
                    case "icon_left":
                        Process.Start("aftereffects.EXE");
                        Console.WriteLine("Left");
                        break;
                    case "icon_topLeft":
                        Process.Start("EXCEL.exe");
                        Console.WriteLine("Top Left");
                        break;
                    case "bridgeApp":
                        Process.Start("bridge.exe");
                        Console.WriteLine("Top Left");
                        break;
                    case "calcApp":
                        Process.Start("calc.exe");
                        Console.WriteLine("Top Left");
                        break;
                    case "explorerApp":
                        Process.Start("explorer.exe");
                        Console.WriteLine("Top Left");
                        break;
                    case "ieApp":
                        Process.Start("iexplore.exe");
                        Console.WriteLine("Top Left");
                        break;
                    case "flassApp":
                        Process.Start("flash.exe");
                        Console.WriteLine("Top Left");
                        break;
                    case "computerApp":
                        Process.Start("C:/../");
                        Console.WriteLine("Top Left");
                        break;
                    case "sublimeApp":
                        Process.Start("sublime_text.exe");
                        Console.WriteLine("Top Left");
                        break;
                    case "wmvApp":
                        Process.Start("wmplayer.exe");
                        Console.WriteLine("Top Left");
                        break;
                    default:
                        Console.WriteLine("Error");
                        break;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Please check if the program is installed correctly", "Application Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        

        private void panelEye_Paint(object sender, PaintEventArgs e)
        {
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);

            e.Graphics.SmoothingMode = SmoothingMode.HighQuality;
            Point eyeFollower = new Point((panelEye.ClientSize.Width / 2) - eyeLocationX, (panelEye.ClientSize.Height / 2) - eyeLocationY);

            Rectangle rc = new Rectangle(eyeFollower, new Size(1, 1));
            rc.Inflate(EyeBallRadius, EyeBallRadius);
            e.Graphics.FillEllipse(Brushes.White, rc);

            Point curPos = panelEye.PointToClient(Cursor.Position);
            Double DistanceFromLeftEyeToCursor = getDistance(eyeFollower.X, eyeFollower.Y, curPos.X, curPos.Y);
            double angleLeft = getAngleInDegrees(eyeFollower.X, eyeFollower.Y, curPos.X, curPos.Y);

            rc = new Rectangle(new Point(Math.Min((int)DistanceFromLeftEyeToCursor, EyeBallRadius - PupilRadius), 0), new Size(1, 1));
            rc.Inflate(PupilRadius, PupilRadius);
            e.Graphics.TranslateTransform(eyeFollower.X, eyeFollower.Y);
            e.Graphics.RotateTransform((float)angleLeft);
            e.Graphics.FillEllipse(Brushes.Black, rc);

            e.Graphics.ResetTransform();


        }

        private Double getDistance(int Ax, int Ay, int Bx, int By)
        {
            return Math.Sqrt(Math.Pow((Double)Ax - Bx, 2) + Math.Pow((Double)Ay - By, 2));
        }

        private Double getAngleInDegrees(int cx, int cy, int X, int Y)
        {
            // draw a line from the center of the circle
            // to the where the cursor is...
            // If the line points:
            // up = 0 degrees
            // right = 90 degrees
            // down = 180 degrees
            // left = 270 degrees

            Double angle;
            int dy = Y - cy;
            int dx = X - cx;
            if (dx == 0) // Straight up and down | avoid divide by zero error!
            {
                if (dy <= 0)
                {
                    angle = 0;
                }
                else
                {
                    angle = 180;
                }
            }
            else
            {
                angle = Math.Atan((Double)dy / (Double)dx);
                angle = angle * ((Double)180 / Math.PI);

                if (X <= cx)
                {
                    angle = 180 + angle;
                }
            }

            return angle;
        }

        private void shutdown_hover(object sender, EventArgs e)
        {
            shutdown_btn.Image = Properties.Resources.clarity_shutdown_icon; 
        }

        private void leave_shutdown(object sender, EventArgs e)
        {    
            shutdown_btn.Image = null;
        }

        private void shutdown_btn_Click(object sender, EventArgs e)
        {
            Bootdown boot = new Bootdown("Shutting Down...");
            boot.ShowDialog();
            this.Close();
        }

        private void testBtn_Click(object sender, EventArgs e)
        {
            toggleEye = true;
            toggleCount++;
        }

        private void mouseClick_Highlight(object sender, MouseEventArgs e)
        {

        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            Bootdown boot = new Bootdown("Shutting Down...");
            boot.ShowDialog();
            this.Close();
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            Bootdown boot = new Bootdown("Restarting...");
            boot.ShowDialog();
            this.Close();
        }
    }
}
