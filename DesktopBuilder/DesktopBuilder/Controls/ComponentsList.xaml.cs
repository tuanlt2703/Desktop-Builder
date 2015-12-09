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
            //gridComList.Visibility = Visibility.Hidden;
            
        }
        #endregion

        #region Properties
        private ProductList aList = new ProductList();     
        #endregion

        #region Events
        private void btnCPU_Click(object sender, RoutedEventArgs e)
        {
            ShowList(aList.List(0), 0);
        }

        private void btnMainboard_Click(object sender, RoutedEventArgs e)
        {
            ShowList(aList.List(1), 1);
        }

        private void btnRAM_Click(object sender, RoutedEventArgs e)
        {
            ShowList(aList.List(2), 2);
        }

        private void btnHDD_Click(object sender, RoutedEventArgs e)
        {
            ShowList(aList.List(3), 3);
        }

        private void btnSSD_Click(object sender, RoutedEventArgs e)
        {
            ShowList(aList.List(4), 4);
        }

        private void btnVGA_Click(object sender, RoutedEventArgs e)
        {
            ShowList(aList.List(5), 5);
        }

        private void btnPSU_Click(object sender, RoutedEventArgs e)
        {
            ShowList(aList.List(6), 6);
        }

        private void btnCase_Click(object sender, RoutedEventArgs e)
        {
            ShowList(aList.List(7), 7);
        }

        private void btnFanCase_Click(object sender, RoutedEventArgs e)
        {
            ShowList(aList.List(8), 8);
        }

        private void btnCpuCooler_Click(object sender, RoutedEventArgs e)
        {
            ShowList(aList.List(9), 9);
        }

        private void btnODD_Click(object sender, RoutedEventArgs e)
        {
            ShowList(aList.List(10), 10);
        }

        private void btnSoundCard_Click(object sender, RoutedEventArgs e)
        {
            ShowList(aList.List(11), 11);
        }
        #endregion

        #region Methods
        private void ShowList(ArrayList listtoshow, int index)
        {
            gridComList.Visibility = Visibility.Hidden;
            scrPList.Visibility = Visibility.Visible;
            switch (index)
            {
                case 0:
                    foreach(CPU cpu in listtoshow)
                    {
                        Product show = new Product();
                        show.tbBriefInfo.Text = cpu.BriefInfo();
                        //show.Avatar.Source = new BitmapImage(new Uri( "CoverPath" , UriKind.Relative));
                        ProductList.Children.Add(show);
                    }
                    break;
                case 1:
                    foreach(Mainboard mainboard in listtoshow)
                    {
                        Product show = new Product();
                        //show.tbBriefInfo.Text = mainboard.BriefInfo();
                        //show.Avatar.Source = new BitmapImage(new Uri( "CoverPath" , UriKind.Relative));
                        ProductList.Children.Add(show);
                    }
                    break;
                case 2:
                    foreach (RAM ram in listtoshow)
                    {
                        Product show = new Product();
                        //show.tbBriefInfo.Text = ram.BriefInfo();
                        //show.Avatar.Source = new BitmapImage(new Uri( "CoverPath" , UriKind.Relative));
                        ProductList.Children.Add(show);
                    }
                    break;
                case 3:
                    foreach (HDD hdd in listtoshow)
                    {
                        Product show = new Product();
                        //show.tbBriefInfo.Text = hdd.BriefInfo();
                        //show.Avatar.Source = new BitmapImage(new Uri( "CoverPath" , UriKind.Relative));
                        ProductList.Children.Add(show);
                    }
                    break;
                case 4:
                    foreach (SSD ssd in listtoshow)
                    {
                        Product show = new Product();
                        //show.tbBriefInfo.Text = ssd.BriefInfo();
                        //show.Avatar.Source = new BitmapImage(new Uri( "CoverPath" , UriKind.Relative));
                        ProductList.Children.Add(show);
                    }
                    break;
                case 5:
                    foreach (VGA vga in listtoshow)
                    {
                        Product show = new Product();
                        //show.tbBriefInfo.Text = vga.BriefInfo();
                        //show.Avatar.Source = new BitmapImage(new Uri( "CoverPath" , UriKind.Relative));
                        ProductList.Children.Add(show);
                    }
                    break;
                case 6:
                    foreach (PSU psu in listtoshow)
                    {
                        Product show = new Product();
                        //show.tbBriefInfo.Text = psu.BriefInfo();
                        //show.Avatar.Source = new BitmapImage(new Uri( "CoverPath" , UriKind.Relative));
                        ProductList.Children.Add(show);
                    }
                    break;
                case 7:
                    foreach (Case cas in listtoshow)
                    {
                        Product show = new Product();
                        //show.tbBriefInfo.Text = cas.BriefInfo();
                        //show.Avatar.Source = new BitmapImage(new Uri( "CoverPath" , UriKind.Relative));
                        ProductList.Children.Add(show);
                    }
                    break;
                case 8:
                    foreach (FanCase fan in listtoshow)
                    {
                        Product show = new Product();
                        //show.tbBriefInfo.Text = fan.BriefInfo();
                        //show.Avatar.Source = new BitmapImage(new Uri( "CoverPath" , UriKind.Relative));
                        ProductList.Children.Add(show);
                    }
                    break;
                case 9:
                    foreach (AirCPUCooler cooler in listtoshow)
                    {
                        Product show = new Product();
                        //show.tbBriefInfo.Text = cooler.BriefInfo();
                        //show.Avatar.Source = new BitmapImage(new Uri( "CoverPath" , UriKind.Relative));
                        ProductList.Children.Add(show);
                    }
                    break;
                case 10:
                    foreach (ODD odd in listtoshow)
                    {
                        Product show = new Product();
                        //show.tbBriefInfo.Text = odd.BriefInfo();
                        //show.Avatar.Source = new BitmapImage(new Uri( "CoverPath" , UriKind.Relative));
                        ProductList.Children.Add(show);
                    }
                    break;
                case 11:
                    foreach (SoundCard card in listtoshow)
                    {
                        Product show = new Product();
                        //show.tbBriefInfo.Text = card.BriefInfo();
                        //show.Avatar.Source = new BitmapImage(new Uri( "CoverPath" , UriKind.Relative));
                        ProductList.Children.Add(show);
                    }
                    break;
            }
        }
        #endregion

        #region ForTesting
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            gridComList.Visibility = Visibility.Hidden;
            scrPList.Visibility = Visibility.Visible;

            RAM tmp = new RAM();
            tmp.setifo();
            Product show = new Product();
            show.tbBriefInfo.Text = tmp.BriefIfo();
            ProductList.Children.Add(show);
        }
        #endregion


    }
}
