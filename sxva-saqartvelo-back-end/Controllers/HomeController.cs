using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using sxva_saqartvelo_back_end.Models;
using PagedList.Mvc;
using PagedList;
using System.Web.Helpers;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Net.Mail;
using System.Net;

namespace sxva_saqartvelo_back_end.Controllers
{
    public class HomeController : Controller
    {
        OtherGeorgiaEntities _db = new OtherGeorgiaEntities();


        public ActionResult Index(int ? page)
        {
            //Mvc PagedList
            int pageSize = 8;
            int pageNumber = (page ?? 1);

            var freelancers = _db.Freelancers.OrderBy(x => Guid.NewGuid()).ToPagedList(pageNumber, pageSize);
            return View(freelancers);
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Contact(SendMailModel SendEmail)
        {
            //try
            //{
            //    System.Net.Mail.MailMessage email = new System.Net.Mail.MailMessage();
            //    email.From = new System.Net.Mail.MailAddress(SendEmail.Email);
            //    email.To.Add("giorgi.khutsishvili04@geolab.edu.ge");
            //    email.Subject = SendEmail.Subject;
            //    email.Body = SendEmail.Body;


            //    System.Net.Mail.SmtpClient SmtpServer = new System.Net.Mail.SmtpClient("smtp.gmail.com");
            //    //WebMail.SmtpServer = "smtp.gmail.com";
            //    WebMail.SmtpPort = 587;
            //    WebMail.SmtpUseDefaultCredentials = true;
            //    WebMail.EnableSsl = true;
            //    WebMail.UserName = "giorgi.khutsishvili04@geolab.edu.ge";
            //    WebMail.Password = "Geo12341234";
            //    SmtpServer.Send(email);
            //    ViewBag.SendSucceeded = "თქვენი შეტყობინება გაიგზავნა წარმატებით";

            //}
            //catch (DbEntityValidationException dbEx)
            //{
            //    foreach (var validationErrors in dbEx.EntityValidationErrors)
            //    {
            //        foreach (var validationError in validationErrors.ValidationErrors)
            //        {
            //            Trace.TraceInformation("Property: {0} Error: {1}",
            //                                    validationError.PropertyName,
            //                                    validationError.ErrorMessage);
            //        }
            //    }
            //}
            //catch (Exception)
            //{
            //    ViewBag.SendFailed = "შეტყობინების გაგზავნის დროს მოხდა შეცდომა";
            //}

            //var fromAddress = new MailAddress(SendEmail.Email, "From Name");
            //var toAddress = new MailAddress("giorgi.khutsishvili04@geolab.edu.ge", "To Name");
            //const string fromPassword = "Geo12341234";
            //string subject = SendEmail.Subject;
            //string body = SendEmail.Body;

            //var smtp = new SmtpClient
            //{
            //    Host = "smtp.gmail.com",
            //    Port = 587,
            //    EnableSsl = true,
            //    DeliveryMethod = SmtpDeliveryMethod.Network,
            //    UseDefaultCredentials = false,
            //    Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
            //};
            //using (var message = new MailMessage(fromAddress, toAddress)
            //{
            //    Subject = subject,
            //    Body = body
            //})
            //{
            //    smtp.Send(message);
            //}

            try
            {
                ////gmail smtp server  
                //WebMail.SmtpServer = "smtp.gmail.com";

                ////gmail port to send emails  
                //WebMail.SmtpPort = 587;
                //WebMail.SmtpUseDefaultCredentials = true;
                ////sending emails with secure protocol  
                //WebMail.EnableSsl = true;
                ////EmailId used to send emails from application  
                //WebMail.UserName = "giorgi.khutsishvili04@geolab.edu.ge";
                //WebMail.Password = "Geo12341234";

                ////Sender email address.  
                //WebMail.From = SendEmail.Email;


                ////Send email  
                //WebMail.Send(to: "giorgi.khutsishvili04@geolab.edu.ge", subject: SendEmail.Subject, body: SendEmail.Body, isBodyHtml: true);

                //MailMessage email = new MailMessage();
                //email.From = new MailAddress(SendEmail.Email);


                SmtpClient client = new SmtpClient("smtp.gmail.com");
                client.Port = 587;
                client.Credentials = new NetworkCredential("testtestmail109@gmail.com", "Tt123123");
                client.EnableSsl = true;
                




                MailMessage mailMessage = new MailMessage();
                mailMessage.From = new MailAddress(SendEmail.Email);
                mailMessage.To.Add("giorgi.khutsishvili04@geolab.edu.ge");
                mailMessage.Subject = SendEmail.Subject;
                mailMessage.IsBodyHtml = true;
                mailMessage.Body = "გამომგზავნის ელ.ფოსტა " + " " +  SendEmail.Email + ", " +"<br>"+ SendEmail.Body;
                client.Send(mailMessage);

                ViewBag.SendSucceeded = "თქვენი შეტყობინება გაიგზავნა წარმატებით";
            }
            //catch (DbEntityValidationException dbEx)
            //{
            //    foreach (var validationErrors in dbEx.EntityValidationErrors)
            //    {
            //        foreach (var validationError in validationErrors.ValidationErrors)
            //        {
            //            Trace.TraceInformation("Property: {0} Error: {1}",
            //                                    validationError.PropertyName,
            //                                    validationError.ErrorMessage);
            //        }
            //    }
            //}
            catch (Exception)
            {
                ViewBag.SendFailed = "შეტყობინების გაგზავნის დროს მოხდა შეცდომა";
            }

            return View();
        }
    }
}