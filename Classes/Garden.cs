using GardenAndGardeners.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GardenAndGardeners.Classes
{

    class Garden
    {
        private int _cntColumns;
        private int _cntRows;
        private int[,] _arGardenArea { get; set; }

    
        public Garden(int cntColumns, int cntRows)
        {
            this._arGardenArea = new int[cntColumns, cntRows];
            this._cntColumns = cntColumns;
            this._cntRows = cntRows;
            this.GardenInit();            
        }

        protected virtual void GardenInit()
        {
            for (int i = 0; i < this._cntRows; i++)
            {
                for (int j = 0; j < this._cntColumns; j++)
                {
                    int rnd = Randomizer.GetRandomNumber(0, 2);
                    this._arGardenArea[i, j] = rnd;
                }
            }
        }
            
        public int this[int i, int j]
        {
            get
            {
                return this._arGardenArea[i, j];
            }
            set
            {
                this._arGardenArea[i, j] = value;
            }
        }

        public int CntRows
        {
            get
            {
                return this._cntRows;
            }
        }

        public int CntColumns
        {
            get
            {
                return this._cntColumns;
            }
        }

    }

}
