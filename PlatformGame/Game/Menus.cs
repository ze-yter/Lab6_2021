using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;
using System.IO;
using System.Threading;
using Game.Levels;
using System.Reflection;

namespace Game
{
    public partial class Menus : Form
    {
        public static WMPLib.WindowsMediaPlayer player; 
        string workDirectory = Directory.GetCurrentDirectory() + @"\music\"; 

        public static Game.Scripts.Player player_;

        public Menus()
        {
            InitializeComponent();
            player_ = new Scripts.Player(null);

            player_.SetAudioMusic(player_.GetCurrentDirectory("Music") + "\\" + "Ray_Gun_Hero_-_I_Am_Android_68851446.mp3");
            player_.SetAudioEnable(true);

            vih.Size = new Size(Convert.ToInt32(Convert.ToDouble(Screen.PrimaryScreen.Bounds.Width) / 1.3), Convert.ToInt32(Convert.ToDouble(Screen.PrimaryScreen.Bounds.Height) / 2d));
            vih.Visible = false;
            vih.Location = new Point(Convert.ToInt32((Convert.ToDouble(Screen.PrimaryScreen.Bounds.Width) / 2d) - (Convert.ToDouble(vih.Size.Width) / 2d)), Convert.ToInt32((Convert.ToDouble(Screen.PrimaryScreen.Bounds.Height) / 2d) - (Convert.ToDouble(vih.Size.Height) / 2d)));
            float ii = (float)Convert.ToDouble(Convert.ToDouble(Screen.PrimaryScreen.Bounds.Width) / 30d);
            vih.Font = new Font("Microsoft Sans Serif", ii, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        }
     
        private void Menu_Load(object sender, EventArgs e) 
        {
            Size size = new Size(0, 0);
            size.Width = Convert.ToInt32(Convert.ToDouble(Size.Width) / 2.524953789279113);
            size.Height = Convert.ToInt32(Convert.ToDouble(Size.Height) / 4.727272727272727);
            button2.Size = size;

            Point point = new Point(0, 0);
            point.X = Convert.ToInt32(Convert.ToDouble(Size.Width) / 3.169042316258352);
            point.Y = Convert.ToInt32(Convert.ToDouble(Size.Height) / 1.397849462365591);
            button2.Location = point;

            
            int b = Convert.ToInt32(Convert.ToDouble(Size.Width) / 18d);
            button2.Font = new Font(button2.Font.Name, b, button2.Font.Style);

        }

        private const int cGrip = 16;
        private const int cCaption = 32;

        protected override void WndProc(ref Message m)
        {
            if(m.Msg == 0x84)
            {
                Point pos = new Point(m.LParam.ToInt32());
                pos = this.PointToClient(pos);

                if(pos.Y < cCaption)
                {
                    m.Result = (IntPtr)2;
                    return;
                }  

                if(pos.X >= this.ClientSize.Width - cGrip && pos.Y >= this.ClientSize.Height - cGrip)
                {
                    m.Result = (IntPtr)17;
                    return;
                }
            }
            base.WndProc(ref m);
        }
        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Click(object sender, EventArgs e)
        {

        }
       
        private void button2_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 10; i++)
            {
                Thread.Sleep(30);
                Opacity = this.Opacity - 0.1;
            }

            Thread.Sleep(100);
            Intro f = new Intro();
            f.Show();
            this.Hide();
        }
     
        private void Menus_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Menus.player_.SetAudioEnable(false);
        }

        int a = 0;

        private void Menus_KeyDown(object sender, KeyEventArgs e)
        {
            
            if (e.KeyCode.ToString() == "Escape")
            {
                if (a == 0)
                {
                    a = 1;
                    vih.Visible = true;
                    return;
                }

                if (a == 1)
                {
                    a = 0;
                    vih.Visible = false;
                }
            }

            if (e.KeyCode.ToString() == "Return" && a == 1)
            {
                Environment.Exit(0);
            }
        }
    }
}
