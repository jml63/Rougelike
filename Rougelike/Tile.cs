using RLNET;

namespace Rougelike
{
    class Tile : GameObject
    {
        private bool blocked;

        public bool Blocked
        {
            get { return blocked; }
            set { blocked = value; }
        }

        public new void Draw(RLConsole console)
        {
            if (blocked)
                console.Set(x, y, col, null, shape);
        }

        public Tile(int x, int y, RLColor col, char shape, bool blocked) : base(x, y, col, shape) { }
    }
}
