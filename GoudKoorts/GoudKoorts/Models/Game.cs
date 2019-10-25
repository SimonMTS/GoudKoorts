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
        private bool firstRound = true;

        public List<SpawnerTrack> Spawners
        { 
            get {
                return map.Spawners;
            }
        }

        public List<Switch> Switches
        {
            get {
                return map.Switches;
            }
        }

        public Dock Dock
        {
            get
            {
                return map.Dock;
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

        public void Advance()
        {
            var cartsInGame = map.Carts.Where(c => c.Position != null).ToList();

            // Move carts
            foreach (var cart in cartsInGame)
            {
                cart.Move();
            }

            // Spawn carts
            Random r = new Random();

            foreach (var spawner in map.Spawners)
            {
                if (spawner.WillSpawn(Score, r.Next(100)) || firstRound)
                {
                    Cart cart = new Cart(spawner.Next);
                    spawner.Next.Cart = cart;
                    map.Carts.Add(cart);

                    firstRound = false;
                }
            }

            // Spawn ship
            if (!map.Dock.HasShip && (new Random()).Next(0, 2) == 1)
            {
                map.Dock.HasShip = true;
            }
        }

        public bool HasLost()
        {
            var cartsInGame = map.Carts.Where(c => c.Position != null).ToList();

            Track[] cartPositions = cartsInGame.Select(c => c.Position).Distinct().ToArray();

            return (cartPositions.Length != cartsInGame.Count);
        }

    }
}
