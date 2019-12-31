using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using project_conventions.Models;
using projectconventions.Models;

namespace project_conventions.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("cors_policy")]
    public class ConventionController : ControllerBase
    {

        ConventionContext ConventionContext = new ConventionContext();



        /*
         * ------------------------------------------------------------------
         * add convention
         * ------------------------------------------------------------------
         * GET api/convention/add
         */
        [HttpPost]
        [Route("add")]
        public ActionResult<Convention> Add([FromBody] Convention convention)
        {
            convention.Status = "pending";
            return ConventionContext.Save(convention);
        }








        /*
         * ------------------------------------------------------------------
         * get all conventions
         * ------------------------------------------------------------------
         * GET api/convention/get/all
         */
        [HttpGet]
        [Route("get/all")]
        public ActionResult<List<Convention>> GetAll()
        {
            return ConventionContext.GetAll();
        }

        /*
         * ------------------------------------------------------------------
         * get all conventions of one user
         * ------------------------------------------------------------------
         * GET api/convention/get/all/5
         */
        [HttpGet]
        [Route("get/all/{apogee}")]
        public ActionResult<List<Convention>> GetAllOfUser(int apogee)
        {
            return ConventionContext.GetAllOfUser(apogee);
        }

        /*
         * ------------------------------------------------------------------
         * get convention by id
         * ------------------------------------------------------------------
         * GET api/convention/get/5
         */
        [HttpGet]
        [Route("get/{id}")]
        public ActionResult<Convention> GetOneById(int id)
        {
            return ConventionContext.GetOneById(id);
        }









        /*
         * ------------------------------------------------------------------
         * update convention
         * ------------------------------------------------------------------
         * GET api/convention/update
         */
        [HttpPost]
        [Route("update")]
        public ActionResult<Convention> Update([FromBody] Convention convention)
        {
            return ConventionContext.Update(convention);
        }









        /*
         * ------------------------------------------------------------------
         * delete convention
         * ------------------------------------------------------------------
         * GET api/convention/delete/5
         */
        [HttpGet]
        [Route("delete/{id}")]
        public void Delete(int id)
        {
            ConventionContext.DeleteOneById(id);
        }









        /*
         * ------------------------------------------------------------------
         * accept convention
         * ------------------------------------------------------------------
         * GET api/convention/accept/5
         */
        [HttpGet]
        [Route("accept/{id}")]
        public void Accept(int id)
        {
            Convention convention = ConventionContext.GetOneById(id);

            Console.WriteLine(convention.ToString());

            convention.Status = "accept";

            ConventionContext.Update(convention);
        }










        /*
         * ------------------------------------------------------------------
         * refuse convention
         * ------------------------------------------------------------------
         * GET api/convention/accept/5
         */
        [HttpGet]
        [Route("refuse/{id}")]
        public void Refuse(int id)
        {
            Convention convention = ConventionContext.GetOneById(id);

            convention.Status = "refused";

            ConventionContext.Update(convention);
        }

    }
}