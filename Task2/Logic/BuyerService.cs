using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Data;

namespace Service
{
    class BuyerService
    {
        public IEnumerable<Buyer> GetBuyers()
        {
            using (var context = new ShopDataContext())
            {
                return context.Buyers.ToList();
            }
        }

        public Buyer GetBuyer(string Phone)
        {
            using (var context = new ShopDataContext())
            {
                foreach (Buyer Buyer in context.Buyers.ToList())
                {
                    if (Buyer.phone.Equals(Phone))
                    {
                        return Buyer;
                    }
                }
                return null;
            }
        }

        public bool AddBuyer(string Name, string Surname, string Phone)
        {
            using (var context = new ShopDataContext())
            {
                if (GetBuyer(Phone) == null && !Name.Equals(null) && !Surname.Equals(null) && !Phone.Equals(null))
                {
                    Buyer NewBuyer = new Buyer
                    {
                        name = Name,
                        surname = Surname,
                        phone = Phone
                    };
                    context.Buyers.InsertOnSubmit(NewBuyer);
                    context.SubmitChanges();
                    return true;
                }
                return false;
            }
        }

        public bool UpdateBuyer(int id, string Name, string Surname, string Phone)
        {
            using (var context = new ShopDataContext())
            {
                Buyer Buyer = context.Buyers.SingleOrDefault(i => i.id == id);
                if (GetBuyer(Phone) == null && !Name.Equals(null) && !Surname.Equals(null) && !Phone.Equals(null))
                {
                    Buyer.name = Name;
                    Buyer.surname = Surname;
                    Buyer.phone = Phone;
                    context.SubmitChanges();
                    return true;
                }
                return false;
            }
        }

        public bool DeleteBuyer(string Phone)
        {
            using (var context = new ShopDataContext())
            {
                Buyer Buyer = context.Buyers.SingleOrDefault(i => i.phone == Phone);
                if (GetBuyer(Phone) != null && !Phone.Equals(null))
                {
                    context.Buyers.DeleteOnSubmit(Buyer);
                    context.SubmitChanges();
                    return true;
                }
                return false;
            }
        }
    }
}
