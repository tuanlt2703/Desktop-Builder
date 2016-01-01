using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopBuilder.Classes
{
    class RAM : Component
    {
        #region Constructor
        public RAM()
        {
            
        }
        #endregion

        #region Properties
        public string Manufacturer{ get; set; }
        public int Capacity{ get; set; }
        public int Bus { get; set; }
        public int memType { get; set; }
        public int Price { get; set; }
        #endregion

        #region Methods
        public override string BriefInfo()
        {
            string ifo;
            ifo = this.Manufacturer + " - " + this.Capacity.ToString() +"Gb\n bus" + this.Bus.ToString()
                + " - " + cList.RAMType[this.memType] + "\n Giá: " + this.Price.ToString() + "000 VNĐ";
            return ifo;
        }
        public override List<Tuple<string, string>> PassDetailData()
        {
            List<Tuple<string, string>> DetailData = new List<Tuple<string, string>>();
            DetailData.Add(Tuple.Create("Manufacturer", Manufacturer));
            DetailData.Add(Tuple.Create("Capacity", Capacity.ToString() + "Gb"));
            DetailData.Add(Tuple.Create("Bus", Bus.ToString() + "Mhz"));
            DetailData.Add(Tuple.Create("RAM type", cList.RAMType[this.memType]));

            return DetailData;
        }
        #endregion
    }
}
