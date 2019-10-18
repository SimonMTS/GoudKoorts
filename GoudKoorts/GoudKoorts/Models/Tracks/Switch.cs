using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoudKoorts.Models.Tracks
{
    class Switch : Track
    {
        public Track[] PrevTracks = new Track[2];

        public new Track Prev {
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
        }


        public Track[] NextTracks = new Track[2];

        public new Track Next
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
        }

        public int Position { get; private set; } = 0;

        public void Flip()
        {
            Position = 1 - Position;
        }
    }
}
