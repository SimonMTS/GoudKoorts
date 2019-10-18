using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoudKoorts.Models.Tracks
{
    class InputSwitch : Switch
    {
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
    }
}
