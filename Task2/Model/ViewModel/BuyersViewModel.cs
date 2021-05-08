using Model.ViewModel;
using Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    class BuyersViewModel : ViewModelBase
    {
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
                return this.name;
            }
            set
            {
                this.name = value;
                OnPropertyChanged("Name");
            }
        }

        private string surname;
        public string Surname
        {
            get
            {
                return this.surname;
            }
            set
            {
                this.surname = value;
                OnPropertyChanged("Surname");
            }
        }

        private string phone;
        public string Phone
        {
            get
            {
                return this.phone;
            }
            set
            {
                this.phone = value;
                OnPropertyChanged("Phone");
            }
        }

        private int id;
        public int ID
        {
            get
            {
                return this.id;
            }
            set
            {
                this.id = value;
                OnPropertyChanged("ID");
            }
        }

        public ActionBase AddBuyerCommand { get; private set; }
        public ActionBase UpdateBuyerCommand { get; private set; }
        public ActionBase DeleteBuyerCommand { get; private set; }

        private void AddBuyer()
        {
            bool added = BuyerService.AddBuyer(Name, Surname, Phone);
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

        private void UpdateBuyer()
        {
            bool added = BuyerService.UpdateBuyer(ID, Name, Surname, Phone);
            if (added)
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
            bool added = BuyerService.DeleteBuyer(Phone);
            if (added)
            {
                text = "Buyer deleted";
            }
            else
            {
                text = "Cannot delete Buyer";
            }
            MessageBoxShowDelegate(Text);
        }

        private string text;
        public string Text
        {
            get
            {
                return this.text;
            }
            set
            {
                this.text = value;
                OnPropertyChanged("Text");
            }
        }
        public Action<string> MessageBoxShowDelegate { get; set; } = x => throw new ArgumentOutOfRangeException($"The delegate {nameof(MessageBoxShowDelegate)} must be assigned by the view layer");
    }

}