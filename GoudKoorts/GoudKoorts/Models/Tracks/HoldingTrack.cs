using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoudKoorts.Models.Tracks
{
    class HoldingTrack : Track
    {
        public override char CharValue { get { return (Occupied ? Cart.CharValue : '─'); } }

        public override bool CanMoveToNext()
        {
            if (Next == null || Next.Occupied)
            {
                return false;
            }

            return true;
        }
    }
}
