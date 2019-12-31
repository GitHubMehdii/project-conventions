using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using project_conventions.Models;
using projectconventions.Models;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System;

namespace project_conventions.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailController : ControllerBase
    {

        UserContext UserContext = new UserContext();

        /*
         * ------------------------------------------------------------------
         * Email
         * ------------------------------------------------------------------
         */
          
        // GET api/email/5
        [HttpGet("{apogee}")]
        public bool Get(int apogee)
        {
            User user = UserContext.GetOneByApogee(apogee);
            if(user!= null)
            {
                string filePath = @".\pdf\Convention-" + user.LastName + user.FirstName.ToUpper() + ".pdf";
                Attachment data = new Attachment(filePath, MediaTypeNames.Application.Octet);
                MailAddress to = new MailAddress(user.Email);
                MailAddress from = new MailAddress("projectconvention84@gmail.com");
                MailMessage message = new MailMessage(from, to);
                message.Subject = "AKhir pdf";
                message.Body = "hadi ";
                message.Attachments.Add(data);
                SmtpClient client = new SmtpClient("smtp.gmail.com", 587)
                {
                    Credentials = new NetworkCredential("projectconvention84@gmail.com", "maticha123"),
                    EnableSsl = true
                };
                try
                {
                    client.Send(message);
                }
                catch (SmtpException ex)
                {
                    Console.WriteLine(ex.ToString());
                }
                return true;
            }
            else
            {
                return false;
            }
        }



    }
}
