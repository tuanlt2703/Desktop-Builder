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
            
        }
        #endregion

        #region Properties
        public string Manufacturer { get; set; }
        public string Model { get; set; }
        public string Type { get; set; }
        public int Spd { get; set; }
        public int Interface { get; set; }
        public int Price { get; set; }
        #endregion

        #region Methods
        public override string BriefInfo()
        {
            string tmp;
            tmp = this.Manufacturer + " " + this.Model
                + "\n" + this.Type + " " + this.Spd.ToString() + "X"
                + "\nGiá " + this.Price.ToString() + "000 VNĐ";
            return tmp;
        }
        public override List<Tuple<string, string>> PassDetailData()
        {
            List<Tuple<string, string>> DetailData = new List<Tuple<string, string>>();
            DetailData.Add(Tuple.Create("Manufacturer", Manufacturer));
            DetailData.Add(Tuple.Create("Model", Model));
            DetailData.Add(Tuple.Create("Type", Type));
            DetailData.Add(Tuple.Create("Speed", Spd.ToString() + "X"));
            DetailData.Add(Tuple.Create("Interface", cList.Interface[this.Interface]));

            return DetailData;
        }
        #endregion
    }
}
