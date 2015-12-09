using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopBuilder.Classes
{
    class ODD
    {
        #region Constructor
        public ODD()
        {

        }
        #endregion

        #region Properties
        private string _Manufacturer;
        private string _Model;
        private string _Type;
        private int _Spd;
        private string _Interface;
        private int _Price;
        #endregion

        #region Methods
        public string BriefInfo()
        {
            string tmp;
            tmp = this._Manufacturer + " " + this._Model
                + "\n" + this._Type + " " + this._Spd.ToString() + "X"
                + "\nGiá " + this._Price.ToString() + "000 VNĐ";
            return tmp;
        }
        #endregion

        #region test
        public void setifo()
        {
            this._Manufacturer = "Asus";
            this._Model = "24B1ST";
            this._Type = "DVD-RW";
            this._Spd = 24;
            this._Price = 385   ;
        }
        #endregion
    }
}
