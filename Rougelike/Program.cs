using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Rougelike
{
    /// <summary>
    /// Enum of Actions
    /// </summary>
    public enum Action
    {
        None,
        MoveUp,
        MoveDown,
        MoveLeft,
        MoveRight
    }

    class Program
    {
        /// <summary>
        /// Make a Game, Console, and run it
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            var game = new Game();
            var console = new Console(game);
            console.Run();
        }         
    }
}
