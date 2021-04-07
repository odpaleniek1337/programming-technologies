using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class ProducerRepo
    {
        static Dictionary<int, Producer> producers = new Dictionary<int, Producer>();
        public void Upsert(Producer P)
        {
            if (producers.ContainsKey(P.ID))
                producers[P.ID] = P;
            else
                producers.Add(P.ID, P);
        }
        public Producer Get(int ID)
        {
            if (!producers.ContainsKey(ID))
                return null;

            return producers[ID];
        }

    }
}
