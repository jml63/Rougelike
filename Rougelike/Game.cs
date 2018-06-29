using System.Collections.Generic;
using RLNET;
using System;

namespace Rougelike
{
    /// <summary>
    /// Game class which has a list of game objects
    /// </summary>
    class Game
    {
        private List<GameObject> objects;
        private Playable player;
        private GameMap map;

        public List<GameObject> Objects
        {
            get { return objects; }
        }

        public GameMap Map
        {
            get { return map; }
        }

        /// <summary>
        /// Intialise the game and add a player to the list
        /// </summary>
        public Game()
        {
            map = new GameMap(80, 55);
            player = new Playable(40, 25, RLColor.White, '@');

            objects = new List<GameObject>();
            objects.Add(player);
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

            if (!map.Is_Blocked(player.X + dx, player.Y + dy))
            {
                player.Move(dx, dy);
            }
        }

    }
}
