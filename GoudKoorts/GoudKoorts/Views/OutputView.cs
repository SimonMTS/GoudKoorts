using GoudKoorts.Models.Tracks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoudKoorts.Views
{
    class OutputView
    {
        private static bool drawing = false;

        public static void WelcomeScreen()
        {
            Console.WriteLine("bla bla bla");
            Console.WriteLine("press any key to continue.");

            InputView.AwaitAnyKey();
        }

        public static void DrawMap(int timer, List<SpawnerTrack> Spawners, int score)
        {
            if (drawing) return;
            drawing = true;
            {
                Console.Clear();
                Console.WriteLine("-- -- -- " + score + " -- -- --");

                // Good code here

                /* TMP */ thisIsBad_DrawMap(Spawners); /* TMP */

            }
            drawing = false;

            DrawMap(timer);
        }

        public static void DrawMap(int timer)
        {
            if (drawing) return;
            drawing = true;
            {

                Console.Write("\r[");
                for (int i = 0; i < 20; i++)
                {
                    Console.Write((i < timer ? "=" : "-"));
                }
                Console.Write("] " + timer / 2 + "  ");

            }
            drawing = false;
        }

        private static void thisIsBad_DrawMap(List<SpawnerTrack> Spawners)
        {
            Track track = Spawners[0].Next;
            Console.Write("A");
            while (track != null)
            {
                Console.Write(thisIsBad_GetChar(track));

                track = track.Next;
            }
            Console.WriteLine("");

            track = Spawners[1].Next;
            Console.Write("B");
            while (track != null)
            {
                Console.Write(thisIsBad_GetChar(track));

                track = track.Next;
            }
            Console.WriteLine("");

            track = Spawners[2].Next;
            Console.Write("C");
            while (track != null)
            {
                Console.Write(thisIsBad_GetChar(track));

                track = track.Next;
            }
            Console.WriteLine("");
        }

        private static string thisIsBad_GetChar(Track t)
        {

            if (t.Occupied)
            {
                return "O";
            }
            else if (t.GetType() == typeof(Dock))
            {
                return "D";
            }
            else if (t.GetType() == typeof(InputSwitch) || t.GetType() == typeof(OutputSwitch))
            {
                return (((Switch)t).Position == 1 ? "W" : "M");
            }
            else if (t.GetType() == typeof(SpawnerTrack))
            {
                return "S";
            }
            else if (t.GetType() == typeof(HoldingTrack))
            {
                return "H";
            }
            else
            {
                return "-";
            }

        }

    }
}
