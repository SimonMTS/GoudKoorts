using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoudKoorts.Models.Tracks
{
    class Dock : Track
    {
        public Game Game { get; set; }

        private Cart _cart;
        public override Cart Cart
        {
            get
            {
                return _cart;
            }

            set {
                _cart = value;

                if (value != null) Game.Score++;
            }
        }
    }
}
