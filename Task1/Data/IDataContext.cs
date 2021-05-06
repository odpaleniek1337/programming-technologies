using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public interface IDataContext
    {
        Dictionary<int, IProduct> Products;
        Dictionary<int, IBuyer> Buyers;
        Dictionary<int, IOrder> Orders;
        Dictionary<int, IProducer>;
        Dictionary<int, IEvent> Events;
        Dictionary<int, IState> States;
    }
}
