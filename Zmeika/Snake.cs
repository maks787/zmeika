using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Zmeika
{
    class Snake : Figure
    {
        direction Direction;
        public Snake(Point tail, int lenght, direction _Direction)
        {
            Direction = _Direction;
            pList = new List<Point>();
            for(int i = 0; i< lenght; i++) 
            {
                Point p = new Point(tail);
                p.Move(i, Direction);
                pList.Add(p);
            }

        }
        internal void Move()
        {
            
            Point tail = pList.First();
            pList.Remove(tail);
            Point head = GetNextPoint();
            pList.Add(head);
            tail.Clear();
            head.Draw();

        }
        public Point GetNextPoint()
        {
            Point head = pList.Last();
            Point nextPoint = new Point(head);
            nextPoint.Move(1, Direction);
            return nextPoint;
        }
        internal bool IsHitTail()
        {
            var head = pList.Last();
            for(int i = 0; i < pList.Count - 2; i++)
            {
                if (head.IsHit(pList[i]))
                    return true;
            }
            return false;
        }
        public void HandleKey(ConsoleKey key)
        {
            if (key == ConsoleKey.LeftArrow)
                Direction = direction.LEFT;
            else if (key == ConsoleKey.RightArrow)
                Direction = direction.RIGHT;
            else if (key == ConsoleKey.DownArrow)
                Direction = direction.DOWN;
            else if (key == ConsoleKey.UpArrow)
                Direction = direction.UP;
        }
        internal bool Eat(Point food)
        {
            Point head = GetNextPoint();
            if (head.IsHit(food))
            {
                food.sym = head.sym;
                pList.Add(food);
                return true;
            }
            else
                return false;
        }
        internal bool Eat2(Point food)
        {
            Point head = GetNextPoint();
            if (head.IsHit(food))
            {
                food.sym = head.sym;
                pList.Add(food);
                return true;
            }
            else
                return false;
        }


    }  
}
