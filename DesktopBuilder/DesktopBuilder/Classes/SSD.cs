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
            
        }
        #endregion

        #region Properties
        public string Manufacturer;
        public int Capacity;
        public int Interface;
        public int Price;
        #endregion

        #region Methods
        public override string Info()
        {
            string tmpcap;
            if (this.Capacity > 1000)
                tmpcap = (this.Capacity / 1000).ToString() + "TB";
            else
                tmpcap = this.Capacity.ToString() + "GB";

            string tmp;
            tmp = this.Manufacturer + " " + tmpcap + " ";
            return tmp;
        }
        public override string BriefInfo()
        {
            string tmpcap;
            if (this.Capacity > 1000)
                tmpcap = (this.Capacity / 1000).ToString() + "TB";
            else
                tmpcap = this.Capacity.ToString() + "GB";

            string tmp;
            tmp = this.Manufacturer + " " + tmpcap + " "
                + "\nGiá " + base.PricetoStr(Price);
            return tmp;
        }
        public override List<Tuple<string, string>> PassDetailData()
        {
            string tmpcap;
            if (this.Capacity > 1000)
                tmpcap = (this.Capacity / 1000).ToString() + "TB";
            else
                tmpcap = this.Capacity.ToString() + "GB";

            List<Tuple<string, string>> DetailData = new List<Tuple<string, string>>();
            DetailData.Add(Tuple.Create("Manufacturer", Manufacturer));
            DetailData.Add(Tuple.Create("Capacity", tmpcap));
            DetailData.Add(Tuple.Create("Interface", cList.Interface[this.Interface]));
            DetailData.Add(Tuple.Create("Price", base.PricetoStr(Price)));

            return DetailData;
        }
        #endregion
    }
}
