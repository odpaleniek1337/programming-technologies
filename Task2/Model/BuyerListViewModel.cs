using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Service;
using Data;
using Model.ViewModel;
using System.Windows.Input;

namespace Model
{
    public class BuyerListViewModel : ViewModelBase
    {
        private BuyerService buyerService;

        public BuyerListViewModel()
        {
            buyerService = new BuyerService();

            AddBuyerCommand = new ActionBase(ShowAddNewBuyer);
            UpdateBuyerCommand = new ActionBase(ShowUpdateBuyer);
            DeleteBuyerCommand = new ActionBase(DeleteBuyer);
            RefreshBuyersCommand = new ActionBase(RefreshBuyers);
            RefreshBuyers();
        }

        private IEnumerable<Buyer> buyers;
        public IEnumerable<Buyer> Buyers
        {
            get
            {
                return buyers;
            }
            set
            {
                buyers = value;
                OnPropertyChanged("Buyers");
            }
        }

        private void RefreshBuyers()
        {
            Task.Run(() => Buyers = BuyerService.GetBuyers());
        }

        
        /*ICommand */
        public ICommand AddBuyerCommand { get; private set; }

        public ICommand UpdateBuyerCommand { get; private set; }

        public ActionBase DeleteBuyerCommand { get; private set; }

        public ActionBase RefreshBuyersCommand { get; private set; }

        private Buyer currentBuyer;
        public Buyer CurrentBuyer
        {
            get
            {
                return currentBuyer;
            }
            set
            {
                currentBuyer = value;
                OnPropertyChanged("CurrentBuyer");
                RefreshBuyers();
            }
        }
        public Lazy<IWindow> AddWindow { get; set; }

        public Lazy<IWindow> UpdateWindow { get; set; }

        private void ShowAddNewBuyer()
        {
            IWindow newWindow = AddWindow.Value;
            newWindow.Show();
        }

        private void DeleteBuyer()
        {
            if (CurrentBuyer != null)
            {
                BuyerService.DeleteBuyer(CurrentBuyer.phone);
                RefreshBuyers();
            }
        }
        private void ShowUpdateBuyer()
        {
            IWindow newWindow = UpdateWindow.Value;
            newWindow.Show();
        }
    }
}
