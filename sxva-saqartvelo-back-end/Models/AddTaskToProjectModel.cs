using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace sxva_saqartvelo_back_end.Models
{
    public class AddTaskToProjectModel
    {
        [Required(ErrorMessage = "ჩაწერეთ ამოცანის სახელი")]
        public string Name { get; set; }


        public string Body { get; set; }

        [DataType(DataType.Date)]
        [Required(ErrorMessage = "აირჩიეთ თარიღი")]
        [DisplayFormat(DataFormatString = "{yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DueDate { get; set; }
    }
}