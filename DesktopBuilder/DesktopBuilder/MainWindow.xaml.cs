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

namespace DesktopBuilder
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region Constructor
        public MainWindow()
        {
            InitializeComponent();
            recSelected.Add(recComponentSelected);
            recSelected.Add(recAdvisorSelected);
            recSelected.Add(recCustomSelected);
            gridSelected.Add(gridComponents);
            gridSelected.Add(gridAdvisor);
            gridSelected.Add(gridCustom);
        }
        #endregion

        #region Properties
        private List<Rectangle> recSelected = new List<Rectangle>();
        private List<Grid> gridSelected = new List<Grid>();
        #endregion

        #region Events
        private void btnComponents_Click(object sender, RoutedEventArgs e)
        {
            Alternate(0);
        }
        private void btnAdvisor_Click(object sender, RoutedEventArgs e)
        {
            Alternate(1);
        }
        private void btnCustom_Click(object sender, RoutedEventArgs e)
        {
            Alternate(2);
        }
        #endregion

        #region Methods
        private void Alternate(int index)
        {
            recSelected[index].Visibility = Visibility.Visible;
            gridSelected[index].Visibility = Visibility.Visible;
            int tmp = index + 1;
            while ((tmp % 3) != index)
            {
                recSelected[tmp % 3].Visibility = Visibility.Hidden;
                gridSelected[tmp % 3].Visibility = Visibility.Hidden;
                tmp++;
            }
        }
        #endregion
    }
}
