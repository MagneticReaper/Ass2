using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;

namespace Models
{
    public class Applications
    {
        public Response GetAllProducts(SQLiteConnection con)
        {
            Response response = new();
            SQLiteCommand sqlite_cmd = con.CreateCommand();
            sqlite_cmd.CommandText = "SELECT * FROM Product";
            SQLiteDataReader dataReader = sqlite_cmd.ExecuteReader();
            List<Product> list = new();
            while (dataReader.Read())

            {
                Product product = new()
                {
                    Id = dataReader.GetInt32(0),
                    Name = dataReader.GetString(1),
                    Amount = dataReader.GetInt32(2),
                    Price = dataReader.GetDouble(3)
                };

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
            Response response = new();
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
            Response response = new();
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
            Response response = new();
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

        public Response ReplaceProducts(SQLiteConnection con, List<Product> products)
        {
            Response response = new();
            SQLiteCommand cmd = con.CreateCommand();
            cmd.CommandText = "DELETE FROM Product;";//drop table and recreate if for increased performance
            int i = cmd.ExecuteNonQuery();
            if (i > 0)
            {
                response.StatusCode = 200;
                response.StatusMessage = "Products deleted";
            }
            else
            {
                response.StatusCode = 100;
                response.StatusMessage = "Products not deleted";
            }
            SQLiteCommand cmd2 = con.CreateCommand();
            string command = "insert into Product(id, name, amount, price) values";
            foreach (Product product in products)
            {
                command += "(" + product.Id + ", '" + product.Name + "', '" + product.Amount + "', " + product.Price + ") ,";
            }
            command = command.Remove(command.Length - 2);
            command += ";";
            cmd2.CommandText = command;
            int j = cmd2.ExecuteNonQuery();
            if(j > 0) { response.StatusMessage += ", products inserted"; } else { response.StatusCode = 100; response.StatusMessage += ", products not inserted"; }
            return response;
        }
    }
}
