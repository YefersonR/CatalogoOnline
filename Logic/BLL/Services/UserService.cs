using DataLayer.Repositories;
using Logic.BLL.DTOS;
using Logic.BLL.Helpers;
using Logic.BLL.Intefaces.Repository;
using Logic.BLL.Intefaces.Services;
using Logic.BLL.ViewModels;
using Logic.DAL.Entities;

namespace Logic.BLL.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository = new UserRepository();
        public void AddUser(UserViewModel request)
        {
            User user = new User
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                PhoneNumber = request.PhoneNumber,
                Email = request.Email,
                Address = request.Address,
                UserName = request.UserName,
                UserPassword = PasswordEncryption.Encryption(request.UserPassword),
                IsActive = request.IsActive

            };
            
            _userRepository.CreateUser(user);
        }

        public UserViewModel Login(LoginViewModel request)
        {
            request.UserPassword = PasswordEncryption.Encryption(request.UserPassword);
            var user = _userRepository.Login(request.UserName,request.UserPassword);
            UserViewModel UserR = new UserViewModel
            {
                ID = user.ID,
                FirstName = user.FirstName,
                LastName = user.LastName,
                PhoneNumber = user.PhoneNumber,
                Email = user.Email,
                Address = user.Address,
                UserName = user.UserName
            };

            return UserR;
        }

        public void UpdateUser(UserViewModel request)
        {
            User user = new User
            {
                ID = request.ID,
                FirstName = request.FirstName,
                LastName = request.LastName,
                PhoneNumber = request.PhoneNumber,
                Email = request.Email,
                Address = request.Address,
                UserName = request.UserName,
                UserPassword = request.UserPassword,
                IsActive = request.IsActive

            };
            _userRepository.UpdateUser(user);
        }
        public void DeleteUser(int Id)
        {
            _userRepository.DeleteUser(Id);
        }
    }
}
