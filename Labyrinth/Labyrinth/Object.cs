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
        private int x;
        private int y;

        public int X { get => x; set => x = value; }
        public int Y { get => y; set => y = value; }
        public int Damage { get => damage; set => damage = value; }

        public Object(int damage, int x, int y)
        {
            this.damage = damage;
            this.x = x;
            this.y = y;
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
