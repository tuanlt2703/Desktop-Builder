using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Data;
using System.Data.SQLite;

namespace DesktopBuilder.Controls
{
    /// <summary>
    /// Interaction logic for DatabaseView.xaml
    /// </summary>
    public partial class DatabaseView : UserControl
    {
        #region Constructor
        public DatabaseView()
        {
            InitializeComponent();
            
            //SQLiteConnection.CreateFile("Hardwares.db"); // create empty database
            dbCon = new SQLiteConnection("Data Source=Hardwares.db;Version=3;"); // connect to database
            //CreateDatabase();
            CreateTablelist();
        }
        #endregion

        #region Properties
        private SQLiteConnection dbCon;
        private SQLiteDataAdapter dbAdapter;
        private List<int> Socketlist = new List<int>();
        private List<int> mbSizelist = new List<int>();
        private List<int> RAMTypeList = new List<int>();
        private List<int> VGAmTypeList = new List<int>();
        private List<int> InterfaceList = new List<int>();
        private List<List<int>> ForeignList = new List<List<int>>(5);
        #endregion

        #region Methods
        private void CreateDatabase()
        {           
            dbCon.Open();

            #region Create Queries
            string tbSocketType = "CREATE TABLE SocketType (ID INTEGER PRIMARY KEY NOT NULL,Type nvarchar(10) NOT NULL UNIQUE )";
            string tbmbSize = "CREATE TABLE mbSizeType (ID INTEGER PRIMARY KEY NOT NULL, Type nvarchar(10) NOT NULL UNIQUE )";
            string tbRAMType = "CREATE TABLE RAMType (ID INTEGER PRIMARY KEY NOT NULL, Type nvarchar(10) NOT NULL UNIQUE )";
            string tbVGAmType = "CREATE TABLE VGAmType (ID INTEGER PRIMARY KEY NOT NULL, Type nvarchar(10) NOT NULL UNIQUE )";
            string tbInterfaceType = "CREATE TABLE InterfaceType (ID INTEGER PRIMARY KEY NOT NULL, Type nvarchar(10) NOT NULL UNIQUE )";

            string tbCPU = "CREATE TABLE CPU (ID INTEGER PRIMARY KEY NOT NULL, Manufacturer nvarchar(20) NOT NULL, Processor nvarchar(20) NOT NULL, " +
                "Gen nvarchar(20) NOT NULL, Frequency DOUBLE NOT NULL, Socket INTEGER NOT NULL, Cache INTEGER NOT NULL , " +
                "Cores INTEGER NOT NULL, Threads INTEGER NOT NULL, Unlocked BOOL NOT NULL, Price INTEGER NOT NULL," +
                "FOREIGN KEY (Socket) REFERENCES SocketType(ID))";

            string tbMainboard = "CREATE TABLE Mainboard (ID INTEGER PRIMARY KEY NOT NULL, Manufacturer nvarchar(20) NOT NULL, Model nvarchar(20) NOT NULL, " +
                "Chipset nvarchar(20) NOT NULL, Size INTEGER NOT NULL, Socket INTEGER NOT NULL, " +
                "memType INTEGER NOT NULL, memSlot INTEGER NOT NULL, StorageInterface INTEGER NOT NULL, " +
                "PCI INTEGER NOT NULL, PCIx1 INTEGER NOT NULL, PCIx16 INTEGER NOT NULL, Price INTEGER NOT NULL, " +
                "FOREIGN KEY (Socket) REFERENCES SocketType(ID), FOREIGN KEY (Size) REFERENCES mbSizeType(ID), FOREIGN KEY (memType) REFERENCES RAMType(ID))";

            string tbRAM = "CREATE TABLE RAM (ID INTEGER PRIMARY KEY NOT NULL, Manufacturer nvarchar(20) NOT NULL, Capacity INTEGER NOT NULL, " +
                "Bus INTEGER NOT NULL, Type INTEGER NOT NULL, Price INTEGER NOT NULL, FOREIGN KEY (Type) REFERENCES RAMType(ID))";

            string tbHDD = "CREATE TABLE HDD (ID INTEGER PRIMARY KEY NOT NULL, Manufacturer nvarchar(10) NOT NULL, Capacity INTEGER NOT NULL, " +
                "Interface INTEGER NOT NULL, Cache INTEGER NOT NULL, RPM INTEGER NOT NULL, Price INTEGER NOT NULL, " +
                "FOREIGN KEY (Interface) REFERENCES InterfaceType(ID))";

            string tbSSD = "CREATE TABLE SSD (ID INTEGER PRIMARY KEY NOT NULL, Manufacturer nvarchar(20) NOT NULL, Capacity INTEGER NOT NULL, " +
                "Interface INTEGER NOT NULL, Price INTEGER NOT NULL, FOREIGN KEY (Interface) REFERENCES InterfaceType(ID))";

            string tbVGA = "CREATE TABLE VGA (ID INTEGER PRIMARY KEY NOT NULL, Manufacturer nvarchar(20) NOT NULL, GPU nvarchar(20) NOT NULL, " +
            "GPUManufacturer nvarchar(20) NOT NULL, CoreClock INTEGER NOT NULL, memType INTEGER NOT NULL, memSize INTEGER NOT NULL, " +
            "memInterface INTEGER NOT NULL, PowReq INTEGER NOT NULL, Interface INTEGER NOT NULL, _8pin INTEGER NOT NULL, _6pin INTEGER NOT NULL, Price INTEGER NOT NULL, " +
            "FOREIGN KEY (memType) REFERENCES VGAmType(ID), FOREIGN KEY (Interface) REFERENCES InterfaceType(ID))";

            string tbPSU = "CREATE TABLE PSU (ID INTEGER PRIMARY KEY NOT NULL, Manufacturer nvarchar(20) NOT NULL, Model nvarchar(20) NOT NULL, " +
                "PowerSupply INTEGER NOT NULL, Connectors INTEGER NOT NULL, _8pin INTEGER NOT NULL, _6pin INTEGER NOT NULL, _62pin INTEGER NOT NULL, " +
                "Molex INTEGER NOT NULL, Price INTEGER NOT NULL)";

            string tbCase = "CREATE TABLE Cases (ID INTEGER PRIMARY KEY NOT NULL, Manufacturer nvarchar(20) NOT NULL, Model nvarchar(20) NOT NULL, Size INTEGER NOT NULL, FanSlot INTEGER NOT NULL, Price INTEGER NOT NULL, FOREIGN KEY (Size) REFERENCES mbSizeType(ID))";

            string tbFanCase = "CREATE TABLE FanCase (ID INTEGER PRIMARY KEY NOT NULL, Manufacturer nvarchar(20) NOT NULL, Model nvarchar(20) NOT NULL, " +
                "Size INTEGER NOT NULL, Spd INTEGER NOT NULL, Price INTEGER NOT NULL)";

            string tbCooler = "CREATE TABLE AirCPUCooler (ID INTEGER PRIMARY KEY NOT NULL, Manufacturer nvarchar(20) NOT NULL, Model nvarchar(20) NOT NULL, Price INTEGER NOT NULL)";

            string tbODD = "CREATE TABLE ODD (ID INTEGER PRIMARY KEY NOT NULL, Manufacturer nvarchar(20) NOT NULL, Mode nvarchar(20) NOT NULL, " +
                "Type nvarchar(10) NOT NULL, Spd INTEGER NOT NULL, Interface INTEGER NOT NULL, Price INTEGER NOT NULL)";

            string tbSoundCard = "CREATE TABLE SoundCard (ID INTEGER PRIMARY KEY NOT NULL, Manufacturer nvarchar(20) NOT NULL, Model nvarchar(20) NOT NULL, " +
                "Channels nvarchar(10) NOT NULL, SampleRate INTEGER NOT NULL, DigitalAudio INTEGER NOT NULL, Interface INTEGER NOT NULL, Price INTEGER NOT NULL, " +
                "FOREIGN KEY (Interface) REFERENCES InterfaceType(ID))";

            List<string> strtmp = new List<string>(17);
            strtmp.Add(tbSocketType);
            strtmp.Add(tbmbSize);
            strtmp.Add(tbRAMType);
            strtmp.Add(tbVGAmType);
            strtmp.Add(tbInterfaceType);
            strtmp.Add(tbCPU);
            strtmp.Add(tbMainboard);
            strtmp.Add(tbRAM);
            strtmp.Add(tbHDD);
            strtmp.Add(tbSSD);
            strtmp.Add(tbVGA);
            strtmp.Add(tbPSU);
            strtmp.Add(tbCase);
            strtmp.Add(tbFanCase);
            strtmp.Add(tbCooler);
            strtmp.Add(tbODD);
            strtmp.Add(tbSoundCard);
            #endregion
            foreach(string str in strtmp)
            {
                SQLiteCommand cmd = new SQLiteCommand(str, dbCon);
                cmd.ExecuteNonQuery();
            }
            dbCon.Close();
        }
        private void LoadSocketList()
        {
            dbCon.Open();
            //query string
            string query = "select ID from SocketType";

            //create query command & execute
            SQLiteCommand cmd = new SQLiteCommand(query, dbCon);
            SQLiteDataReader myReader = cmd.ExecuteReader();

            //load result to socketlist
            while (myReader.Read())
            {
                //int a = myReader.GetInt32(0);
                Socketlist.Add(myReader.GetInt32(0));
            }
            dbCon.Close();
        }
        private void LoadmbSizeList()
        {
            dbCon.Open();
            //query string
            string query = "select ID from mbSizeType";

            //create query command & execute
            SQLiteCommand cmd = new SQLiteCommand(query, dbCon);
            SQLiteDataReader myReader = cmd.ExecuteReader();

            //load result to socketlist
            while (myReader.Read())
            {
                mbSizelist.Add(myReader.GetInt32(0));
            }
            dbCon.Close();
        }
        private void LoadRAMList()
        {
            dbCon.Open();
            //query string
            string query = "select ID from RAMType";

            //create query command & execute
            SQLiteCommand cmd = new SQLiteCommand(query, dbCon);
            SQLiteDataReader myReader = cmd.ExecuteReader();

            //load result to socketlist
            while (myReader.Read())
            {
                RAMTypeList.Add(myReader.GetInt32(0));
            }
            dbCon.Close();
        }
        private void LoadInterfaceTypeList()
        {
            dbCon.Open();
            //query string
            string query = "select ID from InterfaceType";

            //create query command & execute
            SQLiteCommand cmd = new SQLiteCommand(query, dbCon);
            SQLiteDataReader myReader = cmd.ExecuteReader();

            //load result to socketlist
            while (myReader.Read())
            {
                InterfaceList.Add(myReader.GetInt32(0));
            }
            dbCon.Close();
        }
        private void LoadVGAmTypeList()
        {
            dbCon.Open();
            //query string
            string query = "select ID from VGAmType";

            //create query command & execute
            SQLiteCommand cmd = new SQLiteCommand(query, dbCon);
            SQLiteDataReader myReader = cmd.ExecuteReader();

            //load result to socketlist
            while (myReader.Read())
            {
                VGAmTypeList.Add(myReader.GetInt32(0));
            }
            dbCon.Close();
        }
        private void CreateTablelist()//combobox
        {
            Tables.Items.Add("SocketType");
            Tables.Items.Add("mbSizeType");
            Tables.Items.Add("RAMType");
            Tables.Items.Add("VGAmType");
            Tables.Items.Add("InterfaceType");
            Tables.Items.Add("CPU");
            Tables.Items.Add("Mainboard");
            Tables.Items.Add("RAM");
            Tables.Items.Add("HDD");
            Tables.Items.Add("SSD");
            Tables.Items.Add("VGA");
            Tables.Items.Add("PSU");
            Tables.Items.Add("Cases");
            Tables.Items.Add("FanCase");
            Tables.Items.Add("AirCPUCooler");
            Tables.Items.Add("ODD");
            Tables.Items.Add("SoundCard");

            LoadSocketList();
            LoadmbSizeList();
            LoadRAMList();
            LoadVGAmTypeList();
            LoadInterfaceTypeList();

            ForeignList.Add(Socketlist);
            ForeignList.Add(mbSizelist);
            ForeignList.Add(RAMTypeList);
            ForeignList.Add(VGAmTypeList);
            ForeignList.Add(InterfaceList);
        }       
        private bool ValidForeignKey(int index, int input)
        {
            foreach(int i in ForeignList[index])
            {
                if (input == i)
                    return true;
            }
            Warring.Text = input.ToString() + " không có";
            return false;
        }
        #endregion

        #region events
        private void Tables_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Warring.Text = "";
            dbCon.Open();
            //enable foreign key constraint
            SQLiteCommand pragma = new SQLiteCommand("PRAGMA foreign_keys = true;", dbCon);
            pragma.ExecuteNonQuery();

            string query = "Select * From " + Tables.SelectedItem.ToString();
            SQLiteCommand newcmd = new SQLiteCommand(query, dbCon);
            dbAdapter = new SQLiteDataAdapter(newcmd);

            SQLiteCommandBuilder cmdBuilder = new SQLiteCommandBuilder(dbAdapter);

            DataTable dt = new DataTable("test");
            dbAdapter.Fill(dt);
            dt.ColumnChanging += Dt_ColumnChanging;

            dtgrid.ItemsSource = dt.DefaultView;
            dbCon.Close();
            
            //check sockettype table 
            int tmp = Tables.SelectedIndex;
            if ((tmp == 5 || tmp == 6) && Socketlist.Count == 0)
                Warring.Text = "Bảng SocketType chưa có dữ liệu!! \r\n";
            if ((tmp == 6 || tmp == 12) && mbSizelist.Count == 0)
                Warring.Text += "Bảng MainboardSize chưa có dữ liệu!! \r\n";
            if ((tmp == 6 || tmp == 7) && RAMTypeList.Count == 0)
                Warring.Text += "Bảng RAMType chưa có dữ liệu!! \r\n";
            if (tmp == 10 && VGAmTypeList.Count == 0)
                Warring.Text += "Bảng VGA memory Type chưa có dữ liệu!!";
            if ((tmp == 8 || tmp == 9 || tmp == 10) && InterfaceList.Count == 0)
                Warring.Text += "Bảng Interface Type chưa có dữ liệu!!";
        }
        private void Dt_ColumnChanging(object sender, DataColumnChangeEventArgs e)
        {
            
            if (!DBNull.Value.Equals(e.ProposedValue))
            {
                int SelectedColumnIndex = e.Column.Table.Columns.IndexOf(e.Column);
                
                switch (Tables.SelectedIndex)
                {
                    case 5: //CPU
                        if (SelectedColumnIndex == 5) // CPU Socket Column
                        {
                            int input = Convert.ToInt16(e.ProposedValue);
                            if (!ValidForeignKey(0, input)) // 0 = SocketList
                            {
                                e.Row.Table.RejectChanges();
                                e.Row.Table.AcceptChanges();
                            }
                        }
                        break;
                    case 6: //Mainboard
                        if (SelectedColumnIndex == 4) // Mainboard Size Column
                        {
                            int input = Convert.ToInt16(e.ProposedValue);
                            if (!ValidForeignKey(1, input)) // 1 = mbSizelist
                            {
                                e.Row.Table.RejectChanges();
                                e.Row.Table.AcceptChanges();
                            }
                        }
                        else if (SelectedColumnIndex == 5) // Mainboard Socket Column
                        {
                            int input = Convert.ToInt16(e.ProposedValue);
                            if (!ValidForeignKey(0, input)) // 0 = SocketList
                            {
                                e.Row.Table.RejectChanges();
                                e.Row.Table.AcceptChanges();
                            }
                        }
                        else if (SelectedColumnIndex == 6) // Mainboard memoty Type Column
                        {
                            int input = Convert.ToInt16(e.ProposedValue);
                            if (!ValidForeignKey(2, input)) // 2 = RAMTypeList
                            {
                                e.Row.Table.RejectChanges();
                                e.Row.Table.AcceptChanges();
                            }
                        }
                        break;
                    case 7: //RAM
                        if (SelectedColumnIndex == 4) // RAM Type Column
                        {
                            int input = Convert.ToInt16(e.ProposedValue);
                            if (!ValidForeignKey(2, input)) // 2 = RAMTypeList
                            {
                                e.Row.Table.RejectChanges();
                                e.Row.Table.AcceptChanges();
                            }
                        }
                        break;
                    case 8: //HDD
                        if (SelectedColumnIndex == 3) // HDD Interface Column
                        {
                            int input = Convert.ToInt16(e.ProposedValue);
                            if (!ValidForeignKey(4, input)) // 4 = InterfaceList
                            {
                                e.Row.Table.RejectChanges();
                                e.Row.Table.AcceptChanges();
                            }
                        }
                        break;
                    case 9: //SSD
                        if (SelectedColumnIndex == 3) // SSD Interface Column
                        {
                            int input = Convert.ToInt16(e.ProposedValue);
                            if (!ValidForeignKey(4, input)) // 4 = InterfaceList
                            {
                                e.Row.Table.RejectChanges();
                                e.Row.Table.AcceptChanges();
                            }
                        }
                        break;
                    case 10: //VGA
                        if (SelectedColumnIndex == 5) // VGA memory Type Column
                        {
                            int input = Convert.ToInt16(e.ProposedValue);
                            if (!ValidForeignKey(3, input)) // 3 = VGAmTypeList
                            {
                                e.Row.Table.RejectChanges();
                                e.Row.Table.AcceptChanges();
                            }
                        }
                        else if (SelectedColumnIndex == 9) // Interface Column
                        {
                            int input = Convert.ToInt16(e.ProposedValue);
                            if (!ValidForeignKey(4, input)) // 4 = VGAmTypeList
                            {
                                e.Row.Table.RejectChanges();
                                e.Row.Table.AcceptChanges();
                            }
                        }
                        break;
                    case 12: //Case
                        if (SelectedColumnIndex == 3) // Case Size Column
                        {
                            int input = Convert.ToInt16(e.ProposedValue);
                            if (!ValidForeignKey(1, input)) // 1 = mbSizelist
                            {
                                e.Row.Table.RejectChanges();
                                e.Row.Table.AcceptChanges();
                            }
                        }
                        break;
                    default:
                        break;
                }
            }
        }
        private void Updatedtb_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                dbAdapter.Update((dtgrid.ItemsSource as DataView).Table);
                LoadSocketList();
                LoadmbSizeList();
                LoadRAMList();
                LoadVGAmTypeList();
                LoadInterfaceTypeList();
            }
            catch (Exception err)
            {
                Warring.Text = err.Message;
            }
        }
        
        #endregion      
    }
}
