using DataLayer.Repositories;
using Logic.BLL.DTOS;
using Logic.BLL.Helpers;
using Logic.BLL.Intefaces.Repository;
using Logic.BLL.Intefaces.Services;
using Logic.BLL.ViewModels;
using Logic.DAL.Entities;
using System.Collections.Generic;
using System.Linq;

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
                UserPassword = request.UserPassword, //PasswordEncryption.Encryption(request.UserPassword),
                IsActive = request.IsActive,
                TypeUser = request.TypeUser
            };
            var ExistUser = _userRepository.GetUsers().FirstOrDefault(userr=> userr.UserName == user.UserName);
            if(ExistUser == null)
            {
                _userRepository.CreateUser(user);
            }
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
        public UserViewModel LoginAdmin(LoginViewModel request)
        {
            request.UserPassword = PasswordEncryption.Encryption(request.UserPassword);
            var user = _userRepository.LoginAdmin(request.UserName, request.UserPassword);
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
        public List<UserViewModel> GetAllProduct()
        {
            var users = _userRepository.GetUsers();
            List<UserViewModel> userRequest = users.Select(request => new UserViewModel
            {
                ID = request.ID,
                FirstName = request.FirstName,
                LastName = request.LastName,
                PhoneNumber = request.PhoneNumber,
                Email = request.Email,
                Address = request.Address,
                UserName = request.UserName
            }).ToList();

            return userRequest;
        }
        public UserViewModel GetUserById(int Id)
        {
            var user = _userRepository.GetUserById(Id);
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
                IsActive = request.IsActive

            };
            if (request.UserPassword == "" || request.UserPassword == null)
            {
                var userById = _userRepository.GetUserById(request.ID);
                user.UserPassword = userById.UserPassword;
            }
            else
            {
                user.UserPassword = PasswordEncryption.Encryption(request.UserPassword);
            }
            _userRepository.UpdateUser(user);
        }
        public void DeleteUser(int Id)
        {
            _userRepository.DeleteUser(Id);
        }
    }
}
