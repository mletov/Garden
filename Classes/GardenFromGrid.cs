using GardenAndGardeners.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace GardenAndGardeners.Classes
{
    class GardenFromGrid : Garden
    {
        public Grid Grid { get;  }

        public GardenFromGrid(Grid grid, int cntColumns, int cntRows) : base(cntColumns, cntRows)
        {
            this.Grid = grid;
        }

        protected override void GardenInit()
        {
            base.GardenInit();
        }



        /*
        public Grid Grid { get; private set; }
        public Garden(Grid grid)
        {
            this.Grid = grid;
            GridInitioanalizator gi = new GridInitioanalizator(this.Grid);
            gi.Initialize();
        }
        */
    }
}
