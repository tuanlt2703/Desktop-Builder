using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopBuilder.Classes
{
    enum MainbSize : byte { MicroATX, ATX}
    enum InterfaceType : byte { Sata, Sata3, PCI, PCIx16, PCIx1}
    class Mainboard : Component
    {
        #region Constructor
        public Mainboard()
        {
            this.setifo();
        }
        #endregion

        #region Properties
        private string _Manufacturer;
        private string _Model;
        private string _Chipet;
        private MainbSize _Size;
        private SocketType _Socket;
        private RamType _memType;
        private int _memSlot;
        private int _StoreInterface;
        private int _PCI;
        private int _PCIx16; // PCI-Ex16
        private int _PCIx1;  // PCI-Ex1
        private int _Price;
        #endregion

        #region Methods
        public override string BriefInfo()
        {
            string ifo;
            ifo = this._Manufacturer + " " + this._Model + " - " + this._Socket.ToString().Substring(1)
                + "\n Giá: " + this._Price.ToString() + "000 VNĐ";
            return ifo;
        }
        public override List<Tuple<string, string>> PassDetailData()
        {
            List<Tuple<string, string>> DetailData = new List<Tuple<string, string>>();
            DetailData.Add(Tuple.Create("Manufacturer", _Manufacturer));
            DetailData.Add(Tuple.Create("Model", _Model));
            //DetailData.Add(Tuple.Create("Chipset", _Chipet));
            DetailData.Add(Tuple.Create("Size", _Size.ToString()));
            DetailData.Add(Tuple.Create("Socket", _Socket.ToString().Substring(1)));
            DetailData.Add(Tuple.Create("Support Ram Type", _memType.ToString()));
            DetailData.Add(Tuple.Create("Ram slot", _memSlot.ToString()));
            DetailData.Add(Tuple.Create("Store Interface", _StoreInterface.ToString()));
            DetailData.Add(Tuple.Create("PCI-Express x16", _PCIx16.ToString()));
            DetailData.Add(Tuple.Create("PCI-Express x1", _PCIx1.ToString()));
            DetailData.Add(Tuple.Create("PCI", _PCI.ToString()));

            return DetailData;
        }
        #endregion

        #region testing
        private void setifo()
        {
            this._Manufacturer = "Gigabyte";
            this._Model = "B85M - Gaming 3";
            this._Chipet = "Intel B85";
            this._Size = MainbSize.MicroATX;
            this._Socket = SocketType._1150;
            this._memType = RamType.DDR3;
            this._memSlot = 2;
            this._StoreInterface = 6;
            this._PCI = 0;
            this._PCIx16 = 1;
            this._PCIx1 = 2;
            this._Price = 1556;
        }
        #endregion
    }
}
