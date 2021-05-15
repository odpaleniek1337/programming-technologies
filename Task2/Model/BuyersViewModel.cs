using Model.ViewModel;
using Service;
using System;
using System.Collections.Generic;
using System.Text;
using Data;

namespace Model
{
    public class BuyersViewModel : ViewModelBase
    {
        private BuyerService service;
        public BuyersViewModel(BuyerService service)
        {
            this.service = service;
        }
        public BuyersViewModel()
        {
            AddBuyerCommand = new ActionBase(AddBuyer);
            UpdateBuyerCommand = new ActionBase(UpdateBuyer);
            DeleteBuyerCommand = new ActionBase(DeleteBuyer);
        }
        private string name;
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
                OnPropertyChanged("Name");
            }
        }

        private string surname;
        public string Surname
        {
            get
            {
                return surname;
            }
            set
            {
                surname = value;
                OnPropertyChanged("Surname");
            }
        }

        private string phone;
        public string Phone
        {
            get
            {
                return phone;
            }
            set
            {
                phone = value;
                OnPropertyChanged("Phone");
            }
        }

        private int id;
        public int ID
        {
            get
            {
                return id;
            }
            set
            {
                id = value;
                OnPropertyChanged("ID");
            }
        }

        public ActionBase AddBuyerCommand { get; private set; }
        public ActionBase UpdateBuyerCommand { get; private set; }
        public ActionBase DeleteBuyerCommand { get; private set; }

        private void AddBuyer()
        {
            bool added = service.AddBuyer(Name, Surname, Phone);
            if (added)
            {
                text = "Buyer added";
            }
            else
            {
                text = "Cannot add Buyer";
            }
            MessageBoxShowDelegate(Text);
        }

        private Buyers currentBuyer;
        public Buyers CurrentBuyer
        {
            get => currentBuyer;
            set
            {
                currentBuyer = value;
                OnPropertyChanged("CurrentBuyer");
            }
        }
        private void UpdateBuyer()
        {
            bool updated = service.UpdateBuyer(ID, Name, Surname, Phone);
            if (updated)
            {
                text = "Buyer updated";
            }
            else
            {
                text = "Cannot update Buyer";
            }
            MessageBoxShowDelegate(Text);
        }
        private void DeleteBuyer()
        {
            bool deleted = service.DeleteBuyer(Phone);
            if (deleted)
            {
                text = "Buyer deleted";
            }
            else
            {
                text = "Cannot delete Buyer";
            }
            MessageBoxShowDelegate(Text);
        }

        private IEnumerable<Buyers> buyers;
        public IEnumerable<Buyers> Buyers
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

        private string text;
        public string Text
        {
            get
            {
                return text;
            }
            set
            {
                text = value;
                OnPropertyChanged("Text");
            }
        }
        public Action<string> MessageBoxShowDelegate { get; set; } = x => throw new ArgumentOutOfRangeException($"The delegate {nameof(MessageBoxShowDelegate)} must be assigned by the view layer");
    }

}