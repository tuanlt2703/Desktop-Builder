using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopBuilder.Classes
{
    class PSU
    {
        #region Constructor
        public PSU()
        {
        }
        #endregion

        #region Properties
        private string _Manufacturer;
        private string Model;
        private int _Power;
        private int _Connector;
        private int _8pin;
        private int _6pin;
        private int _62pin;
        private int _Molex;
        private int _Price;
        #endregion
    }
}
