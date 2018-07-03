using RLNET;

namespace Rougelike
{
    class Tile : GameObject
    {
        private bool blocked;
        private bool isBottomWall;

        public bool Blocked
        {
            get { return blocked; }
            set { blocked = value; }
        }

        public bool IsBottomWall
        {
            get { return isBottomWall; }
            set { isBottomWall = value; }
        }

        public new void Draw(RLConsole console)
        {
            if (blocked)
            {
                if (isBottomWall == true)
                    console.Set(x, y, col, null, 176);
                else if (isBottomWall == false)
                    console.Set(x, y, col, null, 178);
            }
            else
            {
                console.Set(x, y, col, null, 0);
            }

            
        }

        public Tile(int x, int y, RLColor col, char shape, bool blocked) : base(x, y, col, shape)
        {
            this.blocked = blocked;
        }
    }
}
