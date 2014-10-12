using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using NeshStudios.Games.Beerpong.Data.Model;

namespace NeshStudios.Games.Beerpong.Data.Model.Test
{
    [TestClass]
    public class GameTest
    {
        [TestMethod]
        public void Game_Created_Not_Null()
        {
            Game g = new Game();
            Assert.IsNotNull(g);
        }

        [TestMethod]
        public void Game_Created_Successfully()
        {
            Game g = new Game();
            g.StartTime = DateTime.Now;
            g.GameId = 1;
            g.Status = GameStatus.Created;
            Assert.IsTrue(g.Status == GameStatus.Created);
        }

        [TestMethod]
        public void Game_InProgress()
        {
            Game g = new Game();
            g.StartTime = DateTime.Now;
            g.GameId = 1;
            g.Status = GameStatus.InProgress;
            Assert.IsTrue(g.Status == GameStatus.InProgress);
        }

        [TestMethod]
        public void Game_Completed_Successfully()
        {
            Game g = new Game();
            g.StartTime = DateTime.Now;
            g.GameId = 1;
            g.Status = GameStatus.Completed;
            Assert.IsTrue(g.Status == GameStatus.Completed);
        }

        [TestMethod]
        public void Game_Has_Shots()
        {
            Game g = new Game();
            g.GameId = 1;
            g.Shots = new List<OffensiveShotResult> { new OffensiveShotResult() };
            Assert.IsNotNull(g.Shots);
        }
    }
}
