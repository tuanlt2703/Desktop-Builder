using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopBuilder.Classes
{
    class SoundCard
    {
        #region Constructor
        public SoundCard()
        {

        }
        #endregion

        #region Properties
        private string _Manufacturer;
        private string _Model;
        private string _Channel;//
        private int _SampleRate;
        private int _Digital;
        private string _Interface; //
        private int _Price;
        #endregion

        #region Methods
        public string BriefInfo()
        {
            string tmp;
            tmp = this._Manufacturer + " " + this._Model + " - " + this._Channel 
                + "\nGiá " + this._Price.ToString() + "000 VNĐ";
            return tmp;
        }
        #endregion

        #region test
        public void setifo()
        {
            this._Manufacturer = "Creative";
            this._Model = "SB0570L4";
            this._Channel = "7.1";
            this._Price = 460;
        }
        #endregion
    }
}
