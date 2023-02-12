using Microsoft.AspNetCore.Mvc;
using Models;
using System.Data.SQLite;

namespace Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public ProductController(IConfiguration _configuration)
        {
            this._configuration = _configuration;
        }

        [HttpGet]
        [Route("GetAllProducts")]
        public Response GetAllProducts()
        {
            SQLiteConnection con = new(_configuration.GetConnectionString("productCon"));
            con.Open();
            Applications apl = new();
            Response response = apl.GetAllProducts(con);
            con.Close();
            return response;
        }

        [HttpPost]
        [Route("AddProduct")]
        public Response AddProduct(Product product)
        {
            SQLiteConnection con = new(_configuration.GetConnectionString("productCon"));
            con.Open();
            Applications apl = new();
            Response response = apl.AddProduct(con, product);
            con.Close();
            return response;
        }
        [HttpPost]
        [Route("UpdateProduct")]
        public Response UpdateProduct(Product product)
        {
            SQLiteConnection con = new(_configuration.GetConnectionString("productCon"));
            con.Open();
            Applications apl = new();
            Response response = apl.UpdateProduct(con, product);
            con.Close();
            return response;
        }
        [HttpDelete]
        [Route("DeleteProduct")]
        public Response DeleteProduct(Product product)
        {
            SQLiteConnection con = new(_configuration.GetConnectionString("productCon"));
            con.Open();
            Applications apl = new();
            Response response = apl.DeleteProduct(con, product);
            con.Close();
            return response;
        }

        [HttpPost]
        [Route("ReplaceProducts")]
        public Response ReplaceProducts(List<Product> products)
        {
            SQLiteConnection con = new(_configuration.GetConnectionString("productCon"));
            con.Open();
            Applications apl = new();
            Response response = apl.ReplaceProducts(con, products);
            con.Close();
            return response;
        }
    }
}