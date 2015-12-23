using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopBuilder.Classes
{
    class FanCase : Component
    {
        #region Constructor
        public FanCase()
        {
            this.setifo();
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
        public override string BriefInfo()
        {
            string tmp;
            tmp = this._Manufacturer + " " + this._Model + "\n" + this._Spd + "RPM"
                + "\nGiá " + this._Price.ToString() + "000 VNĐ";
            return tmp;
        }
        public override List<Tuple<string, string>> PassDetailData()
        {
            List<Tuple<string, string>> DetailData = new List<Tuple<string, string>>();
            DetailData.Add(Tuple.Create("Manufacturer", _Manufacturer));
            DetailData.Add(Tuple.Create("Model", _Model));
            DetailData.Add(Tuple.Create("Size", _Size.ToString() + "mm"));
            DetailData.Add(Tuple.Create("Speed", _Spd.ToString() + "RPM"));

            return DetailData;
        }
        #endregion

        #region test
        private void setifo()
        {
            this._Manufacturer = "Xigmatek";
            this._Model = "XAF-F1253";
            this._Size = 120;
            this._Spd = 1500;
            this._Price = 160;
        }
        #endregion
    }
}
