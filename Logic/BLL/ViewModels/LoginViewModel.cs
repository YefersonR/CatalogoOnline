using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.BLL.ViewModels
{
    public class LoginViewModel
    {
        public string UserName { get; set; }
        public string UserPassword { get; set; }
        public bool HasError { get; set; }
        public string Error { get; set; }
    }
}
