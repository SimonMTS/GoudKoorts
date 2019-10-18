using GoudKoorts.Models.Tracks;
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
        public int Score = 0;

        public List<SpawnerTrack> Spawners
        { 
            get {
                return map.Spawners;
            }
        }

        public List<Switch> Switches
        {
            get
            {
                return map.Switches;
            }
        }

        public void FlipSwitch(int index)
        {
            map.Switches[index].Flip();
        }

        public Game(Map _map)
        {
            map = _map;
            map.Dock.Game = this;
        }

        public void advance()
        {
            // Move carts
            foreach (var cart in map.Carts)
            {
                cart.Move();
            }

            // Spawn carts
            Random r = new Random();

            foreach (var spawner in map.Spawners)
            {
                if (spawner.WillSpawn(Score, r.Next(100)))
                {
                    Cart cart = new Cart(spawner.Next);
                    spawner.Next.Cart = cart;
                    map.Carts.Add(cart);
                }
            }
        }

    }
}
