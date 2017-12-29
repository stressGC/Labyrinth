using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labyrinth
{
    class Fighter
    {
        // ATTRIBUTES
        private int x;
        private int y;

        private int life;
        private int power;
        private List<Object> objects;
        private bool isOffensive;

        Random random = new Random();

        // ACCESSORS
        public int X { get => x; set => x = value; }
        public int Y { get => y; set => y = value; }
        public bool IsOffensive { get => IsOffensive; set => isOffensive = value; }
        // public List<Object> Objects { get => Objects; set => Objects.Add(value); }

        // CONSTRUCTOR
        public Fighter(int x, int y)
        {
            this.X = x;
            this.Y = y;

            this.life = 100;
            this.power = 10;
            this.objects = new List<Object>();
            this.isOffensive = false;


            //Console.WriteLine("Fighter placed at (" + x + "," + y + ")");
            //Console.ReadKey();
        }

        // METHODS

        public void AddObjectInList(Object obj)
        {
            objects.Add(obj);
        }

        public string Display()
        {
            return "$";
        }

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

        // moves the fighter randomly to a possible location near him
        internal void Move(Maze maze)
        {
            int rnd = random.Next(0, 4);

            switch (rnd) // 0, 1, 2, 3
            {
                case 0:
                    if (CanMoveTop(maze))
                    {
                        MoveTop();
                        CheckForWin(maze.Board);
                    }
                    else
                    {
                        this.Move(maze);
                    }
                    break;
                case 1:
                    if (CanMoveRight(maze))
                    {
                        MoveRight();
                        CheckForWin(maze.Board);
                    }
                    else
                    {
                        this.Move(maze);
                    }
                    break;
                case 2:
                    if (CanMoveBottom(maze))
                    {
                        MoveBottom();
                        CheckForWin(maze.Board);
                    }
                    else
                    {
                        this.Move(maze);
                    }
                    break;
                case 3:
                    if (CanMoveLeft(maze))
                    {
                        MoveLeft();
                        CheckForWin(maze.Board);
                    }
                    else
                    {
                        this.Move(maze);
                    }
                    break;
            }

        }

        private bool CanMoveTop(Maze maze)
        {
            foreach(Fighter f in maze.Fighter)
            {
                if (f.X==this.x && f.Y==this.y-1)
                    return false;
            }
  
            if (this.Y > 0 && maze.Board[this.x, this.y - 1].IsEmpty && maze.Board[this.x, this.y - 1].Value != "1")
            {
                return true;
            }
            return false;
        }
        private bool CanMoveRight(Maze maze)
        {
            foreach (Fighter f in maze.Fighter)
            {
                if (f.X == this.x+1 && f.Y == this.y)
                    return false;
            }

            if (this.X < maze.Board.GetLength(0) - 1 && maze.Board[this.x + 1, this.y].IsEmpty && maze.Board[this.x + 1, this.y].Value != "1")
            {
                return true;
            }
            return false;
        }
        private bool CanMoveBottom(Maze maze)
        {
            foreach (Fighter f in maze.Fighter)
            {
                if (f.X == this.x && f.Y == this.y + 1)
                    return false;
            }

            if (this.Y < maze.Board.GetLength(1) - 1 && maze.Board[this.x, this.y + 1].IsEmpty && maze.Board[this.x, this.y + 1].Value != "1")
            {
                return true;
            }

            return false;
        }
        private bool CanMoveLeft(Maze maze)
        {
            foreach (Fighter f in maze.Fighter)
            {
                if (f.X == this.x - 1 && f.Y == this.y)
                    return false;
            }

            if (this.X > 0 && maze.Board[this.x, this.y].Value != "1"&& maze.Board[this.x - 1, this.y].IsEmpty) 
            {
                return true;
            }
            return false;
        }

        private void MoveTop()
        {
            this.Y--;
        }
        private void MoveRight()
        {
            this.X++;
        }
        private void MoveBottom()
        {
            this.Y++;
        }
        private void MoveLeft()
        {
            this.X--;
        }

        private void CheckForWin(Cell[,] board)
        {
            if(board[this.x, this.y].Value=="2")
            {
                //has win
                Console.Clear();
                Console.WriteLine("Fighter has won");
                Console.ReadKey();
                Environment.Exit(0);
            }
        }

        public void Fight()
        {
            throw new NotImplementedException();
        }
    }
}
