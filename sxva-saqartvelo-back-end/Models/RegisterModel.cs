using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace sxva_saqartvelo_back_end.Models
{
    public class RegisterModel
    {
        [Required(ErrorMessage = "გთხოვთ, ჩაწერეთ თქვენი სახელი")]
        public string Name { get; set; }

        [Required(ErrorMessage = "გთხოვთ, ჩაწერეთ თქვენი გვარი")]
        public string Surname { get; set; }

        [Required(ErrorMessage = "გთხოვთ, ჩაწერეთ თქვენი პოზიცია")]
        public string Field { get; set; }  //Freelancer Position

        [Required(ErrorMessage = "გთხოვთ, ჩაწერეთ თქვენი ბიოგრაფია")]
        public string Bio { get; set; }

       
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "გთხოვთ, ჩაწერეთ თქვენი ელ.ფოსტა")]
        [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
                            @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
                            @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$",
                            ErrorMessage = "გთხოვთ ჩაწეროთ სწორედ ელ.ფოსტის მისამართ")]
        [StringLength(50, ErrorMessage = "ჩაწერილი ელ.ფოსტა არ უნდა აღემატებოდეს 50 სიმბოლოს")]
        public string Email { get; set; }


        [DataType(DataType.Password)]
        [Required(ErrorMessage = "გთხოვთ, ჩაწერეთ თქვენი პაროლი")]
        //[RegularExpression("^(?=.*[A-Z].*[A-Z])(?=.*[!@#$&*])(?=.*[0-9].*[0-9])(?=.*[a-z].*[a-z].*[a-z]).{8}$",
        //    ErrorMessage = "გთხოვთ, ჩაწერეთ სწორედ პაროლი")]
        [StringLength(30, MinimumLength = 6, ErrorMessage = "პაროლი უნდა შედგებოდეს მინიმუმ 6 სიმბოლოსგან და მაქსიმუმ 30 სიმბოლოსგან")]
        public string Password { get; set; }


        [Compare("Password", ErrorMessage = "პაროლები არ ემთხვევა")]
        [DataType(DataType.Password)]    
    //    [RegularExpression("^(?=.*[A-Z].*[A-Z])(?=.*[!@#$&*])(?=.*[0-9].*[0-9])(?=.*[a-z].*[a-z].*[a-z]).{8}$",
    //ErrorMessage = "გთხოვთ, ჩაწერეთ სწორედ პაროლი")]
        [StringLength(50, MinimumLength = 6, ErrorMessage = "პაროლი უნდა შედგებოდეს მინიმუმ 6 სიმბოლოსგან")]
        [Required(ErrorMessage = "გთხოვთ, გაიმეორეთ თქვენი პაროლი")]
        public string RepeatPassword { get; set; }

        [Required(ErrorMessage = "ჩაწერეთ თქვენი ტელეფონი")]
        //[Display(Name = "Phone")]
        [DataType(DataType.PhoneNumber)]
        //[RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "გთხოვთ, ჩაწერეთ ტელეფონის ნომერი სწორედ")]
        public string Mobile { get; set; }

    }
}