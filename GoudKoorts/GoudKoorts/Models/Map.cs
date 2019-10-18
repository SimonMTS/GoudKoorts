using GoudKoorts.Models.Tracks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoudKoorts.Models
{
    class Map
    {
        public List<Switch> Switches { get; private set; } = new List<Switch>();

        public bool[] SwitchesAsBoolArray
        {
            get
            {
                bool[] _switches = new bool[Switches.Count];

                for (int i = 0; i < Switches.Count; i++)
                {
                    _switches[i] = (Switches[i].Position == 1);
                }

                return _switches;
            }
        }

        public void Add(Switch t)
        {
            Switches.Add(t);
        }


        public List<SpawnerTrack> Spawners { get; private set; } = new List<SpawnerTrack>();

        public void Add(SpawnerTrack t)
        {
            Spawners.Add(t);
        }

    }
}
