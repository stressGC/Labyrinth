using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labyrinth
{
    class Fighter : InCase
    {
        int life;
        int power;
        List<Object> objects;
        bool isOffensive;

        public Fighter()
        {
            this.life = 100;
            this.power = 10;
            this.objects = new List<Object>();
            this.isOffensive = false;
        }
    }
}
