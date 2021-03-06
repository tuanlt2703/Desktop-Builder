﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopBuilder.Classes
{
    class FanCase : Component
    {
        #region Constructor
        public FanCase()
        {
            
        }
        #endregion

        #region Properties
        public string Manufacturer { get; set; }
        public string Model { get; set; }
        public int Size { get; set; }
        public int Spd { get; set; }
        //public int Price { get; set; }
        #endregion

        #region Methods
        public override string Info()
        {
            string tmp;
            tmp = this.Manufacturer + " " + this.Model + " " + this.Spd + "RPM";
            return tmp;
        }
        public override string BriefInfo()
        {
            string tmp;
            tmp = this.Manufacturer + " " + this.Model + "\n" + this.Spd + "RPM"
                + "\nGiá " + base.PricetoStr(Price);
            return tmp;
        }
        public override List<Tuple<string, string>> PassDetailData()
        {
            List<Tuple<string, string>> DetailData = new List<Tuple<string, string>>();
            DetailData.Add(Tuple.Create("Manufacturer", Manufacturer));
            DetailData.Add(Tuple.Create("Model", Model));
            DetailData.Add(Tuple.Create("Size", Size.ToString() + "mm"));
            DetailData.Add(Tuple.Create("Speed", Spd.ToString() + "RPM"));
            DetailData.Add(Tuple.Create("Price", base.PricetoStr(Price)));

            return DetailData;
        }
        #endregion
    }
}
