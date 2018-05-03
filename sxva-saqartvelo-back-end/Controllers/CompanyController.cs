using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using sxva_saqartvelo_back_end.Filters;
using sxva_saqartvelo_back_end.Models;
using System.Net;
using sxva_saqartvelo_back_end.Helpers;
using System.IO;

namespace sxva_saqartvelo_back_end.Controllers
{
    
    public class CompanyController : Controller
    {

        OtherGeorgiaEntities _db = new OtherGeorgiaEntities();

        //Random 32 Bit Hash String
        string randomSecret = "4b47a904bc5e81234a754f552355bf44"; //პაროლის დასაჰეშად


        // GET: Company
        [LoginFilterForCompany]
        public ActionResult CompanyProfile()
        {
            var company = LoginHelperForCompany.company();
            var project = _db.Projects.Where(x => x.CompanyID == company.ID).ToList();
            return View(project);
        }

        //[LoginFilterForCompany]
        //public ActionResult EditCompany(int? id)
        //{
        //    if(id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }

        //    var editCompanyViewModel = new EditCompanyViewModel
        //    {
        //        company = _db.Companies.Find(id)
        //    };
        //    if(editCompanyViewModel == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(editCompanyViewModel);
        //}

        //[ValidateInput(false)]
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult EditCompany([Bind(Include = "ID, Name, Mobile, oldPassword, Password, RepeatPassword, Description")] Company editCompany, EditCompanyViewModel model, HttpPostedFileBase file)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var companyToEdit = _db.Companies.Find(editCompany.ID);

        //        if(companyToEdit == null)
        //        {
        //            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //        }


        //        var existingCompany = _db.Companies.FirstOrDefault(x => x.ID == editCompany.ID);
        //        ViewBag.ExistingCompanyID = existingCompany.ID;

        //        if(model.editCompanyModel.Password != null)
        //        {


        //            var hashedPassword = PasswordHashHelper.MD5Hash(randomSecret + model.editCompanyModel.oldPassword);

        //            Company Company = _db.Companies.FirstOrDefault(x => x.Password == hashedPassword);

        //            if (Company == null)
        //            {
        //                ViewBag.error = "არსებული პაროლი არ არის სწორი";
        //                return View(model);
        //            }
        //            else
        //            {
        //                ViewBag.success = "მონაცემები წარმატებით შეიცვალა";
        //            }



        //            existingCompany.Password = PasswordHashHelper.MD5Hash(randomSecret + model.editCompanyModel.Password.Trim());
        //            _db.SaveChanges();

        //            return View(model);
        //        }


        //        if (model.company.Name != null)
        //        {
        //            var allowedExtensions = new[] {
        //            ".Jpg", ".png", ".jpg", ".jpeg"
        //            };


        //            if (file != null)
        //            {
        //                var fileName = Path.GetFileName(file.FileName); //სურათის სახელი
        //                var ext = Path.GetExtension(file.FileName); //სურათის extension
        //                var randomString = Guid.NewGuid().ToString("N").Substring(0, 10); //რენდომ სტრინგი სურათის უნიკალურობისთვის
        //                fileName = randomString + "ID" + existingCompany.ID; //სურათზე რენდომ სტრინგის და კომპანიის ID-ის დამატება უნიკალურობისთვის


        //                if (allowedExtensions.Contains(ext))
        //                {

        //                    string name = Path.GetFileNameWithoutExtension(fileName); //სურათი extension-ის გარეშე
        //                    var path = Path.Combine(Server.MapPath("~/img/logos"), name + ext); //ფოლდერი ატვირთული სურათების შესანახად
        //                    if (existingCompany.Logo != "default-logo-forCompany.jpg") //არსებული სურათი თუ არ არის კომპანიის default სურათი, "default-logo-forCompany.jpg", 
        //                    {

        //                        string existingCompanyPhoto = Request.MapPath("~/img/logos/" + existingCompany.Logo); //არსებული კომპანიის სურათი
        //                        System.IO.File.Delete(existingCompanyPhoto); //არსებული კომპანიის სურათის წაშლა თუ არსებული არ არის "default-logo-forCompany.jpg"
        //                        existingCompany.Logo = name + ext; //სურათის ჩაწერა ბაზაში
        //                        file.SaveAs(path); //სურათის შენახვა ფოლდერში
        //                        _db.SaveChanges();
        //                        ViewBag.uploadedImg = name + ext; //ატვირთული სურათის ჩვენება layout-ის header-ისთვის და EditCompany view-ისთვის
        //                        return View(model);
        //                    }
        //                    else
        //                    {
        //                        existingCompany.Logo = name + ext; //სურათის ჩაწერა ბაზაში
        //                        file.SaveAs(path); //სურათის შენახვა ფოლდერში
        //                        _db.SaveChanges();
        //                        return View(model);
        //                    }

        //                }
        //            }



        //            existingCompany.Name = model.company.Name.Trim();
        //            existingCompany.Mobile= model.company.Mobile.Trim();
        //            existingCompany.Description = model.company.Description.Trim();
        //            _db.SaveChanges();
        //            return View(model);
        //        }


        //    }
        //    return View(model);
        //}

        [LoginFilterForCompany]
        public ActionResult EditCompany(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var company = _db.Companies.Find(id);
            var result = new EditCompanyModel
            {
               ID = company.ID,
               Name = company.Name,
               Mobile = company.Mobile,
               Description = company.Description
            };
            if (result == null)
            {
                return HttpNotFound();
            }
            return View(result);
        }

        [ValidateInput(false)]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditCompany([Bind(Include = "ID, Name, Mobile, Password, NewPassword, RepeatPassword, Description")] EditCompanyModel model, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                var companyToUpdate = _db.Companies.FirstOrDefault(x=> x.ID == model.ID);
                var hashedPassword = PasswordHashHelper.MD5Hash(randomSecret + model.Password);
                Company company = _db.Companies.FirstOrDefault(x => x.Password == hashedPassword);


                companyToUpdate.Name = model.Name.Trim();
                companyToUpdate.Mobile = model.Mobile.Trim();
                companyToUpdate.Description = model.Description.Trim();
                _db.SaveChanges();
                
                if(model.NewPassword != null)
                {
                    companyToUpdate.Password = PasswordHashHelper.MD5Hash(randomSecret + model.NewPassword.Trim());
                    _db.SaveChanges();
                    return View();
                }

                if (companyToUpdate == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }


                if (company == null)
                {
                    ViewBag.error = "არსებული პაროლი არ არის სწორი";
                    return View();
                }
                else
                {
                    ViewBag.success = "მონაცემები წარმატებით შეიცვალა";
                }


                var allowedExtensions = new[] {
                    ".Jpg", ".png", ".jpg", ".jpeg"
                    };


                if (file != null)
                {
                    var fileName = Path.GetFileName(file.FileName); //სურათის სახელი
                    var ext = Path.GetExtension(file.FileName); //სურათის extension
                    var randomString = Guid.NewGuid().ToString("N").Substring(0, 10); //რენდომ სტრინგი სურათის უნიკალურობისთვის
                    fileName = randomString + "ID" + companyToUpdate.ID; //სურათზე რენდომ სტრინგის და კომპანიის ID-ის დამატება უნიკალურობისთვის


                    if (allowedExtensions.Contains(ext))
                    {

                        string name = Path.GetFileNameWithoutExtension(fileName); //სურათი extension-ის გარეშე
                        var path = Path.Combine(Server.MapPath("~/img/logos"), name + ext); //ფოლდერი ატვირთული სურათების შესანახად
                        if (companyToUpdate.Logo != "default-logo-forCompany.jpg") //არსებული სურათი თუ არ არის კომპანიის default სურათი, "default-logo-forCompany.jpg", 
                        {

                            string existingCompanyPhoto = Request.MapPath("~/img/logos/" + companyToUpdate.Logo); //არსებული კომპანიის სურათი
                            System.IO.File.Delete(existingCompanyPhoto); //არსებული კომპანიის სურათის წაშლა თუ არსებული არ არის "default-logo-forCompany.jpg"
                            companyToUpdate.Logo = name + ext; //სურათის ჩაწერა ბაზაში
                            file.SaveAs(path); //სურათის შენახვა ფოლდერში
                            _db.SaveChanges();
                            ViewBag.uploadedImg = name + ext; //ატვირთული სურათის ჩვენება layout-ის header-ისთვის და EditCompany view-ისთვის
                            return View(model);
                        }
                        else
                        {
                            companyToUpdate.Logo = name + ext; //სურათის ჩაწერა ბაზაში
                            file.SaveAs(path); //სურათის შენახვა ფოლდერში
                            _db.SaveChanges();
                            return View(model);
                        }

                    }
                }
                return View();
            }
            return View(model);
        }

        public ActionResult CompanyDetails(int? id)
        {
            var company = _db.Companies.FirstOrDefault(x => x.ID == id);
            return View(company);
        }
    }
}