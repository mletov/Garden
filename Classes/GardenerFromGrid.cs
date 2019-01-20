using GardenAndGardeners.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;

namespace GardenAndGardeners.Classes
{
    class GardenerFromGrid : Gardener
    {
        public readonly SolidColorBrush BgBrushColor;
        static object locker = new object();

        public GardenerFromGrid(int gardenerNumber, SolidColorBrush bgBrushColor) : base(gardenerNumber)
        {
            this.BgBrushColor = bgBrushColor;
        }

        /*
        public void TakeGardenCell(GardenFromGrid garden, int rowNum, int colNum) 
        {
            base.TakeGardenCell(garden, rowNum, colNum);
            this.FillArea(garden, colNum, rowNum);
        }


        public void FillArea(GardenFromGrid garden, int colNum, int rowNum)
        {        
            System.Windows.Controls.Border border = new System.Windows.Controls.Border()
            {
                Background = this.color,
                BorderThickness = new System.Windows.Thickness(1, 1, 1, 1),
                BorderBrush = Brushes.Green

            };
            border.SetValue(Grid.ColumnProperty, colNum);
            border.SetValue(Grid.RowProperty, rowNum);

            garden.Grid.Children.Add(border);
        }
        */

    }
}
