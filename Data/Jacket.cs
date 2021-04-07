using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    class Jacket : IProduct
    {
        private int season_id;
        public int Id { get; set; }
        public string Name { get; set; }
        public string Model { get; set; }
        public float Price { get; set; }
        public string Size { get; set; }
        public int Quantity { get; set; }
        public int ProducerId { get; set; }
        public int SeasonId { get; set; }
    }
}
