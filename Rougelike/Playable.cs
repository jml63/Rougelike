using RLNET;

namespace Rougelike
{
    class Playable : GameObject
    {
        public Playable(int x, int y, RLColor col, char shape) : base(x, y, col, shape) {  }

        public void Move(int dx, int dy)
        {
            x += dx;
            y += dy;
        }
    }
}
