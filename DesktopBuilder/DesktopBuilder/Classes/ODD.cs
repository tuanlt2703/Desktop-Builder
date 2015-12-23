using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopBuilder.Classes
{
    class ODD : Component
    {
        #region Constructor
        public ODD()
        {
            this.setifo();
        }
        #endregion

        #region Properties
        private string _Manufacturer;
        private string _Model;
        private string _Type;
        private int _Spd;
        private InterfaceType _Interface;
        private int _Price;
        #endregion

        #region Methods
        public override string BriefInfo()
        {
            string tmp;
            tmp = this._Manufacturer + " " + this._Model
                + "\n" + this._Type + " " + this._Spd.ToString() + "X"
                + "\nGiá " + this._Price.ToString() + "000 VNĐ";
            return tmp;
        }
        public override List<Tuple<string, string>> PassDetailData()
        {
            List<Tuple<string, string>> DetailData = new List<Tuple<string, string>>();
            DetailData.Add(Tuple.Create("Manufacturer", _Manufacturer));
            DetailData.Add(Tuple.Create("Model", _Model));
            DetailData.Add(Tuple.Create("Type", _Type));
            DetailData.Add(Tuple.Create("Speed", _Spd.ToString() + "X"));
            DetailData.Add(Tuple.Create("Interface", _Interface.ToString()));

            return DetailData;
        }
        #endregion

        #region test
        private void setifo()
        {
            this._Manufacturer = "Asus";
            this._Model = "24B1ST";
            this._Type = "DVD-RW";
            this._Spd = 24;
            this._Interface = InterfaceType.Sata;
            this._Price = 385;
        }
        #endregion
    }
}
