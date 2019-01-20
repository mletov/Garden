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

    class GardenGridDecorator
    {
        public readonly Garden Garden;
        private Grid grid { get; }


        public GardenGridDecorator(Grid grid, Garden garden)
        {
            this.grid = grid;
            this.Garden = garden;
            this.Initialize();
        }

        public void TakeGardenCell(int rowNum, int colNum, int gardenerNumber)
        {
            GardenerFromGrid gardener = GardenerCollection.Gardeners.Where(x => x.GardenerNumber == gardenerNumber).FirstOrDefault();
            if (gardener != null && gardener.BgBrushColor != null)
            {
                this.SetCellStyle(rowNum, colNum, gardener.BgBrushColor);
            }
        }

        private void AddColums()
        {
            for (int i = 0; i < this.Garden.CntColumns; i++)
            {
                ColumnDefinition cd = new ColumnDefinition();
                grid.ColumnDefinitions.Add(cd);
            }
        }

        private void AddRows()
        {
            for (int i = 0; i < this.Garden.CntRows; i++)
            {
                RowDefinition rd = new RowDefinition();
                grid.RowDefinitions.Add(rd);
            }
        }

        private void SetDefaltCellsStyle()
        {
            for (int i = 0; i < this.Garden.CntColumns; i++)
            {
                for (int j = 0; j < this.Garden.CntRows; j++)
                {
                    this.SetCellStyle(j, i, Brushes.Yellow);
                }
            }
        }

        private void SetCellStyle(int rowNum, int colNum, SolidColorBrush bgBrush)
        {
            System.Windows.Controls.Border border = new System.Windows.Controls.Border()
            {
                Background = bgBrush,
                BorderThickness = new System.Windows.Thickness(1, 1, 1, 1),
                BorderBrush = Brushes.Green
            };
            border.SetValue(Grid.ColumnProperty, colNum);
            border.SetValue(Grid.RowProperty, rowNum);
            grid.Children.Add(border);
        }

        private void Initialize()
        {
            this.AddColums();
            this.AddRows();
            this.SetDefaltCellsStyle();
        }
    }
    
}
