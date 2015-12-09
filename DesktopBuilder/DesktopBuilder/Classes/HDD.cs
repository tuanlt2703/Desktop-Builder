using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopBuilder.Classes
{
    class HDD
    {
        #region Constructor
        public HDD()
        {
        }
        #endregion
        
        #region Properties
        private string _Manufacturer;
        private int _Capacity;
        //private string _Interface;
        private int _Cache;
        private int _RPM;
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
            tmp = this._Manufacturer + " " + tmpcap + " " + this._RPM.ToString() + "RPM"
                + "\nGiá " + this._Price.ToString() + "000 VNĐ";
            return tmp;
        }
        #endregion

        #region test
        public void setifo()
        {
            this._Manufacturer = "Western Digital";
            this._Capacity = 3000;
            this._RPM = 7200;
            this._Price = 4150;
        }
        #endregion
    }
}
