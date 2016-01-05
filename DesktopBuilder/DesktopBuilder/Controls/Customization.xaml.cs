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
using System.Windows.Shapes;
using System.Data.SQLite;
using DesktopBuilder.Classes;

namespace DesktopBuilder.Controls
{
    /// <summary>
    /// Interaction logic for Customization.xaml
    /// </summary>
    public partial class Customization : UserControl
    {
        #region Constructor
        public Customization()
        {
            InitializeComponent();
            cbList.Add(CPUList);
            cbList.Add(MainboardList);
            cbList.Add(RAMList);
            cbList.Add(HDD1_List);
            cbList.Add(HDD2_List);
            cbList.Add(SSD1_List);
            cbList.Add(SSD2_List);
            cbList.Add(VGAList);            
            cbList.Add(PSUList);
            cbList.Add(CaseList);
            cbList.Add(FanCaseList);
            cbList.Add(AirCoolerList);
            cbList.Add(ODDList);
            cbList.Add(SoundCardList);

            
        }
        #endregion

        #region Properties
        private List<ComboBox> cbList = new List<ComboBox>();
        private List<bool> errList = new List<bool>();
        private bool Save = false;
        public MainWindow Main { get; set; }
        #endregion

        #region Events
        private void HDD1_List_DropDownClosed(object sender, EventArgs e)
        {
            if (HDD1_List.SelectedIndex > 0) // selected another HDD
            {
                //index of selected HDD in full list
                int selectedHDD = SearchComponent(3, HDD1_List.SelectedItem.ToString()); // 3 = HDDList's index

                //Update price of selected HDD
                int price = (Main.pList.List(3)[selectedHDD] as HDD).Price;
                if (price > 10000)
                    tbHDD1Price.Text = price.ToString().Insert(2, ".") + ".000";
                else if (price > 1000)
                    tbHDD1Price.Text = price.ToString().Insert(1, ".") + ".000";
                else
                    tbHDD1Price.Text = price.ToString() + ".000";

            }
            else if (HDD1_List.SelectedIndex == 0) //deselect HDD
            {
                tbHDD1Price.Text = ""; //no item selected, price = 0               
            }
        }
        private void HDD2_List_DropDownClosed(object sender, EventArgs e)
        {
            if (HDD2_List.SelectedIndex > 0) // selected another HDD
            {
                //index of selected HDD in full list
                int selectedHDD = SearchComponent(3, HDD2_List.SelectedItem.ToString()); // 3 = HDDList's index

                //Update price of selected HDD
                int price = (Main.pList.List(3)[selectedHDD] as HDD).Price;
                if (price > 10000)
                    tbHDD2Price.Text = price.ToString().Insert(2, ".") + ".000";
                else if (price > 1000)
                    tbHDD2Price.Text = price.ToString().Insert(1, ".") + ".000";
                else
                    tbHDD2Price.Text = price.ToString() + ".000";

            }
            else if (HDD2_List.SelectedIndex == 0) //deselect HDD
            {
                tbHDD2Price.Text = ""; //no item selected, price = 0               
            }
        }
        private void SSD1_List_DropDownClosed(object sender, EventArgs e)
        {
            if (SSD1_List.SelectedIndex > 0) // selected another SSD
            {
                //index of selected SSD in full list
                int selectedSSD = SearchComponent(4, SSD1_List.SelectedItem.ToString()); // 4 = SSDList's index

                //Update price of selected SSD
                int price = (Main.pList.List(4)[selectedSSD] as SSD).Price;
                if (price > 10000)
                    tbSSD1Price.Text = price.ToString().Insert(2, ".") + ".000";
                else if (price > 1000)
                    tbSSD1Price.Text = price.ToString().Insert(1, ".") + ".000";
                else
                    tbSSD1Price.Text = price.ToString() + ".000";

            }
            else if (SSD1_List.SelectedIndex == 0) //deselect SSD
            {
                tbSSD1Price.Text = ""; //no item selected, price = 0               
            }
        }
        private void SSD2_List_DropDownClosed(object sender, EventArgs e)
        {
            if (SSD2_List.SelectedIndex > 0) // selected another SSD
            {
                //index of selected SSD in full list
                int selectedSSD = SearchComponent(4, SSD2_List.SelectedItem.ToString()); // 4 = SSDList's index

                //Update price of selected SSD
                int price = (Main.pList.List(4)[selectedSSD] as SSD).Price;
                if (price > 10000)
                    tbSSD2Price.Text = price.ToString().Insert(2, ".") + ".000";
                else if (price > 1000)
                    tbSSD2Price.Text = price.ToString().Insert(1, ".") + ".000";
                else
                    tbSSD2Price.Text = price.ToString() + ".000";

            }
            else if (SSD2_List.SelectedIndex == 0) //deselect SSD
            {
                tbSSD2Price.Text = ""; //no item selected, price = 0               
            }
        }
        private void FanCaseList_DropDownClosed(object sender, EventArgs e)
        {
            if (FanCaseList.SelectedIndex > 0) // selected another Fan
            {
                //index of selected Fan in full list
                int selectedFan = SearchComponent(8, FanCaseList.SelectedItem.ToString()); // 8 = FanCaseList's index

                //Update price of selected Fan
                int price = (Main.pList.List(8)[selectedFan] as FanCase).Price;
                //if (price > 10000)
                //    tbFanCasePrice.Text = price.ToString().Insert(2, ".") + ".000";
                //else 
                if (price > 1000)
                    tbFanCasePrice.Text = price.ToString().Insert(1, ".") + ".000";
                else
                    tbFanCasePrice.Text = price.ToString() + ".000";
            }
            else if (FanCaseList.SelectedIndex == 0) //deselect Fan
            {
                tbFanCasePrice.Text = ""; //no item selected, price = 0               
            }
        }
        private void AirCoolerList_DropDownClosed(object sender, EventArgs e)
        {
            if (AirCoolerList.SelectedIndex > 0) // selected another AirCooler
            {
                //index of selected AirCooler in full list
                int selectedAC = SearchComponent(9, AirCoolerList.SelectedItem.ToString()); // 9 = AirCoolerList's index

                //Update price of selected AirCooler
                int price = (Main.pList.List(9)[selectedAC] as AirCPUCooler).Price;
                //if (price > 10000)
                //    tbAirCoolerPrice.Text = price.ToString().Insert(2, ".") + ".000";
                //else 
                if (price > 1000)
                    tbAirCoolerPrice.Text = price.ToString().Insert(1, ".") + ".000";
                else
                    tbAirCoolerPrice.Text = price.ToString() + ".000";
            }
            else if (AirCoolerList.SelectedIndex == 0) //deselect AirCooler
            {
                tbAirCoolerPrice.Text = ""; //no item selected, price = 0               
            }
        }
        private void ODDList_DropDownClosed(object sender, EventArgs e)
        {
            if (ODDList.SelectedIndex > 0) // selected another ODD
            {
                //index of selected ODD in full list
                int selectedODD = SearchComponent(10, ODDList.SelectedItem.ToString()); // 10 = ODDList's index

                //Update price of selected ODD
                int price = (Main.pList.List(10)[selectedODD] as ODD).Price;

                if (price > 1000)
                    tbODDPrice.Text = price.ToString().Insert(1, ".") + ".000";
                else
                    tbODDPrice.Text = price.ToString() + ".000";
            }
            else if (ODDList.SelectedIndex == 0) //deselect ODD
            {
                tbODDPrice.Text = ""; //no item selected, price = 0               
            }
        }
        private void SoundCardList_DropDownClosed(object sender, EventArgs e)
        {
            if (SoundCardList.SelectedIndex > 0) // selected another SoundCard
            {
                //index of selected SoundCard in full list
                int selectedSC = SearchComponent(11, SoundCardList.SelectedItem.ToString()); // 11 = SoundCardList's index

                //Update price of selected SoundCard
                int price = (Main.pList.List(11)[selectedSC] as SoundCard).Price;

                if (price > 1000)
                    tbSCPrice.Text = price.ToString().Insert(1, ".") + ".000";
                else
                    tbSCPrice.Text = price.ToString() + ".000";
            }
            else if (SoundCardList.SelectedIndex == 0) //deselect SoundCard
            {
                tbSCPrice.Text = ""; //no item selected, price = 0               
            }
        }

        private void MainboardList_DropDownClosed(object sender, EventArgs e)
        {
            if (MainboardList.SelectedIndex > 0) // selected another Mainboard
            {
                //index of selected mainboard in full list
                int selectedMain = SearchComponent(1, MainboardList.SelectedItem.ToString()); // 1 = MainboardList's index

                //Update price of selected Mainboard
                tbMainbPrice.Text = (Main.pList.List(1)[selectedMain] as Mainboard).Price.ToString()
                    .Insert((Main.pList.List(1)[selectedMain] as Mainboard).Price > 10000 ? 2 : 1, ".") + ".000";
                #region CPU
                if (CPUList.SelectedIndex > 0) // check whether this mainboard support selected cpu or not
                {
                    //index of selected cpu in full list
                    int selectedCPU = SearchComponent(0, CPUList.SelectedItem.ToString()); // 0 = CPUList's index
                    if ((Main.pList.List(0)[selectedCPU] as CPU).Socket != (Main.pList.List(1)[selectedMain] as Mainboard).Socket) //not supported
                    {
                        errList[0] = true;
                        SetTbText(tbCPUPrice, "Socket không hỗ trợ!", true);
                    }
                    else // supported
                    {
                        errList[0] = false;
                        //Update price of selected CPU
                        int price = (Main.pList.List(0)[selectedCPU] as CPU).Price; // 0 = CPUList's index
                        if (price > 10000)
                            SetTbText(tbCPUPrice, price.ToString().Insert(2, ".") + ".000");
                        else if (price > 1000)
                            SetTbText(tbCPUPrice, price.ToString().Insert(1, ".") + ".000");
                        else
                            SetTbText(tbCPUPrice, price.ToString() + ".000");
                    }
                }
                #endregion

                #region RAM
                if (RAMList.SelectedIndex > 0) // check whether this mainboard support selected RAM or not
                {
                    errList[1] = true;
                    //index of selected cpu in full list
                    int selectedRAM = SearchComponent(2, RAMList.SelectedItem.ToString()); // 2 = RAMList's index
                    if ((Main.pList.List(2)[selectedRAM] as RAM).memType != (Main.pList.List(1)[selectedMain] as Mainboard).memType) //not supported
                    {
                        SetTbText(tbRAMPrice, "RAM không hỗ trợ!", true);
                    }
                    else // supported
                    {
                        errList[1] = false;
                        //Update price of selected RAM
                        int price = (Main.pList.List(2)[selectedRAM] as RAM).Price;
                        if (price > 1000)
                            SetTbText(tbRAMPrice, price.ToString().Insert(1, ".") + ".000");
                        else
                            SetTbText(tbRAMPrice, price.ToString() + ".000");
                    }
                }
                #endregion

                #region Case
                if (CaseList.SelectedIndex > 0) // check whether this mainboard fit in selected Case or not
                {
                    errList[2] = true;
                    //index of selected Case in full list
                    int selectedCase = SearchComponent(7, CaseList.SelectedItem.ToString()); // 7 = CaseList's index
                    if ((Main.pList.List(7)[selectedCase] as Case).Size < (Main.pList.List(1)[selectedMain] as Mainboard).Size) //not supported
                    {
                        SetTbText(tbCasePrice, "Case nhỏ hơn Mainboard!", true);
                    }
                    else // supported
                    {
                        errList[2] = false;
                        //Update price of selected Case
                        int price = (Main.pList.List(7)[selectedCase] as Case).Price;
                        if (price > 1000)
                            SetTbText(tbCasePrice, price.ToString().Insert(1, ".") + ".000");
                        else
                            SetTbText(tbCasePrice, price.ToString() + ".000");
                    }
                }
                #endregion
            }
            else if (MainboardList.SelectedIndex == 0) //deselect Mainboard
            {
                tbMainbPrice.Text = ""; //no item selected, price = 0
                //more optimal solution: check whether previous conflict exits, if so re-update price//
                #region CPU
                if (CPUList.SelectedIndex > 0)
                {
                    errList[0] = true;
                    //index of selected cpu in full list
                    int selectedCPU = SearchComponent(0, CPUList.SelectedItem.ToString()); // 0 = CPUList's index

                    //Update price of selected CPU
                    int price = (Main.pList.List(0)[selectedCPU] as CPU).Price; // 0 = CPUList's index
                    if (price > 10000)
                        SetTbText(tbCPUPrice, price.ToString().Insert(2, ".") + ".000");
                    else if (price > 1000)
                        SetTbText(tbCPUPrice, price.ToString().Insert(1, ".") + ".000");
                    else
                        SetTbText(tbCPUPrice, price.ToString() + ".000");
                }
                #endregion

                #region RAM
                if (RAMList.SelectedIndex > 0)
                {
                    errList[0] = true;
                    //index of selected RAM in full list
                    int selectedRAM = SearchComponent(2, RAMList.SelectedItem.ToString()); // 2 = RAMList's index

                    //Update price of selected RAM
                    int price = (Main.pList.List(2)[selectedRAM] as RAM).Price;
                    if (price > 1000)
                        SetTbText(tbRAMPrice, price.ToString().Insert(1, ".") + ".000");
                    else
                        SetTbText(tbRAMPrice, price.ToString() + ".000");
                }
                #endregion

                #region Case
                if (CaseList.SelectedIndex > 0) // check whether this mainboard support selected RAM or not
                {
                    errList[0] = true;
                    //index of selected Case in full list
                    int selectedCase = SearchComponent(7, CaseList.SelectedItem.ToString()); // 7 = CaseList's index

                    //Update price of selected Case
                    int price = (Main.pList.List(7)[selectedCase] as Case).Price;
                    if (price > 1000)
                        SetTbText(tbCasePrice, price.ToString().Insert(1, ".") + ".000");
                    else
                        SetTbText(tbCasePrice, price.ToString() + ".000");
                }
                #endregion
            }
        }
        private void CPUList_DropDownClosed(object sender, EventArgs e)
        {
            if (CPUList.SelectedIndex > 0) // selected another CPU
            {
                //index of selected cpu in full list
                int selectedCPU = SearchComponent(0, CPUList.SelectedItem.ToString()); // 0 = CPUList's index

                //Update price of selected CPU
                int price = (Main.pList.List(0)[selectedCPU] as CPU).Price; // 0 = CPUList's index
                if (price >= 10000)
                    SetTbText(tbCPUPrice, price.ToString().Insert(2, ".") + ".000");
                else if (price >= 1000)
                    SetTbText(tbCPUPrice, price.ToString().Insert(1, ".") + ".000");
                else
                    SetTbText(tbCPUPrice, price.ToString() + ".000");

                if (MainboardList.SelectedIndex > 0) //check whether selected mainboard support this cpu or not
                {
                    errList[0] = false;
                    //index of selected mainboard in full list
                    int selectedMain = SearchComponent(1, MainboardList.SelectedItem.ToString()); // 1 = MainboardList's index
                    if ((Main.pList.List(0)[selectedCPU] as CPU).Socket != (Main.pList.List(1)[selectedMain] as Mainboard).Socket) // not supported
                    {
                        errList[0] = true;
                        SetTbText(tbCPUPrice, "Socket không hỗ trợ!", true);
                    }
                }
            }
            else if (CPUList.SelectedIndex == 0) //deselect CPU
            {
                errList[0] = false;
                tbCPUPrice.Text = ""; //no item selected, price = 0            
            }
        }
        private void RAMList_DropDownClosed(object sender, EventArgs e)
        {
            if (RAMList.SelectedIndex > 0) // selected another CPU
            {
                //index of selected RAM in full list
                int selectedRAM = SearchComponent(2, RAMList.SelectedItem.ToString()); // 2 = RAMList's index

                //Update price of selected RAM
                int price = (Main.pList.List(2)[selectedRAM] as RAM).Price;
                if (price > 1000)
                    SetTbText(tbRAMPrice, price.ToString().Insert(1, ".") + ".000");
                else
                    SetTbText(tbRAMPrice, price.ToString() + ".000");

                if (MainboardList.SelectedIndex > 0)
                {
                    errList[1] = false;
                    //index of selected cpu in full list
                    int selectedMain = SearchComponent(1, MainboardList.SelectedItem.ToString()); // 1 = MainboardList's index

                    if ((Main.pList.List(2)[selectedRAM] as RAM).memType != (Main.pList.List(1)[selectedMain] as Mainboard).memType)
                    {
                        errList[1] = true;
                        SetTbText(tbRAMPrice, "RAM không hỗ trợ!", true);
                    }
                }
            }
            else if (RAMList.SelectedIndex == 0) //deselect RAM
            {
                errList[1] = false;
                tbRAMPrice.Text = ""; //no item selected, price = 0               
            }
        }
        private void CaseList_DropDownClosed(object sender, EventArgs e)
        {
            if (CaseList.SelectedIndex > 0) // selected another CPU
            {
                //index of selected RAM in full list
                int selectedCase = SearchComponent(7, CaseList.SelectedItem.ToString()); // 2 = RAMList's index

                //Update price of selected RAM
                int price = (Main.pList.List(7)[selectedCase] as Case).Price;
                if (price > 1000)
                    SetTbText(tbCasePrice, price.ToString().Insert(1, ".") + ".000");
                else
                    SetTbText(tbCasePrice, price.ToString() + ".000");

                if (MainboardList.SelectedIndex > 0)
                {
                    errList[2] = false;
                    //index of selected cpu in full list
                    int selectedMain = SearchComponent(1, MainboardList.SelectedItem.ToString()); // 1 = MainboardList's index

                    if ((Main.pList.List(7)[selectedCase] as Case).Size < (Main.pList.List(1)[selectedMain] as Mainboard).Size)
                    {
                        errList[2] = true;
                        SetTbText(tbCasePrice, "Case nhỏ hơn Mainboard!", true);
                    }
                }
            }
            else if (CaseList.SelectedIndex == 0) //deselect RAM
            {
                errList[2] = false;
                tbCasePrice.Text = ""; //no item selected, price = 0               
            }
        }

        private void VGAList_DropDownClosed(object sender, EventArgs e)
        {
            if (VGAList.SelectedIndex > 0) // selected another VGA
            {
                //index of selected VGA in full list
                int selectedVGA = SearchComponent(5, VGAList.SelectedItem.ToString()); // 5 = VGAList's index

                //Update price of selected VGA
                int price = (Main.pList.List(5)[selectedVGA] as VGA).Price;
                if (price > 10000)
                    SetTbText(tbVGAPrice, price.ToString().Insert(2, ".") + ".000");
                else if (price > 1000)
                    SetTbText(tbVGAPrice, price.ToString().Insert(1, ".") + ".000");
                else
                    SetTbText(tbVGAPrice, price.ToString() + ".000");

                #region PSU
                if (PSUList.SelectedIndex > 0) // check whether this PSU supply enough power for selected VGA or not
                {
                    //index of selected PSU in full list
                    int selectedPSU = SearchComponent(6, PSUList.SelectedItem.ToString()); // 6 = PSUList's index
                    if ((Main.pList.List(6)[selectedPSU] as PSU).Power < (Main.pList.List(5)[selectedVGA] as VGA).PowReq + 50)
                    {
                        errList[3] = true;
                        SetTbText(tbPSUPrice, "Nguồn không đủ!", true);
                    }
                    else
                    {
                        errList[3] = false;
                        //Update price of selected PSU
                        int price1 = (Main.pList.List(6)[selectedPSU] as PSU).Price;
                        if (price1 > 1000)
                            SetTbText(tbPSUPrice, price1.ToString().Insert(1, ".") + ".000");
                        else
                            SetTbText(tbPSUPrice, price1.ToString() + ".000");
                    }
                }
                #endregion
            }
            else if (VGAList.SelectedIndex == 0) //deselect VGA
            {
                tbVGAPrice.Text = ""; //no item selected, price = 0
                //more optimal solution: check whether previous conflict exits, if so re-update price//
                #region PSU
                if (PSUList.SelectedIndex > 0) // check whether this PSU supply enough power for selected VGA or not
                {
                    errList[3] = false;
                    //index of selected PSU in full list
                    int selectedPSU = SearchComponent(6, PSUList.SelectedItem.ToString()); // 7 = CaseList's index

                    //Update price of selected PSU
                    int price1 = (Main.pList.List(6)[selectedPSU] as PSU).Price;
                    if (price1 > 1000)
                        SetTbText(tbPSUPrice, price1.ToString().Insert(1, ".") + ".000");
                    else
                        SetTbText(tbPSUPrice, price1.ToString() + ".000");
                }
                #endregion
            }
        }
        private void PSUList_DropDownClosed(object sender, EventArgs e)
        {
            if (PSUList.SelectedIndex > 0) // 
            {
                //
                int selectedPSU = SearchComponent(6, PSUList.SelectedItem.ToString()); //

                //
                int price = (Main.pList.List(6)[selectedPSU] as PSU).Price;
                if (price > 1000)
                    SetTbText(tbPSUPrice,price.ToString().Insert(1, ".") + ".000");
                else
                    SetTbText(tbPSUPrice, price.ToString() + ".000");

                if (VGAList.SelectedIndex > 0)
                {
                    errList[3] = false;
                    //
                    int selectedVGA = SearchComponent(5, VGAList.SelectedItem.ToString()); //

                    if ((Main.pList.List(6)[selectedPSU] as PSU).Power < (Main.pList.List(5)[selectedVGA] as VGA).PowReq + 50)
                    {
                        errList[3] = true;
                        SetTbText(tbPSUPrice, "Case nhỏ hơn Mainboard!", true);
                    }
                }
            }
            else if (PSUList.SelectedIndex == 0) //
            {
                errList[3] = false;
                tbPSUPrice.Text = ""; //             
            }
        }
        
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (!Save)
            {
                if (AllCoreItemsSelected())
                {
                    imgComplete.Visibility = Visibility.Visible;
                    btnRS.Visibility = Visibility.Visible;
                    btnBuild.Margin = new Thickness(217, 465, 0, 0);
                    btnBuild.Content = "Save";
                    Save = true;
                }
            }
            else
            {
                MessageBox.Show("Chưa có tính năng này....");
            }
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MessageBoxResult choice = MessageBox.Show("Clear all?", "Warnning", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if(choice == MessageBoxResult.Yes)
            {
                InitCb();
                imgComplete.Visibility = Visibility.Hidden;
                btnRS.Visibility = Visibility.Hidden;
                btnBuild.Margin = new Thickness(276, 465, 0, 0);
                btnBuild.Content = "Build!";
                Save = false;
            }
        }
        #endregion

        #region Methods
        private bool AllCoreItemsSelected()
        {
            if (CPUList.SelectedIndex == 0 ||
                MainboardList.SelectedIndex == 0 ||
                RAMList.SelectedIndex == 0 ||
                (HDD1_List.SelectedIndex == 0 && HDD2_List.SelectedIndex == 0) &&
                PSUList.SelectedIndex == 0
                )
            {
                MessageBox.Show("Chưa đủ phần cứng để ráp máy!", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }
            else
            {
                if (errList[0])
                {
                    MessageBox.Show("CPU và Mainboard không tương thích!", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return false;
                }
                if (errList[1])
                {
                    MessageBox.Show("RAM và Mainboard không tương thích!", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return false;
                }
                if (errList[2])
                {
                    MessageBox.Show("Case không vừa Mainboard!", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return false;
                }
                if (errList[3])
                {
                    MessageBox.Show("PSU không đủ để kéo VGA!", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return false;
                }
            }
            return true;
        }
        private int SearchComponent(int index, string input)
        {
            int i = 0;
            foreach (var item in Main.pList.List(index))
            {
                if (item.Info() == input)
                    return i;
                i += 1;
            }
            return -1;
        }
        private void SetTbText(TextBlock tb, string texttoshow, bool error=false)
        {
            if (!error)
                tb.Foreground = new SolidColorBrush(Color.FromRgb(0, 150, 136));
            else
                tb.Foreground = Brushes.Red;

            tb.Text = texttoshow;
        }
        public void InitCb()
        {
            for (int i = 0; i < cbList.Count; i++)
            {
                cbList[i].Items.Clear();
                cbList[i].Items.Add("[---------------------------------------]");
                cbList[i].SelectedIndex = 0;
            }

            //CPU, Mainboard, RAM,  list
            for (int i = 0; i < 3; i++)
            {
                foreach (var item in Main.pList.List(i))
                {
                    cbList[i].Items.Add(item.Info());
                }
            }

            //HDD1, HHD2 list
            foreach (var item in Main.pList.List(3))
            {
                cbList[3].Items.Add(item.Info());
                cbList[4].Items.Add(item.Info());
            }

            //SSD1, SSD2 list
            foreach (var item in Main.pList.List(4))
            {
                cbList[5].Items.Add(item.Info());
                cbList[6].Items.Add(item.Info());
            }

            //VGA, PSU, Case, FanCase, AirCooler, ODD, SoundCard list
            for (int i = 7; i < 14; i++)
            {
                foreach (var item in Main.pList.List(i - 2))
                {
                    cbList[i].Items.Add(item.Info());
                }
            }

            errList.Clear();
            errList.Add(false); // 0 = Mainboard - CPU error
            errList.Add(false); // 1 = Mainboard - RAM error
            errList.Add(false); // 2 = Mainboard - Case error
            errList.Add(false); // 3 = VGA - PSU error
        }
        #endregion            
    }
}
