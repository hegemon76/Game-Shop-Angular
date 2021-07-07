﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Entities
{
    public class Opinion
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string Surname { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
