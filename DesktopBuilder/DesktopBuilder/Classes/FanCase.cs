using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopBuilder.Classes
{
    class FanCase
    {
        #region Constructor
        public FanCase()
        {
        }
        #endregion

        #region Properties
        private string _Manufacturer;
        private string _Model;
        private int _Size;
        private int _Spd;
        private int _Price;
        #endregion

        #region Methods
        public string BriefInfo()
        {
            string tmp;
            tmp = this._Manufacturer + " " + this._Model + "\n" + this._Spd + "RPM"
                + "\nGiá " + this._Price.ToString() + "000 VNĐ";
            return tmp;
        }
        #endregion

        #region test
        public void setifo()
        {
            this._Manufacturer = "Xigmatek";
            this._Model = "XAF-F1253";
            this._Spd = 1500;
            this._Price = 160;
        }
        #endregion
    }
}
