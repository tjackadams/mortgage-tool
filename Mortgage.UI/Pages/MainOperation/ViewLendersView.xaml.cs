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

namespace Mortgage.UI.Pages.MainOperation
{
    using MVVMC;

    /// <summary>
    /// Interaction logic for ViewLendersView.xaml
    /// </summary>
    public partial class ViewLendersView : UserControl
    {
        public ViewLendersView()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var navService = NavigationServiceProvider.GetNavigationServiceInstance();
            var controller = navService.GetController<MainOperationController>();
            if (!(controller.GetCurrentViewModel() is ViewLendersViewModel viewModel))
            {
                throw new Exception("Failed to get lender :(");
            }

            controller.EditLender(viewModel.SelectedLender);
        }
    }
}
