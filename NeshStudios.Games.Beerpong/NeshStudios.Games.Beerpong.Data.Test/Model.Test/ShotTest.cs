using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NeshStudios.Games.Beerpong.Data.Model;

namespace NeshStudios.Games.Beerpong.Data.Model.Test
{
    [TestClass]
    public class ShotTest
    {
        [TestMethod]
        public void Shot_Is_Not_Null()
        {
            OffensiveShotResult t = new OffensiveShotResult();
            Assert.IsNotNull(t);
        }

        [TestMethod]
        public void Shot_Created_Successfully()
        {
            var s = ShotFactory.Create();
            Assert.IsNotNull(s.ShotId); //not a good test
        }

        [TestMethod]
        public void Shot_Belongs_To_a_Game()
        {
            var s = ShotFactory.Create();
            Assert.IsNotNull(s.Game);
        }

        [TestMethod]
        public void Shot_Has_Ball_Status_Rim()
        {
            var s = ShotFactory.Create();
            s.Status = BallStatus.Rim;
            Assert.IsTrue(s.Status == BallStatus.Rim);
        }

        [TestMethod]
        public void Shot_Has_Ball_Status_Air()
        {
            var s = ShotFactory.Create();
            s.Status = BallStatus.Air;
            Assert.IsTrue(s.Status == BallStatus.Air);
        }

        [TestMethod]
        public void Shot_Has_Ball_Status_Hit()
        {
            var s = ShotFactory.Create();
            s.Status = BallStatus.Hit;
            Assert.IsTrue(s.Status == BallStatus.Hit);
        }

        [TestMethod]
        public void Shot_Was_Taken_At_Rack()
        {
            var s = ShotFactory.Create();
            Assert.IsNotNull(s.Rack);
        }

        private static class ShotFactory
        {
            public static OffensiveShotResult Create()
            {
                Rack r = new Rack();
                r.RackId = 1;

                Game g = new Game();
                g.GameId = 1;

                OffensiveShotResult s = new OffensiveShotResult();
                s.ShotId = 1;
                
                s.Game = g;
                s.Rack = r;

                return s;
            }
        }


    }
}
