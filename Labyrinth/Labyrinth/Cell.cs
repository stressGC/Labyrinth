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
        Element element;

        // CONSTRUCTOR
        public Cell(string value)
        {
            this.value = value;
            this.element = null;

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
        public Element Element
        {
            get { return element; }
            set { element = value; }
        }

        // METHODS
        public void SetFighter(Fighter fighter)
        {
            this.IsEmpty = false;
            this.element = fighter;
        }
        public override string ToString()
        {
            return this.value;
        } 

        public string Display()
        {
            if(this.value=="1")
            {
                return "";
            }
            return "";
        }
    }
}
