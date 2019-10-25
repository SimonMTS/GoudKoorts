using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoudKoorts.Models.Tracks
{
    class OutputSwitch : Switch
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
                        c = '╗';
                    }
                    else
                    {
                        c = '╝';
                    }
                }

                return c;
            }
        }

        public Track[] NextTracks = new Track[2];

        public override Track Next
        {
            get
            {
                if (NextTracks[1] == null)
                { // Contains only one track
                    return NextTracks[0];
                }
                else
                { // This must be the flippable side of the track
                    return NextTracks[Position];
                }
            }

            set
            {
                if (NextTracks[0] == null)
                {
                    NextTracks[0] = value;
                }
                else
                {
                    NextTracks[1] = value;
                }
            }
        }
    }
}
