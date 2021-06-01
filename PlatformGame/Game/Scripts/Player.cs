using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Threading;
using System.IO;


namespace Game.Scripts
{
    public class Player
    {
        public PictureBox currentPlayer;
        private Sprite playerSprite;

        private Image weaponsImage;

        public Label UI_HP;

        public delegate void Event();
        public delegate bool EventBool();
        public delegate void EventControl(Control control);
        public delegate void EventPlayerUpdate(int HP);
        public delegate bool EventBoolVrag(Vrag vrag);
        public event Event NextLevel;
        public event EventControl AddControl;
        public event EventControl RemoveControl;
        public event EventPlayerUpdate PlayerUpdate;
        public event Event PlayerButton1;
        public event Event PlayerButton2;

        public event EventBoolVrag VragCollisWithWeapon;
        public event EventBool VragCollisWithPlayer;

        private static Size window = Screen.PrimaryScreen.Bounds.Size;

        private WMPLib.WindowsMediaPlayer Audio = new WMPLib.WindowsMediaPlayer();

        private int HP = 100;
        private int Damage = 20;
        private int Speed = 5;
        private int Jump = 45;
        public int death = 0;
        private int levelSunduk = 0;
        private int openSunduk = 0;

        private int damageTime = 0;

        private int[] DamageByVrag = new int[25];

        private bool finish = false;

        public enum Types
        {            
            LESNICA,
            WATER,
            ZEMLA,
            BORDER,
            WALL,
            SAFE,

            HEALTH,
            SUNDUK,

            VRAG_LVL1,
            VRAG_LVL2,
            VRAG_LVL3,
            VRAG_LVL4,
            VRAG_LVL5,
            VRAG_LVL6,
            VRAG_LVL7,
            VRAG_LVL8,

            VRAG_STATIC_LVL1,
            VRAG_STATIC_LVL2,
            VRAG_STATIC_LVL3,
            VRAG_STATIC_LVL4,

            PORTAL
        }

        private List<PictureBox> zemla = new List<PictureBox> { };
        private List<PictureBox> lesnica = new List<PictureBox> { };
        private List<PictureBox> water = new List<PictureBox> { };
        private List<PictureBox> border = new List<PictureBox> { };
        private List<PictureBox> wall = new List<PictureBox> { };
        private List<PictureBox> safe = new List<PictureBox> { };
        
        private List<PictureBox> health = new List<PictureBox> { };
        private List<PictureBox> sunduk = new List<PictureBox> { };

        private List<Vrag> vrag = new List<Vrag> { };
        private List<Weapons> weapons = new List<Weapons> { };

        private List<PictureBox> portal = new List<PictureBox> { };

        private int widthAccuracy = 0;
        private int heightAccuracy = 5;

        public void SundukOpen(int a)
        {
            openSunduk = a;
        }

        public void SundukOpen()
        {
            openSunduk++;
        }

        public void AddObject(PictureBox obj, Types type)
        {
            if (type == Types.ZEMLA)
                zemla.Add(obj);
            else if (type == Types.LESNICA)
                lesnica.Add(obj);
            else if (type == Types.WATER)
                water.Add(obj);
            else if (type == Types.BORDER)
                border.Add(obj);
            else if (type == Types.WALL)
                wall.Add(obj);
            else if (type == Types.SAFE)
                safe.Add(obj);

            else if (type == Types.HEALTH)
                health.Add(obj);
            else if (type == Types.SUNDUK)
                sunduk.Add(obj);

            else if (type == Types.VRAG_LVL1 || type == Types.VRAG_LVL2 || type == Types.VRAG_LVL3 || type == Types.VRAG_LVL4
                || type == Types.VRAG_LVL5 || type == Types.VRAG_LVL6 || type == Types.VRAG_LVL7 || type == Types.VRAG_LVL8
               || type == Types.VRAG_STATIC_LVL1 || type == Types.VRAG_STATIC_LVL2 || type == Types.VRAG_STATIC_LVL3 || type == Types.VRAG_STATIC_LVL4)
                vrag.Add(new Vrag(obj, type));
            

            else if (type == Types.PORTAL)
                portal.Add(obj);
        }

        public void SetPlayerSpeed(int speed)
        {
            this.Speed = speed;
        }

        public void SetPlayerHP(int HP)
        {
            this.HP = HP;
        }

        public void PlusPlayerHP(int HP)
        {
            this.HP += HP;
        }

        public void MinusPlayerHP(int HP)
        {
            if (damageTime == 0)
            {
                this.HP = ((this.HP -= HP) < 0) ? this.HP = 0 : this.HP;
                damageTime = 100;
            }
            else
                damageTime--;
        }

        public void damage()
        {
            this.HP -= 10;
        }

        public bool NextLevelCheck()
        {
            return levelSunduk == openSunduk;
        }

        public int deathcheck()
        {
            if (HP == 0)
                death = 1;
            else
                death = 0;
            return death;
        }

        public void SetPlayerDamage(int damage)
        {
            this.Damage = damage;
        }

        public void SetPlayerJump(int jump)
        {
            this.Jump = jump;
        }

        public void SetVragDamage(int damage, Types type)
        {
            DamageByVrag[(int)type] = damage;
        }

        public void SetMaxSunduks(int count)
        {
            levelSunduk = count;
        }

        public int GetPlayerHP()
        {
            return HP;
        }

        public bool GetCollisionByType(Control obj, Types type, ref PictureBox objItem)
        {
            bool collision = false;

            List<PictureBox> list = new List<PictureBox> { };

            if (type == Types.ZEMLA)
                list = zemla;
            else if (type == Types.LESNICA)
                list = lesnica;
            else if (type == Types.WATER)
                list = water;
            else if (type == Types.BORDER)
                list = border;
            else if (type == Types.WALL)
                list = wall;
            else if (type == Types.SAFE)
                list = safe;

            else if (type == Types.HEALTH)
                list = health;
            else if (type == Types.SUNDUK)
                list = sunduk;
         
            else if (type == Types.PORTAL)
                list = portal;           


            if (list.Count != 0)
            {
                foreach (var item in list)
                {
                    if (GetCollision(obj, item))
                    {
                        collision = true;
                        objItem = item;
                        break;
                    }
                }
            }

            return collision;
        }

        public bool GetCollisionByType(Control obj, Types type)
        {
            PictureBox objItem = null;
            return GetCollisionByType(obj, type, ref objItem);
        }

        public bool GetCollisionByVrags(Control obj, Types type, ref Vrag vragItem)
        {
            bool collision = false;

            if (vrag.Count != 0)
            {
                foreach (var item in vrag)
                {
                    if (item.level != type)
                        continue;

                    if (GetCollision(obj, item.obj))
                    {
                        collision = true;
                        vragItem = item;
                        break;
                    }
                }
            }

            return collision;
        }

        public bool GetCollisionByVrags(Control obj, Types type)
        {
            Vrag vrag = null;
            return GetCollisionByVrags(obj, type, ref vrag);
        }

        public bool GetCollision(Control obj, Control obj2)
        {
            return obj.Bounds.IntersectsWith(new Rectangle(obj2.Bounds.X + widthAccuracy, obj2.Bounds.Y + heightAccuracy, obj2.Bounds.Width, obj2.Bounds.Height));
        }

        public void SetAudioVolume(int volume)
        {
            Audio.settings.volume = volume;
        }

        public void SetAudioMusic(string music)
        {
            Audio.URL = music;
        }

        public void SetAudioEnable(bool enable)
        {
            if (enable)
                Audio.controls.play();
            else
                Audio.controls.stop();
        }

        public int GetAudioVolume()
        {
            return Audio.settings.volume;
        }

        public class Sprite
        {
            int current;
            int currentSkip = 0;
            public bool mirror = false;
            PictureBox obj;
            List<Image> sprites = new List<Image> { };            

            public Sprite(List<Image> sprites, PictureBox obj, int current = 0)
            {
                this.current = 0;
                this.obj = obj;
                this.sprites = sprites;
                Update();
            }
           
            public Sprite(Image[] sprites, PictureBox obj, int current = 0)
            {
                this.current = 0;
                this.obj = obj;
                for(var i = 0; i < sprites.Length; i++)
                {
                    this.sprites.Add(sprites[i]);
                }
                Update();
            }

            public void Update()
            {
                if (current >= 0 && sprites.Count > 0)
                {
                    try
                    {
                        if (obj == null)
                            return;

                        obj.Invoke(new Action(() =>
                        {
                            try
                            {
                                obj.Image = sprites[current];                               
                                obj.Update();
                            }

                            catch { }
                        }));
                    }

                    catch { }
                }
            }

            public void Animate(int min, int max, int skip = 0)
            {
                min--;
                max--;

                if (current < min || current > max)
                    current = min;

                if (currentSkip < 0 || currentSkip > skip)
                    currentSkip = 0;

                Update();

                if (currentSkip == 0)
                    current++;

                currentSkip++;
            }

            public void MirrorSprite(bool mirror)
            {
                if (this.mirror == mirror)
                    return;

                this.mirror = mirror;

                try
                {
                    for (var i = 0; i < sprites.Count; i++)
                        sprites[i].RotateFlip(RotateFlipType.Rotate180FlipY);
                }

                catch { }
            }

            public Image GetImage()
            {
                return obj.Image;
            }

        }

        public class Vrag
        {
            public int skip = 0;
            public int impuls;
            public int HP;
            public Types level;
            public PictureBox obj;
            private Sprite spriteVrag;

            private List<int> Walk = new List<int> { };

            public Vrag(PictureBox obj, Types level)
            {
                this.obj = obj;
                this.level = level;
                this.HP = 100;
                this.impuls = 8;
                DebugDraw(false);
            }

            public void SetSprite(List<Image> sprites)
            {
                var newSprites = new List<Image> { };

                foreach (var item in sprites)
                {
                    newSprites.Add((Image)item.Clone());
                }

                spriteVrag = new Sprite(newSprites, obj);
            }
          
            public void DebugDraw(bool draw)
            {
                if (!draw)
                {
                    obj.BackColor = Color.Transparent;
                    obj.Update();
                }
            }

            public void SetAnimate(int min, int max, int skip = 0)
            {
                Walk = new List<int> { min, max, skip };
            }

            public void Animate()
            {
                if (spriteVrag == null || Walk.Count < 3)
                    return;

                spriteVrag.Animate(Walk[0], Walk[1], Walk[2]);
            }

            public void MinusVragHP(int HP)
            {
                this.HP = ((this.HP -= HP) < 0) ? this.HP = 0 : this.HP;
            }

            public void SetHP(int HP)
            {
                this.HP = HP;
            }

            public Sprite GetSprite()
            {
                return spriteVrag;
            }

            public bool GetSkipUpdate()
            {
                if (skip == 0)
                    return false;
                skip--;
                return true;
            }

        };

        public void SetVragHP(int HP, Types type)
        { 
            foreach (var item in vrag.ToArray())
            {
                if (item.level == type)
                {
                    item.SetHP(HP);
                }
            }
        }

        public void SetSpriteAnimateForVragByType(int min, int max, int skip, Types type)
        {
            foreach (var item in vrag.ToArray())
            {
                if (item.level == type)
                {
                    item.SetAnimate(min, max, skip);
                }
            }
        }

        public void SetSpriteForVragByType(List<Image> sprites, Types type)
        {

            foreach(var item in vrag.ToArray())
            {
                if (item.level == type)
                {
                    item.SetSprite(sprites);                    
                }
            }

        }

        private void RemoveVrag(Vrag vrag)
        {
            RemoveControl(vrag.obj);
            this.vrag.Remove(vrag);
        }
       
        private void UpdateVrag(Vrag vrag)
        {
            if (vrag.GetSkipUpdate())
                return;

            vrag.Animate();

            if (vrag.HP == 0)
            {
                RemoveVrag(vrag);
                return;
            }

            if (vrag.level == Types.VRAG_STATIC_LVL1 || vrag.level == Types.VRAG_STATIC_LVL2 || vrag.level == Types.VRAG_STATIC_LVL3 || vrag.level == Types.VRAG_STATIC_LVL4)
                return;

            int posX = GetPosObject(vrag.obj).X + vrag.impuls;
            int posY = GetPosObject(vrag.obj).Y;

            try
            {
                vrag.obj.Invoke(new Action(() => { SetPosObject(vrag.obj, posX, posY); }));
            }

            catch { }

            if (GetCollisionByType(vrag.obj, Types.BORDER))
            {
                vrag.impuls = vrag.impuls * -1;
                
                if (vrag.GetSprite() != null)
                    vrag.obj.Invoke(new Action(() => { vrag.GetSprite().MirrorSprite((vrag.impuls > 0) ? false : true); }));
            }

        }

        class Weapons
        {
            public int timeAlive = 10;
            public int currentTime = 0;
            public int impuls = 0;
            public PictureBox obj;
          
            public Weapons(int impuls, int timeAlive, Point pos, Image image)
            {
                this.impuls = impuls;
                this.timeAlive = timeAlive;

                obj = new PictureBox();
                obj.Image = image;
                obj.Location = pos;
                obj.SizeMode = PictureBoxSizeMode.Zoom;
                obj.BackColor = Color.Transparent;
                obj.Name = "Magiya";
                obj.Size = new Size(44, 44);
                obj.Update();
            }    
        };

        private void AddWeapons(int impuls, int timeAlive)
        {
            int posX = GetPosPlayer().X;
            int posY = GetPosPlayer().Y;
            var weapon = new Weapons(impuls, timeAlive, new Point(posX + impuls*2, posY), weaponsImage);
            weapons.Add(weapon);
            AddControl(weapon.obj);
        }

        private void RemoveWeapons(Weapons weapon)
        {
           RemoveControl(weapon.obj);
           weapons.Remove(weapon);
        }

        private void UpdateWeapons(Weapons weapons)
        {
            int posX = GetPosObject(weapons.obj).X + weapons.impuls;
            int posY = GetPosObject(weapons.obj).Y;

            try
            {
                weapons.obj.Invoke(new Action(() => { SetPosObject(weapons.obj, posX, posY); }));
            }

            catch { }

            Vrag vrag = null;

            if (GetCollisionByVrags(weapons.obj, Types.VRAG_LVL1, ref vrag))
            {
                RemoveWeapons(weapons);
            }

            else if (GetCollisionByVrags(weapons.obj, Types.VRAG_LVL2, ref vrag))
            {
                RemoveWeapons(weapons);
            }

            else if (GetCollisionByVrags(weapons.obj, Types.VRAG_LVL3, ref vrag))
            {
                RemoveWeapons(weapons);
            }

            else if (GetCollisionByVrags(weapons.obj, Types.VRAG_LVL4, ref vrag))
            {
                RemoveWeapons(weapons);
            }

            else if (GetCollisionByVrags(weapons.obj, Types.VRAG_LVL5, ref vrag))
            {
                RemoveWeapons(weapons);
            }

            else if (GetCollisionByVrags(weapons.obj, Types.VRAG_LVL6, ref vrag))
            {
                RemoveWeapons(weapons);
            }

            else if (GetCollisionByVrags(weapons.obj, Types.VRAG_LVL7, ref vrag))
            {
                RemoveWeapons(weapons);
            }

            else if (GetCollisionByVrags(weapons.obj, Types.VRAG_LVL8, ref vrag))
            {
                RemoveWeapons(weapons);
            }

            else if (GetCollisionByVrags(weapons.obj, Types.VRAG_STATIC_LVL1, ref vrag))
            {
                RemoveWeapons(weapons);
            }

            else if (GetCollisionByVrags(weapons.obj, Types.VRAG_STATIC_LVL2, ref vrag))
            {
                RemoveWeapons(weapons);
            }

            else if (GetCollisionByVrags(weapons.obj, Types.VRAG_STATIC_LVL3, ref vrag))
            {
                RemoveWeapons(weapons);
            }

            else if (GetCollisionByVrags(weapons.obj, Types.VRAG_STATIC_LVL4, ref vrag))
            {
                RemoveWeapons(weapons);
            }

            if (vrag != null)
            {
                if (VragCollisWithWeapon(vrag))
                {
                    vrag.MinusVragHP(Damage);
                }
            }

            weapons.timeAlive--;

            if (weapons.timeAlive < 0)
            {
                weapons.timeAlive = 0;
                RemoveWeapons(weapons);
            }     
        }

        public void SetPlayerWeapon(Image image)
        {
            weaponsImage = image;
        }

        public void SetUI(Label UI_HP)
        {
            this.UI_HP = UI_HP;
        }

        public bool[] keys = new bool[2000];

        public void SetKeyDown(int key)
        {
            keys[key] = true;
        }

        public void SetKeyUp(int key)
        {
            keys[key] = false;
        }

        public void SetKeyMouseUp(MouseButtons button)
        {
            int i = 0;

            if (button == MouseButtons.Left)
                i = 1;
            else if (button == MouseButtons.Right)
                i = 2;
            else if (button == MouseButtons.Middle)
                i = 4;

            SetKeyUp(i);
        }
        public void SetKeyMouseDown(MouseButtons button)
        {
            int i = 0;

            if (button == MouseButtons.Left)
                i = 1;
            else if (button == MouseButtons.Right)
                i = 2;
            else if (button == MouseButtons.Middle)
                i = 4;

            SetKeyDown(i);
        }

        public bool GetKeyPress(int key)
        {          
            return keys[key];
        }

        public Point GetPosPlayer()
        {
            return currentPlayer.Location;
        }

        public void SetPosPlayer(int posX, int posY)
        {
            currentPlayer.Location = new Point(posX, posY);
        }

        public Point GetPosObject(Control obj)
        {
            return obj.Location;
        }

        public void SetPosObject(Control obj, int posX, int posY)
        {
            obj.Location = new Point(posX, posY);
        }

        public void FixBackGroundImage(Control image, Control background)
        {
            image.Parent = background;           
        }

        public void HiddenDraw(List<PictureBox> items)
        {
            foreach (var item in items)
            {
                item.BackColor = Color.Transparent;
                item.Update();
            }
        }

        public void DebugDraw(bool draw)
        {
            if (!draw)
            {               
                HiddenDraw(zemla);
                HiddenDraw(lesnica);
                HiddenDraw(water);
                HiddenDraw(border);
                HiddenDraw(wall);
                HiddenDraw(safe);

                HiddenDraw(health);
                HiddenDraw(sunduk);
               
                HiddenDraw(portal);
            }
        }

        public string GetCurrentDirectory()
        {
            return Directory.GetCurrentDirectory();
        }

        public string GetCurrentDirectory(string directory)
        {
            return Directory.GetCurrentDirectory() + "\\" + directory + "\\";
        }
      
        public List<Image> LoadSpritesFromDirectory(string directory, int countSprites, bool mirrorSprite = false)
        {
            List<Image> list = new List<Image> { };

            try
            {

                Image image = null;

                for (var i = 1; i <= countSprites; i++)
                {
                    image = Image.FromFile(directory + i + ".png");

                    if (mirrorSprite)
                        image.RotateFlip(RotateFlipType.Rotate180FlipY);

                    list.Add(image);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Sprites don't found in " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return list;
        }

        public static void ShowCursor()
        {
            Cursor.Clip = new Rectangle(0, 0, window.Width, window.Height);
            Cursor.Show();
        }
      
        public static void HideCursor()
        {
            Cursor.Clip = new Rectangle(0, 0, 1, 1);
            Cursor.Hide();
        }

        public Player(PictureBox currentPlayer)
        {           
            this.currentPlayer = currentPlayer;

            SetAudioVolume(20);

            Audio.settings.playCount = 1000;

            List<Image> images = LoadSpritesFromDirectory(GetCurrentDirectory("Sprites"), 9);

            this.playerSprite = new Sprite(images, currentPlayer, 1);

            SetPlayerWeapon(Properties.Resources.урон_магией);

            SetVragDamage(10, Types.VRAG_LVL1);
            SetVragDamage(20, Types.VRAG_LVL2);
            SetVragDamage(30, Types.VRAG_LVL3);
            SetVragDamage(40, Types.VRAG_LVL4);
            SetVragDamage(50, Types.VRAG_LVL5);
            SetVragDamage(60, Types.VRAG_LVL6);
            SetVragDamage(70, Types.VRAG_LVL7);
            SetVragDamage(80, Types.VRAG_LVL8);

            SetVragDamage(10, Types.VRAG_STATIC_LVL1);
            SetVragDamage(20, Types.VRAG_STATIC_LVL2);
            SetVragDamage(30, Types.VRAG_STATIC_LVL3);
            SetVragDamage(40, Types.VRAG_STATIC_LVL4);
        }

        public void Start()
        {
            HideCursor();

            Thread thr = new Thread(UILoop);
            thr.Start();

            Thread thr2 = new Thread(SecondLoop);
            thr2.Start();

            Thread thr3 = new Thread(ThirdLoop);
            thr3.Start();

            Thread thr4 = new Thread(MainLoop);
            thr4.Start();
        }

        private void MainLoop()
        {
            int posX = GetPosPlayer().X;
            int posY = GetPosPlayer().Y;

            int gravity = 0;
            bool space = false;

            PictureBox item = null;

            while (!finish)
            {
                if (HP == 0)
                    playerSprite.Animate(7, 8);
                    
                PlayerUpdate(HP);

                if (HP == 0)
                {
                    finish = true;
                    break;
                }

                if (GetCollisionByType(currentPlayer, Types.LESNICA))
                {
                    if (GetKeyPress(87)) // W
                    {
                        posY -= Speed;
                    }
                    if (GetKeyPress(83)) // S
                    {
                        posY += Speed;
                    }
                }

                else if (!GetCollisionByType(currentPlayer, Types.ZEMLA))
                {
                    gravity += 2;
                }

                else
                {
                    gravity = 0;
                    space = false;
                }

                if (GetCollisionByType(currentPlayer, Types.HEALTH, ref item))
                {
                    if (HP <= 100)
                    {
                        SetPlayerHP(HP + 5);
                        RemoveControl(item);
                        health.Remove(item);
                    }
                }

                if (GetKeyPress(65)) // A
                {
                    if (posX > 0)
                    {
                        posX -= Speed;
                        playerSprite.Animate(1, 6, 5);
                        playerSprite.MirrorSprite(true);
                    }
                }

                if (GetKeyPress(68)) // D
                {
                    if (posX < window.Width - currentPlayer.Bounds.Size.Width)
                    {
                        posX += Speed;
                        playerSprite.Animate(1, 6, 5);
                        playerSprite.MirrorSprite(false);
                    }
                }

                if (GetKeyPress(69)) // E
                {
                    if (GetCollisionByType(currentPlayer, Types.SUNDUK, ref item))
                    {
                        item.Image = Properties.Resources._23;
                        Thread.Sleep(100);
                        item.Image = Properties.Resources._32;
                        Thread.Sleep(100);
                        item.Image = Properties.Resources._41;
                        Thread.Sleep(100);
                        item.Image = Properties.Resources._52;
                        Thread.Sleep(100);
                        item.Image = Properties.Resources._6;
                        Thread.Sleep(100);
                        item.Image = Properties.Resources._7;
                        Thread.Sleep(800);
                        item.Image = Properties.Resources._8;
                        openSunduk++;
                    }
                }

                if (GetKeyPress(32) && !space) // SPACE
                {
                    gravity = -Jump;                   
                    space = true;
                }

                if (GetKeyPress(49)) // 1
                {
                    PlayerButton1();
                }

                if (GetKeyPress(50)) // 2
                {
                    PlayerButton2();
                }

                if (!GetCollisionByType(currentPlayer, Types.SAFE))
                {
                    if (GetKeyPress(1)) 
                    {
                        if (weapons.Count < 3)
                        {
                            AddWeapons(playerSprite.mirror ? -10 : 10, 55);
                            Thread.Sleep(500);
                        }
                    }

                    if (VragCollisWithPlayer())
                    {
                        if (GetCollisionByVrags(currentPlayer, Types.VRAG_LVL1))
                            MinusPlayerHP(DamageByVrag[(int)Types.VRAG_LVL1]);
                        if (GetCollisionByVrags(currentPlayer, Types.VRAG_LVL2))
                            MinusPlayerHP(DamageByVrag[(int)Types.VRAG_LVL2]);
                        if (GetCollisionByVrags(currentPlayer, Types.VRAG_LVL3))
                            MinusPlayerHP(DamageByVrag[(int)Types.VRAG_LVL3]);
                        if (GetCollisionByVrags(currentPlayer, Types.VRAG_LVL4))
                            MinusPlayerHP(DamageByVrag[(int)Types.VRAG_LVL4]);
                        if (GetCollisionByVrags(currentPlayer, Types.VRAG_LVL5))
                            MinusPlayerHP(DamageByVrag[(int)Types.VRAG_LVL5]);
                        if (GetCollisionByVrags(currentPlayer, Types.VRAG_LVL6))
                            MinusPlayerHP(DamageByVrag[(int)Types.VRAG_LVL6]);
                        if (GetCollisionByVrags(currentPlayer, Types.VRAG_LVL7))
                            MinusPlayerHP(DamageByVrag[(int)Types.VRAG_LVL7]);
                        if (GetCollisionByVrags(currentPlayer, Types.VRAG_LVL8))
                            MinusPlayerHP(DamageByVrag[(int)Types.VRAG_LVL8]);

                        if (GetCollisionByVrags(currentPlayer, Types.VRAG_STATIC_LVL1))
                            MinusPlayerHP(DamageByVrag[(int)Types.VRAG_STATIC_LVL1]);
                        if (GetCollisionByVrags(currentPlayer, Types.VRAG_STATIC_LVL2))
                            MinusPlayerHP(DamageByVrag[(int)Types.VRAG_STATIC_LVL2]);
                        if (GetCollisionByVrags(currentPlayer, Types.VRAG_STATIC_LVL3))
                            MinusPlayerHP(DamageByVrag[(int)Types.VRAG_STATIC_LVL3]);
                        if (GetCollisionByVrags(currentPlayer, Types.VRAG_STATIC_LVL4))
                            MinusPlayerHP(DamageByVrag[(int)Types.VRAG_STATIC_LVL4]);
                    }
                }

                if (GetCollisionByType(currentPlayer, Types.WALL))
                {
                    gravity = 0;
                    posY += 10;
                }

                posY += gravity;

                try
                {
                    currentPlayer.Invoke(new Action(() => { SetPosPlayer(posX, posY); }));
                }
                catch { }

                if (gravity > 0) gravity--;
                if (gravity < 0) gravity++;

                if (GetCollisionByType(currentPlayer, Types.PORTAL))
                {
                    if (NextLevel != null && !finish && openSunduk >= levelSunduk)
                    {
                        finish = true;
                        NextLevel.Invoke();
                    }
                }

                Thread.Sleep(15);
            }
        }
         
        private void SecondLoop()
        {
            while (!finish)
            {
                if (vrag.Count != 0)
                {
                    foreach (var item in vrag.ToArray())
                    {
                        UpdateVrag(item);                      
                        Thread.Sleep(1);
                    }
                }
            }
        }

        private void ThirdLoop()
        {
            while (!finish)
            {
                if (weapons.Count != 0)
                {
                    foreach (var item in weapons.ToArray())
                    {
                        UpdateWeapons(item);                        
                        Thread.Sleep(1);
                    }
                }
            }
        }

        private async void UILoop()
        {
            while (!finish)
            {
                try
                {
                    if (UI_HP != null)
                        UI_HP.Invoke(new Action(() => { UI_HP.Text = HP.ToString(); }));
                }

                catch { }           
                await Task.Delay(10);
            }
        }
    }
}
