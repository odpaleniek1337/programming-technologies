using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class Shoes : IProduct
    {
        public Shoes(int ID, string Name, string Model, float Price, string Size, int Quantity, int ProducerId, bool WaterProof)
        {
            this.ID = ID;
            this.Name = Name;
            this.Model = Model;
            this.Price = Price;
            this.Size = Size;
            this.Quantity = Quantity;
            this.ProducerId = ProducerId;
            this.WaterProof = WaterProof;
        }
        public int ID { get; set; }
        public string Name { get; set; }
        public string Model { get; set; }
        public float Price { get; set; }
        public string Size { get; set; }
        public int Quantity { get; set; }
        public int ProducerId { get; set; }
        public bool WaterProof { get; set; }
    }
}
