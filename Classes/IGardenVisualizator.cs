using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garden.Classes
{
    abstract class IGardenVisualizator
    {
        private IGarden _garden;
        IGardenVisualizator(IGarden garden)
        {
            this._garden = garden;
        }
        abstract public void Visualize();
    }
}
