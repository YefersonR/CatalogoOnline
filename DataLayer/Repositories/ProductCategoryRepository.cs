using DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repositories
{
    public class ProductCategoryRepository
    {
        private DBConnection _DBConnection;
        public ProductCategoryRepository(DBConnection dBConnection)
        {
            _DBConnection = dBConnection;
        }
        public void CreateCategoryProduct(ProductCategory productCategory)
        {
            try
            {
                var command = _DBConnection.CreateCommand();
                command.CommandText = "InsertProductCategory";
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@ProductId", productCategory.ProductId);
                command.Parameters.AddWithValue("@CategoryId", productCategory.CategoryId);
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

        public void DeleteCategoryProduct(int Id)
        {
            try
            {
                var command = _DBConnection.CreateCommand();
                command.CommandText = "DeleteCategoryProducts";
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

        public List<Category> GetCategoryProduct()
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
