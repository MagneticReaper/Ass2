using ass2.Models;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;

namespace WebApplication1.Models
{
    public class Applications
    {
        public Response GetAllProducts(SQLiteConnection con)
        {
            Response response = new Response();
            SQLiteCommand sqlite_cmd = con.CreateCommand();
            sqlite_cmd.CommandText = "SELECT * FROM Product";
            SQLiteDataReader dataReader = sqlite_cmd.ExecuteReader();
            List<Product> list = new List<Product>();
            while (dataReader.Read())

            {
                Product product = new Product();
                product.Id = dataReader.GetInt32(0);
                product.Name = dataReader.GetString(1);
                product.Amount = dataReader.GetInt32(2);
                product.Price = dataReader.GetDouble(3);

                list.Add(product);

            }
            if (list.Count > 0)
            {
                response.StatusCode = 200;
                response.StatusMessage = "Products Retrived Perfectly";
                response.Products = list;
            }
            else
            {
                response.StatusCode = 100;
                response.StatusMessage = "No Product Found";
                response.Products = null;
            }
            return response;
        }
        public Response AddProduct(SQLiteConnection con, Product product)
        {
            Response response = new Response();
            SQLiteCommand cmd = con.CreateCommand();
            cmd.CommandText = "insert into Product(id, name, amount, price) values(" + product.Id + ", '" + product.Name + "', '" + product.Amount + "', " + product.Price + ")";
            int i;
            try { i = cmd.ExecuteNonQuery(); } catch { i = 0; }
            
            if (i > 0)
            {
                response.StatusCode = 200;
                response.StatusMessage = "Product Inserted";
            }
            else
            {
                response.StatusCode = 100;
                response.StatusMessage = "Product Not Inserted";
            }

            return response;
        }

        public Response UpdateProduct(SQLiteConnection con, Product product)
        {
            Response response = new Response();
            SQLiteCommand cmd = con.CreateCommand();
            cmd.CommandText = "UPDATE Product SET name = '" + product.Name + "', amount = " + product.Amount + ", price = " + product.Price + " WHERE id = " + product.Id + ";";
            int i = cmd.ExecuteNonQuery();
            if (i > 0)
            {
                response.StatusCode = 200;
                response.StatusMessage = "Product Updated";
            }
            else
            {
                response.StatusCode = 100;
                response.StatusMessage = "Product Not Updated";
            }

            return response;
        }

        public Response DeleteProduct(SQLiteConnection con, Product product)
        {
            Response response = new Response();
            SQLiteCommand cmd = con.CreateCommand();
            cmd.CommandText = "DELETE FROM Product WHERE id = " + product.Id + ";";
            int i = cmd.ExecuteNonQuery();
            if (i > 0)
            {
                response.StatusCode = 200;
                response.StatusMessage = "Product Deleted";
            }
            else
            {
                response.StatusCode = 100;
                response.StatusMessage = "Product Not Deleted";
            }

            return response;
        }
    }
}
