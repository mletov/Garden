using GardenAndGardeners.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Garden.Classes
{
    class GardenVisualisatorFromGrid
    {
        public static void Visualize(GardenGridDecorator gd)
        {            
            for (int i = 0; i < gd.Garden.CntRows; i++)
            {
                for (int j = 0; j < gd.Garden.CntColumns; j++)
                {
                    gd.TakeGardenCell(i, j, gd.Garden[i, j]);
                }
            }
        }

    
    }
}
