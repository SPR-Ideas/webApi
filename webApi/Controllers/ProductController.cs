using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using webApi.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace webApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        // GET: api/<ProductController>
        private readonly IConfiguration _configuration;
        public ProductController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public List<ProductModel> list = new List<ProductModel>();


        [HttpGet]
        public IActionResult GetProducts()
        {
            try {

                using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("localdb")))
                {
                    SqlCommand cmd = new SqlCommand("select * from Products", connection);
                    connection.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read()) { 
                        ProductModel model = new ProductModel();
                        model.product_code = reader.GetString(0);
                        model.product_name = reader.GetString(1);
                        model.price = reader.GetDouble(2);
                        model.product_remaining = reader.GetInt32(3);
                        model.quantity_sold  = reader.GetInt32(4);
                        list.Add(model);
                    }
                    connection.Close();
                    return Ok(list);
                }  
                }
            catch(SqlException e) { Console.WriteLine(e.Message);
                
                return NotFound();
            }

        }

        // GET api/<ProductController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ProductController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ProductController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ProductController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
