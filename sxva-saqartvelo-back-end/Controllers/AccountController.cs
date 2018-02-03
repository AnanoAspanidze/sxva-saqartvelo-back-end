using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using sxva_saqartvelo_back_end.Models;
using sxva_saqartvelo_back_end.Helpers;

using System.Data;


namespace sxva_saqartvelo_back_end.Controllers
{
    public class AccountController : Controller
    {
        //Random 32 Bit Hash String
        string randomSecret = "4afd759a8e1df217901aaeecd1ea9949";

        OtherGeorgiaEntities _db = new OtherGeorgiaEntities();

        public ActionResult Login()
        {
            return View();
        }

        public ActionResult Logout()
        {
            return View();
        }


        public ActionResult Register()
        {
            return View();
        }


        //Register Freelancer
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register([Bind(Include = "Name, Surname, Field, Bio, Email, Password, Mobile")]  RegisterModel freelancer)
        {
            

            //Check Freelancer Is Registered Or Not
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
                freelancerTbl.Bio = freelancer.Bio.Trim();
                freelancerTbl.Email = freelancer.Email.Trim();
                freelancerTbl.Password = PasswordHashHelper.MD5Hash(randomSecret + freelancer.Password.Trim());
                freelancerTbl.Mobile = freelancer.Mobile.Trim();
                freelancerTbl.Date = DateTime.Now;
                _db.Freelancers.Add(freelancerTbl);
                _db.SaveChanges();


                ViewBag.RegistrationSuccess = "თქვენ წარმატებით დარეგისტრირდით, გთხოვთ გაიაროთ ავტორიზაცია";
                return View();
                //return View(freelancer);
            }

        }

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Register(RegisterModel freelancer)
        //{
        //    Freelancer freelancerTbl = new Freelancer();

        //    //Check Freelancer Is Registered Or Not
        //    if (_db.Freelancers.Where(x => x.Email == freelancer.Email).Count() > 0)
        //    {
        //        ViewBag.RegistrationFailed = "ასეთი ელ.ფოსტით მომხმარებელი დარეგისტრირებულია";
        //        return View();
        //    }
        //    else
        //    {
        //        try
        //        {
        //            //Add Freelancer To DB
        //            if (ModelState.IsValid)
        //            {
        //                freelancerTbl.Name = freelancer.Name.Trim();
        //                freelancerTbl.Surname = freelancer.Surname.Trim();
        //                freelancerTbl.Field = freelancer.Field.Trim();
        //                freelancerTbl.Bio = freelancer.Bio.Trim();
        //                freelancerTbl.Email = freelancer.Email.Trim();
        //                freelancerTbl.Password = PasswordHashHelper.MD5Hash(randomSecret + freelancer.Password.Trim());
        //                freelancerTbl.Mobile = freelancer.Mobile.Trim();
        //                freelancerTbl.Date = DateTime.Now;
        //                _db.Freelancers.Add(freelancerTbl);
        //                _db.SaveChanges();


        //                ViewBag.RegistrationSuccess = "თქვენ წარმატებით დარეგისტრირდით, გთხოვთ გაიაროთ ავტორიზაცია";
        //                return View();
        //            }
        //        }
        //        catch (DataException)
        //        {
        //            ModelState.AddModelError("", "მონაცემების ჩაწერის დროს მოხდა შეცდომა");
        //        }
        //        return View(freelancer);
        //    }

        //}
    }
}