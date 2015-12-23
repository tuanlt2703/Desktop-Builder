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

namespace DesktopBuilder.Controls
{
    /// <summary>
    /// Interaction logic for Product.xaml
    /// </summary>
    public partial class Product : UserControl
    {
        #region Constructor
        public Product(int index, int id, ComponentsList coms)
        {
            InitializeComponent();
            this.Index = index;
            this.ID = id;
            this.coList = coms;
        }
        #endregion

        #region Properties
        private ComponentsList coList;
        private int Index; // indicate this product is which component
        private int ID; // ID of this product in component list
        #endregion

        #region Evens
        private void Grid_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            coList.ShowProductDetail(this.Index, this.ID);
        }
        #endregion
    }
}
