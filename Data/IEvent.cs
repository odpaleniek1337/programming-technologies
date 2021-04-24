using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public interface IEvent
    {
        int ID { get; set; }
        DateTime Date { get; set; }
        IOrder Order { get; set; }
        string Reason { get; set; }
        string Complain { get; set; }
        int ClientRating { get; set; }
    }
}
