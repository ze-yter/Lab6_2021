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
    public partial class Level2 : Form
    {
        Game.Scripts.Player player_;

        double diametr1 = 1080d / 35d;
        double diametr2 = 1920d / 5d;
        double diametr3 = 1920d / 4d;

        private void _MouseDown(object sender, MouseEventArgs e)
        {
            player_.SetKeyMouseDown(e.Button);
        }

        private void _MouseUp(object sender, MouseEventArgs e)
        {
            player_.SetKeyMouseUp(e.Button);
        }

        private void _KeyUp(object sender, KeyEventArgs e)
        {
            player_.SetKeyUp(e.KeyValue);
        }

        int a = 0;
        int shit = 0;
        int heal = 0;

        private void _KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 49 && Level1.personLevel == 3)
            {
                if (shit == 0)
                {
                    shit = 1;
                    player_.SetKeyDown(e.KeyValue);
                }
            }

            else if (e.KeyValue == 50)
            {
                if (heal == 0)
                {
                    player_.SetKeyDown(e.KeyValue);
                    heal = 1;
                }
            }

            else
                player_.SetKeyDown(e.KeyValue);
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

        private void PlayerUpdate(int HP)
        {
            if (HP == 0)
            {
                Thread.Sleep(1000);
                this.Invoke(new Action(() => {
                    Level2 l2 = new Level2(0); 
                    l2.Show();
                    player_.SetAudioEnable(false);
                    this.Hide();
                }));
            }
        }

        public Level2(int hp2)
        {
            InitializeComponent();
            this.FormClosing += Level2_FormClosing;
            pic(Player);
            vih.Size = new Size(Convert.ToInt32(Convert.ToDouble(Screen.PrimaryScreen.Bounds.Width) / 1.3), Convert.ToInt32(Convert.ToDouble(Screen.PrimaryScreen.Bounds.Height) / 2d));
            vih.Visible = false;
            vih.BackColor = Color.White;
            vih.Location = new Point(Convert.ToInt32((Convert.ToDouble(Screen.PrimaryScreen.Bounds.Width) / 2d) - (Convert.ToDouble(vih.Size.Width) / 2d)), Convert.ToInt32((Convert.ToDouble(Screen.PrimaryScreen.Bounds.Height) / 2d) - (Convert.ToDouble(vih.Size.Height) / 2d)));
            float ii = (float)Convert.ToDouble(Convert.ToDouble(Screen.PrimaryScreen.Bounds.Width) / 30d);
            vih.Font = new Font("Microsoft Sans Serif", ii, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            player_ = new Scripts.Player(Player);

            player_.PlayerUpdate += PlayerUpdate; 

            player_.PlayerButton1 += Level1.PlayerButton1; 
            player_.PlayerButton2 += Level1.PlayerButton2; 
            player_.VragCollisWithWeapon += Level1.VragCollisWithWeapon; 
            player_.VragCollisWithPlayer += Level1.VragCollisWithPlayer; 

            player_.SetMaxSunduks(1);

            player_.SetVragHP(85, Scripts.Player.Types.VRAG_LVL1);
            player_.SetVragHP(85, Scripts.Player.Types.VRAG_LVL1);
            player_.SetVragHP(90, Scripts.Player.Types.VRAG_LVL2);
            player_.SetVragHP(90, Scripts.Player.Types.VRAG_LVL2);
            player_.SetVragHP(100, Scripts.Player.Types.VRAG_LVL3);         

            if (Level1.personLevel == 1) 
            {
                player_.SetPlayerJump(Convert.ToInt32(Convert.ToDouble(Screen.PrimaryScreen.Bounds.Height) / diametr1)); 
                player_.SetPlayerSpeed(Convert.ToInt32(Convert.ToDouble(Screen.PrimaryScreen.Bounds.Width) / diametr2)); 
                player_.SetPlayerDamage(20); 
                player_.SetPlayerHP(100); 
                player_.SetPlayerWeapon(Properties.Resources.урон_магией); 
            }

            else if (Level1.personLevel == 2)
            {
                player_.SetPlayerJump(Convert.ToInt32(Convert.ToDouble(Screen.PrimaryScreen.Bounds.Height) / diametr1)); 
                player_.SetPlayerSpeed(Convert.ToInt32(Convert.ToDouble(Screen.PrimaryScreen.Bounds.Width) / diametr2)); 
                player_.SetPlayerDamage(15); 
                player_.SetPlayerHP(150); 
                player_.SetPlayerWeapon(Properties.Resources.стрела_обычная); 
            }

            else if (Level1.personLevel == 3)
            {
                player_.SetPlayerJump(Convert.ToInt32(Convert.ToDouble(Screen.PrimaryScreen.Bounds.Height) / diametr1)); 
                player_.SetPlayerSpeed(Convert.ToInt32(Convert.ToDouble(Screen.PrimaryScreen.Bounds.Width) / diametr3)); 
                player_.SetPlayerDamage(10); 
                player_.SetPlayerHP(200);
                player_.SetPlayerWeapon(Properties.Resources.урон_камнем); 
            }

            if (hp2 != 0)
                player_.SetPlayerHP(hp2);

            player_.SetVragDamage(25, Scripts.Player.Types.VRAG_STATIC_LVL1);
            player_.SetVragDamage(25, Scripts.Player.Types.VRAG_LVL1);
            player_.SetVragDamage(25, Scripts.Player.Types.VRAG_LVL1);
            player_.SetVragDamage(30, Scripts.Player.Types.VRAG_LVL2);
            player_.SetVragDamage(30, Scripts.Player.Types.VRAG_LVL2);
            player_.SetVragDamage(45, Scripts.Player.Types.VRAG_LVL3);

            player_.SetUI(HP);

            player_.NextLevel += Loader;

            player_.AddControl += (Control control) =>
            {
                this.Invoke(new Action(() =>
                {
                    this.Controls.Add(control);
                }));
            };

            player_.RemoveControl += (Control control) =>
            {
                this.Invoke(new Action(() =>
                {                   
                    this.Controls.Remove(control);
                }));
            };

            player_.AddObject(zemla_1, Scripts.Player.Types.ZEMLA);
            player_.AddObject(zemla_2, Scripts.Player.Types.ZEMLA);
            player_.AddObject(zemla_3, Scripts.Player.Types.ZEMLA);
            player_.AddObject(zemla_4, Scripts.Player.Types.ZEMLA);
            player_.AddObject(zemla_5, Scripts.Player.Types.ZEMLA);
            player_.AddObject(zemla_6, Scripts.Player.Types.ZEMLA);        
           
            player_.AddObject(lestnica_1, Scripts.Player.Types.LESNICA);
            player_.AddObject(lestnica_2, Scripts.Player.Types.LESNICA);
            player_.AddObject(lestnica_3, Scripts.Player.Types.LESNICA);

            player_.AddObject(wall_1, Scripts.Player.Types.WALL);
            player_.AddObject(wall_2, Scripts.Player.Types.WALL);
            player_.AddObject(wall_3, Scripts.Player.Types.WALL);
            player_.AddObject(wall_4, Scripts.Player.Types.WALL);
            player_.AddObject(wall_5, Scripts.Player.Types.WALL);
            player_.AddObject(wall_6, Scripts.Player.Types.WALL);

            player_.AddObject(sunduk_1, Scripts.Player.Types.SUNDUK);            

            player_.AddObject(vrag_static_lvl1_1, Scripts.Player.Types.VRAG_STATIC_LVL1);
            player_.AddObject(vrag_lvl1_1, Scripts.Player.Types.VRAG_LVL1);
            player_.AddObject(vrag_lvl1_2, Scripts.Player.Types.VRAG_LVL1);
            player_.AddObject(vrag_lvl2_1, Scripts.Player.Types.VRAG_LVL2);
            player_.AddObject(vrag_lvl2_2, Scripts.Player.Types.VRAG_LVL2);
            player_.AddObject(vrag_lvl3_1, Scripts.Player.Types.VRAG_LVL3);           

            player_.AddObject(border_1, Scripts.Player.Types.BORDER);
            player_.AddObject(border_2, Scripts.Player.Types.BORDER);
            player_.AddObject(border_3, Scripts.Player.Types.BORDER);
            player_.AddObject(border_4, Scripts.Player.Types.BORDER);
            player_.AddObject(border_5, Scripts.Player.Types.BORDER);
            player_.AddObject(border_6, Scripts.Player.Types.BORDER);
            player_.AddObject(border_7, Scripts.Player.Types.BORDER);
            player_.AddObject(border_8, Scripts.Player.Types.BORDER);   
            
            player_.AddObject(portal_2, Scripts.Player.Types.PORTAL);

            List<Image> vrag1 = player_.LoadSpritesFromDirectory(player_.GetCurrentDirectory("Sprites\\level2\\vrag1"), 29);
            List<Image> vrag2 = player_.LoadSpritesFromDirectory(player_.GetCurrentDirectory("Sprites\\level2\\vrag2"), 12);
            List<Image> vrag3 = player_.LoadSpritesFromDirectory(player_.GetCurrentDirectory("Sprites\\level2\\vrag3"), 8);           

            player_.SetSpriteForVragByType(vrag3, Scripts.Player.Types.VRAG_LVL1);
            player_.SetSpriteForVragByType(vrag1, Scripts.Player.Types.VRAG_LVL2);
            player_.SetSpriteForVragByType(vrag2, Scripts.Player.Types.VRAG_LVL3);         
            
            player_.SetSpriteAnimateForVragByType(1, 8, 5, Scripts.Player.Types.VRAG_LVL1);
            player_.SetSpriteAnimateForVragByType(23, 29, 5, Scripts.Player.Types.VRAG_LVL2);
            player_.SetSpriteAnimateForVragByType(1, 8, 5, Scripts.Player.Types.VRAG_LVL3);
           
            player_.DebugDraw(false);

            player_.Start();  
        }
       
        async void Loader()
        {
            this.Invoke(new Action(() =>
            {
               
                Level3 f3 = new Level3(Convert.ToInt32(HP.Text));
                f3.Show();
                this.Hide();
            }));
        }
        private void Level2_FormClosing(Object sender, FormClosingEventArgs e)
        {
            Application.OpenForms.OfType<Menus>().First().Close();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void Level2_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Menus.player.controls.stop();
        }

        private void HP_Click(object sender, EventArgs e)
        {

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

        #endregion

        private void Level2_Load(object sender, EventArgs e)
        {
            pic(border_1,false);
            pic(border_2, false);
            pic(border_3, false);
            pic(border_4, false);
            pic(border_5, false);
            pic(border_6, false);
            pic(border_7, false);
            pic(border_8, false);
            lab(HP);
            pic(lestnica_1, false);
            pic(lestnica_2, false);
            pic(lestnica_3, false);
            pic(portal_2, false);
            pic(sunduk_1);
            pic(vrag_lvl1_1);
            pic(vrag_lvl1_2);
            pic(vrag_lvl2_1);
            pic(vrag_lvl2_2);
            pic(vrag_lvl3_1);
            pic(vrag_static_lvl1_1, false);
            pic(wall_1, false);
            pic(wall_2, false);
            pic(wall_3, false);
            pic(wall_4, false);
            pic(wall_5, false);
            pic(wall_6, false);
            pic(zemla_1, false);
            pic(zemla_2, false);
            pic(zemla_3, false);
            pic(zemla_4, false);
            pic(zemla_5, false);
            pic(zemla_6, false);
        }
    }
}
