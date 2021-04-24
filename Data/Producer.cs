using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class Producer : IProducer
    {
        public Producer(string Name, int ID, int YearOfCreation)
        {
            this.Name = Name;
            this.ID = ID;
            this.YearOfCreation = YearOfCreation;
        }
        public string Name { get; set; }
        public int ID { get; set; }
        public int YearOfCreation { get; set; }
    }
}
