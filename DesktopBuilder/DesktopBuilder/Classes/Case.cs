using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopBuilder.Classes
{
    class Case
    {
        #region Constructor
        public Case()
        {
        }
        #endregion

        #region Properties
        private string _Manufacturer;
        private string _Model;
        private string _Size;//
        private int _FanSlot;
        private int _Price;
        #endregion

        #region Methods
        public string BriefInfo()
        {
            string tmp;
            tmp = this._Manufacturer + " " + this._Model + "\n" + this._Size
                + "\nGiá " + this._Price.ToString() + "000 VNĐ";
            return tmp;
        }
        #endregion

        #region test
        public void setifo()
        {
            this._Manufacturer = "Cooler Master";
            this._Model = "K380";
            this._Size = "ATX";
            this._Price = 930;
        }
        #endregion
    }
}
