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
        InCase element;

        // CONSTRUCTOR
        public Cell(string value)
        {
            this.value = value;
            this.empty = true;
            this.element = null;
        }

        // ACCESSORS
        public string Value
        {
            get { return value; }
        }
        public bool isEmpty
        {
            get { return empty; }
            set { empty = value; }
        }
        public InCase Element
        {
            get { return element; }
            set { element = value; }
        }

        // METHODS


        public override string ToString()
        {
            return this.value;
        }

          
    }
}
