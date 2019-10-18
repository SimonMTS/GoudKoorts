using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoudKoorts.Models.Tracks
{
    abstract class Switch : Track
    {
        public int Position { get; private set; } = 0;

        public void Flip()
        {
            Position = 1 - Position;
        }
    }
}
