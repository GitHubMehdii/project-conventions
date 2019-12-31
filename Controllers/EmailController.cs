using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using project_conventions.Models;
using projectconventions.Models;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using iTextSharp;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.IO;

namespace project_conventions.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailController : ControllerBase
    {

        static UserContext UserContext = new UserContext();
        static ConventionContext ConventionContext = new ConventionContext();

        /*
         * ------------------------------------------------------------------
         * Email
         * ------------------------------------------------------------------
         */

        public static bool Refuse(int idConvention)
        {
            Convention convention = ConventionContext.GetOneById(idConvention);
            Console.WriteLine("convention.Apogee" + convention.Apogee);
            User user = UserContext.GetOneByApogee(convention.Apogee);
            if (user != null)
            {
                //this.GetPdf(idConvention);
                //string filePath = @".\assets/pdf/Convention-" + user.LastName + user.FirstName.ToUpper() + ".pdf";
               // Attachment data = new Attachment(filePath, MediaTypeNames.Application.Octet);
                MailAddress to = new MailAddress(user.Email);
                MailAddress from = new MailAddress("projectconvention84@gmail.com");
                MailMessage message = new MailMessage(from, to);
                message.Subject = "Convention de stage concernant " + convention.CompanyName;
                message.Body = "Bonjour " + user.FirstName + " " + user.LastName.ToUpper() + ",\n\rVotre convention a été rejeter. \n\rVeuillez contacter le service apogée pour plus de détails\n\r" +
                    "Cordialement Service apogée.";
                //message.Attachments.Add(data);
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
        // GET api/email/5
        public static bool Accept(int idConvention)
        {
            Convention convention = ConventionContext.GetOneById(idConvention);
            User user = UserContext.GetOneByApogee(convention.Apogee);
            if(user!= null)
            {
                GetPdf(idConvention);
                string filePath = @"assets/pdf/Convention-" + user.LastName + user.FirstName.ToUpper() + ".pdf";
                Attachment data = new Attachment(filePath, MediaTypeNames.Application.Octet);
                MailAddress to = new MailAddress(user.Email);
                MailAddress from = new MailAddress("projectconvention84@gmail.com");
                MailMessage message = new MailMessage(from, to);
                message.Subject = "Convention de stage concernant "+ convention.CompanyName;
                message.Body = "Bonjour "+user.FirstName+" "+user.LastName.ToUpper()+",\n\rVous trouverez ci-joint votre convention de stage approuvée. \n\r" +
                    "Cordialement Service apogée.";
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

        public static bool GetPdf(int idConvention)
        {
            Convention convention = ConventionContext.GetOneById(idConvention);
            User user = UserContext.GetOneByApogee(convention.Apogee);
            if (user != null)
            {
                FileStream fs = new FileStream(
                    @".\assets\pdf" + "\\" + "Convention-" + user.LastName + user.FirstName.ToUpper() + ".pdf",
                    FileMode.Create);
                // Create an instance of the document class which represents the PDF document itself.  
                Document document = new Document(PageSize.A4, 25, 25, 30, 30);
                // Create an instance to the PDF file by creating an instance of the PDF   
                // Writer class using the document and the filestrem in the constructor.  

                PdfWriter writer = PdfWriter.GetInstance(document, fs);
                // Open the document to enable you to write to the document  
                document.Open();
                PdfContentByte cb = writer.DirectContent;
                iTextSharp.text.Image img = iTextSharp.text.Image.GetInstance(@"assets/img/ensa.png");
                iTextSharp.text.Image img2 = iTextSharp.text.Image.GetInstance(@"assets/img/Signature Benkadour.png");
                img.SetAbsolutePosition(60, 727);
                img.ScalePercent(50);
                cb.AddImage(img);
                img2.SetAbsolutePosition(340, 120);
                img2.ScalePercent(50);
                cb.AddImage(img2);
                cb.SetLineWidth(0f);
                cb.MoveTo(30, 725);
                cb.LineTo(540, 725);
                cb.Stroke();
                cb.SetLineWidth(0f);
                cb.MoveTo(30, 45);
                cb.LineTo(540, 45);
                cb.Stroke();

                cb.BeginText();
                BaseFont f_cn = BaseFont.CreateFont(@"assets/fonts/Lato-Black.ttf", BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
                BaseFont f_bo = BaseFont.CreateFont(@"assets/fonts/Lato-Bold.ttf", BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
                BaseFont f_li = BaseFont.CreateFont(@"assets/fonts/Lato-Heavy.ttf", BaseFont.CP1252, BaseFont.NOT_EMBEDDED);

                cb.SetFontAndSize(f_bo, 20);
                cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, "CONVENTION CADRE", 300, 656, 0);
                cb.SetFontAndSize(f_bo, 16);
                cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, "Entreprise/Ecole Nationale des Sciences Appliquées de Tétouan", 300, 630, 0);

                cb.SetFontAndSize(f_cn, 7);
                cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, "Ecole Nationale des Sciences Appliquées de Tétouan BP : 2222 M'hannech II - Tétouan", 300, 35, 0);
                cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, "Tél 0539 68 80 27; Fax 0539 99 46 24 www.ensate.uae.ma", 300, 25, 0);
                cb.SetFontAndSize(f_bo, 12);

                cb.SetTextMatrix(30, 530);
                cb.ShowText("Convention pour : " + user.LastName + "  " + user.FirstName.ToUpper());

                cb.SetTextMatrix(30, 510);
                cb.ShowText("Entre :  " + convention.CompanyName);

                cb.SetTextMatrix(30, 490);
                cb.ShowText("Et l'Ecole Nationale des Sciences Appliquées de Tétouan");

                cb.SetTextMatrix(30, 470);
                cb.ShowText("Représentée par : M.Mostafa STITOU Directeur de l'école");

                cb.SetTextMatrix(30, 450);
                cb.ShowText("Du : " + convention.StartDate);

                cb.SetTextMatrix(200, 450);
                cb.ShowText("Au : " + convention.EndDate);

                cb.SetFontAndSize(f_li, 12);
                cb.SetTextMatrix(30, 400);
                cb.ShowText("Article :");

                cb.SetFontAndSize(f_bo, 12);
                cb.SetTextMatrix(30, 380);
                cb.ShowText("La présente convention régit les rapports des deux partiesm dans le cadre de l'organisation");
                cb.SetTextMatrix(30, 350);
                cb.ShowText("de stages d'entreprises qui s'inscrivent dans le programme de formation de l'établissement de");
                cb.SetTextMatrix(30, 320);
                cb.ShowText("formation cité ci-dessus");


                cb.SetTextMatrix(400, 300);
                cb.ShowText("Fait le : " + DateTime.Now.ToString("dd/MM/yyyy"));

                cb.SetTextMatrix(400, 230);
                cb.ShowText("Signature Directeur de l'ecole :");

                cb.SetTextMatrix(250, 130);
                cb.ShowText("Signature Stagiaire :");

                cb.SetTextMatrix(30, 230);
                cb.ShowText("Signature Directeur d'entreprise :");






                cb.EndText();
                // Close the document  
                document.Close();
                // Close the writer instance  
                writer.Close();
                // Always close open filehandles explicity  
                fs.Close();
                return true;
            }
            else
            {
                return false;
            }
        }



    }
}
