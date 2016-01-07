using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopBuilder.Classes
{
    class VGA : Component
    {
        #region Constructor
        public VGA()
        {
            
        }
        #endregion

        #region Properties
        public string Manufacturer { get; set; }
        public string GPU { get; set; }
        public string GPUManufacturer { get; set; }
        public int CoreClock { get; set; }
        public int memType { get; set; }
        public int memSize { get; set; }
        public int memInterface { get; set; }
        public int PowReq { get; set; }
        public int Interface { get; set; }
        public int _8pin { get; set; }
        public int _6pin { get; set; }
        //public int Price { get; set; }
        #endregion

        #region Methods
        public override string Info()
        {
            string tmp;
            tmp = this.Manufacturer + " " + this.GPU + " " + this.memSize.ToString() + "Gb (" + this.memInterface + " bit) - "
                 + cList.VGAm[this.memType]; 
            return tmp;
        }
        public override string BriefInfo()
        {
            string tmp;
            tmp = this.Manufacturer + " " + this.GPU + "\n" + this.memSize.ToString() + "Gb (" + this.memInterface + " bit) - "
                 + cList.VGAm[this.memType] + "\nGiá " + base.PricetoStr(Price);
            return tmp;
        }
        public override List<Tuple<string, string>> PassDetailData()
        {
            List<Tuple<string, string>> DetailData = new List<Tuple<string, string>>();
            DetailData.Add(Tuple.Create("Manufacturer", Manufacturer));
            DetailData.Add(Tuple.Create("GPU", GPU));
            DetailData.Add(Tuple.Create("GPUManufacturer", GPUManufacturer));
            DetailData.Add(Tuple.Create("CoreClock", CoreClock.ToString() + "Mhz"));
            DetailData.Add(Tuple.Create("Memory Type", cList.VGAm[this.memType])); //
            DetailData.Add(Tuple.Create("Memory Size", memSize.ToString() + "Gb"));
            DetailData.Add(Tuple.Create("Memory Interface", memInterface.ToString() + "bits"));
            DetailData.Add(Tuple.Create("Power Required", PowReq.ToString() + "W"));
            DetailData.Add(Tuple.Create("Interface", cList.Interface[this.Interface])); //
            DetailData.Add(Tuple.Create("Price", base.PricetoStr(Price)));
            //DetailData.Add(Tuple.Create("8 pin", 8pin.ToString()));
            //DetailData.Add(Tuple.Create("6 pin", 6pin.ToString()));

            return DetailData;
        }
        #endregion
    }
}
