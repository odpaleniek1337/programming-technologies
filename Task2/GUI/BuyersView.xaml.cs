using Model;
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
            BuyersViewModel buyersViewModel = (BuyersViewModel)DataContext;
        }

        //  protected override void OnInitialized(EventArgs e)
        //  {
        //      base.OnInitialized(e);
        //
        //  }
    }
}
