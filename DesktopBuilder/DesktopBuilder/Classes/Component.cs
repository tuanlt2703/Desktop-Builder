using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopBuilder.Classes
{
    public abstract class Component
    {
        #region Properties
        public int Price { get; set; }
        #endregion

        #region Methods
        public abstract string Info();
        public abstract string BriefInfo();
        public abstract List<Tuple<string, string>> PassDetailData();
        public string PricetoStr(int price)
        {
            if (price >= 10000)
                return price.ToString().Insert(2, ".") + ".000 VNĐ";
            else if (price >= 1000)
                return price.ToString().Insert(1, ".") + ".000 VNĐ";
            else
                return price.ToString() + ".000 VNĐ";
        }
        #endregion
    }
}
