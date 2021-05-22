using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Entities
{
    public class Courier:Delivery
    {
        public Courier()
        {
            Name = "Courier";
            Price = 16;
        }
    }
}
