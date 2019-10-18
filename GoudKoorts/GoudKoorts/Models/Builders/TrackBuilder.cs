using GoudKoorts.Models.Tracks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoudKoorts.Models.Builders
{
    class TrackBuilder
    {
        public static (Track Start, Track End) BuildLine(int length)
        {
            return BuildLine(length, typeof(Track));
        }

        public static (Track Start, Track End) BuildLine(int length, Type type)
        {
            if (length == 1)
            {
                if (type == typeof(HoldingTrack))
                {
                    Track start = new HoldingTrack();

                    return (Start: start, End: start);
                }
                else
                {
                    Track start = new Track();

                    return (Start: start, End: start);
                }
            }

            if (type == typeof(HoldingTrack))
            {
                Track start = new HoldingTrack();

                Track prevTrack = start;
                for (int i = 0; i < length - 2; i++)
                {
                    Track newTrack = new HoldingTrack()
                    {
                        Prev = prevTrack
                    };

                    prevTrack.Next = newTrack;

                    prevTrack = newTrack;
                }

                Track end = new HoldingTrack()
                {
                    Prev = prevTrack
                };

                return (Start: start, End: end);
            }
            else
            {
                Track start = new Track();

                Track prevTrack = start;
                for (int i = 0; i < length - 2; i++)
                {
                    Track newTrack = new Track()
                    {
                        Prev = prevTrack
                    };

                    prevTrack.Next = newTrack;

                    prevTrack = newTrack;
                }

                Track end = new Track()
                {
                    Prev = prevTrack
                };

                return (Start: start, End: end);
            }
        }

        public static Track[] BuildFromString(string s)
        {
            Track[] tracks = new Track[s.Length];

            Track prevTrack = null;
            for (int i = 0; i < s.Length; i++)
            {
                Track newTrack = null;

                if (s[i].Equals('d'))
                {
                    newTrack = new Dock();
                }
                else if (s[i].Equals('h'))
                {
                    newTrack = new HoldingTrack();
                }
                else if (s[i].Equals('o'))
                {
                    newTrack = new SpawnerTrack();
                }
                else if (s[i].Equals('s'))
                {
                    newTrack = new Switch();
                }
                else
                {
                    newTrack = new Track();
                }

                newTrack.Prev = prevTrack;
                if (prevTrack != null) prevTrack.Next = newTrack;

                prevTrack = newTrack;

                tracks[i] = newTrack;
            }

            return tracks;
        }
    }
}
