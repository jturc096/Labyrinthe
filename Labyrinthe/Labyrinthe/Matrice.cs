﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;

namespace Labyrinthe
{

    public class Matrice
    {
        int dimTotY;
        int dimTotX;
        int dimX;
        int dimY;
        private int[,] map;
        Random rnd;
        

        public Matrice(int x, int y)
        {
            dimX = x;
            dimY = y;
            dimTotX = x * 2 + 3;
            dimTotY = y * 2 + 3;
            map = new int[dimTotX, dimTotY];
            rnd = new Random();
            init();
        }

        public int[,] getMap()
        {
            return map;
        }

        public void init()
        {
            for (int row = 0; row < dimTotX; row++)
            {
                for (int column = 0; column < dimTotY; column++)
                {
                    if (row <= 1 || column <= 1 || row >= dimTotX - 2 || column >= dimTotY - 2)
                    {
                        map[row, column] = -1;
                    }
                    else
                    {
                        map[row, column] = 0;
                    }
                }
            }

            //Generate de maze (matrix of int but not colors)
            generateMaze(2, 2);

            //Add a default start and a default finish

            //Start:
            map[1, 2] = 1;
            map[0, 2] = 1;

            //Finish:
            map[dimTotX - 2, dimTotY - 3] = 1;
            map[dimTotX - 1, dimTotY - 3] = 1;
        }

        //Verify all 4 directions and return TRUE if none of them are available
        private bool noOther(int[] dir)
        {
            return (dir[0] != 0 && dir[1] != 0 && dir[2] != 0 && dir[3] != 0);
        }

        public void generateMaze(int x, int y)
        {


            //Mark as visited
            map[x, y] = 1;

            //Directions map
            int[] dir = new int[4];
            dir[0] = map[x + 2, y];
            dir[1] = map[x - 2, y];
            dir[2] = map[x, y + 2];
            dir[3] = map[x, y - 2];

            //Check if all directions are unavailable
            if (noOther(dir)) {
                return;
            } 

            //Explore all possible directions
            while (!noOther(dir))
            {

                int newDir = randomize(0, 3);
                while (dir[newDir] != 0)
                {
                    newDir = randomize(0, 3);
                }
                if (newDir == 0)
                {
                    if (map[x + 2, y] == 0)
                    {
                        map[x + 1, y] = 1;
                        generateMaze(x + 2, y);
                    }
                    dir[newDir] = 1;
                }
                else if (newDir == 1)
                {
                    if (map[x - 2, y] == 0)
                    {
                        map[x - 1, y] = 1;
                        generateMaze(x - 2, y);
                    }
                    dir[newDir] = 1;
                }
                else if (newDir == 2)
                {
                    if (map[x, y + 2] == 0)
                    {
                        map[x, y + 1] = 1;
                        generateMaze(x, y + 2);
                    }
                    dir[newDir] = 1;
                }
                else if (newDir == 3)
                {
                    if (map[x, y - 2] == 0)
                    {
                        map[x, y - 1] = 1;
                        generateMaze(x, y - 2);
                    }
                    dir[newDir] = 1;
                }
            }


        }

        //MÉTHODE RANDOMIZE()
        /** Cette méthode génère un chiffre entier aléatoire entre a et b.
          * @return un nombre aléatoire compris dans l'intervalle de a et de b.
         */
        private int randomize(int a, int b)
        {
            //0 = UP, 1 = DOWN, 2 = RIGHT, 3 = LEFT
            int rez = rnd.Next(0,4);

            return rez;

        }

        public int[,] getDim() { 
            int[,] ret = new int[1,2];
            ret[0, 0] = dimTotX;
            ret[0, 1] = dimTotY;
            return ret;
        }
        public void toString()
        {
  
            foreach (var item in map)
            {
                Console.WriteLine(item.ToString());
            }

        }


    }
    }

