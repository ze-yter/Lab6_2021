using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Game.Levels
{
    public partial class Outro : Form
    {

        public Outro()
        {
            InitializeComponent();
            this.FormClosing += Outro_FormClosing; 
            Scripts.Player.ShowCursor();
        }
        
        public Task TypeWriterEffect(string txt, Label lbl, int delay)
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

        private void outroLabel_Click(object sender, EventArgs e)
        {

        }
       
        private void Outro_FormClosing(Object sender, FormClosingEventArgs e)
        {
            Application.OpenForms.OfType<Menus>().First().Close();
        }
      
        public async void Outro_Load(object sender, EventArgs e)
        {
            label1.Size = new Size(Convert.ToInt32(Convert.ToDouble(Screen.PrimaryScreen.Bounds.Width) / 1.890260631001372), Convert.ToInt32(Convert.ToDouble(Screen.PrimaryScreen.Bounds.Height) / 5.2));
            vih.Visible = false;
            vih.Location = new Point(Convert.ToInt32(Convert.ToDouble(Screen.PrimaryScreen.Bounds.Width) / 3.971181556195965), Convert.ToInt32(Convert.ToDouble(Screen.PrimaryScreen.Bounds.Height) / 1.291390728476821));
            float ii = (float)Convert.ToDouble(Convert.ToDouble(Screen.PrimaryScreen.Bounds.Width) / 30d);
            vih.Font = new Font("HeinrichScript", ii, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            ii = (float)Convert.ToDouble(Convert.ToDouble(Screen.PrimaryScreen.Bounds.Width) /40d);
            outroLabel.Font = new Font("HeinrichScript", ii, FontStyle.Regular, GraphicsUnit.Point, ((byte) (0)));
            lab(outroLabel);
            lab(vih);            
            outroLabel.TextAlign = System.Drawing.ContentAlignment.TopLeft; 
            outroLabel.Text = ""; 
            await TypeWriterEffect("Бэндер побывал на планете Агрия, сразился с разными монстрами\nи по пути собрал детали корабля.", outroLabel, 80); 
            Thread.Sleep(1000); 
            outroLabel.Text = ""; 
            Thread.Sleep(500); 
            await TypeWriterEffect("Затем он починил корабль и прилетел к своей семье.", outroLabel, 80); 
            Thread.Sleep(1000); 
            outroLabel.Text = ""; 
            Thread.Sleep(500); 
            outroLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter; 
            outroLabel.Font = new System.Drawing.Font("HeinrichScript", 52.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204))); 
            await TypeWriterEffect("Конец :) ", outroLabel, 100);
            outroLabel.Visible = false;
            vih.Visible = false;
            label1.Visible = true;
            ex = 1;
        }

        int ex = 0;

        public bool Lab()
        {
            return label1.Visible == true;
        }

        private void Outro_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Menus.player.controls.stop();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        #region Масштабировние

        Size screen = new Size(1920, 1080);

        public void pic(PictureBox obj, bool i)
        {
            Size size = new Size(0, 0);
            Point point = new Point(0, 0);
            size.Width = Convert.ToInt32(Convert.ToDouble(Screen.PrimaryScreen.Bounds.Size.Width) / (Convert.ToDouble(screen.Width) / Convert.ToDouble(obj.Width)));
            size.Height = Convert.ToInt32(Convert.ToDouble(Screen.PrimaryScreen.Bounds.Size.Height) / (Convert.ToDouble(screen.Height) / Convert.ToDouble(obj.Height)));
            obj.Size = size;
            point.X = Convert.ToInt32(Convert.ToDouble(Screen.PrimaryScreen.Bounds.Size.Width) / (Convert.ToDouble(screen.Width) / Convert.ToDouble(obj.Location.X)));
            point.Y = Convert.ToInt32(Convert.ToDouble(Screen.PrimaryScreen.Bounds.Size.Height) / (Convert.ToDouble(screen.Height) / Convert.ToDouble(obj.Location.Y)));
            obj.Location = point;
            obj.Visible = i;
        }

        public void pic(PictureBox obj)
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

        public void lab(Label obj)
        {
            Size size = new Size(0, 0);
            Point point = new Point(0, 0);
            size.Width = Convert.ToInt32(Convert.ToDouble(Screen.PrimaryScreen.Bounds.Size.Width) / (Convert.ToDouble(screen.Width) / Convert.ToDouble(obj.Width)));
            size.Height = Convert.ToInt32(Convert.ToDouble(Screen.PrimaryScreen.Bounds.Size.Height) / (Convert.ToDouble(screen.Height) / Convert.ToDouble(obj.Height)));
            obj.Size = size;
            point.X = Convert.ToInt32(Convert.ToDouble(Screen.PrimaryScreen.Bounds.Size.Width) / (Convert.ToDouble(screen.Width) / Convert.ToDouble(obj.Location.X)));
            point.Y = Convert.ToInt32(Convert.ToDouble(Screen.PrimaryScreen.Bounds.Size.Height) / (Convert.ToDouble(screen.Height) / Convert.ToDouble(obj.Location.Y)));
            obj.Location = point;
            float b = (float)Convert.ToDouble(Convert.ToDouble(Screen.PrimaryScreen.Bounds.Width) / (Convert.ToDouble(screen.Width) / Convert.ToDouble(obj.Font.Size)));

            obj.Font = new Font(obj.Font.Name, b, obj.Font.Style);
        }

        public void but(Button obj)
        {
            Size size = new Size(0, 0);
            Point point = new Point(0, 0);
            size.Width = Convert.ToInt32(Convert.ToDouble(Screen.PrimaryScreen.Bounds.Size.Width) / (Convert.ToDouble(screen.Width) / Convert.ToDouble(obj.Width)));
            size.Height = Convert.ToInt32(Convert.ToDouble(Screen.PrimaryScreen.Bounds.Size.Height) / (Convert.ToDouble(screen.Height) / Convert.ToDouble(obj.Height)));
            obj.Size = size;
            point.X = Convert.ToInt32(Convert.ToDouble(Screen.PrimaryScreen.Bounds.Size.Width) / (Convert.ToDouble(screen.Width) / Convert.ToDouble(obj.Location.X)));
            point.Y = Convert.ToInt32(Convert.ToDouble(Screen.PrimaryScreen.Bounds.Size.Height) / (Convert.ToDouble(screen.Height) / Convert.ToDouble(obj.Location.Y)));
            obj.Location = point;
            float b = (float)Convert.ToDouble(Convert.ToDouble(Screen.PrimaryScreen.Bounds.Width) / (Convert.ToDouble(screen.Width) / Convert.ToDouble(obj.Font.Size)));

            obj.Font = new Font(obj.Font.Name, b, obj.Font.Style);
        }

        #endregion

        private void Outro_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.ToString() == "Return")
            {
                if (ex == 1)
                {
                    Environment.Exit(0);
                }
            }
        }
    }
}
