using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopBuilder.Classes
{
    enum SocketType : byte{ _1150, _1151, _2011, _2011v3}
    class CPU : Component
    {
        #region Constructor
        public CPU()
        {
            this.setifo();
        }
        #endregion

        #region Properties
        private string _Manufacturer;
        private string _Processor;
        private int _Gen;
        private double _Frequency;
        private SocketType _Socket;
        private int _Cache;
        private int _Cores;
        private int _Threads;
        private bool _Unlocked;
        private int _Price;
        #endregion

        #region Methods
        public override string BriefInfo()
        {
            string ifo;
            ifo = this._Manufacturer + " " + this._Processor + "\n" + this._Frequency.ToString() + "GHz - "
                + this._Socket.ToString().Substring(1)
                + "\n Giá: " + this._Price.ToString() + "000 VNĐ";
            return ifo;
        }
        public override List<Tuple<string, string>> PassDetailData()
        {
            List<Tuple<string, string>> DetailData = new List<Tuple<string, string>>();
            DetailData.Add(Tuple.Create("Manufacturer", _Manufacturer));
            DetailData.Add(Tuple.Create("Processor", _Processor));
            DetailData.Add(Tuple.Create("Generation", _Gen.ToString()));
            DetailData.Add(Tuple.Create("Frequency", _Frequency.ToString() + "Ghz"));
            DetailData.Add(Tuple.Create("Socket", _Socket.ToString().Substring(1)));
            DetailData.Add(Tuple.Create("Cache", _Cache.ToString()));
            DetailData.Add(Tuple.Create("Num of Cores", _Cores.ToString()));
            DetailData.Add(Tuple.Create("Num of Threads", _Threads.ToString()));
            DetailData.Add(Tuple.Create("Unlocked", _Unlocked.ToString()));

            return DetailData;
        }
        #endregion

        #region for testing
        private void setifo()
        {
            this._Manufacturer = "Intel";
            this._Processor = "i7-4690K";
            this._Gen = 4;
            this._Frequency = 3.5;
            this._Socket = SocketType._1150;
            this._Cache = 6;
            this._Cores = 4;
            this._Threads = 4;
            this._Unlocked = true;
            this._Price = 26000;
        }
        #endregion
    }
}
