using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopBuilder.Classes
{
    enum VGAmType : byte { GDDR5}
    class VGA : Component
    {
        #region Constructor
        public VGA()
        {
            this.setifo();
        }
        #endregion

        #region Properties
        private string _Manufacturer;
        private string _GPU;
        private string _GPUManufacturer;
        private int _CoreClock;
        private VGAmType _memType;
        private int _memSize;
        private int _memInterface;
        private int _PowReq;
        private InterfaceType _Interface;
        private int _8pin;
        private int _6pin;
        private int _Price;
        #endregion

        #region Methods
        public override string BriefInfo()
        {
            string tmp;
            tmp = this._Manufacturer + " " + this._GPU + "\n" + this._memSize.ToString() + "Gb (" + this._memInterface + " bit) - "
                 + this._memType + "\nGiá " + this._Price.ToString() + "000 VNĐ";
            return tmp;
        }
        public override List<Tuple<string, string>> PassDetailData()
        {
            List<Tuple<string, string>> DetailData = new List<Tuple<string, string>>();
            DetailData.Add(Tuple.Create("Manufacturer", _Manufacturer));
            DetailData.Add(Tuple.Create("GPU", _GPU));
            DetailData.Add(Tuple.Create("GPUManufacturer", _GPUManufacturer));
            DetailData.Add(Tuple.Create("CoreClock", _CoreClock.ToString() + "Mhz"));
            DetailData.Add(Tuple.Create("Memory Type", _memType.ToString()));
            DetailData.Add(Tuple.Create("Memory Size", _memSize.ToString() + "Gb"));
            DetailData.Add(Tuple.Create("Memory Interface", _memInterface.ToString() + "bits"));
            DetailData.Add(Tuple.Create("Power Required", _PowReq.ToString() + "W"));
            //DetailData.Add(Tuple.Create("Interface", _Interface.ToString()));
            //DetailData.Add(Tuple.Create("8 pin", _8pin.ToString()));
            //DetailData.Add(Tuple.Create("6 pin", _6pin.ToString()));

            return DetailData;
        }
        #endregion

        #region test
        private void setifo()
        {
            this._Manufacturer = "Gigabyte";
            this._GPU = "GTX 980";
            this._GPUManufacturer = "NVIDIA";
            this._CoreClock = 1228;
            this._memType = VGAmType.GDDR5;
            this._memSize = 4;
            this._memInterface = 256;
            this._PowReq = 600;
            this._Interface = InterfaceType.PCIx16;
            this._8pin = 2;
            this._6pin = 0;
            this._Price = 15150;
        }
        #endregion
    }
}
