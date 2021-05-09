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
using Model;
using System.ComponentModel;

namespace View
{
    /// <summary>
    /// Logika interakcji dla klasy AddBuyerView.xaml
    /// </summary>
    public partial class AddBuyerView : IWindow
    {
        public AddBuyerView()
        {
            InitializeComponent();
            BuyersViewModel buyerViewModel = (BuyersViewModel)DataContext;
            buyerViewModel.MessageBoxShowDelegate = text => MessageBox.Show(text, "Information", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        public void Show()
        {
            throw new NotImplementedException();
        }
    }
}
