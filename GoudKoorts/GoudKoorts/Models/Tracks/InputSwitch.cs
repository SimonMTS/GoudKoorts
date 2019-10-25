using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoudKoorts.Models.Tracks
{
    class InputSwitch : Switch
    {
        public override char CharValue
        {
            get
            {
                char c;

                if (Occupied)
                {
                    c = Cart.CharValue;
                }
                else
                {
                    if (Position == 0)
                    {
                        c = '╔';
                    }
                    else
                    {
                        c = '╚';
                    }
                }

                return c;
            }
        }

        public Track[] PrevTracks = new Track[2];

        public override Track Prev {
            get
            {
                if (PrevTracks[1] == null)
                { // Contains only one track
                    return PrevTracks[0];
                }
                else
                { // This must be the flippable side of the track
                    return PrevTracks[Position];
                }
            }

            set
            {
                if (PrevTracks[0] == null)
                {
                    PrevTracks[0] = value;
                }
                else
                {
                    PrevTracks[1] = value;
                }
            }
        }

        protected override bool CanReceiveCartFrom(Track t)
        {
            return (t == Prev);
        }
    }
}
