using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.BLL.DTOS
{
    public class ProductsViewModel
    {
        public int ID { get; set; }
        public string ProductName { get; set; }
        public double UnitPrice { get; set; }
        public int UnitInStock { get; set; }
        public string Garantie { get; set; }
        public bool Discontinued { get; set; }
        public int CategoryID { get; set; }
        public string Autor { get; set; }
        public bool HasError { get; set; }
        public string Error { get; set; }


    }
}
