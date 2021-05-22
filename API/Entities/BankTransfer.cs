using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Entities
{
    public class BankTransfer:Payment
    {
        public BankTransfer()
        {
            Name = "Bank Transfer";
        }
    }
}
