using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoudKoorts.Models.Tracks
{
    class SpawnerTrack : Track
    {
        public new Track Prev => null;

        public bool WillSpawn(int score, int number)
        {
            int extra = (int)(Math.Log(score) * 10);
            int chance = 10 + (extra > 0 ? extra : 0);
            bool spawn = number < chance;

            return spawn;
        }
    }
}
