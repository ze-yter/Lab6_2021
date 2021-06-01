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
    public partial class Level4 : Form
    {
        public static Game.Scripts.Player player_;

        double diametr1 = 1080d / 30d;
        double diametr2 = 1920d / 8d;
        double diametr3 = 1920d / 7d;      

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
                    Level4 l4 = new Level4(0);
                    l4.Show();
                    player_.SetAudioEnable(false);
                    this.Hide();
                }));
            }
        }

        public static int SafeWall = 0;
        public static int personLevel = 1;

        public static bool VragCollisWithPlayer()
        {
            if (personLevel == 3)
            {
                if (SafeWall == 0)
                    return true;

                SafeWall--;

                return false;

            }

            return true;
        }

        public static bool VragCollisWithWeapon(Scripts.Player.Vrag vrag)
        {
            if (personLevel == 1 && typeWeapon == 1)
            {
                vrag.skip = 100;
                return false;
            }

            if (personLevel == 2 && typeWeapon == 1)
            {
                vrag.MinusVragHP(30);
                return false;
            }

            return true;
        }

        public static int typeWeapon = 0;

        public static void PlayerButton1()
        {
            if (personLevel == 1)
            {
                if (typeWeapon == 0)
                {
                    player_.SetPlayerWeapon(Properties.Resources.магия_света);
                    typeWeapon = 1;
                }

                else
                {
                    player_.SetPlayerWeapon(Properties.Resources.урон_магией);
                    typeWeapon = 0;
                }
            }

            else if (personLevel == 2)
            {
                if (typeWeapon == 0)
                {
                    player_.SetPlayerWeapon(Properties.Resources.огненная_стрела);
                    typeWeapon = 1;
                }

                else
                {
                    player_.SetPlayerWeapon(Properties.Resources.стрела_обычная);
                    typeWeapon = 0;
                }
            }
            else if (personLevel == 3)
            {
                if (SafeWall == 0)
                    SafeWall = 100;
            }
        }

        public static void PlayerButton2()
        {
            if (personLevel == 1)
            {
                if (player_.GetPlayerHP() < 100)
                {
                    player_.PlusPlayerHP(10);
                    Thread.Sleep(100);
                }
            }
        }

        public Level4(int hp4)
        {
            InitializeComponent();
            this.FormClosing += Level4_FormClosing;
            pic(Player);
            vih.Size = new Size(Convert.ToInt32(Convert.ToDouble(Screen.PrimaryScreen.Bounds.Width) / 1.3), Convert.ToInt32(Convert.ToDouble(Screen.PrimaryScreen.Bounds.Height) / 2d));
            vih.Visible = false;
            vih.BackColor = Color.White;
            vih.Location = new Point(Convert.ToInt32((Convert.ToDouble(Screen.PrimaryScreen.Bounds.Width) / 2d) - (Convert.ToDouble(vih.Size.Width) / 2d)), Convert.ToInt32((Convert.ToDouble(Screen.PrimaryScreen.Bounds.Height) / 2d) - (Convert.ToDouble(vih.Size.Height) / 2d)));
            float ii = (float)Convert.ToDouble(Convert.ToDouble(Screen.PrimaryScreen.Bounds.Width) / 30d);
            vih.Font = new Font("Microsoft Sans Serif", ii, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            player_ = new Scripts.Player(Player);

            player_.PlayerUpdate += PlayerUpdate; 

            player_.PlayerButton1 += Level4.PlayerButton1; 
            player_.PlayerButton2 += Level4.PlayerButton2; 
            player_.VragCollisWithWeapon += Level4.VragCollisWithWeapon; 
            player_.VragCollisWithPlayer += Level4.VragCollisWithPlayer; 

            player_.SetVragHP(110, Scripts.Player.Types.VRAG_LVL1);
            player_.SetVragHP(130, Scripts.Player.Types.VRAG_LVL2);
            player_.SetVragHP(140, Scripts.Player.Types.VRAG_LVL3);
            player_.SetVragHP(160, Scripts.Player.Types.VRAG_LVL4);
            player_.SetVragHP(170, Scripts.Player.Types.VRAG_LVL5);
            player_.SetVragHP(180, Scripts.Player.Types.VRAG_LVL6);
            player_.SetVragHP(200, Scripts.Player.Types.VRAG_LVL7);

            player_.SetMaxSunduks(2);

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

            if (hp4 != 0)
                player_.SetPlayerHP(hp4);

            player_.SetVragDamage(25, Scripts.Player.Types.VRAG_LVL1);
            player_.SetVragDamage(28, Scripts.Player.Types.VRAG_LVL2);
            player_.SetVragDamage(30, Scripts.Player.Types.VRAG_LVL3);
            player_.SetVragDamage(35, Scripts.Player.Types.VRAG_LVL4);
            player_.SetVragDamage(40, Scripts.Player.Types.VRAG_LVL5);
            player_.SetVragDamage(45, Scripts.Player.Types.VRAG_LVL6);
            player_.SetVragDamage(50, Scripts.Player.Types.VRAG_LVL7);

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
            player_.AddObject(zemla_7, Scripts.Player.Types.ZEMLA);
            player_.AddObject(zemla_8, Scripts.Player.Types.ZEMLA);
            player_.AddObject(zemla_9, Scripts.Player.Types.ZEMLA);
            player_.AddObject(zemla_10, Scripts.Player.Types.ZEMLA);
            player_.AddObject(zemla_11, Scripts.Player.Types.ZEMLA);
            player_.AddObject(zemla_12, Scripts.Player.Types.ZEMLA);
            player_.AddObject(zemla_13, Scripts.Player.Types.ZEMLA);

            player_.AddObject(lestnica_1, Scripts.Player.Types.LESNICA);

            player_.AddObject(wall_1, Scripts.Player.Types.WALL);
            player_.AddObject(wall_2, Scripts.Player.Types.WALL);
            
            player_.AddObject(wall_4, Scripts.Player.Types.WALL);
            player_.AddObject(wall_5, Scripts.Player.Types.WALL);
            ;
            player_.AddObject(wall_7, Scripts.Player.Types.WALL);
            
            player_.AddObject(wall_9, Scripts.Player.Types.WALL);
            player_.AddObject(wall_10, Scripts.Player.Types.WALL);
            player_.AddObject(wall_11, Scripts.Player.Types.WALL);
            player_.AddObject(wall_12, Scripts.Player.Types.WALL);
            player_.AddObject(wall_13, Scripts.Player.Types.WALL);
            player_.AddObject(wall_14, Scripts.Player.Types.WALL);
            player_.AddObject(wall_15, Scripts.Player.Types.WALL);
            player_.AddObject(wall_16, Scripts.Player.Types.WALL);

            player_.AddObject(vrag_lvl1_1, Scripts.Player.Types.VRAG_LVL1);
            player_.AddObject(vrag_lvl2_1, Scripts.Player.Types.VRAG_LVL2);
            player_.AddObject(vrag_lvl3_1, Scripts.Player.Types.VRAG_LVL3);
            player_.AddObject(vrag_lvl4_1, Scripts.Player.Types.VRAG_LVL4);
            player_.AddObject(vrag_lvl5_1, Scripts.Player.Types.VRAG_LVL5);
            player_.AddObject(vrag_lvl6_1, Scripts.Player.Types.VRAG_LVL6);
            player_.AddObject(vrag_lvl7_1, Scripts.Player.Types.VRAG_LVL7);        

            player_.AddObject(vrag_lvl5_1, Scripts.Player.Types.SAFE);

            player_.AddObject(health_1, Scripts.Player.Types.HEALTH);
            player_.AddObject(health_2, Scripts.Player.Types.HEALTH);

            player_.AddObject(sunduk_1, Scripts.Player.Types.SUNDUK);
            player_.AddObject(sunduk_2, Scripts.Player.Types.SUNDUK);

            player_.AddObject(border_1, Scripts.Player.Types.BORDER);
            player_.AddObject(border_2, Scripts.Player.Types.BORDER);
            player_.AddObject(border_3, Scripts.Player.Types.BORDER);
            player_.AddObject(border_4, Scripts.Player.Types.BORDER);
            player_.AddObject(border_5, Scripts.Player.Types.BORDER);
            player_.AddObject(border_6, Scripts.Player.Types.BORDER);
            player_.AddObject(border_7, Scripts.Player.Types.BORDER);
            player_.AddObject(border_8, Scripts.Player.Types.BORDER);
            player_.AddObject(border_9, Scripts.Player.Types.BORDER);
            player_.AddObject(border_10, Scripts.Player.Types.BORDER);
            player_.AddObject(border_11, Scripts.Player.Types.BORDER);
            player_.AddObject(border_12, Scripts.Player.Types.BORDER);
            player_.AddObject(border_13, Scripts.Player.Types.BORDER);

            player_.AddObject(portal_4, Scripts.Player.Types.PORTAL);

            List<Image> vrag1 = player_.LoadSpritesFromDirectory(player_.GetCurrentDirectory("Sprites\\level4\\vrag1"), 39);
            List<Image> vrag2 = player_.LoadSpritesFromDirectory(player_.GetCurrentDirectory("Sprites\\level4\\vrag2"), 16);
            List<Image> vrag3 = player_.LoadSpritesFromDirectory(player_.GetCurrentDirectory("Sprites\\level4\\vrag3"), 3, true);
            List<Image> vrag4 = player_.LoadSpritesFromDirectory(player_.GetCurrentDirectory("Sprites\\level4\\vrag4"), 4, true);
            List<Image> vrag5 = player_.LoadSpritesFromDirectory(player_.GetCurrentDirectory("Sprites\\level4\\vrag5"), 7, true);
            List<Image> vrag6 = player_.LoadSpritesFromDirectory(player_.GetCurrentDirectory("Sprites\\level4\\vrag6"), 37);
            List<Image> vrag7 = player_.LoadSpritesFromDirectory(player_.GetCurrentDirectory("Sprites\\level4\\vrag7"), 8);

            player_.SetSpriteForVragByType(vrag6, Scripts.Player.Types.VRAG_LVL1);
            player_.SetSpriteForVragByType(vrag4, Scripts.Player.Types.VRAG_LVL2);
            player_.SetSpriteForVragByType(vrag2, Scripts.Player.Types.VRAG_LVL3);
            player_.SetSpriteForVragByType(vrag3, Scripts.Player.Types.VRAG_LVL4);
            player_.SetSpriteForVragByType(vrag5, Scripts.Player.Types.VRAG_LVL5);
            player_.SetSpriteForVragByType(vrag7, Scripts.Player.Types.VRAG_LVL6);
            player_.SetSpriteForVragByType(vrag1, Scripts.Player.Types.VRAG_LVL7);

            player_.SetSpriteAnimateForVragByType(27, 37, 5, Scripts.Player.Types.VRAG_LVL1);
            player_.SetSpriteAnimateForVragByType(1, 4, 5, Scripts.Player.Types.VRAG_LVL2);
            player_.SetSpriteAnimateForVragByType(9, 16, 5, Scripts.Player.Types.VRAG_LVL3);
            player_.SetSpriteAnimateForVragByType(1, 3, 5, Scripts.Player.Types.VRAG_LVL4);
            player_.SetSpriteAnimateForVragByType(1, 4, 5, Scripts.Player.Types.VRAG_LVL5);
            player_.SetSpriteAnimateForVragByType(1, 8, 5, Scripts.Player.Types.VRAG_LVL6);
            player_.SetSpriteAnimateForVragByType(30, 39, 5, Scripts.Player.Types.VRAG_LVL7);

            player_.DebugDraw(false);

            player_.Start();           
        }
       
        void Loader()
        {          
            this.Invoke(new Action(() =>
            {
               
                Outro f = new Outro();
                f.Show();
                this.Hide();
            }));
        }

        private void Level4_FormClosing(Object sender, FormClosingEventArgs e)
        {
            Application.OpenForms.OfType<Menus>().First().Close();
        }

        private void Level4_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Level1.player_.SetAudioEnable(false);
        }

        private void zemla_8_Click(object sender, EventArgs e)
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

        private void Level4_Load(object sender, EventArgs e)
        {
            pic(wall_1, false);
            pic(wall_2, false);
            pic(wall_13, false);
            pic(wall_4, false);
            pic(wall_5, false);
            pic(wall_14, false);
            pic(wall_7, false);
            pic(wall_15, false);
            pic(wall_9, false);
            pic(wall_10, false);
            pic(wall_11, false);
            pic(wall_12, false);
            pic(wall_16, false);
            pic(zemla_1, false);
            pic(zemla_2, false);
            pic(zemla_3, false);
            pic(zemla_4, false);
            pic(zemla_5, false);
            pic(zemla_6, false);
            pic(zemla_7, false);
            pic(zemla_8, false);
            pic(zemla_9, false);
            pic(zemla_10, false);
            pic(zemla_11, false);
            pic(zemla_12, false);
            pic(zemla_13, false);
            pic(vrag_lvl1_1);
            pic(vrag_lvl2_1);
            pic(vrag_lvl3_1);
            pic(vrag_lvl4_1);
            pic(vrag_lvl5_1);
            pic(vrag_lvl6_1);
            pic(vrag_lvl7_1);
            pic(sunduk_1);
            pic(sunduk_2);
            pic(portal_4, false);
            pic(health_1);
            pic(health_2);
            pic(lestnica_1, false);
            lab(HP);
            pic(border_1, false);
            pic(border_2, false);
            pic(border_3, false);
            pic(border_4, false);
            pic(border_5, false);
            pic(border_6, false);
            pic(border_7, false);
            pic(border_8, false);
            pic(border_9, false);
            pic(border_10, false);
            pic(border_11, false);
            pic(border_12, false);
            pic(border_13, false);
        }
    }
}
