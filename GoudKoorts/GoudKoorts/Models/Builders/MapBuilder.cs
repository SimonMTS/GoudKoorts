﻿using GoudKoorts.Models.Tracks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoudKoorts.Models.Builders
{
    class MapBuilder
    {

        public static Map Build()
        {
            Map map = new Map();
            
            // Generate main paths, there is an image in the 'Presentatie' folder explaining what the 'mainPaths' are.
            Track[] mainPath1 = TrackBuilder.BuildFromString("o...I.U.....I.......d..........");
            Track[] mainPath2 = TrackBuilder.BuildFromString("o......I.U........hhhhhhhhh");

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

            // Set switches second in/output
            mainPath1[4].Prev = trackBto1.End;
            mainPath1[6].Next = track2to3.Start;
            mainPath2[7].Prev = track2to3.End;
            mainPath2[9].Next = track4to5.Start;
            mainPath1[12].Prev = track4to5.End;

            // Flip in/output numbers
            ((Switch)mainPath1[4]).DownPosition = 1;
            ((Switch)mainPath1[6]).DownPosition = 1;
            ((Switch)mainPath1[12]).DownPosition = 1;

            // Pre flip switch for ease of testing
            ((Switch)mainPath2[9]).Flip();

            // Insert into map
            {
                map.Spawners.Add((SpawnerTrack)mainPath1[0]);
                map.Spawners.Add((SpawnerTrack)spawnerB);
                map.Spawners.Add((SpawnerTrack)mainPath2[0]);

                map.Switches.Add((Switch)mainPath1[4]);
                map.Switches.Add((Switch)mainPath1[6]);
                map.Switches.Add((Switch)mainPath2[7]);
                map.Switches.Add((Switch)mainPath2[9]);
                map.Switches.Add((Switch)mainPath1[12]);

                map.Dock = (Dock)mainPath1[20];
            }

            // Add different char values
            mainPath1[3].DefaultChar = '╗';
            trackBto1.End.DefaultChar = '╝';

            mainPath1[7].DefaultChar = '╔';
            track2to3.Start.DefaultChar = '╚';

            track2to3.End.DefaultChar = '╗';
            mainPath2[6].DefaultChar = '╝';

            track4to5.Start.DefaultChar = '╔';
            mainPath2[10].DefaultChar = '╚';

            mainPath1[11].DefaultChar = '╗';
            track4to5.End.DefaultChar = '╝';

            mainPath1[18].DefaultChar = '╗';
            mainPath1[17].DefaultChar = '║';
            mainPath1[16].DefaultChar = '║';
            mainPath1[15].DefaultChar = '╝';

            mainPath2[13].DefaultChar = '╗';
            mainPath2[14].DefaultChar = '║';
            mainPath2[15].DefaultChar = '╝';

            return map;
        }

    }
}
