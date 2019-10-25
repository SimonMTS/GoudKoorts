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
                Console.WriteLine(@"~ ~ ~ ~ ~ ~ ~ ~ ~  "+ score.ToString().PadLeft(3, '0') +"  ~\n~ ~ ~ ~ ~ ~ ~ ~ ~ ▀▀▀▀▀ ~");

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
            Track[] vt = new Track[400];
            int index = 100;

            Track t = Spawners[0].Next;
            while (t != null)
            {
                vt[index] = t;

                index++;
                if (t is OutputSwitch)
                {
                    t = ((OutputSwitch)t).NextTracks[0];
                }
                else
                {
                    t = t.Next;
                }
            }

            index = 200;
            t = Spawners[1].Next;
            int flip = 1;
            while (t != null)
            {
                vt[index] = t;

                index++;
                if (t is OutputSwitch)
                {
                    t = ((OutputSwitch)t).NextTracks[flip];
                    flip = 1 - flip;
                }
                else
                {
                    t = t.Next;
                }
            }

            index = 300;
            t = Spawners[2].Next;
            while (t != null)
            {
                vt[index] = t;

                index++;
                if (t is OutputSwitch)
                {
                    t = ((OutputSwitch)t).NextTracks[1];
                }
                else
                {
                    t = t.Next;
                }
            }

            string output = @"%129%═%128%═%127%═%126%═%125%═%124%═%123%═%122%═%121%═%120%═%119%═%118%═%117%
                        %116%  
A═%100%═%101%═%102%   %106%═%107%═%108%═%109%═%110%     %115%
     1%103%═%104%═%105%2     5%111%═%112%═%113%═%114%
B═%200%═%201%═%202%   %206%═%207%   %309%═%310%      
           3%208%═%209%═%210%4       
C %300%═%301%═%302%═%303%═%304%═%305%   %211%═%212%═%213%═%214%  
                      %215%  
%227%─%226%─%225%─%224%─%223%─%222%─%221%─%220%─%219%═%218%═%217%═%216%  
";

            while (index >= 0)
            {
                if (vt[index] == null) { index--; continue; }

                output = output.Replace("%" + index + "%", vt[index].CharValue.ToString());

                index--;
            }

            Console.WriteLine(output);
        }

    }
}
