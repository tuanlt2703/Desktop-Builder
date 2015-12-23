using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopBuilder.Classes
{
    class HDD : Component
    {
        #region Constructor
        public HDD()
        {
            this.setifo();
        }
        #endregion
        
        #region Properties
        private string _Manufacturer;
        private int _Capacity;
        private InterfaceType _Interface;
        private int _Cache;
        private int _Spd;
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
            tmp = this._Manufacturer + " " + tmpcap + " " + this._Spd.ToString() + "RPM"
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
            string tmp;
            tmp = this._Manufacturer + " " + tmpcap + " " + this._Spd.ToString() + "RPM"
                + "\nGiá " + this._Price.ToString() + "000 VNĐ";

            List<Tuple<string, string>> DetailData = new List<Tuple<string, string>>();
            DetailData.Add(Tuple.Create("Manufacturer", _Manufacturer));            
            DetailData.Add(Tuple.Create("Capacity", tmpcap));
            DetailData.Add(Tuple.Create("Interface", _Interface.ToString()));
            DetailData.Add(Tuple.Create("Cache", _Cache.ToString() + "Mb"));
            DetailData.Add(Tuple.Create("Speed", _Spd.ToString() + "RPM"));

            return DetailData;
        }
        #endregion

        #region test
        private void setifo()
        {
            this._Manufacturer = "Western Digital";
            this._Capacity = 3000;
            this._Interface = InterfaceType.Sata3;
            this._Cache = 64;
            this._Spd = 7200;
            this._Price = 4150;
        }
        #endregion
    }
}
