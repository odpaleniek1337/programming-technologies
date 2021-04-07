﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class Buyer

    {
        public Buyer(string Name, string Surname, int ID, int PhoneNumber, int ItemCount)
        {
            this.Name = Name;
            this.Surname = Surname;
            this.ID = ID;
            Phone = PhoneNumber;
            BoughtItems = ItemCount;
        }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int ID { get; set; }
        public int Phone { get; set; }

        public int BoughtItems { get; set; }

    }
}
