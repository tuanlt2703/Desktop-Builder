using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopBuilder.Classes
{
    class CPU
    {
        #region Constructor
        public CPU()
        {
            setifo();
        }
        #endregion

        #region Properties
        private string _Manufacturer;
        private string _Processor;
        private int _Gen;
        private double _Frequency;
        private string _Socket; // 
        private int _Cache;
        private int _Cores;
        private int _Threads;
        private bool _Unlocked;
        private int _Price;
        #endregion

        #region Methods
        public string BriefInfo()
        {
            string ifo;
            ifo = this._Manufacturer + " " + this._Processor + "\n" + this._Frequency.ToString() + "GHz - " + this._Socket
                + "\n Giá: " + this._Price.ToString() + "000 VNĐ";
            return ifo;
        }
        #endregion

        #region for testing
        public void setifo()
        {
            this._Manufacturer = "Intel";
            this._Processor = "i7-5960X";
            this._Frequency = 3.0;
            this._Socket = "2011-v3"; //
            this._Price = 26000;
        }
        #endregion
    }
}
