using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labyrinth
{
    class Cell
    {
        // ATTRIBUTES
        string value;
        bool empty;

        // CONSTRUCTOR
        public Cell(string value)
        {
            this.value = value;

            switch (this.value)
            {
                case "0":
                    this.empty = true;
                    break;
                case "1":
                    this.empty = false;
                    break;
                case "2":
                    this.empty = true;
                    break;
                default:
                    Console.WriteLine("Error while instanciating cells");
                    break;
            }
        }

        // ACCESSORS
        public string Value
        {
            get { return value; }
        }
        public bool IsEmpty
        {
            get { return empty; }
            set { empty = value; }
        }

        // METHODS
        public override string ToString()
        {
            return this.value;
        } 

        public string Display()
        {
            string str = "";
            switch (this.value)
            {
                case "1": //wall
                    str = "■";
                    break;

                case "2": // exit
                    str = "X";
                    break;
            }

            return str;
        }
    }
}
