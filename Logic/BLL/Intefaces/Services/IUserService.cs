using Logic.BLL.DTOS;
using Logic.BLL.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.BLL.Intefaces.Services
{
    public interface IUserService
    {
        void AddUser(UserViewModel request);
        UserViewModel Login(LoginViewModel request);
        void UpdateUser(UserViewModel request);
        void DeleteUser(int Id);


    }
}
