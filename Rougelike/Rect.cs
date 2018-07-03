using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rougelike
{
    class Rect
    {
        public int x1, x2, y1, y2;

        public Rect(int x, int y, int w, int h)
        {
            x1 = x;
            x2 = x + w;
            y1 = y;
            y2 = y + h;
        }

        public Tuple<int, int> Center()
        {
            int center_x = ((x1 + x2) / 2);
            int center_y = ((y1 + y2) / 2);
            Tuple<int, int> ret = new Tuple<int, int>(center_x, center_y);
            return ret;
        }

        public bool Intersect(Rect other)
        {
            return (x1 <= other.x2 && x2 >= other.x1 && y1 <= other.y2 && y2 >= other.y1);
        }
    }
}
