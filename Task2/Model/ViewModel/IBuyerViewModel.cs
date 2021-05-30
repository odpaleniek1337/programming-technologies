using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.ViewModel
{
    public interface IBuyerViewModel
    {
        void AddBuyer();
        void UpdateBuyer();
        void DeleteBuyer();
        void RefreshBuyers();
    }
}
