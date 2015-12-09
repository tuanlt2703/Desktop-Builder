using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopBuilder.Classes
{
    class VGA
    {
        #region Constructor
        public VGA()
        {
        }
        #endregion

        #region Properties
        private string _Manufacturer;
        private string _GPU;
        private string _GPUManufacturer;
        private int _CoreClock;
        private string _memType;
        private int _memSize;
        private int _memInterface;
        private int _PowReq;
        //private string _Interface;
        private int _8pin;
        private int _6pin;
        private int _Price;
        #endregion

        #region Methods
        public string BriefInfo()
        {
            string tmp;
            tmp = this._Manufacturer + " " + this._GPU + "\n" + this._memSize.ToString() + "Gb (" + this._memInterface + " bit) - "
                 + this._memType + "\nGiá " + this._Price.ToString() + "000 VNĐ";
            return tmp;
        }
        #endregion

        #region test
        public void setifo()
        {
            this._Manufacturer = "Gigabyte";
            this._GPU = "GTX 980";
            this._memSize = 4;
            this._memInterface = 256;
            this._memType = "GDDR5";
            this._Price = 4150;
        }
        #endregion
    }
}
