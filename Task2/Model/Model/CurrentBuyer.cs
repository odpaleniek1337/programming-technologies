using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.API;

namespace Model.Model
{
    public class CurrentBuyer : IBuyer
    {
        public CurrentBuyer() { }
        public CurrentBuyer(string Name, string Surname, int ID, string PhoneNumber)
        {
            this.Name = Name;
            this.Surname = Surname;
            this.ID = ID;
            this.Phone = PhoneNumber;
        }
        public int ID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Phone { get; set; }
    }
}
