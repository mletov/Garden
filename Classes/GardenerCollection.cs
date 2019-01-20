using GardenAndGardeners.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Garden.Classes
{
    class GardenerCollection
    {
        public static List<GardenerFromGrid> Gardeners { get; private set; } = new List<GardenerFromGrid>();
        public GardenerCollection()
        {
            Gardeners.Add(new GardenerFromGrid(0, Brushes.Yellow));
        }
    }
}
