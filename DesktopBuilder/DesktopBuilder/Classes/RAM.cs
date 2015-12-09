using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopBuilder.Classes
{
    class RAM
    {
        #region Constructor
        public RAM()
        {
        }
        #endregion

        #region Properties
        private string _Manufacturer;
        private int _Capacity;
        private int _Bus;
        private string _memType;//
        private int _Price;
        #endregion

        #region Methods
        public string BriefIfo()
        {
            string ifo;
            ifo = this._Manufacturer + " - " + this._Capacity.ToString() +"Gb\n bus" + this._Bus.ToString()
                + " - " + this._memType + "\n Giá: " + this._Price.ToString() + "000 VNĐ";
            return ifo;
        }
        #endregion

        #region test
        public void setifo()
        {
            this._Manufacturer = "Corsair";
            this._Capacity = 4;
            this._Bus = 1600;
            this._memType = "DDR3";
            this._Price = 747;
        }
        #endregion
    }
}
