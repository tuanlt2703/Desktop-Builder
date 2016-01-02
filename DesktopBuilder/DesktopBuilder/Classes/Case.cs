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
            
        }
        #endregion

        #region Properties
        public string Manufacturer { get; set; }
        public string Model { get; set; }
        public int Size { get; set; }
        public int FanSlot { get; set; }
        public int Price { get; set; }
        #endregion

        #region Methods
        public override string Info()
        {
            string tmp;
            tmp = this.Manufacturer + " " + this.Model + " " + cList.mbSize[this.Size];
            return tmp;
        }
        public override string BriefInfo()
        {
            string tmp;
            tmp = this.Manufacturer + " " + this.Model + "\n" + cList.mbSize[this.Size]
                + "\nGiá " + this.Price.ToString() + "000 VNĐ";
            return tmp;
        }
        public override List<Tuple<string, string>> PassDetailData()
        {
            List<Tuple<string, string>> DetailData = new List<Tuple<string, string>>();
            DetailData.Add(Tuple.Create("Manufacturer", Manufacturer));
            DetailData.Add(Tuple.Create("Model", Model));
            DetailData.Add(Tuple.Create("Size", cList.mbSize[this.Size]));
            DetailData.Add(Tuple.Create("FanSlot", FanSlot.ToString()));

            return DetailData;
        }
        #endregion
    }
}
