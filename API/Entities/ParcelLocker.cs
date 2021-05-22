using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Entities
{
    public class ParcelLocker:Delivery
    {
        public ParcelLocker()
        {
            Name = "Parcel locker";
            Price = 13;
        }
        
    }
}
