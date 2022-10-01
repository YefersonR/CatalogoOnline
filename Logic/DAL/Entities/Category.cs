using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.DAL.Entities
{
    public class Category
    {
        public int ID { get; set; }
        public string CategoryName { get; set; }
        public string CategoryDescription { get; set; }
        public bool IsActive { get; set; }
        public string Autor { get; set; }
        public bool HasError { get; set; }
        public string Error { get; set; }

    }
}
