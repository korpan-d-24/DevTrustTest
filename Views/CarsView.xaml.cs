using DevTrustTest.Interfaces;
using DevTrustTest.ViewModels;
using System.Windows.Controls;
using System.IO;
using System.Linq;
using System.Windows;

namespace DevTrustTest.Views
{
    /// <summary>
    /// Interaction logic for CarsView.xaml
    /// </summary>
    public partial class CarsView : Window
    {
        private readonly ICarDataService _carDataService;
        public CarsView(ICarDataService carDataService, CarsViewModel carsViewModel)
        {
            InitializeComponent();
            _carDataService = carDataService;

            this.DataContext = carsViewModel;
        }

        private void SaveTXTItem_ItemClick(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e)
        {
            if (this.DataContext is not CarsViewModel cvm) return;

            File.WriteAllLines("C:\\Users\\Asus\\Desktop\\DevTrustTest\\SavedLists.txt", cvm.SelectedCars.Select(x => x.ToString()));
        }
        private void SaveCSVItem_ItemClick(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e)
        {
            if (this.DataContext is not CarsViewModel cvm) return;

            File.WriteAllLines("C:\\Users\\Asus\\Desktop\\DevTrustTest\\SavedLists.csv", cvm.SelectedCars.Select(x => x.ToString()));
        }
    }
}
