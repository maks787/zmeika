﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zmeika
{
    class Walls
    {
        List<Figure> wallList;
        public Walls(int mapWidht,int mapHeight)
        {
            wallList = new List<Figure>();
           
            HorizontalLine upLine = new HorizontalLine(0, mapWidht - 2,1, '+');
            
            HorizontalLine downLine = new HorizontalLine(0, mapWidht - 2, mapHeight -1, '+');
            
            VerticalLine leftLine = new VerticalLine(2, mapHeight - 1,0, '|');
            
            VerticalLine rightLine = new VerticalLine(2, mapHeight - 1, mapWidht - 2, '|');
            wallList.Add(upLine);
            wallList.Add(downLine); 
            wallList.Add(leftLine);
            wallList.Add(rightLine);
        }
        internal bool IsHit(Figure figure) 
        {
            foreach (var wall in wallList)
            {
                if (wall.IsHit(figure))
                {
                    return true;
                }
            }
            return false;
        }
        public void Draw()
        {
            foreach (var wall in wallList)
            {
                wall.Draw();
            }
        }
    }
}
