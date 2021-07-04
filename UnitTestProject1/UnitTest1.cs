using System;
using IincapsulationHW;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void DefaultTest()
        {
            var player = new Player();
            var weapon = new Weapon(2, 2000);
            var bot = new Bot(weapon);
            bot.OnSeePlayer(player);
        }
    }
}
