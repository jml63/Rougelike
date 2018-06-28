using System.Collections.Generic;
using RLNET;
using System;

namespace Rougelike
{
    /// <summary>
    /// A Game which has a list of game objects
    /// </summary>
    class Game
    {
        private List<GameObject> objects;
        private GameObject player;
        private GameObject npc;

        public List<GameObject> Objects
        {
            get { return objects; }
        }

        /// <summary>
        /// Intialise the game and add a player to the list
        /// </summary>
        public Game()
        {
            player = new GameObject(40, 25, RLColor.White, '@');
            npc = new GameObject(5, 45, RLColor.Red, 'X');

            objects = new List<GameObject>();
            objects.Add(player);
            objects.Add(npc);
        }

        /// <summary>
        /// Process an action
        /// </summary>
        /// <param name="action"></param>
        public void ProcessAction(Action action)
        {
            int dx = 0;
            int dy = 0;

            switch (action)
            {
                case Action.MoveUp: dy = -1; break;
                case Action.MoveDown: dy = 1; break;
                case Action.MoveLeft: dx = -1; break;
                case Action.MoveRight: dx = 1; break;
                default: break;
            }

            player.Move(dx, dy);

            Random rnd = new Random();
            npc.Move(rnd.Next(-1, 1), rnd.Next(-1, 1));
        }

    }
}
