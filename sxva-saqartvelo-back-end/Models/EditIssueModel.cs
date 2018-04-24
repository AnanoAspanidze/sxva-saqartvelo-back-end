using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace sxva_saqartvelo_back_end.Models
{
    public class EditIssueModel
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "ჩაწერეთ ამოცანის სახელი")]
        public string Name { get; set; }

        [Required(ErrorMessage = "ჩაწერეთ ამოცანის აღწერა")]
        public string Body { get; set; }

        [DataType(DataType.Date)]
        [Required(ErrorMessage = "აირჩიეთ თარიღი")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime DueDate { get; set; }
    }
}