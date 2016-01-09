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
using DesktopBuilder.Classes;

namespace DesktopBuilder.Controls
{
    /// <summary>
    /// Interaction logic for Result.xaml
    /// </summary>
    public partial class Result : UserControl
    {
        #region Constructor
        public Result()
        {
            InitializeComponent();
            InitTbs();
        }
        #endregion

        #region Properties
        public DesktopAdvisor _DA { get; set; }
        private ProductList pList;
        private List<int> SelectedList;// = new List<int>(new int[] { -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1 });

        private List<TextBlock> TBList = new List<TextBlock>(12);
        private List<TextBlock> PriceList = new List<TextBlock>(12);
        #endregion

        #region Events
        private void btnSave_Click(object sender, RoutedEventArgs e)
        {

        }
        private void btnRS_Copy_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult choice = MessageBox.Show("Rebuild?", "Warnning", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (choice == MessageBoxResult.Yes)
            {
                _DA.ReBuild();
            }
        }
        #endregion

        #region Methods
        public void Load(ProductList list, List<int> selected)
        {
            this.pList = list;
            SelectedList = selected;
            DoWord();
        }
        private void DoWord()
        {
            //reset result-form
            foreach (TextBlock tb in TBList)
                tb.Text = "";
            int total = 0;
            for (int i = 0; i < SelectedList.Count; i++)
            {
                if (SelectedList[i] != -1)
                {
                    Component tmp = pList.List(i)[SelectedList[i]];
                    TBList[i].Text = tmp.Info();
                    PriceList[i].Text = tmp.PricetoStr(tmp.Price);
                    total += tmp.Price;
                }
            }

            if (total >= 10000)
                tbTotal.Text = total.ToString().Insert(2, ".") + ".000 VNĐ";
            else if (total >= 1000)
                tbTotal.Text = total.ToString().Insert(1, ".") + ".000 VNĐ";
            else
                tbTotal.Text = total.ToString() + ".000 VNĐ";
        }
        private void InitTbs()
        {
            TBList.Add(tbCPU); //0
            TBList.Add(tbMain); //1
            TBList.Add(tbRAM); //2
            TBList.Add(tbHDD); //3
            TBList.Add(tbSSD); //4 
            TBList.Add(tbVGA); //5
            TBList.Add(tbPSU); //6
            TBList.Add(tbCase); //7
            TBList.Add(tbFan); //8
            TBList.Add(tbCooler); //9
            TBList.Add(tbODD); //10
            TBList.Add(tbSC); //11

            PriceList.Add(tbCPUPrice); //0
            PriceList.Add(tbMainPrice); //1
            PriceList.Add(tbRAMPrice); //2
            PriceList.Add(tbHDDPrice); //3
            PriceList.Add(tbSSDPrice); //4 
            PriceList.Add(tbVGAPrice); //5
            PriceList.Add(tbPSUPrice); //6
            PriceList.Add(tbCasePrice); //7
            PriceList.Add(tbFanPrice); //8
            PriceList.Add(tbCoolerPrice); //9
            PriceList.Add(tbODDPrice); //10
            PriceList.Add(tbSCPrice); //11
        }
        #endregion
    }
}
