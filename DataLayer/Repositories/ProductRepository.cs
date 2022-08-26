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
    public class ProductRepository
    {
        private DBConnection _DBConnection;
        public ProductRepository(DBConnection dBConnection)
        {
            _DBConnection = dBConnection;
        }
        public void CreateProduct(Product product)
        {
            try
            {
                var command = _DBConnection.CreateCommand();
                command.CommandText = "InsertProduct";
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@ProductName", product.ProductName);
                command.Parameters.AddWithValue("@UnitPrice", product.UnitPrice);
                command.Parameters.AddWithValue("@UnitInStock", product.UnitInStock);
                command.Parameters.AddWithValue("@Garantie", product.Garantie);
                command.Parameters.AddWithValue("@Discontinued", product.Discontinued);
                
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
                var command = _DBConnection.CreateCommand();
                command.CommandText = "SetProducts";
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@ID", product.ID);
                command.Parameters.AddWithValue("@ProductName", product.ProductName);
                command.Parameters.AddWithValue("@UnitPrice", product.UnitPrice);
                command.Parameters.AddWithValue("@UnitInStock", product.UnitInStock);
                command.Parameters.AddWithValue("@Garantie", product.Garantie);
                command.Parameters.AddWithValue("@Discontinued", product.Discontinued);

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
                command.CommandText = "GetAllCategory";
                command.CommandType = CommandType.StoredProcedure;
                _DBConnection.OpenConnection();

                SqlDataReader reader = command.ExecuteReader();
                List<Product> products = new();
                while (reader.Read())
                {
                    Product product = new();
                    product.ID = reader.GetInt32(0);
                    product.ProductName = reader.GetString(1);
                    product.UnitPrice = reader.GetInt32(2);
                    product.UnitInStock = reader.GetInt32(3);
                    product.Garantie = reader.GetString(4);
                    product.Discontinued = reader.GetBoolean(5);


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
                Product product = new();
                while (reader.Read())
                {
                    product.ID = reader.GetInt32(0);
                    product.ProductName = reader.GetString(1);
                    product.UnitPrice = reader.GetInt32(2);
                    product.UnitInStock = reader.GetInt32(3);
                    product.Garantie = reader.GetString(4);
                    product.Discontinued = reader.GetBoolean(5);
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
                List<Product> products = new();
                while (reader.Read())
                {
                    Product product = new();
                    product.ID = reader.GetInt32(0);
                    product.ProductName = reader.GetString(1);
                    product.UnitPrice = reader.GetInt32(2);
                    product.UnitInStock = reader.GetInt32(3);
                    product.Garantie = reader.GetString(4);
                    product.Discontinued = reader.GetBoolean(5);


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
    }
}
