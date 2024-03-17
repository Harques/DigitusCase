using DigitusCase.Dtos;
using DigitusCase.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Npgsql;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DigitusCase.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        // GET: api/<UserController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            NpgsqlConnection conn = new NpgsqlConnection("UserID=postgres;Password=pass;Server=localhost;Port=5432;Database=postgres; Integrated Security=true;Pooling=true;");
            conn.Open();
            if (conn.State == System.Data.ConnectionState.Open)
                Console.WriteLine("Success open postgreSQL connection.");
            conn.Close();
            return new string[] { "value1", "value2" };
        }

        // GET api/<user>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<user>
        [HttpPost]
        public IActionResult Create([FromBody] UserDto request)
        {
            return Ok(_userService.Create(request));
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
