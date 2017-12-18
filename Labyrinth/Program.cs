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

        /* returns a string array from a path, representing the maze
        private static string[,] GridFetcher()
        {
            int[] dimensions = GetGridSize();

            if(dimensions[0] == -1 || dimensions[1] == -1)
            {
                return null;
            }

            int tailleX = dimensions[0];
            int tailleY = dimensions[1];
            int counter = 0;

            Console.WriteLine("(" + tailleX.ToString() + "," + tailleY.ToString() + ")");

            string[,] grid = new string[tailleX, tailleY];

            String line;

            try
            {
                StreamReader sr = new StreamReader(PATH);
                line = sr.ReadLine();

                while (line != null)
                {
                    if(line!=null)
                    {
                        for (int i = 0; i < line.Length; i++)
                        {
                            Console.Write(line[i]);
                            grid[i,counter] = line[i].ToString();
                        }

                        Console.WriteLine();
                        line = sr.ReadLine();
                        counter++;
                    }
                }

                sr.Close();
                return grid;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error in GridConstructor : " + e.Message);
                Console.ReadKey();
                return grid;
            }
        }

        // displays a grid
        private static void DisplayGrid(string[,] grid)
        {
            int sizeX = grid.GetLength(0);
            int sizeY = grid.GetLength(1);

            for(int i = 0; i < sizeX; i++)
            {
                for(int j = 0; j < sizeY; j++)
                {
                    Console.Write(grid[i, j]);
                }

                Console.WriteLine();
            }
        }

        // reads a file and prints it in console 
        private static void ReadFile()
        {
            String line;

            try
            {
                StreamReader sr = new StreamReader(PATH);
                line = sr.ReadLine();

                while (line != null)
                {
                    Console.WriteLine(line);
                    line = sr.ReadLine();

                }
                sr.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("exception" + e.Message);
                Console.ReadKey();
            }
        }*/

        static void Main(string[] args)
        {
            Maze maze = new Maze(PATH);
            maze.ToString();
            maze.PlaceFighters(3);

            Console.ReadKey();
        }
    }
}
