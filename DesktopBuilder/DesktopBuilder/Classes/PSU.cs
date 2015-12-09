using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopBuilder.Classes
{
    class PSU
    {
        #region Constructor
        public PSU()
        {
        }
        #endregion

        #region Properties
        private string _Manufacturer;
        private string Model;
        private int _Power;
        private int _Connector;
        private int _8pin;
        private int _6pin;
        private int _62pin;
        private int _Molex;
        private int _Price;
        #endregion

        #region Methods
        public string BriefInfo()
        {            
            string tmp;
            tmp = this._Manufacturer + " " + this.Model + "\n" + this._Power.ToString() + "W"
                + "\nGiá " + this._Price.ToString() + "000 VNĐ";
            return tmp;
        }
        #endregion

        #region test
        public void setifo()
        {
            this._Manufacturer = "Seasonic";
            this.Model = "S12II";
            this._Power = 520;
            this._Price = 4150;
        }
        #endregion
    }
}
