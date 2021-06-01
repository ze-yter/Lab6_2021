using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Game
{
    public partial class Intro : Form
    {
        public Intro()
        {
            
            InitializeComponent(); 
            this.FormClosing += Intro_FormClosing; 

        }
        int[] targetColor = { 0, 0, 0 }; 
        int[] fadeRGB = new int[3];
        int x = 0;

        public Task  TypeWriterEffect(string txt, Label lbl, int delay)
        {
            return Task.Run(() =>
            {
                for (int i = 0; i < txt.Length; i++)
                {
                    lbl.Invoke((MethodInvoker)delegate {
                        lbl.Text = txt.Substring(0, i);
                    });
                    System.Threading.Thread.Sleep(delay); ;
                }
            });
        }
      
        private void Intro_FormClosing(Object sender, FormClosingEventArgs e)
        {
            Application.OpenForms.OfType<Menus>().First().Close();
        }
        
        public Task TypeWriterEffect1(string txt, Label lbl, int delay)
        {
            return Task.Run(() =>
            {
                for (int i = 0; i < txt.Length; i++)
                {
                    lbl.Invoke((MethodInvoker)delegate {
                        lbl.Text = txt.Substring(0, i);
                    });
                    System.Threading.Thread.Sleep(delay); ;
                }
            });
        }
        public bool opened = true; 

        private async void label1_Click(object sender, EventArgs e)
        {
            op = true;

            if (opened)
            {
                opened = false; 

                label1.TextAlign = System.Drawing.ContentAlignment.TopLeft; 
                label1.Text = ""; 
                await TypeWriterEffect("В один прекрасный день, маленький робот, по имени Бэндэр, летел к своей семье на планету Эрида. В процессе полета корабль подвергся метеоритной бомбардировке.", label1, 50); 

                label1.Text = ""; 

                await TypeWriterEffect1("В результате корабль был подбит и Бэндэру пришлось совершить аварийную посадку на ближайшую планету Агрия. \nТеперь ему предстоит отыскать необходимые детали для восстановления разрушенного корабля и вернуться к семье ", label1, 80); 
                
                Thread.Sleep(100); 

                for (int i = 0; i < 10; i++)
                {
                    Thread.Sleep(60);
                    Opacity = this.Opacity - 0.1;
                }

                this.Hide(); 
                HeroChoose f1 = new HeroChoose(); 
                f1.Show(); 
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
       
        private void Intro_Load(object sender, EventArgs e)
        {
            Opacity = 0;

            for (int i = 0; i < 10; i++)
            {
                Thread.Sleep(30);
                Opacity = this.Opacity + 0.1;
            }
            vih.Size = new Size(Convert.ToInt32(Convert.ToDouble(Screen.PrimaryScreen.Bounds.Width) / 1.3), Convert.ToInt32(Convert.ToDouble(Screen.PrimaryScreen.Bounds.Height) / 2d));
            vih.Visible = false;
            vih.Location = new Point(Convert.ToInt32((Convert.ToDouble(Screen.PrimaryScreen.Bounds.Width) / 2d) - (Convert.ToDouble(vih.Size.Width) / 2d)), Convert.ToInt32((Convert.ToDouble(Screen.PrimaryScreen.Bounds.Height) / 2d) - (Convert.ToDouble(vih.Size.Height) / 2d)));
            float ii = (float)Convert.ToDouble(Convert.ToDouble(Screen.PrimaryScreen.Bounds.Width) / 30d);
            vih.Font = new Font("Microsoft Sans Serif", ii, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            
            Point point = new Point(0, 0);

            Size size = new Size(0, 0);
           
            size.Width = Screen.PrimaryScreen.Bounds.Size.Width;
            size.Height = Convert.ToInt32(Convert.ToDouble(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Size.Height) / (780d / 210d));
            label1.Size = size;
           
            point.X = 0;
            point.Y =  System.Windows.Forms.Screen.PrimaryScreen.Bounds.Size.Height - label1.Size.Height;
            label1.Location = point;

            int b = Convert.ToInt32(Convert.ToDouble(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Size.Width) / (1378d  / 33d));
            if (Convert.ToInt32(Convert.ToDouble(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Size.Height) / (780d / 33d)) < b) 
                b = Convert.ToInt32(Convert.ToDouble(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Size.Height) / (780d / 33d));
            label1.Font = new Font(label1.Font.Name, b, label1.Font.Style);
           
            label1.BackColor = Color.FromArgb(this.BackColor.R, this.BackColor.G, this.BackColor.B);

        }
        public bool op = false;
        
        private void timer1_Tick(object sender, EventArgs e)
        {
           
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        void fadeIn()
        {
            fadeRGB[0] = label1.ForeColor.R;
            fadeRGB[1] = label1.ForeColor.G;
            fadeRGB[2] = label1.ForeColor.B;

            if (fadeRGB[0] > targetColor[0])
            {
                fadeRGB[0]--;
            }

            else if (fadeRGB[0] > targetColor[0])
            {
                fadeRGB[0]++;
            }

            if (fadeRGB[1] > targetColor[1])
            {
                fadeRGB[1]--;
            }

            else if (fadeRGB[1] > targetColor[1])
            {
                fadeRGB[1]++;
            }

            if (fadeRGB[2] > targetColor[2])
            {
                fadeRGB[2]--;
            }

            else if (fadeRGB[2] > targetColor[2])
            {
                fadeRGB[2]++;
            }

            if (fadeRGB[0] == targetColor[0] && fadeRGB[1] == targetColor[1] && fadeRGB[2] == targetColor[2])
            {
                timer1.Stop();
            }

            label1.ForeColor = Color.FromArgb(fadeRGB[0], fadeRGB[1], fadeRGB[2]);
        }

        int a = 0;

        private void Intro_KeyDown(object sender, KeyEventArgs e)
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
