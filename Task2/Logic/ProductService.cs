using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Data;

namespace Service
{
    public class ProductService
    {
        static public IEnumerable<Product> GetProducts()
        {
            using (var context = new ShopDataContext())
            {
                return context.Products.ToList();
            }
        }

        static public Product GetProductById(int id)
        {
            using (var context = new ShopDataContext())
            {
                foreach (Product Product in context.Products.ToList())
                {
                    if (Product.id.Equals(id))
                    {
                        return Product;
                    }
                }
                return null;
            }
        }

        static public IEnumerable<Product> GetProductByName(string name)
        {
            using (var context = new ShopDataContext())
            {
                List<Product> result = new List<Product>();
                foreach (Product Product in context.Products.ToList())
                {
                    if (Product.name.Equals(name))
                    {
                        result.Add(Product);
                    }
                }
                return result;
            }
        }

        static public Product GetProductByModel(string model)
        {
            using (var context = new ShopDataContext())
            {
                foreach (Product Product in context.Products.ToList())
                {
                    if (Product.model.Equals(model))
                    {
                        return Product;
                    }
                }
                return null;
            }
        }
        static public bool AddProduct(string name, string model, float price, int size, string producer, string season, int quantity)
        {
            using (var context = new ShopDataContext())
            {
                if (GetProductByModel(model) == null && !name.Equals(null) && !model.Equals(null) && !price.Equals(null) && !size.Equals(null) && !season.Equals(null) && !quantity.Equals(null))
                {
                    Product NewProduct = new Product
                    {
                        name = name,
                        model = model,
                        price = price,
                        size = size,
                        producer = producer,
                        season = season,
                        quantity = quantity,
                    };
                    context.Products.InsertOnSubmit(NewProduct);
                    context.SubmitChanges();
                    return true;
                }
                return false;
            }
        }

        static public bool UpdateProduct(int id, string name, string model, float price, int size, string producer, string season, int quantity)
        {
            using (var context = new ShopDataContext())
            {
                Product Product = context.Products.SingleOrDefault(i => i.id == id);
                if (!name.Equals(null) && !model.Equals(null) && !price.Equals(null) && !size.Equals(null) && !producer.Equals(null) && !season.Equals(null) && !quantity.Equals(null))
                {
                    Product.name = name;
                    Product.model = model;
                    Product.price = price;
                    Product.size = size;
                    Product.producer = producer;
                    Product.season = season;
                    Product.quantity = quantity;
                    context.SubmitChanges();
                    return true;
                }
                return false;
            }
        }

        static public bool UpdateProductQuantity(int id, int quantity)
        {
            using (var context = new ShopDataContext())
            {
                Product Product = context.Products.SingleOrDefault(i => i.id == id);
                if (!quantity.Equals(null))
                {
                    Product.quantity = quantity;
                    context.SubmitChanges();
                    return true;
                }
                return false;
            }
        }

        static public bool DeleteProduct(int id)
        {
            using (var context = new ShopDataContext())
            {
                Product Product = context.Products.SingleOrDefault(i => i.id == id);
                if (GetProductById(id) != null && !id.Equals(null))
                {
                    context.Products.DeleteOnSubmit(Product);
                    context.SubmitChanges();
                    return true;
                }
                return false;
            }
        }
    }
}
