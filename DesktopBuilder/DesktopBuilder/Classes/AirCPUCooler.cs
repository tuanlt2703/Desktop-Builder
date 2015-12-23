using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopBuilder.Classes
{
    class AirCPUCooler :Component
    {
        #region Constructor
        public AirCPUCooler()
        {
            this.setifo();
        }
        #endregion

        #region Properties
        private string _Manufacturer;
        private string _Model;
        private int _Price;
        #endregion

        #region Methods
        public override string BriefInfo()
        {
            string tmp;
            tmp = this._Manufacturer + " " + this._Model
                + "\nGiá " + this._Price.ToString() + "000 VNĐ";
            return tmp;
        }
        public override List<Tuple<string, string>> PassDetailData()
        {
            List<Tuple<string, string>> DetailData = new List<Tuple<string, string>>();
            DetailData.Add(Tuple.Create("Manufacturer", _Manufacturer));
            DetailData.Add(Tuple.Create("Model", _Model));
            return DetailData;
        }
        #endregion

        #region test
        private void setifo()
        {
            this._Manufacturer = "Phanteks";
            this._Model = "TC12DX";
            this._Price = 1050;
        }
        #endregion
    }
}
