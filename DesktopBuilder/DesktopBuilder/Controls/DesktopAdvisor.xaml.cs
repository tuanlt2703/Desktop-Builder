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
using System.IO;
using DesktopBuilder.Classes;

namespace DesktopBuilder.Controls
{
    /// <summary>
    /// Interaction logic for DesktopAdvisor.xaml
    /// </summary>
    public partial class DesktopAdvisor : UserControl
    {
        #region Constructor
        public DesktopAdvisor()
        {
            InitializeComponent();

            Result._DA = this;
            InitRequirementList();
            InitComponentList();
            Step = 1;
        }
        #endregion

        #region Properies
        public MainWindow Main { get; set; }
        private List<RadioButton> rdList = new List<RadioButton>(4);
        private List<CheckBox> cbList = new List<CheckBox>(12);
        private short Step; //indicate current step
        private uint Money; //Money input
        private short Choice; //User requirement
        private List<bool> coList = new List<bool>(12);
        private Builder aBuilder = new Builder();
        #endregion

        #region Events
        //Textbox only accept numeric
        private void TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            char c = Convert.ToChar(e.Text);
            e.Handled = false;
            if (Char.IsNumber(c))
            {
                e.Handled = false;
                lbWarnning.Visibility = Visibility.Hidden;
            }
            else
            {
                e.Handled = true;
                lbWarnning.Visibility = Visibility.Visible;
            }
        }
        private void TextBox_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
                e.Handled = true;
        }
        private void btnNext_Click(object sender, RoutedEventArgs e)
        {
            switch (Step)
            {
                case 1:
                    if (UserMoney())
                    {
                        step1.Visibility = Visibility.Hidden;
                        step2.Visibility = Visibility.Visible;

                        Step++;
                        btnPre.Visibility = Visibility.Visible;
                    }
                    break;
                case 2:
                    if (UserSelectedReq())
                    {
                        step2.Visibility = Visibility.Hidden;
                        step3.Visibility = Visibility.Visible;
                        Step++;

                        btnNext.Visibility = Visibility.Hidden;
                    }
                    break;
                default:
                    break;
            }          
        }
        private void btnPre_Click(object sender, RoutedEventArgs e)
        {
            switch (Step)
            {
                case 2:
                    step1.Visibility = Visibility.Visible;                    
                    step2.Visibility = Visibility.Hidden;
                    Step--;

                    btnPre.Visibility = Visibility.Hidden;
                    break;
                case 3:
                    step2.Visibility = Visibility.Visible;
                    step3.Visibility = Visibility.Hidden;
                    //
                    cbVGA.IsChecked = false;
                    cbSSD.IsChecked = false;
                    cbSSD.IsEnabled = true;
                    //
                    Step--;

                    btnNext.Visibility = Visibility.Visible;
                    break;
                default:
                    break;
            }  
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            coList.Clear();

            string tmp = "Money: " + Money.ToString().Insert(Money.ToString().Length - 3, ".").Insert(Money.ToString().Length - 6, ".") + " VNĐ"
                + "\n\rRequirement: " + rdList[Choice].Content + "\n\rSelected Components: ";
            for (int i = 0; i < cbList.Count; i++)
            {
                coList.Add(cbList[i].IsChecked ?? false);
                if (coList[i])
                    tmp += cbList[i].Content + " ";
            }

            MessageBoxResult choice = MessageBox.Show(tmp, "Confirm", MessageBoxButton.YesNo, MessageBoxImage.Asterisk);
            if (choice == MessageBoxResult.Yes)
            {
                step3.Visibility = Visibility.Hidden;
                btnPre.Visibility = Visibility.Hidden;

                //start
                Money = Money / 1000;
                string sID = "";
                sID = ((cbVGA.IsChecked ?? false) ? "1" : "0") + sID;
                sID = ((cbSSD.IsChecked ?? false) ? "1" : "0") + sID;

                Result.Load(Main.pList, aBuilder.DoWork(Convert.ToInt32(sID, 2), Money, Main.pList));
                Result.Visibility = Visibility.Visible;
            }
        }
        #endregion

        #region Methods
        private void InitRequirementList()
        {
            rdList.Add(btnGame);
            rdList.Add(btnDesign);
            rdList.Add(btnEncode);
            rdList.Add(btnCommon);
        }
        private void InitComponentList()
        {
            cbList.Add(cbCPU);
            cbList.Add(cbMain);
            cbList.Add(cbRAM);
            cbList.Add(cbHDD);
            cbList.Add(cbSSD);
            cbList.Add(cbVGA);
            cbList.Add(cbPSU); cbPSU.IsChecked = true;
            cbList.Add(cbCase); cbCase.IsChecked = true;

            cbList.Add(cbFan); cbFan.IsEnabled = false;
            cbList.Add(cbAirCooler); cbAirCooler.IsEnabled = false;
            cbList.Add(cbODD); cbODD.IsEnabled = false;
            cbList.Add(cbSC); cbSC.IsEnabled = false;
        }
        private bool UserMoney()
        {
            if (tbCash.Text.Length >= 7 && tbCash.Text.Length <= 8) 
            {
                Money = Convert.ToUInt32(tbCash.Text);
                if (Money >= 7000000 && Money <= 30000000)
                {
                    //recommend
                    if (Money >= 7000000) //7m
                    {
                        cbVGA.IsChecked = true; //rec VGA
                        if (Money <= 10000000) //10m
                        {
                            cbSSD.IsEnabled = false; //not rec SSD
                        }
                        else if (Money >= 15000000) //15m
                        {
                            cbSSD.IsChecked = true; //rec SSD
                        }
                    }
                    return true;
                }
            }
            tbCash.BorderBrush = Brushes.Red;
            MessageBox.Show("7m <= Money <= 30m", "Error", MessageBoxButton.OK);
            tbCash.BorderBrush = Brushes.Black;
            return false;
        }       
        private bool UserSelectedReq()
        {
            for (short i = 0; i < rdList.Count; i++)
            {
                if(rdList[i].IsChecked == true)
                {
                    Choice = i;
                    return true;
                }
            }
            //if false
            for (short i = 0; i < rdList.Count; i++)
            {
                rdList[i].Background = Brushes.Red;
            }
            MessageBox.Show("Must Select PC Requirement", "Warnning", MessageBoxButton.OK);         
            for (short i = 0; i < rdList.Count; i++)
            {
                rdList[i].Background = null;
            }
            return false;
        }       
        public void ReBuild()
        {
            Step = 1;
            step1.Visibility = Visibility.Visible;
            step2.Visibility = Visibility.Hidden;
            step3.Visibility = Visibility.Hidden;
            Result.Visibility = Visibility.Hidden;
            btnPre.Visibility = Visibility.Hidden;
            btnNext.Visibility = Visibility.Visible;
            tbCash.Text = "";
        }
        #endregion      
    }
}
