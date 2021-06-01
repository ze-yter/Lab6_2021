using Game.Levels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Game
{
    public partial class HeroChoose : Form
    {       
        public HeroChoose()
        {
            InitializeComponent(); 
            this.FormClosing += HeroChoose_FormClosing; 
            MusicLoader(); 
        }
        
        async void MusicLoader()
        {
            for (int i = 0; i < Menus.player_.GetAudioVolume(); i++)
            {
                Menus.player_.SetAudioVolume(Menus.player_.GetAudioVolume() - 1);
                await Task.Delay(500);
            }

            Menus.player_.SetAudioEnable(false);
        }

        Size screen = new Size(1378, 780);

        public void mas(PictureBox obj)
        {
            Size size = new Size(0, 0);
            Point point = new Point(0, 0);
            size.Width = Convert.ToInt32(Convert.ToDouble(Screen.PrimaryScreen.Bounds.Size.Width) / (Convert.ToDouble(screen.Width) / Convert.ToDouble(obj.Width)));
            size.Height = Convert.ToInt32(Convert.ToDouble(Screen.PrimaryScreen.Bounds.Size.Height) / (Convert.ToDouble(screen.Height) / Convert.ToDouble(obj.Height)));
            obj.Size = size;
            point.X = Convert.ToInt32(Convert.ToDouble(Screen.PrimaryScreen.Bounds.Size.Width) / (Convert.ToDouble(screen.Width) / Convert.ToDouble(obj.Location.X)));
            point.Y = Convert.ToInt32(Convert.ToDouble(Screen.PrimaryScreen.Bounds.Size.Height) / (Convert.ToDouble(screen.Height) / Convert.ToDouble(obj.Location.Y)));
            obj.Location = point;
        }

        private void HeroChoose_Load(object sender, EventArgs e)
        {
            vih.Size = new Size(Convert.ToInt32(Convert.ToDouble(Screen.PrimaryScreen.Bounds.Width) / 1.3), Convert.ToInt32(Convert.ToDouble(Screen.PrimaryScreen.Bounds.Height) / 2d));
            vih.Visible = false;
            vih.BackColor = Color.White;
            vih.Location = new Point(Convert.ToInt32((Convert.ToDouble(Screen.PrimaryScreen.Bounds.Width) / 2d) - (Convert.ToDouble(vih.Size.Width) / 2d)), Convert.ToInt32((Convert.ToDouble(Screen.PrimaryScreen.Bounds.Height) / 2d) - (Convert.ToDouble(vih.Size.Height) / 2d)));
            float ii = (float)Convert.ToDouble(Convert.ToDouble(Screen.PrimaryScreen.Bounds.Width) / 30d);
            vih.Font = new Font("Microsoft Sans Serif", ii, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            mas(pictureBox1);
            mas(pictureBox2);
            mas(pictureBox3);
        }

        int a = 0;
        
        private void HeroChoose_FormClosing(Object sender, FormClosingEventArgs e)
        {
            Application.OpenForms.OfType<Menus>().First().Close();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Level1 f1 = new Levels.Level1(1); 
            f1.Show(); 
            this.Hide(); 
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Level1 f1 = new Levels.Level1(2); 
            f1.Show(); 
            this.Hide(); 
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Level1 f1 = new Levels.Level1(3); 
            f1.Show(); 
            this.Hide(); 
        }
        
        private void HeroChoose_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Menus.player_.SetAudioEnable(false);
        }

        private void HeroChoose_KeyDown(object sender, KeyEventArgs e)
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
