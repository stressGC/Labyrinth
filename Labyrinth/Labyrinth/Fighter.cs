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


            Console.WriteLine("Fighter placed at (" + x + "," + y + ")");
        }

        // METHODS
        public string Display()
        {
            return "$";
        }

        internal void Move()
        {
            throw new NotImplementedException();
        } //to implement

        internal void Fight()
        {
            throw new NotImplementedException();
        } //to implement
    }
}
