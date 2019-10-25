using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoudKoorts.Models.Tracks
{
    class Track
    {
        public virtual char CharValue { get { return (Occupied ? Cart.CharValue : '-'); } }

        public virtual Track Prev { get; set; }
        public virtual Track Next { get; set; }

        public virtual Cart Cart { get; set;  }

        public bool Occupied { get { return Cart != null; } }

    }
}
