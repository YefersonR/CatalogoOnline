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
                command.Parameters.Add(new SqlParameter("@FirstName", SqlDbType.VarChar, 20) { Value = user.FirstName });
                command.Parameters.Add(new SqlParameter("@LastName", SqlDbType.VarChar, 30) { Value = user.LastName });
                command.Parameters.Add(new SqlParameter("@PhoneNumber", SqlDbType.VarChar, 15) { Value = user.PhoneNumber });
                command.Parameters.Add(new SqlParameter("@Email",SqlDbType.VarChar, 50){Value=user.Email});
                command.Parameters.Add(new SqlParameter("@Address", SqlDbType.VarChar, 60){ Value = user.Address});
                command.Parameters.Add(new SqlParameter("@UserName",SqlDbType.VarChar,40){ Value = user.UserName });
                command.Parameters.Add(new SqlParameter("@UserPassword", SqlDbType.VarChar, int.MaxValue) {Value= user.UserPassword });
                command.Parameters.Add(new SqlParameter("@Autor", SqlDbType.VarChar, 20) { Value = "Administrador" });
                command.Parameters.Add(new SqlParameter("@FechaCreacion", SqlDbType.DateTime) { Value = combined });

                _DBConnection.OpenConnection();
                command.ExecuteNonQuery();

                var savedUser = GetUsers().FirstOrDefault(users => users.UserName == user.UserName);
                var command2 = _DBConnection.CreateCommand();
                command2.CommandText = "InsertRoleToUser";
                command2.CommandType = CommandType.StoredProcedure;
                command2.Parameters.Add(new SqlParameter("@UserId", SqlDbType.Int) { Value = savedUser.ID });
                command2.Parameters.Add(new SqlParameter("@RoleId", SqlDbType.Int) { Value = user.TypeUser });

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
                command.Parameters.Add(new SqlParameter("@ID", SqlDbType.Int) { Value = user.ID });
                command.Parameters.Add(new SqlParameter("@FirstName", SqlDbType.VarChar, 20) { Value = user.FirstName });
                command.Parameters.Add(new SqlParameter("@LastName", SqlDbType.VarChar, 30) { Value = user.LastName });
                command.Parameters.Add(new SqlParameter("@PhoneNumber", SqlDbType.VarChar, 15) { Value = user.PhoneNumber });
                command.Parameters.Add(new SqlParameter("@Email", SqlDbType.VarChar, 50) { Value = user.Email });
                command.Parameters.Add(new SqlParameter("@Address", SqlDbType.VarChar, 60) { Value = user.Address });
                command.Parameters.Add(new SqlParameter("@UserName", SqlDbType.VarChar, 40) { Value = user.UserName });
                command.Parameters.Add(new SqlParameter("@UserPassword", SqlDbType.VarChar, int.MaxValue) { Value = user.UserPassword });
                command.Parameters.Add(new SqlParameter("@IsActive", SqlDbType.Bit) { Value = user.IsActive });
                command.Parameters.Add(new SqlParameter("@Autor", SqlDbType.VarChar, 20) { Value = "Administrador" });
                command.Parameters.Add(new SqlParameter("@FechaActualizacion", SqlDbType.DateTime) { Value = combined });
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
                command.Parameters.Add(new SqlParameter("@UserName", SqlDbType.VarChar, 40) { Value = UserName });
                command.Parameters.Add(new SqlParameter("@UserPassword", SqlDbType.VarChar, int.MaxValue) { Value = Password });

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
                command.Parameters.Add(new SqlParameter("@UserName", SqlDbType.VarChar, 40) { Value = UserName });
                command.Parameters.Add(new SqlParameter("@UserPassword", SqlDbType.VarChar, int.MaxValue) { Value = Password });

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
                command.Parameters.Add(new SqlParameter("@ID", SqlDbType.Int) { Value = Id });
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
                command.Parameters.Add(new SqlParameter("@ID", SqlDbType.Int) { Value = Id });
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
