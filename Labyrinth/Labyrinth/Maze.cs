using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
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

        private static Random rnd = new Random();

        private static Mutex mut = new Mutex();

        // CONSTRUCTOR
        public Maze(string path)
        {
            int[] size = GetGridSize(path);
            this.width = size[0];
            this.height = size[1];

            if (!ParseIntoCells(path))
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
            int numberToPlace = 5;
            int alreadyPlaced = 0;

            //Console.WriteLine(numberToPlace+" "+ width + " " + height);

            while (alreadyPlaced < numberToPlace)
            {
                int coordX = rnd.Next(0, width);
                int coordY = rnd.Next(0, height);

                if (board[coordX, coordY].IsEmpty)
                {
                    fighters.Add(new Fighter(coordX, coordY));
                    alreadyPlaced++;
                }
            }
        }

        // places the objects ramdomly on empty cells
        public void PlaceObjectsRamdomly(int percentage)
        {
            int numberToPlace = width * height * percentage / 100;

            Random rnd = new Random();

            //Console.WriteLine(numberToPlace+" "+ width + " " + height);
            for(int y = 0; y < this.height; y++)
            {
                for(int x = 0; x < this.width; x++)
                {
                    int randomInt = rnd.Next(0, 100);
                    
                    if (board[x, y].IsEmpty && !CheckForFighter(x, y) && randomInt < percentage)
                    {
                        objects.Add(new Object(rnd.Next(1, 10), x, y));
                    }
                }
            }
        }

        // checks coordinates to see if there is no fighters
        private bool CheckForFighter(int coordX, int coordY)
        {
            foreach(Fighter fighter in fighters)
            {
                if(fighter.X.Equals(coordX) && fighter.Y.Equals(coordY))
                {
                    return true;
                }
            }
            return false;
        }

        //launches a Thread per fighter, and start to fight
        public void Start()
        {
            new Thread(Display).Start();
            foreach (Fighter fighter in fighters) // à threader
            {
                new Thread(() => DoInBackground(fighter)).Start();
            }
        }


        private void DoInBackground(Fighter fighter)
        {
            int number = rnd.Next(0, 1000);
            Console.WriteLine("New Task with id : " + number.ToString());
            while(true)
            {
                fighter.Move(this.board);
                FighterGetObject(fighter);
                Thread.Sleep(500);
            }
        }

        // returns the object if there is an object in the cell or return null
        public Object CheckForCell(int x,int y)
        {
            foreach(Object obj in objects)
            {
                if (obj.X == x && obj.Y == y)
                    return obj;
            }
            return null;
        }

        // fighter gets an object
        public void FighterGetObject(Fighter fighter)
        {
            Object obj= CheckForCell(fighter.X, fighter.Y);

            mut.WaitOne();
            if (obj != null)
            {
                fighter.AddObjectInList(obj);
                objects.Remove(obj);
            }
            mut.ReleaseMutex();
            //else
                //Console.WriteLine("Erreur fdp");
                
        }

        // displays the board in console
        public void Display()
        {
            while(true)
            {
                Console.Clear();

                // print the static maze
                for (int y = 0; y < height; y++)
                {
                    for (int x = 0; x < width; x++)
                    {
                        WriteAt(board[x, y].Display(), x, y);
                    }
                }

                // print the fighters
                foreach (Fighter fighter in fighters)
                {
                    WriteAt(fighter.Display(), fighter.X, fighter.Y);
                }

                // print the objects
                foreach (Object obj in objects)
                {
                    WriteAt(obj.Display(), obj.X, obj.Y);
                }
                Thread.Sleep(100);
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

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    msg += this.board[x, y].ToString() + " ";
                }
                msg += "\n";
            }

            return msg;
        }
    }
}
