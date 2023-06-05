using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System;

namespace Zmeika
{
    class Stroka
    {
        public string PlayerName { get; set; }
        public int FoodEaten { get; set; }
        public int CurrentSpeed { get; set; }
        

        public Stroka(string playerName, int foodEaten, int currentSpeed)
        {
            PlayerName = playerName;
            FoodEaten = foodEaten;
            CurrentSpeed = currentSpeed;
        }

        public void Draw()
        {
            Console.SetCursorPosition(0, 0);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("Player: ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(PlayerName);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("   Food eaten: ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(FoodEaten);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("   speed: ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(CurrentSpeed);
           
        }
    }
}

