using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Logic;
using Logic.DAL.Entities;
using Logic.BLL.Intefaces.Repository;

namespace DataLayer.Repositories
{
    public class UserRepository : IUserRepository
    {
        private DBConnection _DBConnection = new DBConnection();

        public void CreateUser(User user)
        {
            try
            {
                DateTime date = DateTime.Now;
                TimeSpan time = new TimeSpan(36, 0, 0, 0);
                DateTime combined = date.Add(time);
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
                command.Parameters.AddWithValue("@Autor", "Administrador");
                command.Parameters.AddWithValue("@FechaCreacion", combined);

                _DBConnection.OpenConnection();
                command.ExecuteNonQuery();

                var savedUser = GetUsers().FirstOrDefault(users => users.UserName == user.UserName);
                var command2 = _DBConnection.CreateCommand();
                command2.CommandText = "InsertRoleToUser";
                command2.CommandType = CommandType.StoredProcedure;
                command2.Parameters.AddWithValue("@UserId", savedUser.ID);
                command2.Parameters.AddWithValue("@RoleId", user.TypeUser);

                command2.ExecuteNonQuery();

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
                DateTime date = DateTime.Now;
                TimeSpan time = new TimeSpan(36, 0, 0, 0);
                DateTime combined = date.Add(time);
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
                command.Parameters.AddWithValue("@Autor", "Administrador");
                command.Parameters.AddWithValue("@FechaActualizacion", combined);
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
                    user.Autor = reader.GetString(7);
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

        public User LoginAdmin(string UserName, string Password)
        {
            try
            {
                var command = _DBConnection.CreateCommand();
                command.CommandText = "AdminLogin";
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
                    user.Autor = reader.GetString(7);
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
        public List<User> GetUsers()
        {
            try
            {
                var command = _DBConnection.CreateCommand();
                command.CommandText = "GetAllUsers";
                command.CommandType = CommandType.StoredProcedure;

                _DBConnection.OpenConnection();

                SqlDataReader reader = command.ExecuteReader();
                List<User> users = new List<User>();
                while (reader.Read())
                {
                    User user = new User();
                    user.ID = reader.GetInt32(0);
                    user.FirstName = reader.GetString(1);
                    user.LastName = reader.GetString(2);
                    user.PhoneNumber = reader.GetString(3);
                    user.Email = reader.GetString(4);
                    user.Address = reader.GetString(5);
                    user.UserName = reader.GetString(6);
                    user.Autor = reader.GetString(9);


                    users.Add(user);
                }
                return users;

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
        public User GetUserById(int Id)
        {
            try
            {
                var command = _DBConnection.CreateCommand();
                command.CommandText = "GetUserById";
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@ID", Id);
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
                    user.UserPassword = reader.GetString(7);
                    user.IsActive = reader.GetBoolean(8);
                    user.Autor = reader.GetString(9);

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

    }
}
