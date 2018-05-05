using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace sxva_saqartvelo_back_end.Models
{
    public class EditCompanyModel
    {
        //[DataType(DataType.Password)]
        //public string oldPassword { get; set; }

        //[DataType(DataType.Password)]
        //public string Password { get; set; }

        //[DataType(DataType.Password)]
        //[Compare("Password", ErrorMessage = "პაროლები არ ემთხვევა")]
        //public string RepeatPassword { get; set; }

        public int ID { get; set; }

        [Required(ErrorMessage = "ჩაწერეთ კომპანიის სახელი")]
        public string Name { get; set; }

        [Required(ErrorMessage = "ჩაწერეთ ტელეფონის ნომერი")]
        public string Mobile { get; set; }


        public string Logo { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Compare("NewPassword", ErrorMessage = "პაროლები არ ემთხვევა")]
        public string RepeatPassword { get; set; }

        [Required(ErrorMessage = "ჩაწერეთ კომპანიის აღწერა")]
        public string Description { get; set; }
    }
}