using BusinessLayer.DTOS;
using BusinessLayer2.ViewModels;
using DataLayer.Entities;
using DataLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Services
{
    public class UserService
    {
        private readonly UserRepository _userRepository = new UserRepository();
        public void AddUser(UserRequest request)
        {
            User user = new User
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                PhoneNumber = request.PhoneNumber,
                Email = request.Email,
                Address = request.Address,
                UserName = request.UserName,
                UserPassword = request.UserPassword,
                IsActive = request.IsActive

            };

            _userRepository.CreateUser(user);
        }

        public UserRequest Login(LoginRequest request)
        {
            var user = _userRepository.Login(request.UserName,request.UserPassword);
            UserRequest UserR = new UserRequest
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

        public void UpdateUser(UserRequest request)
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
