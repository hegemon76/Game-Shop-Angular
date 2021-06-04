using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Models
{
    public class SelectListAsItems<T>
    {
        public List<T> Items { get; set; }
       
        public SelectListAsItems(List<T> items)
        {
            Items = items;
        }
    }
}
