using RLNET;
using System;
using System.Collections.Generic;
using System.Diagnostics;

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
                    tiles[i, j] = new Tile(i, j, RLColor.Red, (char)0, true);
                }
            }
            
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

        public void Is_Bottom_Wall()
        {
            for (int i = 0; i < (width); i++)
            {
                for (int j = 0; j < (height); j++)
                {
                    if (j + 1 < tiles.GetLength(1))
                    {

                        if (tiles[i, j + 1].Blocked == true)
                        {
                            tiles[i, j].IsBottomWall = false;
                        }
                        else if(tiles[i, j + 1].Blocked == false)
                        {
                            tiles[i, j].IsBottomWall = true;
                        }
                    }
                }
            }
        }

        public void Create_Room(Rect room)
        {
            for (int i=room.x1+1; i<room.x2; i++)
            {
                for (int j = room.y1+1; j < room.y2; j++)
                {
                    tiles[i, j].Blocked = false;
                }
            }
        }

        public void Make_Map(int max_rooms, int room_min_size, int room_max_size, int map_width, int map_height, Playable player)
        {
            int num_rooms = 0;
            //Rect[] rooms = new Rect[max_rooms];
            List<Rect> rooms = new List<Rect>();

            while (num_rooms <= max_rooms)
            {
                Random r = new Random();
                int w = r.Next(room_min_size, room_max_size + 1);
                int h = r.Next(room_min_size, room_max_size + 1);

                int x = r.Next(0, map_width - w);
                int y = r.Next(0, map_height - h);

                Rect new_room = new Rect(x, y, w, h);

                bool found = false;
                foreach (Rect rm in rooms)
                {
                    if (new_room.Intersect(rm))
                    {
                        found = true;
                        break;
                    }
                }
                if (!found)
                {
                    Create_Room(new_room);
                    Tuple<int, int> new_room_xy = new_room.Center();

                    if (num_rooms == 0)
                    {
                        player.X = new_room_xy.Item1;
                        player.Y = new_room_xy.Item2;
                    }
                    else
                    {
                        Tuple<int, int> prev_room_xy = rooms[num_rooms - 1].Center();
                        Random rand = new Random();

                        if (rand.Next(0, 2) == 1)
                        {
                            Debug.WriteLine("rand 1");
                            Create_Tunnel_Hor(prev_room_xy.Item1, new_room_xy.Item1, prev_room_xy.Item2);
                            Create_Tunnel_Ver(prev_room_xy.Item2, new_room_xy.Item2, new_room_xy.Item1);
                        }
                        else
                        {
                            Debug.WriteLine("rand 0");
                            Create_Tunnel_Ver(prev_room_xy.Item2, new_room_xy.Item2, prev_room_xy.Item1);
                            Create_Tunnel_Hor(prev_room_xy.Item1, new_room_xy.Item1, new_room_xy.Item2);
                        }
                    }

                    Debug.WriteLine("Added room");
                    rooms.Add(new_room);
                    num_rooms++;
                }

                if (num_rooms >= 4)
                {
                    Random e = new Random();
                    if (e.Next(0, 50) == 1)
                        break;
                }

            }

        }

        public void Create_Tunnel_Hor(int x1, int x2, int y)
        {
            for (int i=Math.Min(x1,x2); i<Math.Max(x1,x2)+1; i++)
            {
                tiles[i, y].Blocked = false;
            }
        }

        public void Create_Tunnel_Ver(int y1, int y2, int x)
        {
            for (int i = Math.Min(y1, y2); i < Math.Max(y1, y2)+1; i++)
            {
                tiles[x, i].Blocked = false;
            }
        }

    }
}
