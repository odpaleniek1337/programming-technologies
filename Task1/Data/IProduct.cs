using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public interface IProduct
    {
        int ID { get; set; }
        string Name { get; set; }
        string Model { get; set; }
        float Price { get; set; }
        string Size { get; set; }
        IProducer Producer { get; set; }
        int SeasonID { get; set; }
        string GetSeason();
    }
}
