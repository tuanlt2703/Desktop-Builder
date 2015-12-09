using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopBuilder.Classes
{
    class AirCPUCooler
    {
        #region Constructor
        public AirCPUCooler()
        {
        }
        #endregion

        #region Properties
        private string _Manufacturer;
        private string _Model;
        private int _Price;
        #endregion

        #region Methods
        public string BriefInfo()
        {
            string tmp;
            tmp = this._Manufacturer + " " + this._Model
                + "\nGiá " + this._Price.ToString() + "000 VNĐ";
            return tmp;
        }
        #endregion

        #region test
        public void setifo()
        {
            this._Manufacturer = "Phanteks";
            this._Model = "TC12DX";

            this._Price = 1050;
        }
        #endregion
    }
}
