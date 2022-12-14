using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logic.BLL.Intefaces.Repository;
using Logic.DAL.Entities;

namespace Logic.DAL.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private DBConnection _DBConnection = new DBConnection();
        public void CreateCategory(Category category)
        {
            try
            {
                DateTime date = DateTime.Now;
                TimeSpan time = new TimeSpan(36, 0, 0, 0);
                DateTime combined = date.Add(time);
                var command = _DBConnection.CreateCommand();
                command.CommandText = "InsertCategory";
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@CategoryName", SqlDbType.VarChar, 20) { Value = category.CategoryName });
                command.Parameters.Add(new SqlParameter("@CategoryDescription", SqlDbType.Text) { Value = category.CategoryDescription });
                command.Parameters.Add(new SqlParameter("@Autor", SqlDbType.VarChar, 20) { Value = "Administrador" });
                command.Parameters.Add(new SqlParameter("@FechaCreacion", SqlDbType.DateTime) { Value = combined });
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
                DateTime date = DateTime.Now;
                TimeSpan time = new TimeSpan(36, 0, 0, 0);
                DateTime combined = date.Add(time);
                var command = _DBConnection.CreateCommand();
                command.CommandText = "SetCategorys";
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@ID", SqlDbType.Int) { Value = category.ID });
                command.Parameters.Add(new SqlParameter("@CategoryName", SqlDbType.VarChar, 20) { Value = category.CategoryName });
                command.Parameters.Add(new SqlParameter("@CategoryDescription", SqlDbType.Text){Value = category.CategoryDescription});
                command.Parameters.Add(new SqlParameter("@IsActive", SqlDbType.Bit) { Value = category.IsActive });
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

        public void DeleteCategory(int Id)
        {
            try
            {
                var command = _DBConnection.CreateCommand();
                command.CommandText = "DeleteCategory";
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

        public List<Category> GetCategory()
        {
            try
            {
                var command = _DBConnection.CreateCommand();
                command.CommandText = "GetAllCategory";
                command.CommandType = CommandType.StoredProcedure;
                _DBConnection.OpenConnection();

                SqlDataReader reader =  command.ExecuteReader();
                List<Category> categories = new List<Category>();
                while (reader.Read())
                {
                    Category category = new Category();
                    category.ID = reader.GetInt32(0);
                    category.CategoryName = reader.GetString(1);
                    category.CategoryDescription = reader.GetString(2);
                    category.IsActive = reader.GetBoolean(3);
                    category.Autor = reader.GetString(4);


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
        public List<Category> GetActiveCategory()
        {
            try
            {
                var command = _DBConnection.CreateCommand();
                command.CommandText = "GetActiveCategory    ";
                command.CommandType = CommandType.StoredProcedure;
                _DBConnection.OpenConnection();

                SqlDataReader reader = command.ExecuteReader();
                List<Category> categories = new List<Category>();
                while (reader.Read())
                {
                    Category category = new Category();
                    category.ID = reader.GetInt32(0);
                    category.CategoryName = reader.GetString(1);
                    category.CategoryDescription = reader.GetString(2);
                    category.IsActive = reader.GetBoolean(3);
                    category.Autor = reader.GetString(4);


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
        public Category GetById(int Id)
        {
            try
            {
                var command = _DBConnection.CreateCommand();
                command.CommandText = "GetCategoryById";
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@ID", SqlDbType.Int) { Value = Id });
                _DBConnection.OpenConnection();

                SqlDataReader reader = command.ExecuteReader();
                Category category = new Category();
                while (reader.Read())
                {
                    category.ID = reader.GetInt32(0);
                    category.CategoryName = reader.GetString(1);
                    category.CategoryDescription = reader.GetString(2);
                    category.IsActive = reader.GetBoolean(3);
                    category.Autor = reader.GetString(4);

                }
                return category;

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
