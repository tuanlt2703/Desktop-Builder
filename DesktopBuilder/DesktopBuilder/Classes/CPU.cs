using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopBuilder.Classes
{
    class CPU : Component
    {
        #region Constructor
        public CPU()
        {
        }
        #endregion

        #region Properties
        public string Manufacturer { get; set; }
        public string Processor { get; set; }
        public string Gen { get; set; }
        public double Frequency { get; set; }
        public int Socket { get; set; }
        public int Cache { get; set; }
        public int Cores { get; set; }
        public int Threads { get; set; }
        public bool Unlocked { get; set; }
        public int Price { get; set; }
        #endregion

        #region Methods
        public override string Info()
        {
            string ifo;
            ifo = this.Manufacturer + " " + this.Processor + " " + this.Frequency.ToString() + "GHz - Socket "
                + cList.Socket[this.Socket] + (this.Unlocked ? " - Unlocked" : "");
            return ifo;
        }
        public override string BriefInfo()
        {
            string ifo;
            ifo = this.Manufacturer + " " + this.Processor + "\n" + this.Frequency.ToString() + "GHz - "
                + cList.Socket[this.Socket]
                + "\n Giá: " + base.PricetoStr(Price);
            return ifo;
        }
        public override List<Tuple<string, string>> PassDetailData()
        {
            List<Tuple<string, string>> DetailData = new List<Tuple<string, string>>();
            DetailData.Add(Tuple.Create("Manufacturer", Manufacturer));
            DetailData.Add(Tuple.Create("Processor", Processor));
            DetailData.Add(Tuple.Create("Generation", Gen));
            DetailData.Add(Tuple.Create("Frequency", Frequency.ToString() + "Ghz"));
            //DetailData.Add(Tuple.Create("Socket", Socket.ToString()));
            DetailData.Add(Tuple.Create("Socket", cList.Socket[this.Socket]));
            DetailData.Add(Tuple.Create("Cache", Cache.ToString()));
            DetailData.Add(Tuple.Create("Num of Cores", Cores.ToString()));
            DetailData.Add(Tuple.Create("Num of Threads", Threads.ToString()));
            DetailData.Add(Tuple.Create("Unlocked", Unlocked.ToString()));
            DetailData.Add(Tuple.Create("Price", base.PricetoStr(Price)));

            return DetailData;
        }
        #endregion
    }
}
