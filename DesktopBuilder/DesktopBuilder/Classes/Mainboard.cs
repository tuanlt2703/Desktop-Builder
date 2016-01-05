using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopBuilder.Classes
{
    class Mainboard : Component
    {
        #region Constructor
        public Mainboard()
        {
            
        }
        #endregion

        #region Properties
        public string Manufacturer { get; set; }
        public string Model { get; set; }
        public string Chipet { get; set; }
        public int Size { get; set; }
        public int Socket { get; set; }
        public int memType { get; set; }
        public int memSlot { get; set; }
        public int StoreInterface { get; set; }
        public int PCI { get; set; }
        public int PCIx16 { get; set; } // PCI-Ex16
        public int PCIx1 { get; set; }  // PCI-Ex1
        public int Price { get; set; }
        #endregion

        #region Methods
        public override string Info()
        {
            string ifo;
            ifo = this.Manufacturer + " " + this.Model + " - " + cList.Socket[this.Socket] + " - " + cList.RAMType[this.memType];
            return ifo;
        } 
        public override string BriefInfo()
        {
            string ifo;
            ifo = this.Manufacturer + " " + this.Model + " - " + cList.Socket[this.Socket]
                + "\n Giá: " + base.PricetoStr(Price);
            return ifo;
        }
        public override List<Tuple<string, string>> PassDetailData()
        {
            List<Tuple<string, string>> DetailData = new List<Tuple<string, string>>();
            DetailData.Add(Tuple.Create("Manufacturer", Manufacturer));
            DetailData.Add(Tuple.Create("Model", Model));
            //DetailData.Add(Tuple.Create("Chipset", Chipet));
            DetailData.Add(Tuple.Create("Size", cList.mbSize[this.Size])); //
            DetailData.Add(Tuple.Create("Socket", cList.Socket[this.Socket])); //
            DetailData.Add(Tuple.Create("Support Ram Type", cList.RAMType[this.memType])); //
            DetailData.Add(Tuple.Create("Ram slot", memSlot.ToString()));
            DetailData.Add(Tuple.Create("Store Interface", StoreInterface.ToString()));
            DetailData.Add(Tuple.Create("PCI-Express x16", PCIx16.ToString()));
            DetailData.Add(Tuple.Create("PCI-Express x1", PCIx1.ToString()));
            DetailData.Add(Tuple.Create("PCI", PCI.ToString()));
            DetailData.Add(Tuple.Create("Price", base.PricetoStr(Price)));

            return DetailData;
        }
        #endregion
    }
}
