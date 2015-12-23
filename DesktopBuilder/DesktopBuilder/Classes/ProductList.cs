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
            this.CreateCPUList();
            this.CreateMainboardList();
            this.CreateRAMList();
            this.CreateHDDList();
            this.CreateSSDList();
            this.CreateVGAList();
            this.CreatePSUList();
            this.CreateCaseList();
            this.CreateFanCaseList();
            this.CreateAirCPUCoolerList();
            this.CreateODDList();
            this.CreateSoundCardList();
        }
        #endregion
       
        #region Properties
        private List<List<Component>> myList = new List<List<Component>>();
        private List<Component> CPUList = new List<Component>();
        private List<Component> MainbList = new List<Component>();
        private List<Component> RAMList = new List<Component>();
        private List<Component> HDDList = new List<Component>();
        private List<Component> SSDList = new List<Component>();
        private List<Component> VGAList = new List<Component>();
        private List<Component> PSUList = new List<Component>();
        private List<Component> CaseList = new List<Component>();
        private List<Component> FanCaseList = new List<Component>();
        private List<Component> CoolerList = new List<Component>();
        private List<Component> ODDList = new List<Component>();
        private List<Component> SoundCardList = new List<Component>();
        #endregion

        #region Methods
        private void CreateCPUList()
        {
            //load from dtb
            CPU tmp = new CPU();
            CPUList.Add(tmp);
            CPUList.Add(tmp);
            CPUList.Add(tmp);

            myList.Add(CPUList);
        }
        private void CreateMainboardList()
        {
            //load from dtb
            Mainboard tmp = new Mainboard();
            MainbList.Add(tmp);
            MainbList.Add(tmp);
            MainbList.Add(tmp);

            myList.Add(MainbList);
        }
        private void CreateRAMList()
        {
            //load from dtb
            RAM tmp = new RAM();
            RAMList.Add(tmp);
            RAMList.Add(tmp);
            RAMList.Add(tmp);

            myList.Add(RAMList);
        }
        private void CreateHDDList()
        {
            //load from dtb
            HDD tmp = new HDD();
            HDDList.Add(tmp);
            HDDList.Add(tmp);
            HDDList.Add(tmp);

            myList.Add(HDDList);
        }
        private void CreateSSDList()
        {
            //load from dtb
            SSD tmp = new SSD();
            SSDList.Add(tmp);
            SSDList.Add(tmp);
            SSDList.Add(tmp);

            myList.Add(SSDList);
        }
        private void CreateVGAList()
        {
            //load from dtb
            VGA tmp = new VGA();
            VGAList.Add(tmp);
            VGAList.Add(tmp);
            VGAList.Add(tmp);

            myList.Add(VGAList);
        }
        private void CreatePSUList()
        {
            //load from dtb
            PSU tmp = new PSU();
            PSUList.Add(tmp);
            PSUList.Add(tmp);
            PSUList.Add(tmp);

            myList.Add(PSUList);
        }
        private void CreateCaseList()
        {
            //load from dtb
            Case tmp = new Case();
            CaseList.Add(tmp);
            CaseList.Add(tmp);
            CaseList.Add(tmp);

            myList.Add(CaseList);
        }
        private void CreateFanCaseList()
        {
            //load from dtb
            FanCase tmp = new FanCase();
            FanCaseList.Add(tmp);
            FanCaseList.Add(tmp);
            FanCaseList.Add(tmp);

            myList.Add(FanCaseList);
        }
        private void CreateAirCPUCoolerList()
        {
            //load from dtb
            AirCPUCooler tmp = new AirCPUCooler();
            CoolerList.Add(tmp);
            CoolerList.Add(tmp);
            CoolerList.Add(tmp);

            myList.Add(CoolerList);
        }
        private void CreateODDList()
        {
            //load from dtb
            ODD tmp = new ODD();
            ODDList.Add(tmp);
            ODDList.Add(tmp);
            ODDList.Add(tmp);

            myList.Add(ODDList);
        }
        private void CreateSoundCardList()
        {
            //load from dtb
            SoundCard tmp = new SoundCard();
            SoundCardList.Add(tmp);
            SoundCardList.Add(tmp);
            SoundCardList.Add(tmp);

            myList.Add(SoundCardList);
        }
        public List<Component> List(int index = 0)
        {
            return myList[index];
        }
        #endregion
    }
}
