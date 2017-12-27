using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Labyrinth
{
    class Program
    {
        //file must be in project/bin/Debug
        private const string PATH = "file.txt";

        static void Main(string[] args)
        {
            Maze maze = new Maze(PATH);
            maze.PlaceFighters(3);
            maze.PlaceObjectsRamdomly(30);
            maze.Start();

            Console.ReadKey();
        }


    }
}
