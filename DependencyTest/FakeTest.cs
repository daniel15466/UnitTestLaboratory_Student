using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using CUT;

namespace DependencyTest
{
    // Przykłady z wykładów
    [TestClass]
    public class ScoreManagerTest
    {
        public class InMemoryScoreRepository : IScoreRepository
        {
            private Dictionary<long, long> _scoreDict = new Dictionary<long, long>();

            public long GetScoreById(long playerId)
            {
                long score = 0;
                if (this._scoreDict.ContainsKey(playerId))
                    score = _scoreDict[playerId];

                return score;
            }

            public void SetScore(long playerId, long score)
            {
                this._scoreDict[playerId] = score;
            }
        }

        [TestMethod]
        public void UpdateWithLowerScore_Test()
        {
            var cut = new ScoreManager(new InMemoryScoreRepository());
            cut.UpdateScore(1, 100);
            var actual = cut.UpdateScore(1, 99);

            Assert.IsFalse(actual);
        }
    }
}
