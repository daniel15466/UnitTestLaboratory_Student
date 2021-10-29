using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CUT
{
    public interface IScoreRepository
    {
        long GetScoreById(long playerId);
        void SetScore(long playerId, long score);
    }

    public class MySQLScoreRepository : IScoreRepository
    {
        public long GetScoreById(long playerId)
        {
            // mySQL code
            return 0;
        }

        public void SetScore(long playerId, long score)
        {
            // mySQL code
        }
    }

    public class ScoreManager
    {
        private IScoreRepository _rep;

        public ScoreManager(IScoreRepository rep)
        {
            this._rep = rep;
        }

        public bool UpdateScore(long playerId, long newScore)
        {
            long lastScore = this._rep.GetScoreById(playerId);
            if (newScore > lastScore)
            {
                this._rep.SetScore(playerId, newScore);
                return true;
            }

            return false;
        }
    }
}
