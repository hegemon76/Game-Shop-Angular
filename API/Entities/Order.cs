using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public int TotalPrice { get; set; }
        public int PaymentId { get; set; }
        public virtual Payment Payment { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }
        public int DeliveryId { get; set; }
        public virtual Delivery Delivery { get; set; }
        public DateTime DateOfOrder { get; set; } = DateTime.Now;
    }
}
