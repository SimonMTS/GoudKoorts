using GoudKoorts.Models.Tracks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoudKoorts.Models.Builders
{
    class MapBuilder
    {

        public static Map Build_old()
        {
            Map map = new Map();

            SpawnerTrack spawnerA = new SpawnerTrack();
            SpawnerTrack spawnerB = new SpawnerTrack();
            SpawnerTrack spawnerC = new SpawnerTrack();

            Switch switch1 = new Switch();
            Switch switch2 = new Switch();
            Switch switch3 = new Switch();
            Switch switch4 = new Switch();
            Switch switch5 = new Switch();

            Dock dock = new Dock();
            var holdingTrack = TrackBuilder.BuildLine(8, typeof(HoldingTrack));

            var trackAto1 = TrackBuilder.BuildLine(3);
            var trackBto1 = TrackBuilder.BuildLine(3);
            var trackCto3 = TrackBuilder.BuildLine(1);

            var track1to2 = TrackBuilder.BuildLine(1);
            var track2to3 = TrackBuilder.BuildLine(2);
            var track3to4 = TrackBuilder.BuildLine(1);
            var track4to5 = TrackBuilder.BuildLine(2);
            var track2to5 = TrackBuilder.BuildLine(5);

            var track4toHolding = TrackBuilder.BuildLine(7);
            var track5toDock= TrackBuilder.BuildLine(6);
            var trackDocktoEnd = TrackBuilder.BuildLine(9);

            {
                spawnerA.Next = trackAto1.Start;
                spawnerB.Next = trackBto1.Start;
                spawnerC.Next = trackCto3.Start;

                switch1.PrevTracks[0] = trackAto1.End;
                switch1.PrevTracks[1] = trackBto1.End;
                switch1.NextTracks[0] = track1to2.Start;

                switch2.PrevTracks[0] = track1to2.End;
                switch2.NextTracks[0] = track2to5.Start;
                switch2.NextTracks[1] = track2to3.Start;

                switch3.PrevTracks[0] = track2to3.End;
                switch3.PrevTracks[1] = trackCto3.End;
                switch3.NextTracks[0] = track3to4.Start;

                switch4.PrevTracks[0] = track3to4.End;
                switch4.NextTracks[0] = track4to5.Start;
                switch4.NextTracks[1] = track4toHolding.Start;

                switch5.PrevTracks[0] = track2to5.End;
                switch5.PrevTracks[1] = track4to5.End;
                switch5.NextTracks[0] = track5toDock.Start;

                holdingTrack.Start.Prev = track4toHolding.End;

                dock.Prev = track5toDock.End;
                dock.Next = trackDocktoEnd.Start;
            }

            { // not done at all
                trackAto1.Start.Prev = spawnerA;
                trackAto1.End.Next = switch1;

                trackBto1.Start.Prev = spawnerB;
                trackBto1.End.Next = switch1;

                trackCto3.Start.Prev = spawnerC;
                trackCto3.End.Next = switch3;
            }

            {
                map.Add(spawnerA);
                map.Add(spawnerB);
                map.Add(spawnerC);

                map.Add(switch1);
                map.Add(switch2);
                map.Add(switch3);
                map.Add(switch4);
                map.Add(switch5);
            }

            return map;
        }

        public static Map Build()
        {
            Map map = new Map();

            // Generate main paths
            Track[] mainPath1 = TrackBuilder.BuildFromString("o...s.s.....s......d.........");
            Track[] mainPath2 = TrackBuilder.BuildFromString("o......s.s.......hhhhhhhh");

            // Add tracks outside of mainpaths
            SpawnerTrack spawnerB = new SpawnerTrack();
            var trackBto1 = TrackBuilder.BuildLine(3);
            var track2to3 = TrackBuilder.BuildLine(2);
            var track4to5 = TrackBuilder.BuildLine(2);

            {
                spawnerB.Next = trackBto1.Start;

                trackBto1.Start.Prev = spawnerB;
                trackBto1.End.Next = mainPath1[4];

                track2to3.Start.Prev = mainPath1[6];
                track2to3.End.Next = mainPath2[7];

                track4to5.Start.Prev = mainPath2[9];
                track4to5.End.Next = mainPath1[12];
            }

            // Insert into map
            {
                map.Add((SpawnerTrack)mainPath1[0]);
                map.Add((SpawnerTrack)spawnerB);
                map.Add((SpawnerTrack)mainPath2[0]);

                map.Add((Switch)mainPath1[4]);
                map.Add((Switch)mainPath1[6]);
                map.Add((Switch)mainPath2[7]);
                map.Add((Switch)mainPath2[9]);
                map.Add((Switch)mainPath1[12]);
            }

            return map;
        }

    }
}
