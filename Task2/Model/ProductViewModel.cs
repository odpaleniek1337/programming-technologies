﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Service;
using Model.ViewModel;

namespace Model
{
    public class ProductViewModel : ViewModelBase
    {
        private ProductService service;
        public ProductViewModel(ProductService service)
        {
            this.service = service;
        }
        ProductViewModel()
        {
            service = new ProductService();
            AddProductCommand = new ActionBase(AddProduct);
            UpdateProductCommand = new ActionBase(UpdateProduct);
            UpdateProductQuantityCommand = new ActionBase(UpdateQuantity);
            DeleteProductCommand = new ActionBase(DeleteProduct);
        }
        private string name;
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
                OnPropertyChanged("Name");
            }
        }

        private string model;
        public string Model
        {
            get
            {
                return model;
            }
            set
            {
                model = value;
                OnPropertyChanged("Model");
            }
        }

        private float price;
        public float Price
        {
            get
            {
                return price;
            }
            set
            {
                price = value;
                OnPropertyChanged("Price");
            }
        }

        private int size;
        public int Size
        {
            get
            {
                return size;
            }
            set
            {
                size = value;
                OnPropertyChanged("Size");
            }
        }

        private string producer;
        public string Producer
        {
            get
            {
                return producer;
            }
            set
            {
                producer = value;
                OnPropertyChanged("Producer");
            }
        }

        private string season;
        public string Season
        {
            get
            {
                return season;
            }
            set
            {
                season = value;
                OnPropertyChanged("Season");
            }
        }

        private int quantity;
        public int Quantity
        {
            get
            {
                return quantity;
            }
            set
            {
                quantity = value;
                OnPropertyChanged("Quantity");
            }
        }

        private int id;
        public int ID
        {
            get
            {
                return id;
            }
            set
            {
                id = value;
                OnPropertyChanged("ID");
            }
        }

        public ActionBase AddProductCommand { get; private set; }
        public ActionBase UpdateProductCommand { get; private set; }
        public ActionBase UpdateProductQuantityCommand { get; private set; }
        public ActionBase DeleteProductCommand { get; private set; }

        private void AddProduct()
        {
            bool added = service.AddProduct(Name, Model, Price, Size, Producer, Season, Quantity);
            if (added)
            {
                text = "Product added";
            }
            else
            {
                text = "Cannot add Product";
            }
            MessageBoxShowDelegate(Text);
        }

        private void UpdateProduct()
        {
            bool updated = service.UpdateProduct(ID, Name, Model, Price, Size, Producer, Season, Quantity);
            if (updated)
            {
                text = "Product updated";
            }
            else
            {
                text = "Cannot update Product";
            }
            MessageBoxShowDelegate(Text);
        }

        private void UpdateQuantity()
        {
            bool updated = service.UpdateProductQuantity(ID, Quantity);
            if (updated)
            {
                text = "Product quantity updated";
            }
            else
            {
                text = "Cannot update Product quantity";
            }
            MessageBoxShowDelegate(Text);
        }

        private void DeleteProduct()
        {
            bool deleted = service.DeleteProduct(ID);
            if (deleted)
            {
                text = "Product deleted";
            }
            else
            {
                text = "Cannot delete Product";
            }
            MessageBoxShowDelegate(Text);
        }
        private string text;
        public string Text
        {
            get
            {
                return text;
            }
            set
            {
                text = value;
                OnPropertyChanged("Text");
            }
        }

        public Action<string> MessageBoxShowDelegate { get; set; } = x => throw new ArgumentOutOfRangeException($"The delegate {nameof(MessageBoxShowDelegate)} must be assigned by the view layer");
    }
}
