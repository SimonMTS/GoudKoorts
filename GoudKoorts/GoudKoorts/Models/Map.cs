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

        public List<SpawnerTrack> Spawners { get; } = new List<SpawnerTrack>();

        public List<Cart> Carts { get; } = new List<Cart>();

        public Dock Dock { get; set; }

    }
}
