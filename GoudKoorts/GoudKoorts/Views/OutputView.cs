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

        public static void DrawMap(int timer, bool[] switches)
        {
            if (drawing) return;
            drawing = true;
            {

                Console.Clear();

                // Show switches
                Console.WriteLine("1: " + switches[0]);
                Console.WriteLine("2: " + switches[1]);
                Console.WriteLine("3: " + switches[2]);
                Console.WriteLine("4: " + switches[3]);
                Console.WriteLine("5: " + switches[4]);

                Console.WriteLine();

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

    }
}
