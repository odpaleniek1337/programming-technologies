using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class Payment
    {
        public Payment(int Method, float Cost)
        {
            this.Method = Method;
            this.Cost = Cost;
        }
        public int Method { get; set; }
        public float Cost { get; set; }
    }
}
