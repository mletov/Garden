using Garden.Classes;
using GardenAndGardeners.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace GardenAndGardeners
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
         private Action<Gardener, GardenAndGardeners.Classes.Garden>[] arFillAreas = new Action<Gardener, GardenAndGardeners.Classes.Garden>[2];

        public MainWindow()
        {
            InitializeComponent();
            Grid grid = MainGrid;

            //Создаем сад
            GardenAndGardeners.Classes.Garden garden = new GardenAndGardeners.Classes.Garden(40, 40);

            //Участники
            Gardener gardener1 = new GardenerFromGrid(2,Brushes.Blue);
            Gardener gardener2 = new GardenerFromGrid(3, Brushes.Chocolate);

            //Глобальная коллекция
            GardenerCollection.Gardeners.Add((GardenerFromGrid)gardener1);
            GardenerCollection.Gardeners.Add((GardenerFromGrid)gardener2);           

            //Массив прохода по направлениям
            this.arFillAreas[(int)Direction.Forward] = FillerGarden.FillAllAreasForward;
            this.arFillAreas[(int)Direction.Backward] = FillerGarden.FillAllAreasBackward;

            //Запускаем потоки
            Thread myThread0 = new Thread(new ParameterizedThreadStart(FillAllAreas));
            Thread myThread1 = new Thread(new ParameterizedThreadStart(FillAllAreas));
            myThread0.Start(new Filler { Gardener = gardener1, Direction = Direction.Forward, Garden = garden });
            myThread1.Start(new Filler { Gardener = gardener2, Direction = Direction.Backward, Garden = garden });


            myThread0.Join();
            myThread1.Join();

            //Визуализируем
            GardenGridDecorator gd = new GardenGridDecorator(grid, garden);
            GardenVisualisatorFromGrid.Visualize(gd);
        }

        private void FillAllAreas(Object filler)
        {
            Filler f = (Filler)filler;
            this.arFillAreas[(int)f.Direction].Invoke(f.Gardener, f.Garden);
        }

        private enum Direction { Forward = 0, Backward = 1 };

        private class Filler
        {
            public Gardener Gardener { get; set; }
            public Direction Direction { get; set; }
            public GardenAndGardeners.Classes.Garden Garden { get; set; }
        }


    }



        /*
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Grid grid = MainGrid;

            //Покраска вперед и назад
            this.arFillAreas[(int)Direction.Forward] = this.FillAllAreasForward;
            this.arFillAreas[(int)Direction.Backward] = this.FillAllAreasBackward;

            //Новый сад
            this.garden = new GardenAndGardeners.Classes.Garden(grid);

            //Заполняем сад
            GardenRouteCreator gnCreator = new GardenRouteCreator(garden);
            gnCreator.RecreateGarden();

            Gardener gardener0 = new Gardener(Brushes.Blue);
            Gardener gardener1 = new Gardener(Brushes.Chocolate);


          
          
            Thread myThread0 = new Thread(new ParameterizedThreadStart(FillAllAreas));
            Thread myThread1 = new Thread(new ParameterizedThreadStart(FillAllAreas));

            //  myThread0.SetApartmentState(ApartmentState.STA);

            myThread0.Start(new Filler { Gardener = gardener0, Direction = Direction.Forward });
            myThread1.Start(new Filler { Gardener = gardener1, Direction = Direction.Backward });

         
            Thread myThread1 = new Thread(new ParameterizedThreadStart(FillAllAreas));            
            myThread1.SetApartmentState(ApartmentState.STA);

            myThread0.Start(new Filler { Gardener = gardener0, Direction = Direction.Forward });            
            myThread1.Start(new Filler { Gardener = gardener1, Direction = Direction.Backward });
       

            //this.FillAllAreas(new Filler { Gardener = gardener0, Direction = Direction.Forward });
            //this.FillAllAreas(new Filler { Gardener = gardener1, Direction = Direction.Backward });

        
            var timer = new DispatcherTimer { Interval = TimeSpan.FromSeconds(4) };
            timer.Start();
            timer.Tick += (sender, args) =>
            {
                List<UIElement> el = grid.Children
                               .Cast<UIElement>()
                               .Where(e => Grid.GetRow(e) == 3 && Grid.GetColumn(e) == 3)
                               .ToList();

                if (el[0] is Border)
                {
                    ((Border)el[0]).Background = Brushes.Aqua;
                    ((Border)el[0]).BorderBrush = Brushes.Aqua;
                }
            };
          
        }

        //delegate void del;

        private Action<Gardener>[] arFillAreas = new Action<Gardener>[2];


        private GardenAndGardeners.Classes.Garden garden;


        private void FillAllAreasForward(Gardener gardener)
        {
            Grid grid = MainGrid;

            for (int i = 0; i < grid.RowDefinitions.Count; i++)
            {
                for (int j = 0; j < grid.RowDefinitions.Count; j++)
                {
                    gardener.FillArea(this.garden, i, j);
                }
            }
        }

        private void FillAllAreasBackward(Gardener gardener)
        {
            Grid grid = MainGrid;

            for (int i = grid.RowDefinitions.Count - 1; i >= 0; i--)
            {
                for (int j = grid.RowDefinitions.Count-1; j >= 0 ; j--)
                {
                    gardener.FillArea(this.garden, i, j);
                }
            }
        }

        private void FillAllAreas(Object filler)
        {
            // Simulate some work taking place 
            Thread.Sleep(TimeSpan.FromSeconds(5));
            this.Dispatcher.BeginInvoke(DispatcherPriority.Normal,
                        (ThreadStart)delegate ()
                        {
                            Filler flr = (Filler)filler;
                            this.arFillAreas[(int)flr.Direction].Invoke(flr.Gardener);
                        }
            );
        }

        public enum Direction { Forward = 0, Backward = 1 };

        public class Filler
        {
            public Gardener Gardener { get; set; }
            public Direction Direction { get; set; }
        }
    }
    */
}
