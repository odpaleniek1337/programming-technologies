using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public interface IBuyer
    {
        string Name { get; set; }
        string Surname { get; set; }
        int ID { get; set; }
        int Phone { get; set; }
    }
}
