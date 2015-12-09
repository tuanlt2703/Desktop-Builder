using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
namespace DesktopBuilder.Classes
{
    class ProductList
    {
        #region Constructor
        public ProductList()
        {
            CreateCPUList();
        }
        #endregion

        #region Properties
        private ArrayList CPUList = new ArrayList();
        private ArrayList MainbList = new ArrayList();
        private ArrayList RAMList = new ArrayList();
        private ArrayList HDDList = new ArrayList();
        private ArrayList SSDList = new ArrayList();
        private ArrayList VGAList = new ArrayList();
        private ArrayList PSUList = new ArrayList();
        private ArrayList CaseList = new ArrayList();
        private ArrayList FanCaseList = new ArrayList();
        private ArrayList CoolerList = new ArrayList();
        private ArrayList ODDList = new ArrayList();
        private ArrayList SoundCardList = new ArrayList();
        #endregion

        #region Methods
        private void CreateCPUList()
        {
            //load from dtb
            CPU tmp = new CPU();
            tmp.setifo();
            CPUList.Add(tmp);
            CPUList.Add(tmp);
            CPUList.Add(tmp);
        }
        public ArrayList List(int index = 0)
        {
            switch(index)
            {
                case 0:
                    return CPUList;
                case 1:
                    return MainbList;
                case 2:
                    return RAMList;
                case 3:
                    return HDDList;
                case 4:
                    return SSDList;
                case 5:
                    return VGAList;
                case 6:
                    return PSUList;
                case 7:
                    return CaseList;
                case 8:
                    return FanCaseList;
                case 9:
                    return CoolerList;
                case 10:
                    return ODDList;
                case 11:
                    return SoundCardList;
                default:
                    return CPUList;
            }
        }
        #endregion
    }
}
