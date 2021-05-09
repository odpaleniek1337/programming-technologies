using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.ViewModel;
using Service;
using Data;
using System.Windows.Input;

namespace Model
{
    public class ProductListViewModel : ViewModelBase
    {
        private ProductService productService;

        public ProductListViewModel()
        {
            productService = new ProductService();

            AddProductCommand = new ActionBase(ShowAddProduct);
            UpdateProductCommand = new ActionBase(ShowUpdateProduct);
            UpdateProductQuantityCommand = new ActionBase(ShowUpdateQuantityProduct);
            DeleteProductCommand = new ActionBase(DeleteProduct);
            RefreshProductsCommand = new ActionBase(RefreshProducts);
            RefreshProducts();
        }

        private IEnumerable<Product> products;
        public IEnumerable<Product> Products
        {
            get
            {
                return products;
            }
            set
            {
                products = value;
                OnPropertyChanged("Products");
            }
        }
        private void RefreshProducts()
        {
            Task.Run(() => Products = ProductService.GetProducts());
        }

        public ICommand AddProductCommand { get; private set; }
        public ICommand UpdateProductCommand { get; private set; }
        public ICommand UpdateProductQuantityCommand { get; private set; }

        public ActionBase DeleteProductCommand { get; private set; }

        public ActionBase RefreshProductsCommand { get; private set; }

        private Product currentProduct;
        public Product CurrentProduct
        {
            get
            {
                return currentProduct;
            }
            set
            {
                currentProduct = value;
                OnPropertyChanged("CurrentProduct");
                RefreshProducts();
            }
        }

        public Lazy<IWindow> AddWindow { get; set; }

        public Lazy<IWindow> UpdateWindow { get; set; }

        private void ShowAddProduct()
        {
            IWindow newWindow = AddWindow.Value;
            newWindow.Show();
        }
        private void DeleteProduct()
        {
            if (CurrentProduct != null)
            {
                ProductService.DeleteProduct(CurrentProduct.id);
                RefreshProducts();
            }
        }

        private void ShowUpdateProduct()
        {
            IWindow newWindow = UpdateWindow.Value;
            newWindow.Show();
        }

        private void ShowUpdateQuantityProduct()
        {
            IWindow newWindow = UpdateWindow.Value;
            newWindow.Show();
        }

    }
    

}
