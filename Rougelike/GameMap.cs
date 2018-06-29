using RLNET;

namespace Rougelike
{
    class GameMap
    {
        private int width;
        private int height;
        private Tile[,] tiles;

        public Tile[,] Tiles
        {
            get { return tiles; }
        }

        public GameMap(int width, int height)
        {
            this.width = width;
            this.height = height;
            this.tiles = Init_Tiles();
        }

        public Tile[,] Init_Tiles()
        {
            tiles = new Tile[width, height];

            for(int i=0; i<(width); i++)
            {
                for (int j = 0; j < (height); j++)
                {
                    tiles[i, j] = new Tile(i, j, RLColor.Red, 'X', false);
                }
            }

            tiles[30,22].Blocked = true;
            tiles[31,22].Blocked = true;
            tiles[32,22].Blocked = true;

            return tiles;
        }

        public bool Is_Blocked(int x, int y)
        {
            if (tiles[x, y].Blocked)
            {
                return true;
            }
            return false;
        }
    }
}
