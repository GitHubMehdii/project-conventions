﻿using System.Collections.Generic;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using project_conventions.Models;
using projectconventions.Models;

namespace project_conventions.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("cors_policy")]
    public class UserController : ControllerBase
    {

        UserContext UserContext = new UserContext();


        /*
         * ------------------------------------------------------------------
         * add user
         * ------------------------------------------------------------------
         * GET api/user/add
         */
        [HttpPost]
        [Route("add")]
        public ActionResult<User> Add([FromBody] User user)
        {
            user.IsAdmin = "no";
            return UserContext.Save(user);
        }









        /*
         * ------------------------------------------------------------------
         * get all users
         * ------------------------------------------------------------------
         * GET api/user/get/all
         */
        [HttpGet]
        [Route("get/all")]
        public ActionResult<List<User>> GetAll()
        {
            return UserContext.GetAll();
        }

        /*
         * ------------------------------------------------------------------
         * get user by apogee
         * ------------------------------------------------------------------
         * GET api/user/get/5
         */
        [HttpGet]
        [Route("get/{apogee}")]
        public ActionResult<User> GetOneByApogee(int apogee)
        {
            return UserContext.GetOneByApogee(apogee);
        }









        /*
         * ------------------------------------------------------------------
         * update user
         * ------------------------------------------------------------------
         * GET api/user/update
         */
        [HttpPost]
        [Route("update")]
        public ActionResult<User> Update([FromBody] User user)
        {
            return UserContext.Update(user);
        }









        /*
         * ------------------------------------------------------------------
         * delete user
         * ------------------------------------------------------------------
         * GET api/user/delete/5
         */
        [HttpGet]
        [Route("delete/{apogee}")]
        public void Delete(int apogee)
        {
            UserContext.DeleteOneByApogee(apogee);
        }








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
            // in case admin
            if (user.IsAdmin.Equals("yes"))
            {
                return UserContext.GetOneByEmailAndBirthDate(user.Email, user.BirthDate);
            }
            
            return UserContext.GetOneByApogeeAndBirthDate(user.Apogee, user.BirthDate);

        }

        /*
         * ------------------------------------------------------------------
         * Logout
         * ------------------------------------------------------------------
         * GET api/user/logout
         */
        [HttpGet]
        [Route("logout")]
        public ActionResult<User> Logout([FromBody] User user)
        {
            return UserContext.GetOneByApogeeAndBirthDate(user.Apogee, user.BirthDate);
        }
    }
}