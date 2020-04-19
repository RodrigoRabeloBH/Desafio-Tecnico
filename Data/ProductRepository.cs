using Business.Interface;
using Domain;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace Data
{
    public class ProductRepository : IProduct
    {
        private static readonly string _connectionString = @"Server=localhost\SQLEXPRESS;Database=STORE;Trusted_Connection=True";
        public void Create(Product product)
        {
            try
            {
                using (var conn = new SqlConnection(_connectionString))
                {
                    if (conn.State == ConnectionState.Closed) conn.Open();

                    string query = $@"INSERT INTO PRODUCT(Name,Description,CreatedAt,Price,Quantity)VALUES(@Name,@Description,@CreatedAt,@Price,@Quantity)";

                    using (var cmd = new SqlCommand(query, conn))
                    {
                        cmd.CommandType = CommandType.Text;

                        cmd.Parameters.Add("Name", SqlDbType.VarChar).Value = product.Name.ToUpper();
                        cmd.Parameters.Add("Description", SqlDbType.VarChar).Value = product.Description;
                        cmd.Parameters.Add("CreatedAt", SqlDbType.DateTime).Value = product.CreatedAt;
                        cmd.Parameters.Add("Price", SqlDbType.Float).Value = product.Price;
                        cmd.Parameters.Add("Quantity", SqlDbType.Float).Value = product.Quantity;

                        cmd.ExecuteReader();
                    }
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Delete(int id)
        {
            try
            {
                using (var conn = new SqlConnection(_connectionString))
                {
                    if (conn.State == ConnectionState.Closed) conn.Open();

                    string query = $@"DELETE FROM PRODUCT WHERE Id = @id";

                    using (var cmd = new SqlCommand(query, conn))
                    {
                        cmd.CommandType = CommandType.Text;

                        cmd.Parameters.Add("Id", SqlDbType.Int).Value = id;

                        cmd.ExecuteReader();
                    }
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<Product> GetAll()
        {
            var products = new List<Product>();

            try
            {
                using (var conn = new SqlConnection(_connectionString))
                {
                    if (conn.State == ConnectionState.Closed) conn.Open();

                    string query = $@"SELECT * FROM PRODUCT";
                    var cmd = new SqlCommand(query, conn);
                    cmd.CommandType = CommandType.Text;
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            var product = new Product
                            {
                                Id = int.Parse(reader["Id"].ToString()),
                                CreatedAt = Convert.ToDateTime(Convert.IsDBNull(reader["CreatedAt"]) ? "" : reader["CreatedAt"].ToString()),
                                Name = reader["Name"].ToString(),
                                Quantity = double.Parse(reader["Quantity"].ToString()),
                                Description = reader["Description"].ToString(),
                                Price = double.Parse(reader["Price"].ToString())
                            };
                            products.Add(product);
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return products;
        }

        public Product GetById(int id)
        {

            var product = GetAll().FirstOrDefault(p => p.Id == id);

            return product;
        }

        public List<Product> GetByName(string name)
        {
            var products = GetAll()
                .Where(p => p.Name.Contains(name.ToUpper()))
                .ToList();

            return products;
        }

        public void Update(int id, Product product)
        {
            try
            {
                using (var conn = new SqlConnection(_connectionString))
                {
                    if (conn.State == ConnectionState.Closed) conn.Open();

                    string query = $@"UPDATE PRODUCT SET  Name = @Name, Description = @Description, Price = @Price, Quantity = @Quantity WHERE Id = @id";

                    using (var cmd = new SqlCommand(query, conn))
                    {
                        cmd.CommandType = CommandType.Text;

                        cmd.Parameters.Add("Name", SqlDbType.VarChar).Value = product.Name.ToUpper();
                        cmd.Parameters.Add("Description", SqlDbType.VarChar).Value = product.Description;
                        cmd.Parameters.Add("CreatedAt", SqlDbType.DateTime).Value = product.CreatedAt;
                        cmd.Parameters.Add("Price", SqlDbType.Float).Value = product.Price;
                        cmd.Parameters.Add("Quantity", SqlDbType.Float).Value = product.Quantity;
                        cmd.Parameters.Add("Id", SqlDbType.Int).Value = id;

                        cmd.ExecuteReader();
                    }
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
