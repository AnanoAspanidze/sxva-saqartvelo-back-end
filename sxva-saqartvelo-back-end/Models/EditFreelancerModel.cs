using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace sxva_saqartvelo_back_end.Models
{
    public class EditFreelancerModel
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "ჩაწერეთ სახელი")]
        public string Name { get; set; }
        [Required(ErrorMessage = "ჩაწერეთ გვარი")]
        public string Surname { get; set; }
        [Required(ErrorMessage = "ჩაწერეთ ბიოგრაფია")]
        public string Bio { get; set; }
        [Required(ErrorMessage = "ჩაწერეთ პოზიცია")]
        public string Field { get; set; }  //Freelancer Position
        [Required(ErrorMessage = "ჩაწერეთ ტელეფონის ნომერი")]
        public string Mobile { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Compare("NewPassword", ErrorMessage = "პაროლები არ ემთხვევა")]
        public string RepeatPassword { get; set; }
    }
}