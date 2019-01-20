using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GardenAndGardeners.Classes
{
    class Gardener
    {
        public int GardenerNumber {get; private set;}
        public Gardener(int gardenerNumber)
        {
            this.GardenerNumber = gardenerNumber;
        }

        public void TakeGardenCell(Garden garden, int rowNum, int colNum)
        {
            garden[rowNum, colNum] = this.GardenerNumber;
        }
    }
}
