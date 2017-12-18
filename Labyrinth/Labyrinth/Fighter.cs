using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labyrinth
{
    class Fighter : Element
    {
        private int life;
        private int power;
        private List<Object> objects;
        private bool isOffensive;

        public Fighter()
        {
            this.life = 100;
            this.power = 10;
            this.objects = new List<Object>();
            this.isOffensive = false;
        }
    }
}
