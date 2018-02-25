using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_demo
{
    class Program
    {
        static void Main(string[] args)
        {
            Game game =  new Game();
            game.InitModel();
            game.RunModel();
            Console.ReadLine();
        }
    }
}
