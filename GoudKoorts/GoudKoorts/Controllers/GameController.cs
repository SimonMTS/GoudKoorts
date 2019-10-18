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
        private static int timer = 20;

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
            OutputView.DrawMap(timer, game.Switches);

            GameLoop = new System.Timers.Timer(500);
            GameLoop.Elapsed += Loop;
            GameLoop.AutoReset = true;
            GameLoop.Enabled = true;

            while (true)
            {
                int switchToSwap = InputView.AwaitNumber();

                if (switchToSwap > 0 && switchToSwap <= game.Switches.Length)
                {
                    game.ChangeSwitchDirection(switchToSwap-1);
                }

                OutputView.DrawMap(timer, game.Switches);
            }
        }

        private static void Loop(Object source, ElapsedEventArgs e)
        {
            OutputView.DrawMap(timer);

            timer--;
            if (timer < 0) {
                timer = 20;

                game.advance();
            }
        }

    }
}
