using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace game_arg.UnitTest1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Form1 form = new Form1();
            MapController map = new MapController();
            Player player = new Player();
            int hp = player.lives--;

            form.Update();
            Assert.AreNotEqual(hp, player.lives);
        }
        [TestMethod]
        public void TestMethod2()
        {
            Form1 form = new Form1();
            MapController map = new MapController();
            Physics ph = new Physics();
            Player player = new Player();
            Assert.IsTrue(ph.IsCollide(player, map, 30, 30, 30, 30, form.score));
        }
        [TestMethod]
        public void TestMethod3()
        {
            Form1 form = new Form1();
            MapController map = new MapController();
            Player player = new Player();
            bool pf = player.platformX + 2 < MapController.mapWidth - 1;
            Assert.IsTrue(pf);
        }
        [TestMethod]
        public void TestMethod4()
        {
            Form1 form = new Form1();
            MapController map = new MapController();
            Player player = new Player();
            if(player.platformX != 0)
                Assert.IsNotNull(player.platformX = (MapController.mapWidth - 1) / 2);         
        }

        [TestMethod]
        public void TestMethod5()
        {
            Form1 form = new Form1();
            MapController map = new MapController();
            Player player = new Player();
            int score = Convert.ToInt32(player._score);
            form.Update();
            Assert.AreEqual(score++, player._score);
        }   
    }
}
