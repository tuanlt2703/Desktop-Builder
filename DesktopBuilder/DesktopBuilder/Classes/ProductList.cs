using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Data.SQLite;

namespace DesktopBuilder.Classes
{
    public static class cList
    {
        #region Constructor
        static cList()
        {
            cList.dbCon = new SQLiteConnection("Data Source=Hardwares.db;Version=3;"); // connect to database
            cList.LoadSocketList();
            cList.LoadRAMList();
            cList.LoadmbSizeList();
            cList.LoadVGAmTypeList();
            cList.LoadInterfaceTypeList();
        }
        #endregion

        #region Properties
        public static Dictionary<int, string> Socket = new Dictionary<int, string>();
        public static Dictionary<int, string> RAMType = new Dictionary<int, string>();
        public static Dictionary<int, string> mbSize = new Dictionary<int, string>();
        public static Dictionary<int, string> VGAm = new Dictionary<int, string>();
        public static Dictionary<int, string> Interface = new Dictionary<int, string>();

        private static SQLiteConnection dbCon;
        #endregion

        #region Methods
        private static void LoadSocketList()
        {
            dbCon.Open();
            //query string
            string query = "select * from SocketType";

            //create query command & execute
            SQLiteCommand cmd = new SQLiteCommand(query, dbCon);
            SQLiteDataReader myReader = cmd.ExecuteReader();

            //load result to socketlist
            while (myReader.Read())
            {
                Socket.Add(myReader.GetInt32(0), myReader.GetString(1));
            }
            dbCon.Close();
        }
        private static void LoadRAMList()
        {
            dbCon.Open();
            //query string
            string query = "select * from RAMType";

            //create query command & execute
            SQLiteCommand cmd = new SQLiteCommand(query, dbCon);
            SQLiteDataReader myReader = cmd.ExecuteReader();

            //load result to socketlist
            while (myReader.Read())
            {
                RAMType.Add(myReader.GetInt32(0), myReader.GetString(1));
            }
            dbCon.Close();
        }
        private static void LoadmbSizeList()
        {
            dbCon.Open();
            //query string
            string query = "select * from mbSizeType";

            //create query command & execute
            SQLiteCommand cmd = new SQLiteCommand(query, dbCon);
            SQLiteDataReader myReader = cmd.ExecuteReader();

            //load result to socketlist
            while (myReader.Read())
            {
                mbSize.Add(myReader.GetInt32(0), myReader.GetString(1));
            }
            dbCon.Close();
        }
        private static void LoadVGAmTypeList()
        {
            dbCon.Open();
            //query string
            string query = "select * from VGAmType";

            //create query command & execute
            SQLiteCommand cmd = new SQLiteCommand(query, dbCon);
            SQLiteDataReader myReader = cmd.ExecuteReader();

            //load result to socketlist
            while (myReader.Read())
            {
                VGAm.Add(myReader.GetInt32(0), myReader.GetString(1));
            }
            dbCon.Close();
        }
        private static void LoadInterfaceTypeList()
        {
            dbCon.Open();
            //query string
            string query = "select * from InterfaceType";

            //create query command & execute
            SQLiteCommand cmd = new SQLiteCommand(query, dbCon);
            SQLiteDataReader myReader = cmd.ExecuteReader();

            //load result to socketlist
            while (myReader.Read())
            {
                Interface.Add(myReader.GetInt32(0), myReader.GetString(1));
            }
            dbCon.Close();
        }
        #endregion
    }
    public class ProductList
    {
        #region Constructor
        public ProductList()
        {
            this.dbCon = new SQLiteConnection("Data Source=Hardwares.db;Version=3;"); // connect to database
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
        private SQLiteConnection dbCon;
        #endregion

        #region Methods
        private void CreateCPUList()
        {
            dbCon.Open();
            //query string
            string query = "select * from CPU";

            //create query command & execute
            SQLiteCommand cmd = new SQLiteCommand(query, dbCon);
            SQLiteDataReader myReader = cmd.ExecuteReader();

            //load result to socketlist
            while (myReader.Read())
            {
                CPU tmp = new CPU();
                
                //load cpu details
                tmp.Manufacturer = myReader.GetString(1);
                tmp.Processor = myReader.GetString(2);
                tmp.Gen = myReader.GetString(3);
                tmp.Frequency = myReader.GetDouble(4);
                tmp.Socket = myReader.GetInt32(5);
                tmp.Cache = myReader.GetInt32(6);
                tmp.Cores = myReader.GetInt32(7);
                tmp.Threads = myReader.GetInt32(8);
                tmp.Unlocked = myReader.GetBoolean(9);
                tmp.Price = myReader.GetInt32(10);

                CPUList.Add(tmp);
            }
            dbCon.Close();

            myList.Add(CPUList);
        }
        private void CreateMainboardList()
        {
            dbCon.Open();
            //query string
            string query = "select * from Mainboard";

            //create query command & execute
            SQLiteCommand cmd = new SQLiteCommand(query, dbCon);
            SQLiteDataReader myReader = cmd.ExecuteReader();

            //load result to socketlist
            while (myReader.Read())
            {
                Mainboard tmp = new Mainboard();

                //load cpu details
                tmp.Manufacturer = myReader.GetString(1);
                tmp.Model = myReader.GetString(2);
                tmp.Chipet = myReader.GetString(3);
                tmp.Size = myReader.GetInt32(4);
                tmp.Socket = myReader.GetInt32(5);
                tmp.memType = myReader.GetInt32(6);
                tmp.memSlot = myReader.GetInt32(7);
                tmp.StoreInterface = myReader.GetInt32(8);
                tmp.PCI = myReader.GetInt32(9);
                tmp.PCIx1 = myReader.GetInt32(10);
                tmp.PCIx16 = myReader.GetInt32(11);
                tmp.Price = myReader.GetInt32(12);

                MainbList.Add(tmp);
            }
            dbCon.Close();

            myList.Add(MainbList);
        }
        private void CreateRAMList()
        {
            dbCon.Open();
            //query string
            string query = "select * from RAM";

            //create query command & execute
            SQLiteCommand cmd = new SQLiteCommand(query, dbCon);
            SQLiteDataReader myReader = cmd.ExecuteReader();

            //load result to socketlist
            while (myReader.Read())
            {
                RAM tmp = new RAM();

                //load cpu details
                tmp.Manufacturer = myReader.GetString(1);
                tmp.Capacity = myReader.GetInt32(2);
                tmp.Bus = myReader.GetInt32(3);
                tmp.memType = myReader.GetInt32(4);
                tmp.Price = myReader.GetInt32(5);

                RAMList.Add(tmp);
            }
            dbCon.Close();

            myList.Add(RAMList);
        }
        private void CreateHDDList()
        {
            //load from dtb
            dbCon.Open();
            //query string
            string query = "select * from HDD";

            //create query command & execute
            SQLiteCommand cmd = new SQLiteCommand(query, dbCon);
            SQLiteDataReader myReader = cmd.ExecuteReader();

            //load result to socketlist
            while (myReader.Read())
            {
                HDD tmp = new HDD();

                //load cpu details
                tmp.Manufacturer = myReader.GetString(1);
                tmp.Capacity = myReader.GetInt32(2);
                tmp.Interface = myReader.GetInt32(3);
                tmp.Cache = myReader.GetInt32(4);
                tmp.Spd = myReader.GetInt32(5);
                tmp.Price = myReader.GetInt32(6);

                HDDList.Add(tmp);
            }
            dbCon.Close();

            myList.Add(HDDList);
        }
        private void CreateSSDList()
        {
            //load from dtb
            dbCon.Open();
            //query string
            string query = "select * from SSD";

            //create query command & execute
            SQLiteCommand cmd = new SQLiteCommand(query, dbCon);
            SQLiteDataReader myReader = cmd.ExecuteReader();

            //load result to socketlist
            while (myReader.Read())
            {
                SSD tmp = new SSD();

                //load cpu details
                tmp.Manufacturer = myReader.GetString(1);
                tmp.Capacity = myReader.GetInt32(2);
                tmp.Interface = myReader.GetInt32(3);                
                tmp.Price = myReader.GetInt32(4);

                SSDList.Add(tmp);
            }
            dbCon.Close();

            myList.Add(SSDList);
        }
        private void CreateVGAList()
        {
            //load from dtb
            dbCon.Open();
            //query string
            string query = "select * from VGA";

            //create query command & execute
            SQLiteCommand cmd = new SQLiteCommand(query, dbCon);
            SQLiteDataReader myReader = cmd.ExecuteReader();

            //load result to socketlist
            while (myReader.Read())
            {
                VGA tmp = new VGA();

                //load cpu details
                tmp.Manufacturer = myReader.GetString(1);
                tmp.GPU = myReader.GetString(2);
                tmp.GPUManufacturer = myReader.GetString(3);
                tmp.CoreClock = myReader.GetInt32(4);
                tmp.memType = myReader.GetInt32(5);
                tmp.memSize = myReader.GetInt32(6);
                tmp.memInterface = myReader.GetInt32(7);
                tmp.PowReq = myReader.GetInt32(8);
                tmp.Interface = myReader.GetInt32(9);
                tmp._8pin = myReader.GetInt32(10);
                tmp._8pin = myReader.GetInt32(11);
                tmp.Price = myReader.GetInt32(12);

                VGAList.Add(tmp);
            }
            dbCon.Close();

            myList.Add(VGAList);
        }
        private void CreatePSUList()
        {
            //load from dtb
            dbCon.Open();
            //query string
            string query = "select * from PSU";

            //create query command & execute
            SQLiteCommand cmd = new SQLiteCommand(query, dbCon);
            SQLiteDataReader myReader = cmd.ExecuteReader();

            //load result to socketlist
            while (myReader.Read())
            {
                PSU tmp = new PSU();

                //load cpu details
                tmp.Manufacturer = myReader.GetString(1);
                tmp.Model = myReader.GetString(2);
                tmp.Power = myReader.GetInt32(3);
                tmp.Connector = myReader.GetInt32(4);
                tmp._8pin = myReader.GetInt32(5);
                tmp._6pin = myReader.GetInt32(6);
                tmp._62pin = myReader.GetInt32(7);
                tmp.Molex = myReader.GetInt32(8);
                tmp.Price = myReader.GetInt32(9);

                PSUList.Add(tmp);
            }
            dbCon.Close();

            myList.Add(PSUList);
        }
        private void CreateCaseList()
        {
            //load from dtb
            dbCon.Open();
            //query string
            string query = "select * from Cases";

            //create query command & execute
            SQLiteCommand cmd = new SQLiteCommand(query, dbCon);
            SQLiteDataReader myReader = cmd.ExecuteReader();

            //load result to socketlist
            while (myReader.Read())
            {
                Case tmp = new Case();

                //load cpu details
                tmp.Manufacturer = myReader.GetString(1);
                tmp.Model = myReader.GetString(2);
                tmp.Size = myReader.GetInt32(3);
                tmp.FanSlot = myReader.GetInt32(4);
                tmp.Price = myReader.GetInt32(5);

                CaseList.Add(tmp);
            }
            dbCon.Close();

            myList.Add(CaseList);
        }
        private void CreateFanCaseList()
        {
            //load from dtb
            dbCon.Open();
            //query string
            string query = "select * from FanCase";

            //create query command & execute
            SQLiteCommand cmd = new SQLiteCommand(query, dbCon);
            SQLiteDataReader myReader = cmd.ExecuteReader();

            //load result to socketlist
            while (myReader.Read())
            {
                FanCase tmp = new FanCase();

                //load cpu details
                tmp.Manufacturer = myReader.GetString(1);
                tmp.Model = myReader.GetString(2);
                tmp.Size = myReader.GetInt32(3);
                tmp.Spd = myReader.GetInt32(4);
                tmp.Price = myReader.GetInt32(5);

                FanCaseList.Add(tmp);
            }
            dbCon.Close();

            myList.Add(FanCaseList);
        }
        private void CreateAirCPUCoolerList()
        {
            //load from dtb
            dbCon.Open();
            //query string
            string query = "select * from AirCPUCooler";

            //create query command & execute
            SQLiteCommand cmd = new SQLiteCommand(query, dbCon);
            SQLiteDataReader myReader = cmd.ExecuteReader();

            //load result to socketlist
            while (myReader.Read())
            {
                AirCPUCooler tmp = new AirCPUCooler();

                //load cpu details
                tmp.Manufacturer = myReader.GetString(1);
                tmp.Model = myReader.GetString(2);
                tmp.Price = myReader.GetInt32(3);

                CoolerList.Add(tmp);
            }
            dbCon.Close();

            myList.Add(CoolerList);
        }
        private void CreateODDList()
        {
            //load from dtb
            dbCon.Open();
            //query string
            string query = "select * from ODD";

            //create query command & execute
            SQLiteCommand cmd = new SQLiteCommand(query, dbCon);
            SQLiteDataReader myReader = cmd.ExecuteReader();

            //load result to socketlist
            while (myReader.Read())
            {
                ODD tmp = new ODD();

                //load cpu details
                tmp.Manufacturer = myReader.GetString(1);
                tmp.Model = myReader.GetString(2);
                tmp.Type = myReader.GetString(3);
                tmp.Spd = myReader.GetInt32(4);
                tmp.Interface = myReader.GetInt32(5);
                tmp.Price = myReader.GetInt32(6);

                ODDList.Add(tmp);
            }
            dbCon.Close();

            myList.Add(ODDList);
        }
        private void CreateSoundCardList()
        {
            //load from dtb
            dbCon.Open();
            //query string
            string query = "select * from SoundCard";

            //create query command & execute
            SQLiteCommand cmd = new SQLiteCommand(query, dbCon);
            SQLiteDataReader myReader = cmd.ExecuteReader();

            //load result to socketlist
            while (myReader.Read())
            {
                SoundCard tmp = new SoundCard();

                //load cpu details
                tmp.Manufacturer = myReader.GetString(1);
                tmp.Model = myReader.GetString(2);
                tmp.Channel = myReader.GetString(3);
                tmp.SampleRate = myReader.GetInt32(4);
                tmp.Digital = myReader.GetInt32(5);
                tmp.Interface = myReader.GetInt32(6);
                tmp.Price = myReader.GetInt32(7);

                SoundCardList.Add(tmp);
            }
            dbCon.Close();

            myList.Add(SoundCardList);
        }
        public List<Component> List(int index = 0)
        {
            return myList[index];
        }
        #endregion
    }
}
