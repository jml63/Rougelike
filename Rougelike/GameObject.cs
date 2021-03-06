﻿using RLNET;

namespace Rougelike
{
    /// <summary>
    /// A game object to display
    /// </summary>
    class GameObject
    {
        protected int x;
        protected int y;
        protected RLColor col;
        protected char shape;

        public int X
        {
            get { return x;  }
            set { x = value; }
        }

        public int Y
        {
            get { return y; }
            set { y = value; }
        }

        /// <summary>
        /// Draw the object on given console
        /// </summary>
        /// <param name="console"></param>
        public void Draw(RLConsole console)
        {
            console.Set(x, y, col, null, shape);
        }

        public GameObject(int x, int y, RLColor col, char shape)
        {
            this.x = x;
            this.y = y;
            this.col = col;
            this.shape = shape;
        }
    }
}
