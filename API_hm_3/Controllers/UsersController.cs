using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi;
using Service;
//This using isn't used in this file: you can remove it
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
        public ActionResult<User> Get(int id)
        {
            User user = userService.GetUserById(id);
            if (user != null)
                //Question: reading a user should answer 200 Ok(user), not 201 Created: which method fits GET?
                return CreatedAtAction(nameof(Get), user);
            return NotFound();
        }

        // POST api/<LoginController>
        [HttpPost]
        //In C#, parameters are camelCase: user (User is the class name)
        public IActionResult Post([FromBody] User User)
        {
            //Where should the password strength check be called? A score below 3 should return BadRequest, and the password service should be used here
            return CreatedAtAction(nameof(Get), userService.AddUser(User));
        }

        // POST api/<LoginController>
        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginUser loginUser)
        {
            User user = userService.Login(loginUser);
            if(user != null)
                return CreatedAtAction(nameof(Get), user);
            //The assignment asks a wrong login to return 204 NoContent: which result fits here?
            return NotFound("שם משתמש או סיסמא אינם נכונים");
        }

        // PUT api/<LoginController>/5
        [HttpPut("{id}")]
        public ActionResult<User> Put(int id, [FromBody] User userToUpdate)
        {
            //The assignment asks PUT to return Ok(): this returns 201 Created, so which method fits?
            //Where should the password strength check be called here? A weak password should return BadRequest
            return CreatedAtAction(nameof(Get), userService.UpdateUser(id, userToUpdate));
        }

        // DELETE api/<LoginController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
