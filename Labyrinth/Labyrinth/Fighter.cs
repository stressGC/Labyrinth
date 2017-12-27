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
        internal void Move(Cell[,] board)
        {
            int rnd = random.Next(0, 4);

            switch (rnd) // 0, 1, 2, 3
            {
                case 0:
                    if (CanMoveTop(board))
                    {
                        MoveTop();
                        CheckForWin(board);
                    }
                    else
                    {
                        this.Move(board);
                    }
                    break;
                case 1:
                    if (CanMoveRight(board))
                    {
                        MoveRight();
                        CheckForWin(board);
                    }
                    else
                    {
                        this.Move(board);
                    }
                    break;
                case 2:
                    if (CanMoveBottom(board))
                    {
                        MoveBottom();
                        CheckForWin(board);
                    }
                    else
                    {
                        this.Move(board);
                    }
                    break;
                case 3:
                    if (CanMoveLeft(board))
                    {
                        MoveLeft();
                        CheckForWin(board);
                    }
                    else
                    {
                        this.Move(board);
                    }
                    break;
            }

        }

        private bool CanMoveTop(Cell[,] board)
        {
            if (this.Y > 0 && board[this.x, this.y - 1].IsEmpty && board[this.x, this.y - 1].Value != "1")
            {
                return true;
            }
            return false;
        }
        private bool CanMoveRight(Cell[,] board)
        {
            if (this.X < board.GetLength(0) - 1 && board[this.x + 1, this.y].IsEmpty && board[this.x + 1, this.y].Value != "1")
            {
                return true;
            }
            return false;
        }
        private bool CanMoveBottom(Cell[,] board)
        {
            if (this.Y < board.GetLength(1) - 1 && board[this.x, this.y + 1].IsEmpty && board[this.x, this.y + 1].Value != "1")
            {
                return true;
            }

            return false;
        }
        private bool CanMoveLeft(Cell[,] board)
        {
            if (this.X > 0 && board[this.x, this.y].Value != "1"&& board[this.x - 1, this.y].IsEmpty) 
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
