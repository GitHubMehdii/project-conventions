using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using project_conventions.Models;
using projectconventions.Models;

namespace project_conventions.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {

        UserContext UserContext = new UserContext();

        /*
         * ------------------------------------------------------------------
         * Login
         * ------------------------------------------------------------------
         */

        // POST api/auth
        [HttpPost]
        public ActionResult<User> Post([FromBody] int apogee, string birthDate) 
        {
            return UserContext.GetOneByApogeeAndBirthDate(apogee, birthDate);
        }








        // GET api/auth
        [HttpGet]
        public ActionResult<User> Get()
        {
            return new User();
        }

        // GET api/auth/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value " + id;
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
