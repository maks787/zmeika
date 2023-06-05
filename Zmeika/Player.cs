using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zmeika
{
    class Player
    {
        public string Name { get; set; } 
        public void SetName()
        {
            Console.WriteLine("Sisesta sinu nimi");
            Name = Console.ReadLine();

        }

    }
}
