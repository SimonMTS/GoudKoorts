using GoudKoorts.Models.Tracks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoudKoorts.Models
{
    class Cart
    {
        public Track Position { get; private set; }

        public Cart(Track t)
        {
            Position = t;
        }

        public void Move()
        {
            Position.Cart = null;

            Position = Position.Next;

            Position.Cart = this;
        }

    }
}
