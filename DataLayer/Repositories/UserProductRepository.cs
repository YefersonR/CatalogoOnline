using DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace DataLayer.Repositories
{
    public class UserProductRepository
    {
        private DBConnection _DBConnection;
        public UserProductRepository(DBConnection dBConnection)
        {
            _DBConnection = dBConnection;
        }
        public void CreateProduct(UserProducts userProduct)
        {
            try
            {
                var command = _DBConnection.CreateCommand();
                command.CommandText = "InsertUserProduct";
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@CategoryName", userProduct.ProductId);
                command.Parameters.AddWithValue("@CategoryDescription", userProduct.UserId);
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
        public void DeleteProduct(int Id)
        {
            try
            {
                var command = _DBConnection.CreateCommand();
                command.CommandText = "DeleteUserProducts";
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

        public List<Category> GetProduct()
        {
            try
            {
                var command = _DBConnection.CreateCommand();
                command.CommandText = "GetAllCategory";
                command.CommandType = CommandType.StoredProcedure;
                _DBConnection.OpenConnection();

                SqlDataReader reader = command.ExecuteReader();
                List<Category> categories = new();
                while (reader.Read())
                {
                    Category category = new();
                    category.ID = reader.GetInt32(0);
                    category.CategoryName = reader.GetString(1);
                    category.CategoryDescription = reader.GetString(2);
                    category.IsActive = reader.GetBoolean(1);

                    categories.Add(category);
                }
                return categories;

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
