using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopBuilder.Classes
{
    class SSD
    {
        #region Constructor
        public SSD()
        {
        }
        #endregion

        #region Properties
        private string _Manufacturer;
        private int _Capacity;
        //private string _Interface;
        private int _Price;
        #endregion

        #region Methods
        public string BriefInfo()
        {
            string tmpcap;
            if (this._Capacity > 1000)
                tmpcap = (this._Capacity / 1000).ToString() + "TB";
            else
                tmpcap = this._Capacity.ToString() + "GB";

            string tmp;
            tmp = this._Manufacturer + " " + tmpcap + " "
                + "\nGiá " + this._Price.ToString() + "000 VNĐ";
            return tmp;
        }
        #endregion

        #region test
        public void setifo()
        {
            this._Manufacturer = "Plextor";
            this._Capacity = 128;
            this._Price = 1550;
        }
        #endregion
    }
}
