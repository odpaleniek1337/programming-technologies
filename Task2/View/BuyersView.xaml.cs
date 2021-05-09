using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Model;

namespace View
{
    /// <summary>
    /// Logika interakcji dla klasy BuyersView.xaml
    /// </summary>
    public partial class BuyersView : Window
    {
        public BuyersView()
        {
            InitializeComponent();
            //BuyersViewModel buyersViewModel = (BuyersViewModel)DataContext;
            //buyersViewModel.MessageBoxShowDelegate = text => MessageBox.Show(text, "Text", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        protected override void OnInitialized(EventArgs e)
        {
            base.OnInitialized(e);
            BuyerListViewModel buyersListViewModel = (BuyerListViewModel)DataContext;
            buyersListViewModel.AddWindow = new Lazy<IWindow>(() => new AddBuyerView());
        }

    }


}
