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
            
        }
        #endregion
        
        #region Properties
        public string Manufacturer { get; set; }
        public int Capacity { get; set; }
        public int Interface { get; set; }
        public int Cache { get; set; }
        public int Spd { get; set; }
        public int Price { get; set; }
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
            tmp = this.Manufacturer + " " + tmpcap + " " + this.Spd.ToString() + "RPM";
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
            tmp = this.Manufacturer + " " + tmpcap + " " + this.Spd.ToString() + "RPM"
                + "\nGiá " + this.Price.ToString() + "000 VNĐ";
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
            DetailData.Add(Tuple.Create("Cache", Cache.ToString() + "Mb"));
            DetailData.Add(Tuple.Create("Speed", Spd.ToString() + "RPM"));

            return DetailData;
        }
        #endregion
    }
}
