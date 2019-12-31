using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using project_conventions.Models;
using projectconventions.Models;

namespace project_conventions.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        UserContext UserContext = new UserContext();

        /*
         * ------------------------------------------------------------------
         * Login
         * ------------------------------------------------------------------
         * POST api/user/login
         */
        [HttpPost]
        [Route("login")]
        public ActionResult<User> Login([FromBody] User user) 
        {
            return UserContext.GetOneByApogeeAndBirthDate(user.Apogee, user.BirthDate);
        }


        /*
         * ------------------------------------------------------------------
         * Logout
         * ------------------------------------------------------------------
         * GET api/user/auth/5
         */
        //[HttpGet("{apogee}")]
        //public void Get(int apogee)
        //{

        //}
    }
}
