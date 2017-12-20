using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labyrinth
{
    class Object
    {
        private int damage;

        public Object(int value)
        {
            this.damage = value;
        }

        // function called to decrement the damage of an object after it is used
        public void Use()
        {
            this.damage--;
        }

        // check if object still does damages
        public bool isUsable()
        {
            if(this.damage > 0)
            {
                return true;
            }

            return false;
        }

        public string Display()
        {
            return "@";
        }
    }
}
