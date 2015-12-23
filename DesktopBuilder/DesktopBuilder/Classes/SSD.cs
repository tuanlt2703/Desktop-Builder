using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopBuilder.Classes
{
    class SSD : Component
    {
        #region Constructor
        public SSD()
        {
            this.setifo();
        }
        #endregion

        #region Properties
        private string _Manufacturer;
        private int _Capacity;
        private InterfaceType _Interface;
        private int _Price;
        #endregion

        #region Methods
        public override string BriefInfo()
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
        public override List<Tuple<string, string>> PassDetailData()
        {
            string tmpcap;
            if (this._Capacity > 1000)
                tmpcap = (this._Capacity / 1000).ToString() + "TB";
            else
                tmpcap = this._Capacity.ToString() + "GB";

            List<Tuple<string, string>> DetailData = new List<Tuple<string, string>>();
            DetailData.Add(Tuple.Create("Manufacturer", _Manufacturer));
            DetailData.Add(Tuple.Create("Capacity", tmpcap));
            DetailData.Add(Tuple.Create("Interface", _Interface.ToString()));

            return DetailData;
        }
        #endregion

        #region test
        private void setifo()
        {
            this._Manufacturer = "Plextor";
            this._Capacity = 128;
            this._Interface = InterfaceType.Sata3;
            this._Price = 1550;
        }
        #endregion
    }
}
