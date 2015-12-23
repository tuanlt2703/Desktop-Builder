using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopBuilder.Classes
{
    class Case : Component
    {
        #region Constructor
        public Case()
        {
            this.setifo();
        }
        #endregion

        #region Properties
        private string _Manufacturer;
        private string _Model;
        private MainbSize _Size;
        private int _FanSlot;
        private int _Price;
        #endregion

        #region Methods
        public override string BriefInfo()
        {
            string tmp;
            tmp = this._Manufacturer + " " + this._Model + "\n" + this._Size
                + "\nGiá " + this._Price.ToString() + "000 VNĐ";
            return tmp;
        }
        public override List<Tuple<string, string>> PassDetailData()
        {
            List<Tuple<string, string>> DetailData = new List<Tuple<string, string>>();
            DetailData.Add(Tuple.Create("Manufacturer", _Manufacturer));
            DetailData.Add(Tuple.Create("Model", _Model));
            DetailData.Add(Tuple.Create("Size", _Size.ToString()));
            DetailData.Add(Tuple.Create("FanSlot", _FanSlot.ToString()));

            return DetailData;
        }
        #endregion

        #region test
        private void setifo()
        {
            this._Manufacturer = "Cooler Master";
            this._Model = "K380";
            this._Size = MainbSize.ATX;
            this._FanSlot = 5;
            this._Price = 930;
        }
        #endregion
    }
}
