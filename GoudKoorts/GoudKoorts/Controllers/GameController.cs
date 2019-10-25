using GoudKoorts.Models;
using GoudKoorts.Models.Builders;
using GoudKoorts.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace GoudKoorts.Controllers
{
    class GameController
    {
        private static System.Timers.Timer GameLoop;
        private static int timer = 19;

        private static Game game;

        public GameController()
        {
            Map map = MapBuilder.Build();

            game = new Game(map);

            OutputView.WelcomeScreen();

            StartGameLoop();

        }

        private void StartGameLoop()
        {
            OutputView.DrawMap(timer, game.Spawners, game.Score);

            GameLoop = new System.Timers.Timer(500);
            GameLoop.Elapsed += Loop;
            GameLoop.AutoReset = true;
            GameLoop.Enabled = true;

            while (GameLoop.Enabled)
            {
                int switchToSwap = InputView.AwaitNumber();

                if (switchToSwap > 0 && switchToSwap <= game.Switches.Count)
                {
                    game.FlipSwitch(switchToSwap-1);
                }

                OutputView.DrawMap(timer, game.Spawners, game.Score);
            }
        }

        private static void Loop(Object source, ElapsedEventArgs e)
        {
            OutputView.DrawMap(timer);

            timer--;
            if (timer < 0) {
                timer = 20;

                game.Advance();

                if (!game.HasLost())
                {
                    OutputView.DrawMap(timer, game.Spawners, game.Score);
                }
                else
                {
                    GameLoop.Stop();

                    Console.WriteLine("end");
                }
            }
        }

    }
}
