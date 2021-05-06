using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public interface IOrder
    {
        IProduct Product { get; set; }
        int ID { get; set; }
        IBuyer Buyer { get; set; }
        Payment Payment { get; set; }
    }
}
