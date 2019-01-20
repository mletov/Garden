using Garden.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;

namespace GardenAndGardeners.Classes
{
    
    class IGardenRouteCreator
    {
        private IGarden _garden { get; set; }
        public IGardenRouteCreator(IGarden garden)
        {
            this._garden = garden;
            this.RecreateGarden();
        }

        private void RecreateGarden()
        {
            for (int i = 0; i < this._garden.CntRows; i++)
            {
                for (int j = 0; j < this._garden.CntColumns; j++)
                {
                    int rnd = Randomizer.GetRandomNumber(0, 2);
                    this._garden[i, j] = rnd;
                }
            }
        }
    }
    /*
    class GardenRouteCreator
    {
        private Garden garden { get; set; }
        public GardenRouteCreator(Garden garden)
        {
            this.garden = garden;
        } 

        public void RecreateGarden()
        {

            for (int i = 0; i < this.garden.Grid.RowDefinitions.Count;i++)
            {
                for (int j = 0; j < this.garden.Grid.RowDefinitions.Count; j++)
                {
                    int rnd = Randomizer.GetRandomNumber(0, 2);
                    if (rnd == 1) this.SetCellStyle(i, j);
                }
            }
        }

        private void SetCellStyle(int rowNum, int colNum)
        {
            System.Windows.Controls.Border border = new System.Windows.Controls.Border()
            {
                Background = Brushes.GreenYellow,
                BorderThickness = new System.Windows.Thickness(1, 1, 1, 1),
                BorderBrush = Brushes.Green

            };
            border.SetValue(Grid.ColumnProperty, colNum);
            border.SetValue(Grid.RowProperty, rowNum);
            this.garden.Grid.Children.Add(border);
        }

    }
    */
}
