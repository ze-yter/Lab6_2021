using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Game.Levels
{
    public partial class Level1 : Form
    {
        public static int personLevel = 1;

        public static Game.Scripts.Player player_;

        double diametr1 = 1080d / 35d;
        double diametr2 = 1920d / 6d;
        double diametr3 = 1920d / 5d;

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
        int heal = 0;
        int shit = 0;

        private void _KeyDown(object sender, KeyEventArgs e)
        {            
            if(e.KeyValue == 49 && personLevel == 3)
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
                    Level1 l1 = new Level1(Level1.personLevel);
                    l1.Show();
                    player_.SetAudioEnable(false);
                    this.Hide();
                }));
            }
        }

        public static int SafeWall = 0;

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
                vrag.MinusVragHP(20);
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

        public Level1(int personLevel)
        {
            InitializeComponent(); 
            this.FormClosing += Level1_FormClosing; 
            Level1.personLevel = personLevel;
            vih.Size = new Size(Convert.ToInt32(Convert.ToDouble(Screen.PrimaryScreen.Bounds.Width) / 1.3), Convert.ToInt32(Convert.ToDouble(Screen.PrimaryScreen.Bounds.Height) / 2d));
            vih.Visible = false;
            vih.BackColor = Color.White;
            vih.Location = new Point(Convert.ToInt32((Convert.ToDouble(Screen.PrimaryScreen.Bounds.Width) / 2d) - (Convert.ToDouble(vih.Size.Width) / 2d)), Convert.ToInt32((Convert.ToDouble(Screen.PrimaryScreen.Bounds.Height) / 2d) - (Convert.ToDouble(vih.Size.Height) / 2d)));
            float ii = (float)Convert.ToDouble(Convert.ToDouble(Screen.PrimaryScreen.Bounds.Width) / 30d);
            vih.Font = new Font("Microsoft Sans Serif", ii, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

            pic(Player);

            player_ = new Scripts.Player(Player);

            player_.PlayerUpdate += PlayerUpdate; 

            player_.PlayerButton1 += PlayerButton1; 
            player_.PlayerButton2 += PlayerButton2; 
            player_.VragCollisWithWeapon += VragCollisWithWeapon; 
            player_.VragCollisWithPlayer += VragCollisWithPlayer;

            player_.SetAudioMusic(player_.GetCurrentDirectory("Music") + "\\" + "e154681c4a75334.mp3");
            player_.SetAudioEnable(true);

            player_.SetMaxSunduks(1);

            player_.SetVragHP(60, Scripts.Player.Types.VRAG_LVL1); 
            player_.SetVragHP(60, Scripts.Player.Types.VRAG_LVL1);
            player_.SetVragHP(70, Scripts.Player.Types.VRAG_LVL2);
            player_.SetVragHP(75, Scripts.Player.Types.VRAG_LVL3);
            player_.SetVragHP(80, Scripts.Player.Types.VRAG_LVL4);

            player_.SetVragHP(60, Scripts.Player.Types.VRAG_STATIC_LVL2);

            if (personLevel == 1)
            {
                player_.SetPlayerJump(Convert.ToInt32(Convert.ToDouble(Screen.PrimaryScreen.Bounds.Height) / diametr1)); 
                player_.SetPlayerSpeed(Convert.ToInt32(Convert.ToDouble(Screen.PrimaryScreen.Bounds.Width) / diametr2)); 
                player_.SetPlayerDamage(20); 
                player_.SetPlayerHP(100);
                player_.SetPlayerWeapon(Properties.Resources.урон_магией); 
            }

            else if (personLevel == 2)
            {
                player_.SetPlayerJump(Convert.ToInt32(Convert.ToDouble(Screen.PrimaryScreen.Bounds.Height) / diametr1)); 
                player_.SetPlayerSpeed(Convert.ToInt32(Convert.ToDouble(Screen.PrimaryScreen.Bounds.Width) / diametr2)); 
                player_.SetPlayerDamage(15); 
                player_.SetPlayerHP(150); 
                player_.SetPlayerWeapon(Properties.Resources.стрела_обычная); 
            }

            else if (personLevel == 3)
            {
                player_.SetPlayerJump(Convert.ToInt32(Convert.ToDouble(Screen.PrimaryScreen.Bounds.Height) / diametr1)); 
                player_.SetPlayerSpeed(Convert.ToInt32(Convert.ToDouble(Screen.PrimaryScreen.Bounds.Width) / diametr3)); 
                player_.SetPlayerDamage(10); 
                player_.SetPlayerHP(200);
                player_.SetPlayerWeapon(Properties.Resources.урон_камнем); 
            }

            player_.SetVragDamage(10, Scripts.Player.Types.VRAG_LVL1); 
            player_.SetVragDamage(10, Scripts.Player.Types.VRAG_LVL1);
            player_.SetVragDamage(20, Scripts.Player.Types.VRAG_LVL2);
            player_.SetVragDamage(25, Scripts.Player.Types.VRAG_LVL3);
            player_.SetVragDamage(15, Scripts.Player.Types.VRAG_LVL4);

            player_.SetVragDamage(200, Scripts.Player.Types.VRAG_STATIC_LVL1);
            player_.SetVragDamage(200, Scripts.Player.Types.VRAG_STATIC_LVL1);
            player_.SetVragDamage(25, Scripts.Player.Types.VRAG_STATIC_LVL2);     

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
            player_.AddObject(zemla_dop, Scripts.Player.Types.ZEMLA);     

            player_.AddObject(lesnica_1, Scripts.Player.Types.LESNICA);
            player_.AddObject(lesnica_2, Scripts.Player.Types.LESNICA);
            player_.AddObject(lesnica_3, Scripts.Player.Types.LESNICA);

            player_.AddObject(wall_1, Scripts.Player.Types.WALL);
            player_.AddObject(wall_2, Scripts.Player.Types.WALL);
            player_.AddObject(wall_3, Scripts.Player.Types.WALL);
            player_.AddObject(wall_4, Scripts.Player.Types.WALL);
            player_.AddObject(wall_5, Scripts.Player.Types.WALL);
            player_.AddObject(wall_6, Scripts.Player.Types.WALL);
            player_.AddObject(wall_7, Scripts.Player.Types.WALL);
            player_.AddObject(wall_8, Scripts.Player.Types.WALL);
          
            player_.AddObject(safe_1, Scripts.Player.Types.SAFE);

            player_.AddObject(sunduk_1, Scripts.Player.Types.SUNDUK);

            player_.AddObject(vrag_lvl1_1, Scripts.Player.Types.VRAG_LVL1);
            player_.AddObject(vrag_lvl1_2, Scripts.Player.Types.VRAG_LVL1);
            player_.AddObject(vrag_lvl2_1, Scripts.Player.Types.VRAG_LVL2);
            player_.AddObject(vrag_lvl3_1, Scripts.Player.Types.VRAG_LVL3);
            player_.AddObject(vrag_lvl4_1, Scripts.Player.Types.VRAG_LVL4);          
            
            player_.AddObject(vrag_static_lvl1_1, Scripts.Player.Types.VRAG_STATIC_LVL1);
            player_.AddObject(vrag_static_lvl1_2, Scripts.Player.Types.VRAG_STATIC_LVL1);
            player_.AddObject(vrag_static_lvl2_1, Scripts.Player.Types.VRAG_STATIC_LVL2);

            player_.AddObject(border_1, Scripts.Player.Types.BORDER);
            player_.AddObject(border_2, Scripts.Player.Types.BORDER);
            player_.AddObject(border_3, Scripts.Player.Types.BORDER);
            player_.AddObject(border_4, Scripts.Player.Types.BORDER);
            player_.AddObject(border_5, Scripts.Player.Types.BORDER);
            player_.AddObject(border_6, Scripts.Player.Types.BORDER);
            player_.AddObject(border_7, Scripts.Player.Types.BORDER);
            player_.AddObject(border_8, Scripts.Player.Types.BORDER);
           
            player_.AddObject(portal_1, Scripts.Player.Types.PORTAL);
            
            List<Image> vrag1 = player_.LoadSpritesFromDirectory(player_.GetCurrentDirectory("Sprites\\level1\\vrag1"), 42);
            List<Image> vrag2 = player_.LoadSpritesFromDirectory(player_.GetCurrentDirectory("Sprites\\level1\\vrag2"), 39);
            List<Image> vrag3 = player_.LoadSpritesFromDirectory(player_.GetCurrentDirectory("Sprites\\level1\\vrag3"), 35);
            List<Image> vrag4 = player_.LoadSpritesFromDirectory(player_.GetCurrentDirectory("Sprites\\level1\\vrag4"), 29);
            List<Image> vrag_s5 = player_.LoadSpritesFromDirectory(player_.GetCurrentDirectory("Sprites\\level1\\vrag5"), 16);

            player_.SetSpriteForVragByType(vrag1, Scripts.Player.Types.VRAG_LVL1);
            player_.SetSpriteForVragByType(vrag2, Scripts.Player.Types.VRAG_LVL2);
            player_.SetSpriteForVragByType(vrag3, Scripts.Player.Types.VRAG_LVL3);
            player_.SetSpriteForVragByType(vrag4, Scripts.Player.Types.VRAG_LVL4);
            player_.SetSpriteForVragByType(vrag_s5, Scripts.Player.Types.VRAG_STATIC_LVL2);

            player_.SetSpriteAnimateForVragByType(29, 42, 0, Scripts.Player.Types.VRAG_LVL1);
            player_.SetSpriteAnimateForVragByType(28, 39, 0, Scripts.Player.Types.VRAG_LVL2);
            player_.SetSpriteAnimateForVragByType(24, 35, 0, Scripts.Player.Types.VRAG_LVL3);
            player_.SetSpriteAnimateForVragByType(17, 29, 0, Scripts.Player.Types.VRAG_LVL4);
            player_.SetSpriteAnimateForVragByType(1, 4, 5, Scripts.Player.Types.VRAG_STATIC_LVL2);    
            player_.DebugDraw(false);

            player_.Start();
        }
       
        private void Level1_FormClosing(Object sender, FormClosingEventArgs e)
        {           

        }
       
        void Loader()
        {            
            this.Invoke(new Action(() =>
            {
                Level2 f2 = new Level2(Convert.ToInt32(HP.Text));
                f2.Show();
                this.Hide();
            }));
        }
        
        private void Level1_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            player_.SetAudioEnable(false);
        }

        Size screen = new Size(1920, 1080);

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
            float b = (float) Convert.ToDouble(Convert.ToDouble(Screen.PrimaryScreen.Bounds.Width) / (Convert.ToDouble(screen.Width) / Convert.ToDouble(obj.Font.Size)));

            obj.Font = new Font(obj.Font.Name, b, obj.Font.Style);
        }
        private void Level1_Load(object sender, EventArgs e)
        {
            lab(HP);
            pic(zemla_1);
            pic(zemla_2);
            pic(zemla_3);
            pic(zemla_4);
            pic(zemla_5);
            pic(zemla_6);
            pic(zemla_7);
            pic(zemla_8);
            pic(zemla_9);
            pic(zemla_10);
            pic(zemla_dop);
            pic(border_1);
            pic(border_2);
            pic(border_3);
            pic(border_4);
            pic(border_5);
            pic(border_6);
            pic(border_7);
            pic(border_8);
            pic(lesnica_1);
            pic(lesnica_2);
            pic(lesnica_3);            
            pic(portal_1);
            pic(safe_1);
            pic(sunduk_1);
            pic(vrag_lvl1_1);
            pic(vrag_lvl1_2);
            pic(vrag_lvl2_1);
            pic(vrag_lvl3_1);
            pic(vrag_lvl4_1);
            pic(vrag_static_lvl1_1);
            pic(vrag_static_lvl1_2);
            pic(vrag_static_lvl2_1);
            pic(wall_1);
            pic(wall_2);
            pic(wall_3);
            pic(wall_4);
            pic(wall_5);
            pic(wall_6);
            pic(wall_7);
            pic(wall_8);
        }

        private void Level1_FormClosed(object sender, FormClosedEventArgs e)
        {          
            
        }
    }
}
