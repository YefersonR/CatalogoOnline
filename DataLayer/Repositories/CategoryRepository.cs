using System;
using System.Collections.Generic;
using DataLayer.Entities;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repositories
{
    public class CategoryRepository
    {
        private DBConnection _DBConnection;
        public CategoryRepository(DBConnection dBConnection)
        {
            _DBConnection = dBConnection; 
        }
        public void CreateCategory(Category category)
        {
            try
            {
                var command = _DBConnection.CreateCommand();
                command.CommandText = "InsertCategory";
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@CategoryName", category.CategoryName);
                command.Parameters.AddWithValue("@CategoryDescription", category.CategoryDescription);
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

        public void UpdateCategory(Category category)
        {
            try
            {
                var command = _DBConnection.CreateCommand();
                command.CommandText = "SetCategorys";
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@ID", category.ID);
                command.Parameters.AddWithValue("@CategoryName", category.CategoryName);
                command.Parameters.AddWithValue("@CategoryDescription", category.CategoryDescription);
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

        public void DeleteCategory(int Id)
        {
            try
            {
                var command = _DBConnection.CreateCommand();
                command.CommandText = "DeleteCategory";
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

        public List<Category> GetCategory()
        {
            try
            {
                var command = _DBConnection.CreateCommand();
                command.CommandText = "GetAllCategory";
                command.CommandType = CommandType.StoredProcedure;
                _DBConnection.OpenConnection();

                SqlDataReader reader =  command.ExecuteReader();
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
