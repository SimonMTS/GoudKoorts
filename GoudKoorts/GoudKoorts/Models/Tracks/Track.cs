using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoudKoorts.Models.Tracks
{
    class Track : EqualityComparer<Track>
    {
        public static int Increment = 0;

        private readonly int ID = Increment;

        public virtual char CharValue { get { return (Occupied ? Cart.CharValue : DefaultChar); } }

        public char DefaultChar = '═';

        public virtual Track Prev { get; set; }
        public virtual Track Next { get; set; }

        public virtual Cart Cart { get; set;  }

        public bool Occupied { get { return Cart != null; } }


        public virtual bool CanMoveToNext()
        {
            return Next.CanReceiveCartFrom(this);
        }

        protected virtual bool CanReceiveCartFrom(Track t)
        {
            return true;
        }

        public override bool Equals(Track x, Track y)
        {
            return x.ID == y.ID;
        }

        public override int GetHashCode(Track obj)
        {
            return ID;
        }

    }
}
