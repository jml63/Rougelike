using RLNET;
using RogueSharp;

namespace Rougelike
{
    class Console
    {
        //properties
        private static int screenWidth = 80;
        private static int screenHeight = 50;
        private static RLRootConsole rootConsole;
        private Game game;

        /// <summary>
        /// Get input and update game
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Update(object sender, UpdateEventArgs e)
        {
            var move = Check_Keys();

            if (move != Action.None)
            {
                game.ProcessAction(move);
            }
        }

        /// <summary>
        /// Render game to console
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Render(object sender, UpdateEventArgs e)
        {
            rootConsole.Clear();

            foreach (var tile in game.Map.Tiles)
                tile.Draw(rootConsole);

            foreach (var obj in game.Objects)
                obj.Draw(rootConsole);

            rootConsole.Draw();
        }

        /// <summary>
        /// Get the input from user
        /// </summary>
        private Action Check_Keys()
        {
            var action = Action.None;
            RLKeyPress keyPress = rootConsole.Keyboard.GetKeyPress();
            if (keyPress != null)
            {
                switch (keyPress.Key)
                {
                    case RLKey.Up: action = Action.MoveUp; break;
                    case RLKey.Down: action = Action.MoveDown; break;
                    case RLKey.Left: action = Action.MoveLeft; break;
                    case RLKey.Right: action = Action.MoveRight; break;
                }
            }
            return action;
        }

        /// <summary>
        /// Create a console and display the game
        /// </summary>
        /// <param name="game"></param>
        public Console(Game game)
        {
            this.game = game;
            rootConsole = new RLRootConsole("ascii_8x8.png", screenWidth, screenHeight, 8, 8);
            rootConsole.Update += Update;
            rootConsole.Render += Render;
        }

        public void Run()
        {
            rootConsole.Run();
        }
    }
}
