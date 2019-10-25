using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoudKoorts.Models.Tracks
{
    class Dock : Track
    {
        public override char CharValue { get { return (Occupied ? Cart.CharValue : 'K'); } }

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

                if (value != null && HasShip)
                {
                    Cart.Empty();
                    Game.Score++;
                    ShipFill++;

                    if (ShipFill >= 8)
                    {
                        ShipFill = 0;
                        HasShip = false;

                        Game.Score += 10;
                    }
                }
            }
        }


        public bool HasShip { get; set; } = false;

        public int ShipFill { get; private set; } = 0;


        public override bool CanMoveToNext()
        {
            return Next.CanReceiveCartFrom(this);
        }

    }
}
