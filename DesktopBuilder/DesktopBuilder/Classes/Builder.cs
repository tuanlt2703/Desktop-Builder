using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace DesktopBuilder.Classes
{
    class Builder
    {
        #region Constructor
        public Builder()
        {
            dbCon = new SQLiteConnection("Data Source=Recipe.db;Version=3;"); // connect to database          
        }
        #endregion

        #region Properties
        private SQLiteConnection dbCon;
        ProductList pList;
        private List<double> RatioList = new List<double>();        
        private uint Money;
        private List<int> SelectedList = new List<int>(new int[] {-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1});

        private List<List<int>> PossibleList = new List<List<int>>(12);
        private List<int> CPUList = new List<int>(); //0
        private List<int> MainbList = new List<int>(); //1
        private List<int> RAMList = new List<int>(); //2
        private List<int> HDDList = new List<int>(); //3
        private List<int> SSDList = new List<int>(); //4
        private List<int> VGAList = new List<int>(); //5
        private List<int> PSUList = new List<int>(); //6 
        private List<int> CaseList = new List<int>(); //7
        private List<int> FanCaseList = new List<int>(); //8
        private List<int> CoolerList = new List<int>(); ///9
        private List<int> ODDList = new List<int>(); //10
        private List<int> SoundCardList = new List<int>(); //11
        #endregion

        #region Methods
        private void CreateTable()
        {
            dbCon.Open();
            string tmp = "CREATE TABLE Ratio (CPU DOUBLE NOT NULL , Mainboard DOUBLE NOT NULL , RAM DOUBLE NOT NULL , HDD DOUBLE NOT NULL , SSD DOUBLE NOT NULL , VGA DOUBLE NOT NULL , PSU DOUBLE NOT NULL , Cases DOUBLE NOT NULL , Fan DOUBLE NOT NULL , Cooler DOUBLE NOT NULL , ODD DOUBLE NOT NULL , SoundCard DOUBLE NOT NULL , Max INTEGER NOT NULL , Min INTEGER NOT NULL, Id INTERGER NOT NULL )";
            SQLiteCommand cmd = new SQLiteCommand(tmp, dbCon);
            cmd.ExecuteNonQuery();
            dbCon.Close();
        }
        private void LoadRecipe(int id, uint money)
        {
            RatioList.Clear();
            PossibleList.Clear();

            dbCon.Open();
            string query = "select * From Ratio Where (Ratio.Id = " + id + ") and (Ratio.Max >=" + money + ") and (Ratio.Min <" + money + ")";
            //create query command & execute
            SQLiteCommand cmd = new SQLiteCommand(query, dbCon);
            SQLiteDataReader myReader = cmd.ExecuteReader();

            myReader.Read();

            for (int i = 0; i <= 11; i++)
            {
                RatioList.Add(myReader.GetDouble(i));
            }
            
            dbCon.Close();

            PossibleList.Add(CPUList);
            PossibleList.Add(MainbList);
            PossibleList.Add(RAMList);
            PossibleList.Add(HDDList);
            PossibleList.Add(SSDList);
            PossibleList.Add(VGAList);
            PossibleList.Add(PSUList);
            PossibleList.Add(CaseList);
            PossibleList.Add(FanCaseList);
            PossibleList.Add(CoolerList);
            PossibleList.Add(ODDList);
            PossibleList.Add(SoundCardList);
        }
        private void LoadPossibleList() //Create list of components fit user's money & requirement
        {
            for (int i = 0; i < PossibleList.Count; i++)
            {
                if (RatioList[i] != 0)
                {
                    int j = 0;
                    foreach(Component item in pList.List(i))
                    {
                        // x - 5%*toal < price < x + 5%*toal
                        if ((Money * RatioList[i] - 0.15 * Money) <= item.Price && item.Price <= (Money * RatioList[i] + 0.05 * Money)) 
                        {
                            PossibleList[i].Add(j);
                        }
                        j++;
                    }
                }
            }
        }
        private void SelectHardware() // select by components priority: CPU, VGA, RAM, Case, Main, PSU, HDD, SDD...
        {
            int selectedSocket = FindCPU();

            int selectedRAMType = FindMain(selectedSocket);
            FindRAM(selectedRAMType);       

            int powReq = (RatioList[5] != 0) ? FindVGA() : 0;
            FindPSU(powReq);

            if (RatioList[7] != 0)
                FindCase();

            findHDD();
            if (RatioList[4] != 0)
                findSSD();
        }
        public List<int> DoWork(int id, uint money, ProductList list)
        {
            this.LoadRecipe(id, money);
            this.Money = money;
            this.pList = list;

            LoadPossibleList();
            SelectHardware();
            return SelectedList;
        }
        //select hardware
        private int FindCPU() // index = 0, return socketID of selected CPU
        {
            int maxPrice = 0;
            List<Component> tmp = pList.List(0);
            for (int i = 0; i < CPUList.Count; i++)
            {
                CPU cpu = (tmp[CPUList[i]] as CPU);
                if (cpu.Price > maxPrice)
                {
                    maxPrice = cpu.Price;
                    SelectedList[0] = CPUList[i];
                }              
            }
            return (tmp[SelectedList[0]] as CPU).Socket;
        }
        private int FindMain(int Socket) // index = 1, return memType of selected Mainboard
        {
            int maxPrice = 0;
            List<Component> tmp = pList.List(1);
            for (int i = 0; i < MainbList.Count; i++)
            {
                Mainboard main = (tmp[MainbList[i]] as Mainboard);
                if (main.Socket == Socket )
                {
                    if(main.Price > maxPrice)
                    {
                        maxPrice = main.Price;
                        SelectedList[1] = MainbList[i];
                    }
                }
            }
            return (tmp[SelectedList[1]] as Mainboard).memType;
        }
        private void FindRAM(int memType) // index = 2, return RAMTypeID of selected RAM
        {
            int maxPrice = 0;
            List<Component> tmp = pList.List(2);
            for (int i = 0; i < RAMList.Count; i++)
            {
                RAM ram = (tmp[RAMList[i]] as RAM);
                if (ram.memType == memType)
                {
                    if (ram.Price > maxPrice)
                    {
                        maxPrice = ram.Price;
                        SelectedList[2] = RAMList[i];
                    }
                }
            }
        }
        private void findHDD() // index = 3,
        {
            int maxPrice = 0;
            List<Component> tmp = pList.List(3);
            for (int i = 0; i < HDDList.Count; i++)
            {
                HDD hdd = (tmp[HDDList[i]] as HDD);
                if (hdd.Price > maxPrice)
                {
                    maxPrice = hdd.Price;
                    SelectedList[3] = HDDList[i];
                }
            }
        }
        private void findSSD() // index = 4,
        {
            int maxPrice = 0;
            List<Component> tmp = pList.List(4);
            for (int i = 0; i < SSDList.Count; i++)
            {
                SSD ssd = (tmp[SSDList[i]] as SSD);
                if (ssd.Price > maxPrice)
                {
                    maxPrice = ssd.Price;
                    SelectedList[4] = SSDList[i];
                }
            }
        }
        private int FindVGA() // index = 5, return Power Require of selected VGA
        {
            int maxPrice = 0;
            List<Component> tmp = pList.List(5);
            for (int i = 0; i < VGAList.Count; i++)
            {
                VGA vga = (tmp[VGAList[i]] as VGA);
                if (vga.Price > maxPrice)
                {
                    maxPrice = vga.Price;
                    SelectedList[5] = VGAList[i];
                }
            }
            return (tmp[SelectedList[5]] as VGA).PowReq;
        }
        private void FindPSU(int PowerReq) //index = 6,
        {
            int maxPrice = 0;
            List<Component> tmp = pList.List(6);
            for (int i = 0; i < PSUList.Count; i++)
            {
                PSU psu = (tmp[PSUList[i]] as PSU);
                if (psu.Power >= PowerReq) // + 80)
                {
                    if (psu.Price > maxPrice)
                    {
                        maxPrice = psu.Price;
                        SelectedList[6] = PSUList[i];
                    }
                }
            }
        }
        private void FindCase() //index 7,
        {
            int maxPrice = 0;
            List<Component> tmp = pList.List(7);
            for (int i = 0; i < CaseList.Count; i++)
            {
                Case cse = (tmp[CaseList[i]] as Case);
                if (cse.Size >= (pList.List(1)[SelectedList[1]] as Mainboard).Size)
                {
                    if (cse.Price > maxPrice)
                    {
                        maxPrice = cse.Price;
                        SelectedList[7] = CaseList[i];
                    }
                }
            }
        }
        //current not supported
        private void FindFan() //index = 8,
        { }
        private void FindCooler() // index = 9
        { }
        private void FindODD() // index = 10
        { }
        private void FindSC() // index = 11
        { }
        #endregion
    }
}
