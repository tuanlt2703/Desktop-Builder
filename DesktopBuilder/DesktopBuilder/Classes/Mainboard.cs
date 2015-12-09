using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopBuilder.Classes
{
    class Mainboard
    {
        #region Constructor
        public Mainboard()
        {
        }
        #endregion

        #region Properties
        private string _Manufacturer;
        private string Model;
        private string _Chipet;
        private string _Size; //
        private string _Socket; //
        private string _memType; //
        private int _memSlot;
        private int _StoreInterface;
        private int _PCI;
        private int _PCIx16; // PCI-Ex16
        private int _PCIx1;  // PCI-Ex1
        private int _Price;
        #endregion

        #region Methods
        public string BriefIfo()
        {
            string ifo;
            ifo = this._Manufacturer + " " + this.Model + " - " + this._Socket
                + "\n Giá: " + this._Price.ToString() + "000 VNĐ";
            return ifo;
        }
        #endregion

        #region testing
        public void setifo()
        {
            this._Manufacturer = "Gigabyte";
            this.Model = "B85M - Gaming 3";
            this._Socket = "1150";
            this._Price = 1556;
        }
        #endregion
    }
}
