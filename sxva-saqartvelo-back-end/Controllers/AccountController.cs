using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using sxva_saqartvelo_back_end.Models;
using sxva_saqartvelo_back_end.Helpers;
using sxva_saqartvelo_back_end.Filters;
using System.Data;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Web.Routing;

namespace sxva_saqartvelo_back_end.Controllers
{
    public class AccountController : Controller
    {
        //Random 32 Bit Hash String
        string randomSecret = "4b47a904bc5e81234a754f552355bf44"; //პაროლის დასაჰეშად

        OtherGeorgiaEntities _db = new OtherGeorgiaEntities();


        //[LoginFilterForLoggedInUser]
        public ActionResult Login()
        {
            //freelancer session
            var freelancer = LoginHelper.freelancer();


            if (freelancer != null)
            {
                return RedirectToAction("FreelancerProfile", "Freelancer");
            }

            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginModel login)
        {
            var hashedPassword = PasswordHashHelper.MD5Hash(randomSecret + login.Password);

            Freelancer freelancer = _db.Freelancers.FirstOrDefault(x => x.Email == login.Email && x.Password == hashedPassword);
            
            if (freelancer == null)
            {
                ViewBag.message = "მომხმარებლის სახელი ან პაროლი არასწორია";
                return View();
            }
            else
            {
                Session["freelancer"] = freelancer;

                return RedirectToAction("Index", "Home");
            }
            
        }

        public ActionResult Logout()
        {
            LoginHelper.Logout();
            return RedirectToAction("Index", "Home");
        }


        //[LoginFilterForLoggedInUser]
        public ActionResult Register()
        {
            var freelancer = LoginHelper.freelancer();

            if (freelancer != null)
            {
                return RedirectToAction("FreelancerProfile", "Freelancer");
            }

            return View();
        }


        //Register Freelancer
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register([Bind(Include = "Name, Surname, Field, Photo, Bio, Email, Password, RepeatPassword, Mobile")]RegisterModel freelancer)    
        {
            try
            {
                if (ModelState.IsValid)
                {
                    //Check Freelancer Is Exist Or Not
                    if (_db.Freelancers.Where(x => x.Email == freelancer.Email).Count() > 0)
                    {
                        ViewBag.RegistrationFailed = "ასეთი ელ.ფოსტით მომხმარებელი დარეგისტრირებულია";
                        return View();
                    }
                    else
                    {
                        //Add Freelancer To DB
                        Freelancer freelancerTbl = new Freelancer();
                        freelancerTbl.Name = freelancer.Name.Trim();
                        freelancerTbl.Surname = freelancer.Surname.Trim();
                        freelancerTbl.Field = freelancer.Field.Trim();
                        freelancerTbl.Photo = "default-freelancer-pic.png"; //default photo for freelancer
                        freelancerTbl.Bio = "Freelancer Bio";
                        freelancerTbl.Email = freelancer.Email.Trim();
                        freelancerTbl.Password = PasswordHashHelper.MD5Hash(randomSecret + freelancer.Password.Trim());
                        freelancerTbl.Mobile = freelancer.Mobile.Trim();
                        freelancerTbl.Date = DateTime.Now;
                        _db.Freelancers.Add(freelancerTbl);
                        _db.SaveChanges();


                        ViewBag.RegistrationSuccess = "თქვენ წარმატებით დარეგისტრირდით, გთხოვთ გაიაროთ ავტორიზაცია";
                        return View();
                    }
                }
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
            return View();

        }
    }
}