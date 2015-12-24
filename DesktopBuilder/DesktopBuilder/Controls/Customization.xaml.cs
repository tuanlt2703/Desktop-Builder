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
            cbList.Add(VGAList);
            cbList.Add(HDD1_List);
            cbList.Add(HDD2_List);
            cbList.Add(SSD1_List);
            cbList.Add(SSD2_List);
            cbList.Add(PSUList);
            cbList.Add(CaseList);
            cbList.Add(FanCaseList);
            cbList.Add(AirCoolerList);
            cbList.Add(ODDList);
            cbList.Add(SoundCardList);

            test();
        }
        #endregion

        #region Properties
        private List<ComboBox> cbList = new List<ComboBox>();
        #endregion

        #region Events
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (AllCoreItemsSelected())
                MessageBox.Show("abc");
        }
        #endregion

        #region Methods
        private bool AllCoreItemsSelected()
        {
            if (CPUList.SelectedIndex == -1 ||
                MainboardList.SelectedIndex == -1 ||
                RAMList.SelectedIndex == -1 ||
                (HDD1_List.SelectedIndex == -1 && HDD2_List.SelectedIndex == -1) &&
                PSUList.SelectedIndex == -1
                )
                return false;
            return true;
        }
        #endregion

        private void test()
        {
            for (int i = 0; i < cbList.Count; i++)
                cbList[i].Items.Add("test" + i.ToString());
        }
    }
}
