using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoudKoorts.Models
{
    class Game
    {
        private Map map;

        public bool[] Switches
        { 
            get {
                return map.SwitchesAsBoolArray;
            }
        }

        public void ChangeSwitchDirection(int index)
        {
            map.Switches[index].Flip();
        }

        public Game(Map _map)
        {
            map = _map;
        }

        public void advance()
        {

        }

    }
}
