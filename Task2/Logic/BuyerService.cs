using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Data;

namespace Service
{
    public class BuyerService
    {
        static public IEnumerable<Buyers> GetBuyers()
        {
            using (var context = new ShopDataContext())
            {
                return context.Buyers.ToList();
            }
        }

        static public Buyers GetBuyer(string Phone)
        {
            using (var context = new ShopDataContext())
            {
                foreach (Buyers Buyer in context.Buyers.ToList())
                {
                    if (Buyer.phone.Equals(Phone))
                    {
                        return Buyer;
                    }
                }
                return null;
            }
        }

        static public bool AddBuyer(string Name, string Surname, string Phone)
        {
            using (var context = new ShopDataContext())
            {
                if (GetBuyer(Phone) == null && !Name.Equals(null) && !Surname.Equals(null) && !Phone.Equals(null))
                {
                    Buyers NewBuyer = new Buyers
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

        static public bool UpdateBuyer(int id, string Name, string Surname, string Phone)
        {
            using (var context = new ShopDataContext())
            {
                Buyers Buyer = context.Buyers.SingleOrDefault(i => i.id == id);
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

        static public bool DeleteBuyer(string Phone)
        {
            using (var context = new ShopDataContext())
            {
                Buyers Buyer = context.Buyers.SingleOrDefault(i => i.phone == Phone);
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
