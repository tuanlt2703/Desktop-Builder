using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopBuilder.Classes
{
    class SoundCard : Component
    {
        #region Constructor
        public SoundCard()
        {
            
        }
        #endregion

        #region Properties
        public string Manufacturer;
        public string Model;
        public string Channel;
        public int SampleRate;
        public int Digital;
        public int Interface;
        public int Price;
        #endregion

        #region Methods
        public override string Info()
        {
            string tmp;
            tmp = this.Manufacturer + " " + this.Model + " - " + this.Channel;
            return tmp;
        }
        public override string BriefInfo()
        {
            string tmp;
            tmp = this.Manufacturer + " " + this.Model + " - " + this.Channel
                + "\nGiá " + base.PricetoStr(Price);
            return tmp;
        }
        public override List<Tuple<string, string>> PassDetailData()
        {
            List<Tuple<string, string>> DetailData = new List<Tuple<string, string>>();
            DetailData.Add(Tuple.Create("Manufacturer", Manufacturer));
            DetailData.Add(Tuple.Create("Model", Model));
            DetailData.Add(Tuple.Create("Channel", Channel));
            DetailData.Add(Tuple.Create("SampleRate", SampleRate.ToString() + "KHz"));
            DetailData.Add(Tuple.Create("Digital Audio", Digital.ToString() + "bits"));
            DetailData.Add(Tuple.Create("Interface", cList.Interface[this.Interface]));
            DetailData.Add(Tuple.Create("Price", base.PricetoStr(Price)));

            return DetailData;
        }
        #endregion
    }
}
