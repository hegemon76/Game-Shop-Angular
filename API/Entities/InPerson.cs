using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Entities
{
    public class InPerson:Delivery
    {
        public InPerson()
        {
            Name = "In person";
            Price = 0;
        }
    }
}
