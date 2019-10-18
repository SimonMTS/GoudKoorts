using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoudKoorts.Views
{
    class InputView
    {

        public static int AwaitNumber()
        {
            int number;
            var input = Console.ReadKey(true).KeyChar;

            if (char.IsDigit(input))
            {
                number = int.Parse(input.ToString());
            }
            else
            {
                number = -1;
            }

            return number;
        }

        public static void AwaitAnyKey()
        {
            Console.ReadKey(true);
        }

    }
}
