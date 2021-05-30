using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.ViewModel
{
    public interface IProductViewModel
    {
        void AddProduct();
        void UpdateProduct();
        void DeleteProduct();
        void RefreshProducts();
        void UpdateQuantity();
    }
}
