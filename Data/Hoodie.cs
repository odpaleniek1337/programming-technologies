using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class Hoodie : IProduct
    {
        public Hoodie(int ID, string Name, string Model, float Price, string Size, int Quantity, Producer Producer)
        {
            this.ID = ID;
            this.Name = Name;
            this.Model = Model;
            this.Price = Price;
            this.Size = Size;
            this.Quantity = Quantity;
            this.Producer = Producer;
        }
        public int ID { get; set; }
        public string Name { get; set; }
        public string Model { get; set; }
        public float Price { get; set; }
        public string Size { get; set; }
        public int Quantity { get; set; }
        public Producer Producer { get; set; }
    }
}
