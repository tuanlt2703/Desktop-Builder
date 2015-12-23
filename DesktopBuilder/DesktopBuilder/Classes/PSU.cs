using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopBuilder.Classes
{
    class PSU : Component
    {
        #region Constructor
        public PSU()
        {
            this.setifo();
        }
        #endregion

        #region Properties
        private string _Manufacturer;
        private string _Model;
        private int _Power;
        private int _Connector;
        private int _8pin;
        private int _6pin;
        private int _62pin;
        private int _Molex;
        private int _Price;
        #endregion

        #region Methods
        public override string BriefInfo()
        {            
            string tmp;
            tmp = this._Manufacturer + " " + this._Model + "\n" + this._Power.ToString() + "W"
                + "\nGiá " + this._Price.ToString() + "000 VNĐ";
            return tmp;
        }
        public override List<Tuple<string, string>> PassDetailData()
        {
            List<Tuple<string, string>> DetailData = new List<Tuple<string, string>>();
            DetailData.Add(Tuple.Create("Manufacturer", _Manufacturer));
            DetailData.Add(Tuple.Create("Model", _Model));
            DetailData.Add(Tuple.Create("Power Supply", _Power.ToString() + "W"));
            DetailData.Add(Tuple.Create("Sata Connector", _Connector.ToString()));
            DetailData.Add(Tuple.Create("8 pin", _8pin.ToString()));
            DetailData.Add(Tuple.Create("6 pin", _6pin.ToString()));
            DetailData.Add(Tuple.Create("6-2 pin", _62pin.ToString()));
            DetailData.Add(Tuple.Create("Molex", _Molex.ToString()));

            return DetailData;
        }
        #endregion

        #region test
        private void setifo()
        {
            this._Manufacturer = "Seasonic";
            this._Model = "S12II";
            this._Power = 520;
            this._Connector = 6;
            this._8pin = 0;
            this._6pin = 0;
            this._62pin = 2;
            this._Molex = 0;
            this._Price = 1500;
        }
        #endregion
    }
}
