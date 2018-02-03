using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace sxva_saqartvelo_back_end.Models
{
    public class LoginModel
    {

        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "გთხოვთ, ჩაწერეთ თქვენი ელ.ფოსტა")]
        public string Email { get; set; }


        [DataType(DataType.Password)]
        [Required(ErrorMessage = "გთხოვთ, ჩაწერეთ თქვენი პაროლი")]
        public string Password { get; set; }
    }
}