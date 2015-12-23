using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopBuilder.Classes
{
    abstract class Component
    {
        #region Properties
        private string _Manufacturer;
        #endregion

        #region Methods
        public abstract string BriefInfo();
        public abstract List<Tuple<string, string>> PassDetailData();
        #endregion
    }
}
