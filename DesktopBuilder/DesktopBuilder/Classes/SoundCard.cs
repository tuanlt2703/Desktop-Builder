using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopBuilder.Classes
{
    enum ChannelType : byte { _7_1}
    class SoundCard : Component
    {
        #region Constructor
        public SoundCard()
        {
            this.setifo();
        }
        #endregion

        #region Properties
        private string _Manufacturer;
        private string _Model;
        private ChannelType _Channel;
        private int _SampleRate;
        private int _Digital;
        private InterfaceType _Interface;
        private int _Price;
        #endregion

        #region Methods
        public override string BriefInfo()
        {
            string tmp;
            tmp = this._Manufacturer + " " + this._Model + " - " + this._Channel.ToString().Substring(1).Replace('_', '.')
                + "\nGiá " + this._Price.ToString() + "000 VNĐ";
            return tmp;
        }
        public override List<Tuple<string, string>> PassDetailData()
        {
            List<Tuple<string, string>> DetailData = new List<Tuple<string, string>>();
            DetailData.Add(Tuple.Create("Manufacturer", _Manufacturer));
            DetailData.Add(Tuple.Create("Model", _Model));
            DetailData.Add(Tuple.Create("Channel", _Channel.ToString().Substring(1).Replace('_', '.')));
            DetailData.Add(Tuple.Create("SampleRate", _SampleRate.ToString() + "KHz"));
            DetailData.Add(Tuple.Create("Digital Audio", _Digital.ToString() + "bits"));
            DetailData.Add(Tuple.Create("Interface", _Interface.ToString()));

            return DetailData;
        }
        #endregion

        #region test
        private void setifo()
        {
            this._Manufacturer = "Creative";
            this._Model = "SB0570L4";
            this._Channel = ChannelType._7_1;
            this._SampleRate = 96;
            this._Digital = 24;
            this._Interface = InterfaceType.PCI;
            this._Price = 460;
        }
        #endregion
    }
}
