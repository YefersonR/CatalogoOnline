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
    public class ProductRepository : IProductRepository
    {
        private DBConnection _DBConnection = new DBConnection();

        public void CreateProduct(Product product)
        {
            try
            {
                DateTime date = DateTime.Now;
                TimeSpan time = new TimeSpan(36, 0, 0, 0);
                DateTime combined = date.Add(time);
                var command = _DBConnection.CreateCommand();
                command.CommandText = "InsertProduct";
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@ProductName", SqlDbType.VarChar, 40) { Value = product.ProductName });
                command.Parameters.Add(new SqlParameter("@UnitPrice", SqlDbType.Money) { Value = product.UnitPrice });
                command.Parameters.Add(new SqlParameter("@UnitInStock", SqlDbType.Int) { Value = product.UnitInStock });
                command.Parameters.Add(new SqlParameter("@Garantie", SqlDbType.Text) { Value = product.Garantie });
                command.Parameters.Add(new SqlParameter("@CategoryID",SqlDbType.Int ){Value=product.CategoryID});
                if (product.Autor == "" || product.Autor == null)
                {
                    command.Parameters.Add(new SqlParameter("@Autor", SqlDbType.VarChar, 20) {Value= "Administrador" });
                }
                else
                {
                    command.Parameters.Add(new SqlParameter("@Autor", SqlDbType.VarChar,20) { Value = product.Autor});
                }
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

        public void UpdateProduct(Product product)
        {
            try
            {
                DateTime date = DateTime.Now;
                TimeSpan time = new TimeSpan(36, 0, 0, 0);
                DateTime combined = date.Add(time);
                var command = _DBConnection.CreateCommand();
                command.CommandText = "SetProducts";
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@ID", SqlDbType.Int) {Value= product.ID});
                command.Parameters.Add(new SqlParameter("@ProductName", SqlDbType.VarChar, 40) { Value = product.ProductName });
                command.Parameters.Add(new SqlParameter("@UnitPrice", SqlDbType.Money) { Value = product.UnitPrice });
                command.Parameters.Add(new SqlParameter("@UnitInStock", SqlDbType.Int) { Value = product.UnitInStock });
                command.Parameters.Add(new SqlParameter("@Garantie", SqlDbType.Text) { Value = product.Garantie });
                command.Parameters.Add(new SqlParameter("@CategoryID", SqlDbType.Int) { Value = product.CategoryID });

                command.Parameters.Add(new SqlParameter("@Discontinued", SqlDbType.Bit){Value=product.Discontinued});
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

        public void DeleteProduct(int Id)
        {
            try
            {
                var command = _DBConnection.CreateCommand();
                command.CommandText = "DeleteProducts";
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

        public List<Product> GetProduct()
        {
            try
            {
                var command = _DBConnection.CreateCommand();
                command.CommandText = "GetAllProducts";
                command.CommandType = CommandType.StoredProcedure;

                _DBConnection.OpenConnection();

                SqlDataReader reader = command.ExecuteReader();
                List<Product> products = new List<Product>();
                while (reader.Read())
                {
                    Product product = new Product();
                    product.ID = reader.GetInt32(0);
                    product.ProductName = reader.GetString(1);
                    product.UnitPrice = reader.GetSqlMoney(2).ToDouble();
                    product.UnitInStock = reader.GetInt32(3);
                    product.Garantie = reader.GetString(4);
                    product.Discontinued = reader.GetBoolean(5);
                    product.CategoryID= reader.GetInt32(6);
                    product.Autor= reader.GetString(7);


                    products.Add(product);
                }
                return products;

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

        public List<Product> GetActiveProduct()
        {
            try
            {
                var command = _DBConnection.CreateCommand();
                command.CommandText = "GetAllActivesProducts";
                command.CommandType = CommandType.StoredProcedure;

                _DBConnection.OpenConnection();

                SqlDataReader reader = command.ExecuteReader();
                List<Product> products = new List<Product>();
                while (reader.Read())
                {
                    Product product = new Product();
                    product.ID = reader.GetInt32(0);
                    product.ProductName = reader.GetString(1);
                    product.UnitPrice = reader.GetSqlMoney(2).ToDouble();
                    product.UnitInStock = reader.GetInt32(3);
                    product.Garantie = reader.GetString(4);
                    product.Discontinued = reader.GetBoolean(5);
                    product.CategoryID = reader.GetInt32(6);
                    product.Autor = reader.GetString(7);


                    products.Add(product);
                }
                return products;

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

        public List<Product> SearchProduct(string search)
        {
            try
            {
                var command = _DBConnection.CreateCommand();
                command.CommandText = "SearchProducts";
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@ProductName", SqlDbType.VarChar, 40) { Value = search});
                _DBConnection.OpenConnection();

                SqlDataReader reader = command.ExecuteReader();
                List<Product> products = new List<Product>();
                while (reader.Read())
                {
                    Product product = new Product();
                    product.ID = reader.GetInt32(0);
                    product.ProductName = reader.GetString(1);
                    product.UnitPrice = reader.GetSqlMoney(2).ToDouble();
                    product.UnitInStock = reader.GetInt32(3);
                    product.Garantie = reader.GetString(4);
                    product.Discontinued = reader.GetBoolean(5);
                    product.CategoryID = reader.GetInt32(6);
                    product.Autor = reader.GetString(7);

                    products.Add(product);
                }
                return products;

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

        public List<Product> FilterByCategory(int CategoryId)
        {
            try
            {
                var command = _DBConnection.CreateCommand();
                command.CommandText = "FilterByCategory";
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@CategoryID", SqlDbType.Int) { Value = CategoryId });
                _DBConnection.OpenConnection();

                SqlDataReader reader = command.ExecuteReader();
                List<Product> products = new List<Product>();
                while (reader.Read())
                {
                    Product product = new Product();
                    product.ID = reader.GetInt32(0);
                    product.ProductName = reader.GetString(1);
                    product.UnitPrice = reader.GetSqlMoney(2).ToDouble();
                    product.UnitInStock = reader.GetInt32(3);
                    product.Garantie = reader.GetString(4);
                    product.Discontinued = reader.GetBoolean(5);
                    product.CategoryID = reader.GetInt32(6);
                    product.Autor = reader.GetString(7);

                    products.Add(product);
                }
                return products;

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

        public Product GetProductById(int Id)
        {
            try
            {
                var command = _DBConnection.CreateCommand();
                command.CommandText = "GetProductById";
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@ID", SqlDbType.Int) { Value = Id });
                _DBConnection.OpenConnection();

                SqlDataReader reader = command.ExecuteReader();
                Product product = new Product();
                while (reader.Read())
                {
                    product.ID = reader.GetInt32(0);
                    product.ProductName = reader.GetString(1);
                    product.UnitPrice = reader.GetSqlMoney(2).ToDouble();
                    product.UnitInStock = reader.GetInt32(3);
                    product.Garantie = reader.GetString(4);
                    product.Discontinued = reader.GetBoolean(5);
                    product.CategoryID = reader.GetInt32(6);
                    product.Autor = reader.GetString(7);

                }
                return product;

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
