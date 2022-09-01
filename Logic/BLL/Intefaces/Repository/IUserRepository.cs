using Logic.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.BLL.Intefaces.Repository
{
    public interface IUserRepository
    {
        void CreateUser(User user);
        void UpdateUser(User user);
        User Login(string UserName, string Password);
        void DeleteUser(int Id);
        List<User> GetUsers();
        User GetUserById(int Id);

    }
}
