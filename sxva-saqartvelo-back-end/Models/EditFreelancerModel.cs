using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace sxva_saqartvelo_back_end.Models
{
    public class EditFreelancerModel
    {

        public string Name { get; set; }
        public string Surname { get; set; }
        public string Bio { get; set; }
        public string Field { get; set; }  //Freelancer Position
        public string Mobile { get; set; }

        [DataType(DataType.Password)]
        public string oldPassword { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "პაროლები არ ემთხვევა")]
        public string RepeatPassword { get; set; }
    }
}