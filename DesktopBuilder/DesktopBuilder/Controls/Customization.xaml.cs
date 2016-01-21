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
            tbList.Add(tbCPUPrice);
            cbList.Add(MainboardList);
            tbList.Add(tbMainbPrice);
            cbList.Add(RAMList);
            tbList.Add(tbRAMPrice);
            cbList.Add(HDD1_List);
            tbList.Add(tbHDD1Price);
            cbList.Add(HDD2_List);
            tbList.Add(tbHDD2Price);
            cbList.Add(SSD1_List);
            tbList.Add(tbSSD1Price);
            cbList.Add(SSD2_List);
            tbList.Add(tbSSD2Price);
            cbList.Add(VGAList);
            tbList.Add(tbVGAPrice);
            cbList.Add(PSUList);
            tbList.Add(tbPSUPrice);
            cbList.Add(CaseList);
            tbList.Add(tbCasePrice);
            cbList.Add(FanCaseList);
            tbList.Add(tbFanCasePrice);
            cbList.Add(AirCoolerList);
            tbList.Add(tbAirCoolerPrice);
            cbList.Add(ODDList);
            tbList.Add(tbODDPrice);
            cbList.Add(SoundCardList);
            tbList.Add(tbSCPrice);
        }
        #endregion

        #region Properties
        private int Total;
        private int[] SelectedPrice = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        private List<ComboBox> cbList = new List<ComboBox>();
        private List<TextBlock> tbList = new List<TextBlock>();
        private List<bool> errList = new List<bool>();
        private bool Save = false;
        public MainWindow Main { get; set; }
        #endregion

        #region Events
        private void HDD1_List_DropDownClosed(object sender, EventArgs e) //index = 3
        {
            if (HDD1_List.SelectedIndex > 0) // selected another HDD
            {
                //index of selected HDD in full list
                int selectedHDD = SearchComponent(3, HDD1_List.SelectedItem.ToString()); // 3 = HDDList's index
                
                //Update total price
                UpdateTotalPrice(-SelectedPrice[3]);
                SelectedPrice[3] = (Main.pList.List(3)[selectedHDD] as HDD).Price;
                UpdateTotalPrice(SelectedPrice[3]);

                //Update price of selected HDD
                SetTbText(tbHDD1Price, SelectedPrice[3]);
            }
            else if (HDD1_List.SelectedIndex == 0) //deselect HDD
            {
                tbHDD1Price.Text = ""; //no item selected, price = 0

                //Update total price
                UpdateTotalPrice(-SelectedPrice[3]);
                SelectedPrice[3] = 0;
            }
        }
        private void HDD2_List_DropDownClosed(object sender, EventArgs e) //index = 4
        {
            if (HDD2_List.SelectedIndex > 0) // selected another HDD
            {
                //index of selected HDD in full list
                int selectedHDD = SearchComponent(3, HDD2_List.SelectedItem.ToString()); // 3 = HDDList's index

                //Update total price
                UpdateTotalPrice(-SelectedPrice[4]);
                SelectedPrice[4] = (Main.pList.List(3)[selectedHDD] as HDD).Price;
                UpdateTotalPrice(SelectedPrice[4]);

                //Update price of selected HDD
                SetTbText(tbHDD2Price, SelectedPrice[4]);
            }
            else if (HDD2_List.SelectedIndex == 0) //deselect HDD
            {
                tbHDD2Price.Text = ""; //no item selected, price = 0

                //Update total price
                UpdateTotalPrice(-SelectedPrice[4]);
                SelectedPrice[4] = 0;
            }
        }
        private void SSD1_List_DropDownClosed(object sender, EventArgs e) //index = 5
        {
            if (SSD1_List.SelectedIndex > 0) // selected another SSD
            {
                //index of selected SSD in full list
                int selectedSSD = SearchComponent(4, SSD1_List.SelectedItem.ToString()); // 4 = SSDList's index

                //Update total price
                UpdateTotalPrice(-SelectedPrice[5]);
                SelectedPrice[5] = (Main.pList.List(4)[selectedSSD] as SSD).Price;
                UpdateTotalPrice(SelectedPrice[5]);

                //Update price of selected SSD
                SetTbText(tbSSD1Price, SelectedPrice[5]);
            }
            else if (SSD1_List.SelectedIndex == 0) //deselect SSD
            {
                tbSSD1Price.Text = ""; //no item selected, price = 0         
      
                //Update total price
                UpdateTotalPrice(-SelectedPrice[5]);
                SelectedPrice[5] = 0;
            }
        }
        private void SSD2_List_DropDownClosed(object sender, EventArgs e) //index = 6
        {
            if (SSD2_List.SelectedIndex > 0) // selected another SSD
            {
                //index of selected SSD in full list
                int selectedSSD = SearchComponent(4, SSD2_List.SelectedItem.ToString()); // 4 = SSDList's index

                //Update total price
                UpdateTotalPrice(-SelectedPrice[6]);
                SelectedPrice[6] = (Main.pList.List(4)[selectedSSD] as SSD).Price;
                UpdateTotalPrice(SelectedPrice[6]);

                //Update price of selected SSD
                SetTbText(tbSSD2Price, SelectedPrice[6]);
            }
            else if (SSD2_List.SelectedIndex == 0) //deselect SSD
            {
                tbSSD2Price.Text = ""; //no item selected, price = 0

                //Update total price
                UpdateTotalPrice(-SelectedPrice[6]);
                SelectedPrice[6] = 0;
            }
        }
        private void FanCaseList_DropDownClosed(object sender, EventArgs e) //index = 10
        {
            if (FanCaseList.SelectedIndex > 0) // selected another Fan
            {
                //index of selected Fan in full list
                int selectedFan = SearchComponent(8, FanCaseList.SelectedItem.ToString()); // 8 = FanCaseList's index

                //Update total price
                UpdateTotalPrice(-SelectedPrice[10]);
                SelectedPrice[10] = (Main.pList.List(8)[selectedFan] as FanCase).Price;
                UpdateTotalPrice(SelectedPrice[10]);

                //Update price of selected Fan
                SetTbText(tbFanCasePrice, SelectedPrice[10]);
            }
            else if (FanCaseList.SelectedIndex == 0) //deselect Fan
            {
                tbFanCasePrice.Text = ""; //no item selected, price = 0

                //Update total price
                UpdateTotalPrice(-SelectedPrice[10]);
                SelectedPrice[10] = 0;
            }
        }
        private void AirCoolerList_DropDownClosed(object sender, EventArgs e) //index = 11
        {
            if (AirCoolerList.SelectedIndex > 0) // selected another AirCooler
            {
                //index of selected AirCooler in full list
                int selectedAC = SearchComponent(9, AirCoolerList.SelectedItem.ToString()); // 9 = AirCoolerList's index

                //Update total price
                UpdateTotalPrice(-SelectedPrice[11]);
                SelectedPrice[11] = (Main.pList.List(9)[selectedAC] as AirCPUCooler).Price;
                UpdateTotalPrice(SelectedPrice[11]);

                //Update price of selected Cooler
                SetTbText(tbAirCoolerPrice, SelectedPrice[11]);
            }
            else if (AirCoolerList.SelectedIndex == 0) //deselect AirCooler
            {
                tbAirCoolerPrice.Text = ""; //no item selected, price = 0

                //Update total price
                UpdateTotalPrice(-SelectedPrice[11]);
                SelectedPrice[11] = 0;
            }
        }
        private void ODDList_DropDownClosed(object sender, EventArgs e) //index = 12
        {
            if (ODDList.SelectedIndex > 0) // selected another ODD
            {
                //index of selected ODD in full list
                int selectedODD = SearchComponent(10, ODDList.SelectedItem.ToString()); // 10 = ODDList's index

                //Update total price
                UpdateTotalPrice(-SelectedPrice[12]);
                SelectedPrice[12] = (Main.pList.List(10)[selectedODD] as ODD).Price;
                UpdateTotalPrice(SelectedPrice[12]);

                //Update price of selected ODD
                SetTbText(tbODDPrice, SelectedPrice[12]);
            }
            else if (ODDList.SelectedIndex == 0) //deselect ODD
            {
                tbODDPrice.Text = ""; //no item selected, price = 0

                //Update total price
                UpdateTotalPrice(-SelectedPrice[12]);
                SelectedPrice[12] = 0;
            }
        }
        private void SoundCardList_DropDownClosed(object sender, EventArgs e) //index = 13
        {
            if (SoundCardList.SelectedIndex > 0) // selected another SoundCard
            {
                //index of selected SoundCard in full list
                int selectedSC = SearchComponent(11, SoundCardList.SelectedItem.ToString()); // 11 = SoundCardList's index

                //Update total price
                UpdateTotalPrice(-SelectedPrice[13]);
                SelectedPrice[13] = (Main.pList.List(11)[selectedSC] as SoundCard).Price;
                UpdateTotalPrice(SelectedPrice[13]);

                //Update price of selected ODD
                SetTbText(tbSCPrice, SelectedPrice[13]);
            }
            else if (SoundCardList.SelectedIndex == 0) //deselect SoundCard
            {
                tbSCPrice.Text = ""; //no item selected, price = 0

                //Update total price
                UpdateTotalPrice(-SelectedPrice[13]);
                SelectedPrice[13] = 0;
            }
        }

        private void MainboardList_DropDownClosed(object sender, EventArgs e) //index = 1
        {
            if (MainboardList.SelectedIndex > 0) // selected another Mainboard
            {
                //index of selected mainboard in full list
                int selectedMain = SearchComponent(1, MainboardList.SelectedItem.ToString()); // 1 = MainboardList's index


                //Update total price
                UpdateTotalPrice(-SelectedPrice[1]);
                SelectedPrice[1] = (Main.pList.List(1)[selectedMain] as Mainboard).Price;
                UpdateTotalPrice(SelectedPrice[1]);

                //Update price of selected Mainboard
                SetTbText(tbMainbPrice, SelectedPrice[1]);

                #region CPU
                if (CPUList.SelectedIndex > 0) // check whether this mainboard support selected cpu or not
                {
                    //index of selected cpu in full list
                    int selectedCPU = SearchComponent(0, CPUList.SelectedItem.ToString()); // 0 = CPUList's index
                    if ((Main.pList.List(0)[selectedCPU] as CPU).Socket != (Main.pList.List(1)[selectedMain] as Mainboard).Socket) //not supported
                    {
                        if (!errList[0])
                            //Update total price
                            UpdateTotalPrice(-SelectedPrice[0]);

                        errList[0] = true;

                        //ShowError
                        SetTbText(tbCPUPrice, 0, true, "Socket không hỗ trợ!");

                        
                    }
                    else // supported
                    {
                        if (errList[0])
                            //Update total price
                            UpdateTotalPrice(SelectedPrice[0]);

                        errList[0] = false;

                        //Update price of selected psu
                        SetTbText(tbCPUPrice, SelectedPrice[0]);
                    }
                }
                #endregion

                #region RAM
                if (RAMList.SelectedIndex > 0) // check whether this mainboard support selected RAM or not
                {
                    //index of selected cpu in full list
                    int selectedRAM = SearchComponent(2, RAMList.SelectedItem.ToString()); // 2 = RAMList's index
                    if ((Main.pList.List(2)[selectedRAM] as RAM).memType != (Main.pList.List(1)[selectedMain] as Mainboard).memType) //not supported
                    {
                        if (!errList[1])
                            //Update total price
                            UpdateTotalPrice(-SelectedPrice[2]);

                        errList[1] = true;

                        //ShowError
                        SetTbText(tbRAMPrice, 0, true, "RAM không hỗ trợ!");
                    }
                    else // supported
                    {
                        if (errList[1])
                            //Update total price
                            UpdateTotalPrice(SelectedPrice[2]);

                        errList[1] = false;

                        //Update price of selected psu
                        SetTbText(tbRAMPrice, SelectedPrice[2]);
                    }
                }
                #endregion

                #region Case
                if (CaseList.SelectedIndex > 0) // check whether this mainboard fit in selected Case or not
                {
                    //index of selected Case in full list
                    int selectedCase = SearchComponent(7, CaseList.SelectedItem.ToString()); // 7 = CaseList's index
                    if ((Main.pList.List(7)[selectedCase] as Case).Size < (Main.pList.List(1)[selectedMain] as Mainboard).Size) //not supported
                    {
                        if (!errList[2])
                            //Update total price
                            UpdateTotalPrice(-SelectedPrice[9]);

                        errList[2] = true;

                        //ShowError
                        SetTbText(tbCasePrice, 0, true, "Case nhỏ hơn Mainboard!");
                    }
                    else // supported
                    {
                        if (errList[2])
                            //Update total price
                            UpdateTotalPrice(SelectedPrice[9]);

                        errList[2] = false;

                        //Update price of selected psu
                        SetTbText(tbCasePrice, SelectedPrice[9]);
                    }
                }
                #endregion
            }
            else if (MainboardList.SelectedIndex == 0) //deselect Mainboard
            {
                tbMainbPrice.Text = ""; //no item selected, price = 0

                //Update total price
                UpdateTotalPrice(-SelectedPrice[1]);
                SelectedPrice[1] = 0;

                //more optimal solution: check whether previous conflict exits, if so re-update price//
                #region CPU
                if (CPUList.SelectedIndex > 0)
                {
                    //Update total price
                    if (errList[0])
                        UpdateTotalPrice(SelectedPrice[0]);

                    errList[0] = false;

                    //Update price of selected CPU
                    SetTbText(tbCPUPrice, SelectedPrice[0]);
                }
                #endregion

                #region RAM
                if (RAMList.SelectedIndex > 0)
                {
                    //Update total price
                    if (errList[1])
                        UpdateTotalPrice(SelectedPrice[2]);

                    errList[1] = false;

                    //Update price of selected CPU
                    SetTbText(tbRAMPrice, SelectedPrice[2]);
                }
                #endregion

                #region Case
                if (CaseList.SelectedIndex > 0) // check whether this mainboard support selected RAM or not
                {
                    //Update total price
                    if (errList[2])
                        UpdateTotalPrice(SelectedPrice[9]);

                    errList[2] = false;

                    //Update price of selected CPU
                    SetTbText(tbCasePrice, SelectedPrice[9]);
                }
                #endregion
            }
        }
        private void CPUList_DropDownClosed(object sender, EventArgs e) //index = 0
        {
            if (CPUList.SelectedIndex > 0) // selected another CPU
            {
                //index of selected cpu in full list
                int selectedCPU = SearchComponent(0, CPUList.SelectedItem.ToString()); // 0 = CPUList's index

                //Update total price
                if (!errList[0])
                    UpdateTotalPrice(-SelectedPrice[0]);
                SelectedPrice[0] = (Main.pList.List(0)[selectedCPU] as CPU).Price;
                UpdateTotalPrice(SelectedPrice[0]);

                //Update price of selected CPU
                SetTbText(tbCPUPrice, SelectedPrice[0]);

                if (MainboardList.SelectedIndex > 0) //check whether selected mainboard support this cpu or not
                {
                    errList[0] = false;
                    //index of selected mainboard in full list
                    int selectedMain = SearchComponent(1, MainboardList.SelectedItem.ToString()); // 1 = MainboardList's index
                    if ((Main.pList.List(0)[selectedCPU] as CPU).Socket != (Main.pList.List(1)[selectedMain] as Mainboard).Socket) // not supported
                    {
                        errList[0] = true;

                        //Update total price
                        UpdateTotalPrice(-SelectedPrice[0]);

                        //ShowError
                        SetTbText(tbCPUPrice, 0, true, "Socket không hỗ trợ!");
                    }
                }
            }
            else if (CPUList.SelectedIndex == 0) //deselect CPU
            {
                //Update total price
                if (!errList[0])
                    UpdateTotalPrice(-SelectedPrice[0]);
                SelectedPrice[0] = 0;

                errList[0] = false;
                tbCPUPrice.Text = ""; //no item selected, price = 0
            }
        }
        private void RAMList_DropDownClosed(object sender, EventArgs e) //index = 2
        {
            if (RAMList.SelectedIndex > 0) // selected another CPU
            {
                //index of selected RAM in full list
                int selectedRAM = SearchComponent(2, RAMList.SelectedItem.ToString()); // 2 = RAMList's index

                //Update total price
                if (!errList[1])
                    UpdateTotalPrice(-SelectedPrice[2]);
                SelectedPrice[2] = (Main.pList.List(2)[selectedRAM] as RAM).Price;
                UpdateTotalPrice(SelectedPrice[2]);

                //Update price of selected RAM
                SetTbText(tbRAMPrice, SelectedPrice[2]);


                if (MainboardList.SelectedIndex > 0)
                {
                    errList[1] = false;
                    //index of selected cpu in full list
                    int selectedMain = SearchComponent(1, MainboardList.SelectedItem.ToString()); // 1 = MainboardList's index

                    if ((Main.pList.List(2)[selectedRAM] as RAM).memType != (Main.pList.List(1)[selectedMain] as Mainboard).memType)
                    {
                        errList[1] = true;

                        //Update total price
                        UpdateTotalPrice(-SelectedPrice[2]);

                        //ShowError
                        SetTbText(tbRAMPrice, 0, true, "RAM không hỗ trợ!");
                    }
                }
            }
            else if (RAMList.SelectedIndex == 0) //deselect RAM
            {
                //Update total price
                if (!errList[1])
                    UpdateTotalPrice(-SelectedPrice[2]);
                SelectedPrice[2] = 0;

                errList[1] = false;
                tbRAMPrice.Text = ""; //no item selected, price = 0               
            }
        }
        private void CaseList_DropDownClosed(object sender, EventArgs e) //index = 9
        {
            if (CaseList.SelectedIndex > 0) // selected another CPU
            {
                //index of selected Case in full list
                int selectedCase = SearchComponent(7, CaseList.SelectedItem.ToString()); // 7 = RAMList's index

                //Update total price
                if (!errList[2])
                    UpdateTotalPrice(-SelectedPrice[9]);
                SelectedPrice[9] = (Main.pList.List(7)[selectedCase] as Case).Price;
                UpdateTotalPrice(SelectedPrice[9]);

                //Update price of selected Case
                SetTbText(tbCasePrice, SelectedPrice[9]);

                if (MainboardList.SelectedIndex > 0)
                {
                    errList[2] = false;
                    //index of selected Mainboard in full list
                    int selectedMain = SearchComponent(1, MainboardList.SelectedItem.ToString()); // 1 = MainboardList's index

                    if ((Main.pList.List(7)[selectedCase] as Case).Size < (Main.pList.List(1)[selectedMain] as Mainboard).Size)
                    {
                        errList[2] = true;

                        //Update total price
                        UpdateTotalPrice(-SelectedPrice[9]);

                        //ShowError
                        SetTbText(tbCasePrice, 0, true, "Case nhỏ hơn Mainboard!");
                    }
                }
            }
            else if (CaseList.SelectedIndex == 0) //deselect RAM
            {
                //Update total price
                if (!errList[2])
                    UpdateTotalPrice(-SelectedPrice[9]);
                SelectedPrice[9] = 0;

                errList[2] = false;
                tbCasePrice.Text = ""; //no item selected, price = 0
                
            }
        }

        private void VGAList_DropDownClosed(object sender, EventArgs e) //index = 7
        {
            if (VGAList.SelectedIndex > 0) // selected another VGA
            {
                //index of selected VGA in full list
                int selectedVGA = SearchComponent(5, VGAList.SelectedItem.ToString()); // 5 = VGAList's index

                //Update total price
                UpdateTotalPrice(-SelectedPrice[7]);
                SelectedPrice[7] = (Main.pList.List(5)[selectedVGA] as VGA).Price;
                UpdateTotalPrice(SelectedPrice[7]);

                //Update price of selected VGA
                SetTbText(tbVGAPrice, SelectedPrice[7]);

                #region PSU
                if (PSUList.SelectedIndex > 0) // check whether this PSU supply enough power for selected VGA or not
                {
                    //index of selected PSU in full list
                    int selectedPSU = SearchComponent(6, PSUList.SelectedItem.ToString()); // 6 = PSUList's index

                    if ((Main.pList.List(6)[selectedPSU] as PSU).Power < (Main.pList.List(5)[selectedVGA] as VGA).PowReq + 50)
                    {
                        if (!errList[3])
                            //Update total price
                            UpdateTotalPrice(-SelectedPrice[8]);

                        errList[3] = true;

                        //ShowError
                        SetTbText(tbPSUPrice, 0, true, "Nguồn không đủ!");

                        
                    }
                    else
                    {
                        if (errList[3])
                            //Update total price
                            UpdateTotalPrice(SelectedPrice[8]);

                        errList[3] = false;

                        //Update price of selected psu
                        SetTbText(tbPSUPrice, SelectedPrice[8]);
                    }
                }
                #endregion
            }
            else if (VGAList.SelectedIndex == 0) //deselect VGA
            {
                tbVGAPrice.Text = ""; //no item selected, price = 0

                //Update total price
                UpdateTotalPrice(-SelectedPrice[7]);
                SelectedPrice[7] = 0;

                //more optimal solution: check whether previous conflict exits, if so re-update price//
                #region PSU
                if (PSUList.SelectedIndex > 0) // check whether this PSU supply enough power for selected VGA or not
                {
                    //Update total price
                    if (errList[3])
                        UpdateTotalPrice(SelectedPrice[8]);

                    errList[3] = false;

                    //Update price of selected psu
                    SetTbText(tbPSUPrice, SelectedPrice[8]);                                 
                }
                #endregion
            }
        }
        private void PSUList_DropDownClosed(object sender, EventArgs e) //index = 8
        {
            if (PSUList.SelectedIndex > 0) // 
            {
                //
                int selectedPSU = SearchComponent(6, PSUList.SelectedItem.ToString()); //

                //Update total price
                if (!errList[3])
                    UpdateTotalPrice(-SelectedPrice[8]);
                SelectedPrice[8] = (Main.pList.List(6)[selectedPSU] as PSU).Price;
                UpdateTotalPrice(SelectedPrice[8]);

                //Update price of selected psu
                SetTbText(tbPSUPrice, SelectedPrice[8]);

                if (VGAList.SelectedIndex > 0)
                {
                    errList[3] = false;
                    //
                    int selectedVGA = SearchComponent(5, VGAList.SelectedItem.ToString()); //

                    if ((Main.pList.List(6)[selectedPSU] as PSU).Power < (Main.pList.List(5)[selectedVGA] as VGA).PowReq + 50)
                    {
                        errList[3] = true;

                        //Update total price
                        UpdateTotalPrice(-SelectedPrice[8]);

                        //ShowError
                        SetTbText(tbPSUPrice, 0, true, "Nguồn không đủ!");
                    }
                }
            }
            else if (PSUList.SelectedIndex == 0) //
            {
                //Update total price
                if (!errList[3])
                    UpdateTotalPrice(-SelectedPrice[8]);
                SelectedPrice[8] = 0;

                errList[3] = false;
                tbPSUPrice.Text = ""; //                
            }
        }
        
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (!Save)
            {
                if (ItemsSelectedValid())
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
                ResetAll();

                imgComplete.Visibility = Visibility.Hidden;
                btnRS.Visibility = Visibility.Hidden;

                btnBuild.Margin = new Thickness(276, 465, 0, 0);
                btnBuild.Content = "Build!";

                Save = false;
            }
        }        
        #endregion

        #region Methods
        private bool ItemsSelectedValid()
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
        private void SetTbText(TextBlock tb, int price, bool error = false, string err = "")
        {
            if (!error)
            {
                tb.Foreground = new SolidColorBrush(Color.FromRgb(0, 150, 136));
                if (price > 10000)
                    tb.Text = price.ToString().Insert(2, ".") + ".000";
                else if (price > 1000)
                    tb.Text = price.ToString().Insert(1, ".") + ".000";
                else
                    tb.Text = price.ToString() + ".000";
            }
            else
            {
                tb.Foreground = Brushes.Red;
                tb.Text = err;
            }          
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
        private void ResetAll()
        {
            for (int i = 0; i < cbList.Count; i++)
            {
                cbList[i].SelectedIndex = 0;
            }
            for (int i = 0; i < tbList.Count; i++)
            {
                tbList[i].Text = "";
            }
            UpdateTotalPrice(-Total);
        }
        private void UpdateTotalPrice(int price)
        {
            Total += price;
            if (Total == 0)
                tbTotal.Text = "";
            else
            {
                if (Total > 10000)
                    tbTotal.Text = Total.ToString().Insert(2, ".") + ".000 VNĐ";
                else if (Total > 1000)
                    tbTotal.Text = Total.ToString().Insert(1, ".") + ".000 VNĐ";
                else
                    tbTotal.Text = Total.ToString() + ".000 VNĐ";
            }
        }
        #endregion            
    }
}
