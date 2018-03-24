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
        [LoginFilterForLoggedInUser]
        public ActionResult CompanyProfile()
        {
            return View();
        }

        [LoginFilterForLoggedInUser]
        public ActionResult EditCompany(int? ID)
        {
            if(ID == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var editCompanyViewModel = new EditCompanyViewModel
            {
                company = _db.Companies.Find(ID)
            };
            if(editCompanyViewModel == null)
            {
                return HttpNotFound();
            }
            return View(editCompanyViewModel);
        }

        [ValidateInput(false)]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditCompany([Bind(Include = "ID, Name, Mobile, oldPassword, Password, RepeatPassword, Description")] Company editCompany, EditCompanyViewModel model, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                var companyToEdit = _db.Companies.Find(editCompany.ID);

                if(companyToEdit == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }

                var hashedPassword = PasswordHashHelper.MD5Hash(randomSecret + model.editCompanyModel.oldPassword);

                Company company = _db.Companies.FirstOrDefault(x => x.Password == hashedPassword);


                if(company == null)
                {
                    ViewBag.error = "არსებული პაროლი არ არის სწორი";
                    return View(model);
                }
                else
                {
                    ViewBag.success = "პაროლი წარმატებით შეიცვალა";
                }

                var existingCompany = _db.Companies.FirstOrDefault(x => x.ID == editCompany.ID);

                if(model.editCompanyModel.Password != null)
                {
                    existingCompany.Password = PasswordHashHelper.MD5Hash(randomSecret + model.editCompanyModel.Password.Trim());
                    _db.SaveChanges();

                    return View(model);
                }


                if (model.company.Name != null)
                {
                    var allowedExtensions = new[] {
                    ".Jpg", ".png", ".jpg", ".jpeg"
                    };

                    //if(existingFreelancer.Photo != model.freelancer.Photo)
                    //{

                    //}

                    if (file != null)
                    {
                        var fileName = Path.GetFileName(file.FileName); //სურათის სახელი
                        var ext = Path.GetExtension(file.FileName); //სურათის extension
                        var randomString = Guid.NewGuid().ToString("N").Substring(0, 10); //რენდომ სტრინგი სურათის უნიკალურობისთვის
                        fileName = randomString + "ID" + existingCompany.ID; //სურათზე რენდომ სტრინგის და ფრილანსერის ID-ის დამატება უნიკალურობისთვის


                        if (allowedExtensions.Contains(ext))
                        {

                            string name = Path.GetFileNameWithoutExtension(fileName); //სურათი extension-ის გარეშე
                            var path = Path.Combine(Server.MapPath("~/img/pp"), name + ext); //ფოლდერი ატვირთული სურათების შესანახად
                            if (existingCompany.Logo != "default-logo-forCompany.jpg") //არსებული სურათი თუ არ არის ფრილასნერის default სურათი, "default-freelancer-pic.png", 
                            {
                                string existingCompanyPhoto = Request.MapPath("~/img/logos/" + existingCompany.Logo); //არსებული ფრილასნერის სურათი
                                System.IO.File.Delete(existingCompanyPhoto); //არსებული ფრილასნერის სურათის წაშლა თუ არსებული არ არის "default-freelancer-pic.png"
                                existingCompany.Logo= name + ext; //სურათის ჩაწერა ბაზაში
                                file.SaveAs(path); //სურათის შენახვა ფოლდერში
                                _db.SaveChanges();
                                return View(model);
                            }
                            else
                            {
                                existingCompany.Logo = name + ext; //სურათის ჩაწერა ბაზაში
                                file.SaveAs(path); //სურათის შენახვა ფოლდერში
                                _db.SaveChanges();
                                return View(model);
                            }

                        }
                    }



                    existingCompany.Name = model.company.Name.Trim();
                    existingCompany.Mobile= model.company.Mobile.Trim();
                    existingCompany.Description = model.company.Description.Trim();
                    _db.SaveChanges();
                    return View(model);
                }

            }
            return View(model);
        }
    }
}