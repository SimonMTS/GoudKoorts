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
        private const int TimeToThink = 10; // in seconds

        private static Timer GameLoop;
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
            OutputView.DrawMap(timer, game.Spawners, game.Dock, game.Score);

            GameLoop = new Timer(TimeToThink * 50);
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

                OutputView.DrawMap(timer, game.Spawners, game.Dock, game.Score);
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
                    OutputView.DrawMap(timer, game.Spawners, game.Dock, game.Score);

                    if (game.Score % 18 == 0)
                    {
                        int newTimeToThink = TimeToThink - (game.Score / 18);
                        if (newTimeToThink < 1) newTimeToThink = 1;

                        GameLoop.Enabled = false;
                        GameLoop.Interval = newTimeToThink * 50;
                        GameLoop.Enabled = true;
                    }
                }
                else
                {
                    GameLoop.Stop();

                    OutputView.GameOverScreen();
                }
            }
        }

    }
}
