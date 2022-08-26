using BusinessLayer.DTOS;
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
        private readonly UserRepository _userRepository;
        public UserService(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public void AddProduct(UserRequest request)
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
        public void UpdateProduct(UserRequest request)
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
        public void DeleteProduct(int Id)
        {
            _userRepository.DeleteUser(Id);
        }
    }
}
