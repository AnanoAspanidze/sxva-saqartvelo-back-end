using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace sxva_saqartvelo_back_end.Models
{
    public class CompanyLoginModel
    {

        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "გთხოვთ, ჩაწერეთ თქვენი ელ.ფოსტა")]
        [EmailAddress(ErrorMessage = "ელ.ფოსტის ფორმატი არასწორია")]
        public string Email { get; set; }


        [DataType(DataType.Password)]
        [Required(ErrorMessage = "გთხოვთ, ჩაწერეთ თქვენი პაროლი")]
        public string Password { get; set; }
    }
}