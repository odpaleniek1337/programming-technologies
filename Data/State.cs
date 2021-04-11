using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class State
    {
        public State(int Quantity)
        {
            this.Quantity = Quantity;
        }
        public int Quantity { get; set; }
    }
}