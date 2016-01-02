using System;
using System.Collections;
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
using DesktopBuilder.Classes;
namespace DesktopBuilder.Controls
{
    /// <summary>
    /// Interaction logic for ComponentsList.xaml
    /// </summary>
    public partial class ComponentsList : UserControl
    {
        #region Constructor
        public ComponentsList()
        {
            InitializeComponent();
        }
        #endregion

        #region Properties
        private bool _On2nd;
        public MainWindow Main { get; set; }

        #endregion

        #region Events
        private void btnCPU_Click(object sender, RoutedEventArgs e)
        {
            lbPageTitle.Content = "CPU";
            ShowList(0);
        }
        private void btnMainboard_Click(object sender, RoutedEventArgs e)
        {
            lbPageTitle.Content = "Mainboard";
            ShowList(1);
        }
        private void btnRAM_Click(object sender, RoutedEventArgs e)
        {
            lbPageTitle.Content = "RAM";
            ShowList(2);
        }
        private void btnHDD_Click(object sender, RoutedEventArgs e)
        {
            lbPageTitle.Content = "HDD";
            ShowList(3);
        }
        private void btnSSD_Click(object sender, RoutedEventArgs e)
        {
            lbPageTitle.Content = "SSD";
            ShowList(4);
        }
        private void btnVGA_Click(object sender, RoutedEventArgs e)
        {
            lbPageTitle.Content = "VGA";
            ShowList(5);
        }
        private void btnPSU_Click(object sender, RoutedEventArgs e)
        {
            lbPageTitle.Content = "PSU";
            ShowList(6);
        }
        private void btnCase_Click(object sender, RoutedEventArgs e)
        {
            lbPageTitle.Content = "Case";
            ShowList(7);
        }
        private void btnFanCase_Click(object sender, RoutedEventArgs e)
        {
            lbPageTitle.Content = "FanCase";
            ShowList(8);
        }
        private void btnCpuCooler_Click(object sender, RoutedEventArgs e)
        {
            lbPageTitle.Content = "Air Cpu Cooler";
            ShowList(9);
        }
        private void btnODD_Click(object sender, RoutedEventArgs e)
        {
            lbPageTitle.Content = "ODD";
            ShowList(10);
        }
        private void btnSoundCard_Click(object sender, RoutedEventArgs e)
        {
            lbPageTitle.Content = "SoundCard";
            ShowList(11);
        }

        private void btnBackWard_Click(object sender, RoutedEventArgs e)
        {
            if(_On2nd)
            {
                scrPList.Visibility = Visibility.Hidden; // hide selected component product list
                gridComList.Visibility = Visibility.Visible; // show components list

                btnBackWard.Visibility = Visibility.Hidden; // hide back button
                lbPageTitle.Content = "Hardware Components";
            }
            else
            {
                ProductDetail.Visibility = Visibility.Hidden;
                scrPList.Visibility = Visibility.Visible;
                _On2nd = true;
            }
        }
        #endregion

        #region Methods
        private void ShowList(int index)
        {
            btnBackWard.Visibility = Visibility.Visible; // show back button
            _On2nd = true; // go to 2nd page

            gridComList.Visibility = Visibility.Hidden; // hide components list            
            scrPList.Visibility = Visibility.Visible; // show selected component product list

            ///////////update selected product list  //////////
            ProductList.Children.Clear(); // clear old product list
            for (int i = 0; i < Main.pList.List(index).Count; i++)
            {
                Product show = new Product(index, i, this);
                show.tbBriefInfo.Text = Main.pList.List(index)[i].BriefInfo();
                //show.avatar.Source = new BitmapImage(new Uri( "CoverPath" , UriKind.Relative));

                ProductList.Children.Add(show);
            }
        }
        public void ShowProductDetail(int Index, int ID)
        {
            //CPU cp = (CPU)productList.List(0)[0];
            //List<Tuple<string, string>> tmp = cp.PassDetailData();

            List<Tuple<string, string>> tmp = Main.pList.List(Index)[ID].PassDetailData();

            //clear last selected product detail
            ProductDetail.Details.Children.Clear();
            //add new selected product detail
            foreach(var item in tmp)
            {
                Detail dt = new Detail();
                dt.detail.Text = item.Item1;
                dt.Info.Text = item.Item2;
                ProductDetail.Details.Children.Add(dt);
            }

            _On2nd = false;
            scrPList.Visibility = Visibility.Hidden; // hide selected component product list
            ProductDetail.Visibility = Visibility.Visible; // show selected product detail
        }
        #endregion
    }
}
