﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.DTOS
{
    public class ProductsRequest
    {
        public int ID { get; set; }
        public string ProductName { get; set; }
        public double UnitPrice { get; set; }
        public int UnitInStock { get; set; }
        public string Garantie { get; set; }
        public bool Discontinued { get; set; }
    }
}
