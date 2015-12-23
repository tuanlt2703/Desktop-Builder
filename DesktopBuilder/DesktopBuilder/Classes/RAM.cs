using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopBuilder.Classes
{
    enum RamType : byte { DDR3, DDR4}
    class RAM : Component
    {
        #region Constructor
        public RAM()
        {
            this.setifo();
        }
        #endregion

        #region Properties
        private string _Manufacturer;
        private int _Capacity;
        private int _Bus;
        private RamType _memType;
        private int _Price;
        #endregion

        #region Methods
        public override string BriefInfo()
        {
            string ifo;
            ifo = this._Manufacturer + " - " + this._Capacity.ToString() +"Gb\n bus" + this._Bus.ToString()
                + " - " + this._memType + "\n Giá: " + this._Price.ToString() + "000 VNĐ";
            return ifo;
        }
        public override List<Tuple<string, string>> PassDetailData()
        {
            List<Tuple<string, string>> DetailData = new List<Tuple<string, string>>();
            DetailData.Add(Tuple.Create("Manufacturer", _Manufacturer));
            DetailData.Add(Tuple.Create("Capacity", _Capacity.ToString() + "Gb"));
            DetailData.Add(Tuple.Create("Bus", _Bus.ToString() + "Mhz"));
            DetailData.Add(Tuple.Create("RAM type", _memType.ToString()));

            return DetailData;
        }
        #endregion

        #region test
        private void setifo()
        {
            this._Manufacturer = "Corsair";
            this._Capacity = 4;
            this._Bus = 1600;
            this._memType = RamType.DDR3;
            this._Price = 747;
        }
        #endregion
    }
}
