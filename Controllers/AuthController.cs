using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using projectconventions.Models;

namespace projectconventions.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        // GET api/auth
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "auth1", "auth1" };
        }

        // GET api/auth/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value " + id;
        }

        /*
         * ------------------------------------------------------------------
         * Login
         * ------------------------------------------------------------------
         */

        // POST api/auth
        [HttpPost]
        public ActionResult<User> Post([FromBody] User user)
        {

            return new User(0, user.Username, user.Password);
        }

        // PUT api/auth/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/auth/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

    }
}
