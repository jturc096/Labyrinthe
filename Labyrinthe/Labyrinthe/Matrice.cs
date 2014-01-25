using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;

namespace Labyrinthe
{

    public class Matrice
    {
        int dimTotY = 0;
        int dimTotX = 0;
        private int[,] map;

        public Matrice(int dimToY, int dimToX){
            this.dimTotY = dimToY;
            this.dimTotX = dimToX;
            map = new int[dimTotY, dimTotX];
            init();
        }

        public int[,] getMap(){
            return map;
        }

        public void init()
        {
            for (int row = 0; row < dimTotY; row++)
            {
                for (int column = 0; column < dimTotX; column++)
                {
                    if (row < 1 || column < 1 || row >= dimTotY - 1 || column >= dimTotX - 1)
                    {
                        map[row, column] = -1;
                    }
                    else
                    {
                        map[row, column] = 0;
                    }
                }
            }


            //Add a default start and a default finish

            //Start:
            map[1, 2] = 1;
            map[0, 2] = 1;

            //Finish:
            map[dimTotY - 2, dimTotX - 3] = 1;
            map[dimTotY - 1, dimTotX - 3] = 1;
        }

        //public void generateMaze(int x, int y)
        //{
        //    //Color the cell (explored)
        //    squares[x][y].setBackground(Color.white);

        //    //Mark as visited
        //    array[x][y] = 1;

        //    //Directions array
        //    int[] dir = new int[4];
        //    dir[0] = array[x + 2][y];
        //    dir[1] = array[x - 2][y];
        //    dir[2] = array[x][y + 2];
        //    dir[3] = array[x][y - 2];

        //    //Check if all directions are unavailable
        //    if (noOther(dir)) return;

        //    //Explore all possible directions
        //    while (!noOther(dir))
        //    {

        //        int newDir = randomize(0, 3);
        //        while (dir[newDir] != 0)
        //        {
        //            newDir = randomize(0, 3);
        //        }
        //        if (newDir == 0)
        //        {
        //            if (array[x + 2][y] == 0)
        //            {
        //                generateMaze(x + 2, y);
        //                squares[x + 1][y].setBackground(Color.white);
        //            }
        //            dir[newDir] = 1;
        //        }
        //        else if (newDir == 1)
        //        {
        //            if (array[x - 2][y] == 0)
        //            {
        //                generateMaze(x - 2, y);
        //                squares[x - 1][y].setBackground(Color.white);
        //            }
        //            dir[newDir] = 1;
        //        }
        //        else if (newDir == 2)
        //        {
        //            if (array[x][y + 2] == 0)
        //            {
        //                generateMaze(x, y + 2);
        //                squares[x][y + 1].setBackground(Color.white);
        //            }
        //            dir[newDir] = 1;
        //        }
        //        else if (newDir == 3)
        //        {
        //            if (array[x][y - 2] == 0)
        //            {
        //                generateMaze(x, y - 2);
        //                squares[x][y - 1].setBackground(Color.white);
        //            }
        //            dir[newDir] = 1;
        //        }
        //    }

        //}
    }
}
