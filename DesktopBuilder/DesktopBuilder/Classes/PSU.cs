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
           
        }
        #endregion

        #region Properties
        public string Manufacturer { get; set; }
        public string Model { get; set; }
        public int Power { get; set; }
        public int Connector { get; set; }
        public int _8pin { get; set; }
        public int _6pin { get; set; }
        public int _62pin { get; set; }
        public int Molex { get; set; }
        //public int Price { get; set; }
        #endregion

        #region Methods
        public override string Info()
        {
            string tmp;
            tmp = this.Manufacturer + " " + this.Model + " " + this.Power.ToString() + "W";

            return tmp;
        }
        public override string BriefInfo()
        {            
            string tmp;
            tmp = this.Manufacturer + " " + this.Model + "\n" + this.Power.ToString() + "W"
                + "\nGiá " + base.PricetoStr(Price);
            return tmp;
        }
        public override List<Tuple<string, string>> PassDetailData()
        {
            List<Tuple<string, string>> DetailData = new List<Tuple<string, string>>();
            DetailData.Add(Tuple.Create("Manufacturer", Manufacturer));
            DetailData.Add(Tuple.Create("Model", Model));
            DetailData.Add(Tuple.Create("Power Supply", Power.ToString() + "W"));
            DetailData.Add(Tuple.Create("Sata Connector", Connector.ToString()));
            DetailData.Add(Tuple.Create("8 pin", _8pin.ToString()));
            DetailData.Add(Tuple.Create("6 pin", _6pin.ToString()));
            DetailData.Add(Tuple.Create("6-2 pin", _62pin.ToString()));
            DetailData.Add(Tuple.Create("Molex", Molex.ToString()));
            DetailData.Add(Tuple.Create("Price", base.PricetoStr(Price)));

            return DetailData;
        }
        #endregion
    }
}
