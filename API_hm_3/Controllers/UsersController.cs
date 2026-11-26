using Microsoft.AspNetCore.Mvc;
using Service;
using System.Reflection.PortableExecutable;
using System.Text.Json;
using Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API_hm_3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService userService;

        public UsersController(IUserService userService)
        {
            this.userService = userService;
        }

        // GET: api/<LoginController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<LoginController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> Get(int id)
        {
            User user = await userService.GetUserById(id);
            if (user != null)
                return Ok();
            return NotFound();
        }

        // POST api/<LoginController>
        [HttpPost]
        public IActionResult Post([FromBody] User User)
        {
            return CreatedAtAction(nameof(Get), userService.AddUser(User));
        }

        // POST api/<LoginController>
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginUser loginUser)
        {
            User user = await userService.Login(loginUser);
            if(user != null)
                return CreatedAtAction(nameof(Get), user);
            return NotFound("שם משתמש או סיסמא אינם נכונים");
        }

        // PUT api/<LoginController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<User>> Put(int id, [FromBody] User userToUpdate)
        {
            await userService.UpdateUser(id, userToUpdate);
            return Ok();
        }

        // DELETE api/<LoginController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
