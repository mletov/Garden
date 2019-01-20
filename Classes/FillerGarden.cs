using GardenAndGardeners.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Garden.Classes
{
    class FillerGarden
    {
        static object locker = new object();

        public static void FillAllAreasForward(Gardener gardener, GardenAndGardeners.Classes.Garden garden)
        {
            bool isLoopActive = true;
            for (int i = 0; i < garden.CntRows && isLoopActive; i++)
            {
                for (int j = 0; j < garden.CntColumns && isLoopActive; j++)
                {
                    isLoopActive = (garden[i, j] <= 1);
                    if (!isLoopActive) break;

                    if (garden[i, j] == 1 && isLoopActive)
                    {
                        lock (locker)
                        {
                            gardener.TakeGardenCell(garden, i, j);
                        }
                        int rnd = Randomizer.GetRandomNumber(50, 100);
                        Thread.Sleep(rnd);
                    }
                }
            }
        }


        public static void FillAllAreasBackward(Gardener gardener, GardenAndGardeners.Classes.Garden garden)
        {
            bool isLoopActive = true;
            for (int i = garden.CntRows - 1; i >= 0 && isLoopActive; i--)
            {          
                for (int j = garden.CntColumns - 1; j >=0 && isLoopActive; j--)
                {
                    isLoopActive = (garden[i, j] <= 1);
                    if (!isLoopActive) break;

                    if (garden[i, j] == 1 && isLoopActive)
                    {
                        lock (locker)
                        {
                            gardener.TakeGardenCell(garden, i, j);
                        }
                        int rnd = Randomizer.GetRandomNumber(50, 100);
                        Thread.Sleep(rnd);
                    }
                }
            }
        }

    }
}
