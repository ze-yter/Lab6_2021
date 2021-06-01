using Microsoft.VisualStudio.TestTools.UnitTesting;
using Game.Scripts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using Game.Levels;
using Game;

namespace Game.Scripts.Tests
{
    [TestClass()]
    public class PlayerTests
    {
        Player player = new Player(new PictureBox());
        Outro outro = new Outro();
        double diametr1 = 1080d / 35d;
        double diametr2 = 1920d / 5d;

        [TestMethod()]
        public void SetPlayerHp()
        {
            player.SetPlayerHP(100);
            int need = 100;
            int real = player.GetPlayerHP();
            Assert.AreEqual(need, real);
        }

        [TestMethod()]
        public void LeftWallCheck()
        {
            player.SetPlayerJump(Convert.ToInt32(Convert.ToDouble(Screen.PrimaryScreen.Bounds.Height) / diametr1));
            player.SetPlayerSpeed(Convert.ToInt32(Convert.ToDouble(Screen.PrimaryScreen.Bounds.Width) / diametr2));
            player.SetPosPlayer(0, 200);
            player.SetKeyDown(Convert.ToInt32('A'));
            Thread.Sleep(100);
            player.SetKeyUp(65);
            int real = player.GetPosPlayer().X;
            int need = 0;
            Assert.AreEqual(need, real);
        }

        [TestMethod()]

        public void RightWallCheck()
        {
            player.SetPlayerJump(Convert.ToInt32(Convert.ToDouble(Screen.PrimaryScreen.Bounds.Height) / diametr1));
            player.SetPlayerSpeed(Convert.ToInt32(Convert.ToDouble(Screen.PrimaryScreen.Bounds.Width) / diametr2));
            player.SetPosPlayer(Screen.PrimaryScreen.Bounds.Width, 200);
            player.SetKeyDown(Convert.ToInt32('D'));
            Thread.Sleep(100);
            player.SetKeyUp(Convert.ToInt32('D'));
            int real = player.GetPosPlayer().X;
            int need = Screen.PrimaryScreen.Bounds.Width;
            Assert.AreEqual(need, real);
        }

        [TestMethod()]

        public void DeathCheck()
        {
            player.SetPlayerHP(0);
            int real = player.deathcheck();
            int need = 1;
            Assert.AreEqual(need, real);
        }

        [TestMethod()]

        public void DamageCheck()
        {
            player.SetPlayerHP(100);
            player.damage();
            int need = 90;
            int real = player.GetPlayerHP();
            Assert.AreEqual(need, real);
        }

        [TestMethod()]

        public void NextLevelCheck_NotEnough()
        {
            player.SetMaxSunduks(3);
            player.SundukOpen();
            bool real = player.NextLevelCheck();
            bool need = false;
            Assert.AreEqual(need, real);
        }

        [TestMethod()]

        public void NextLevelCheck_Enough()
        {
            player.SetMaxSunduks(1);
            player.SundukOpen(1);
            bool real = player.NextLevelCheck();
            bool need = true;
            Assert.AreEqual(need, real);
        }

        [TestMethod()]

        
        public void ExitButtonCheck()
        {
            bool real = outro.Lab();
            bool need = false;
            Assert.AreEqual(need, real);
        }
    }
}