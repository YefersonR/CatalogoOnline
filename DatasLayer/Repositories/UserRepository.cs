using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.Entities;
using System.Data;
using System.Data.SqlClient;

namespace DataLayer.Repositories
{
    public class UserRepository
    {
        private DBConnection _DBConnection = new DBConnection();

        public void CreateUser(User user)
        {
            try
            {
                var command = _DBConnection.CreateCommand();
                command.CommandText = "InsertUser";
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@FirstName", user.FirstName);
                command.Parameters.AddWithValue("@LastName", user.LastName);
                command.Parameters.AddWithValue("@PhoneNumber", user.PhoneNumber);
                command.Parameters.AddWithValue("@Email", user.Email);
                command.Parameters.AddWithValue("@Address", user.Address);
                command.Parameters.AddWithValue("@UserName", user.UserName);
                command.Parameters.AddWithValue("@UserPassword", user.UserPassword);
                command.Parameters.AddWithValue("@IsActive", user.IsActive);


                _DBConnection.OpenConnection();
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                _DBConnection.CloseConnection();
            }
        }

        public void UpdateUser(User user)
        {
            try
            {
                var command = _DBConnection.CreateCommand();
                command.CommandText = "SetUsers";
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@ID", user.ID);
                command.Parameters.AddWithValue("@FirstName", user.FirstName);
                command.Parameters.AddWithValue("@LastName", user.LastName);
                command.Parameters.AddWithValue("@PhoneNumber", user.PhoneNumber);
                command.Parameters.AddWithValue("@Email", user.Email);
                command.Parameters.AddWithValue("@Address", user.Address);
                command.Parameters.AddWithValue("@UserName", user.UserName);
                command.Parameters.AddWithValue("@UserPassword", user.UserPassword);
                command.Parameters.AddWithValue("@IsActive", user.IsActive);
                _DBConnection.OpenConnection();
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                _DBConnection.CloseConnection();
            }
        }
        public User Login(string UserName, string Password)
        {
            try
            {
                var command = _DBConnection.CreateCommand();
                command.CommandText = "UserLogin";
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@UserName", UserName);
                command.Parameters.AddWithValue("@UserPassword", Password);

                _DBConnection.OpenConnection();

                SqlDataReader reader = command.ExecuteReader();
             
                    User user = new User();
                while (reader.Read())
                {
                 
                    user.ID = reader.GetInt32(0);
                    user.FirstName = reader.GetString(1);
                    user.LastName = reader.GetString(2);
                    user.PhoneNumber = reader.GetString(3);
                    user.Email = reader.GetString(4);
                    user.Address = reader.GetString(5);
                    user.UserName = reader.GetString(6);

                }
                return user;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                _DBConnection.CloseConnection();

            }
        }

        public void DeleteUser (int Id)
        {
            try
            {
                var command = _DBConnection.CreateCommand();
                command.CommandText = "DeleteUser";
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@ID", Id);
                _DBConnection.OpenConnection();
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                _DBConnection.CloseConnection();
            }
        }

    }
}
