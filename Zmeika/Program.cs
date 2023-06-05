using Zmeika;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using static System.Formats.Asn1.AsnWriter;

namespace Zmeika
{

    class Program
    {

        static void Main(string[] args)
        {

            Console.SetWindowSize(80, 26); // сделал больше окно что бы сделать строку с именем колечтовм еды и скорости

            Player player1 = new Player();
            player1.SetName();
            Console.Clear();

            Walls walls = new Walls(80, 25);
            Console.ForegroundColor = ConsoleColor.Red; //цвет контура
            walls.Draw();

            // Отрисовка точек			
            Point p = new Point(4, 5, '*');
            Snake snake = new Snake(p, 4, direction.RIGHT);
            snake.Draw();

            FoodCreator foodCreator = new FoodCreator(80, 25, '$');
            Point food = foodCreator.CreateFood();
            food.Draw();

            int foodCount = 0; //количество сьеденой еды
            SpeedController speedController = new SpeedController(100, -5, 1);

            using (StreamWriter writer = new StreamWriter("records.txt", true))
            {
                Sounds mainmusic = new Sounds();
                _ = mainmusic.Tagaplaanis_Mangida("../../../snakemusic.mp3");
                while (true)
                {

                    if (walls.IsHit(snake) || snake.IsHitTail())
                    {
                        WriteGameOver(foodCount, player1.Name, writer); //записывается имя 
                        break;
                    }

                    if (snake.Eat(food))
                    {

                        _ = mainmusic.Tagaplaanis_Mangida("../../../eatfood.mp3");
                        foodCount++;
                        food = foodCreator.CreateFood();
                        food.Draw();

                        if (speedController.ShouldIncreaseSpeed(foodCount))
                        {
                            speedController.IncreaseSpeed();
                        }
                    }
                    else
                    {
                        snake.Move();
                    }


                    Stroka stroka = new Stroka(player1.Name, foodCount, speedController.GetCurrentSpeed());
                    stroka.Draw();

                    Thread.Sleep(speedController.GetCurrentSpeed());

                    if (Console.KeyAvailable)
                    {
                        ConsoleKeyInfo key = Console.ReadKey();
                        snake.HandleKey(key.Key);
                    }
                }
            }

            // Чтение и вывод содержимого файла
            using (StreamReader reader = new StreamReader("records.txt"))
            {
                string text = reader.ReadToEnd();
                Console.WriteLine(text);
            }

            Console.ReadLine();
        }

        static void WriteGameOver(int foodCount, string playerName, StreamWriter writer)
        {
            Sounds mainmusic = new Sounds();
            _ = mainmusic.Tagaplaanis_Mangida("../../../umer.mp3");
            int xOffset = 25;
            int yOffset = 8;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(xOffset, yOffset++);

            Console.WriteLine("G A M E  O V E R", xOffset + 1, yOffset++);
            Console.WriteLine("Food eaten: " + foodCount, xOffset + 2, yOffset++);

            // Запись информации в файл
            writer.WriteLine("Player: " + playerName + "   Food eaten: " + foodCount);
        }
    }
}
