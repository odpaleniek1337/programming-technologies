using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public interface IProducer
    {
        string Name { get; set; }
        int ID { get; set; }
        int YearOfCreation { get; set; }
    }
}
