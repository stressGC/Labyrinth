using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labyrinth
{
    class Maze
    {
        // ATTRIBUTES
        private Cell[,] board;
        private int width;
        private int height;

        private List<Fighter> fighters = new List<Fighter>();
        private List<Object> objects = new List<Object>();


        // CONSTRUCTOR
        public Maze(string path)
        {
            int[] size = GetGridSize(path);
            this.width = size[0];
            this.height = size[1];

            if(!ParseIntoCells(path))
            {
                Console.WriteLine("Error in the Maze constructor");
            }
        }

        //converts the file into a Cell array
        private bool ParseIntoCells(string path)
        {
            int[] dimensions = GetGridSize(path);

            if (dimensions[0] == -1 || dimensions[1] == -1)
            {
                return false;
            }

            int tailleX = dimensions[0];
            int tailleY = dimensions[1];
            int counter = 0;

            string[,] grid = new string[tailleX, tailleY];

            String line;

            try
            {
                this.board = new Cell[width, height];
                StreamReader sr = new StreamReader(path);
                line = sr.ReadLine();

                while (line != null)
                {
                    if (line != null)
                    {
                        for (int i = 0; i < line.Length; i++)
                        {
                            this.board[i, counter] = new Cell(line[i].ToString());
                        }
                        
                        line = sr.ReadLine();
                        counter++;
                    }
                }
                sr.Close();
                return true;

            }
            catch (Exception e)
            {
                Console.WriteLine("Error in GridConstructor : " + e.Message);
                Console.ReadKey();
                return false;
            }
        }
        // function that returns an array containing both dimension length of the text file
        private static int[] GetGridSize(string path)
        {
            String line;
            int[] size = new int[2];

            int lineCounter = 0;
            int lineLength = -1;

            bool correctFormat = true;

            try
            {
                StreamReader sr = new StreamReader(path);
                line = sr.ReadLine();
                lineLength = line.Length;


                while (line != null && correctFormat)
                {
                    lineCounter++;
                    line = sr.ReadLine();

                    // file isn't well formatted, lines don't have the same length
                    if (line != null && line.Length != lineLength)
                    {
                        correctFormat = false; //break from while;
                        Console.WriteLine("Error while reading the text file : " + lineLength.ToString() + " chars length expected, line " + lineCounter.ToString() + " contains " + line.Length.ToString());
                    }
                }

                sr.Close();

                if (!correctFormat)
                {
                    size[0] = -1;
                    size[1] = -1;
                    return size;
                }

                //Console.WriteLine("The file " + path + " has correct size.");

                size[0] = lineLength;
                size[1] = lineCounter;
                return size;

            }
            catch (Exception e)
            {
                Console.WriteLine("Exception in gridSize : " + e.Message);
                size[0] = -1;
                size[1] = -1;
                return size;
            }
        }

        // ACCESSORS


        // METHODS


        // places the fighter at random spots of the board
        public void PlaceFighters(int percentage)
        {
            //double numberToPlace = width * height * percentage / 100;
            int numberToPlace = 1;
            int alreadyPlaced = 0;

            Random rnd = new Random();

            //Console.WriteLine(numberToPlace+" "+ width + " " + height);

            while(alreadyPlaced < numberToPlace)
            {
                int coordX = rnd.Next(0, width);
                int coordY = rnd.Next(0, height);

                if(board[coordX, coordY].IsEmpty)
                {
                    fighters.Add(new Fighter(coordX, coordY));
                    alreadyPlaced++;
                }
            }
        }

        //launches a Thread per fighter, and start to fight
        public void Start()
        {
            foreach(Fighter fighter in fighters) // à threader
            {
                for(int i = 0; i < 400; i++)
                {
                    WriteAt("starts moving", 15, 1);
                    fighter.Move(board);
                    this.Display();
                    System.Threading.Thread.Sleep(200);
                }

                //TODO
                /*if(fighter.IsOffensive)
                {
                    fighter.Fight();
                }
                else
                {
                    fighter.Move();
                }*/
            }
        }

        // displays the board in console
        public void Display()
        {
            Console.Clear();

            // print the static maze
            for(int y = 0; y < height; y++)
            {
                for(int x = 0; x < width; x++)
                {
                    WriteAt(board[x, y].Display(), x, y);
                }
            }

            // print the fighters
            foreach(Fighter fighter in fighters)
            {
                WriteAt(fighter.Display(), fighter.X, fighter.Y);
            }
        }

        // prints at a given place in the console
        private void WriteAt(string s, int x, int y)
        {
            try
            {
                Console.SetCursorPosition(1 + 2 * x, y);
                Console.Write(s);
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.Clear();
                Console.WriteLine(e.Message);
            }
        }

        public override string ToString()
        {
            string msg = "";

            for(int y = 0; y < height; y++)
            {
                for(int x = 0; x < width; x++)
                {
                    msg += this.board[x, y].ToString() + " ";
                }
                msg += "\n";
            }

            return msg;
        }
    }
}
