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
                command.Parameters.AddWithValue("@ProductName", product.ProductName);
                command.Parameters.AddWithValue("@UnitPrice", product.UnitPrice);
                command.Parameters.AddWithValue("@UnitInStock", product.UnitInStock);
                command.Parameters.AddWithValue("@Garantie", product.Garantie);
                command.Parameters.AddWithValue("@CategoryID", product.CategoryID);
                if(product.Autor == "" || product.Autor == null)
                {
                    command.Parameters.AddWithValue("@Autor", "Administrador");
                }
                else
                {
                    command.Parameters.AddWithValue("@Autor", product.Autor);
                }
                command.Parameters.AddWithValue("@FechaCreacion", combined);

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
                command.Parameters.AddWithValue("@ID", product.ID);
                command.Parameters.AddWithValue("@ProductName", product.ProductName);
                command.Parameters.AddWithValue("@UnitPrice", product.UnitPrice);
                command.Parameters.AddWithValue("@UnitInStock", product.UnitInStock);
                command.Parameters.AddWithValue("@Garantie", product.Garantie);
                command.Parameters.AddWithValue("@Discontinued", product.Discontinued);
                command.Parameters.AddWithValue("@CategoryID", product.CategoryID);
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

        public void DeleteProduct(int Id)
        {
            try
            {
                var command = _DBConnection.CreateCommand();
                command.CommandText = "DeleteProducts";
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
                command.Parameters.AddWithValue("@ProductName", search);
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
                command.Parameters.AddWithValue("@CategoryID", CategoryId);
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
                command.Parameters.AddWithValue("@ID", Id);
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
