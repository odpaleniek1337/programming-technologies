using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class Jacket : IProduct
    {
        public Jacket(int ID, string Name, string Model, float Price, string Size, IProducer Producer, int SeasonID)
        {
            this.ID = ID;
            this.Name = Name;
            this.Model = Model;
            this.Price = Price;
            this.Size = Size;
            this.Producer = Producer;
            this.SeasonID = SeasonID;
        }
        public int ID { get; set; }
        public string Name { get; set; }
        public string Model { get; set; }
        public float Price { get; set; }
        public string Size { get; set; }
        public IProducer Producer { get; set; }
        public int SeasonID { get; set; }
        public string GetSeason()
        {
            return Enum.GetName(typeof(Seasons), this.SeasonID);
        }
    }
}
