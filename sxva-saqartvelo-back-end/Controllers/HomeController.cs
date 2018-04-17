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
        [ValidateInput(false)]
        public ActionResult Contact(SendMailModel SendEmail)
        {
            try
            {
                System.Net.Mail.MailMessage email = new System.Net.Mail.MailMessage();
                email.From = new System.Net.Mail.MailAddress(SendEmail.Email);
                email.To.Add("giorgi.khutsishvili04@geolab.edu.ge");
                email.Subject = SendEmail.Subject;
                email.Body = SendEmail.Body;


                System.Net.Mail.SmtpClient SmtpServer = new System.Net.Mail.SmtpClient("smtp.gmail.com");
                //WebMail.SmtpServer = "smtp.gmail.com";
                WebMail.SmtpPort = 465;
                WebMail.SmtpUseDefaultCredentials = true;
                WebMail.EnableSsl = true;
                WebMail.UserName = "giorgi.khutsishvili04@geolab.edu.ge";
                WebMail.Password = "Geo12341234";
                SmtpServer.Send(email);
                ViewBag.SendSucceeded = "თქვენი შეტყობინება გაიგზავნა წარმატებით";
              
            }
            catch (DbEntityValidationException dbEx)
            {
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        Trace.TraceInformation("Property: {0} Error: {1}",
                                                validationError.PropertyName,
                                                validationError.ErrorMessage);
                    }
                }
            }
            //catch(Exception)
            //{
            //    ViewBag.SendFailed = "შეტყობინების გაგზავნის დროს მოხდა შეცდომა";
            //}
            return View();
        }
    }
}