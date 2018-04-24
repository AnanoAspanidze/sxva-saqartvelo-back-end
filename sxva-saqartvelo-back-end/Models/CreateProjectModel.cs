using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace sxva_saqartvelo_back_end.Models
{
    public class CreateProjectModel
    {
        [Required(ErrorMessage = "პეოექტის სახელი")]
        public string Name { get; set; }

        [Required(ErrorMessage = "პროექტის აღწერა")]
        public string Description { get; set; }

        [DataType(DataType.Date)]
        [Required(ErrorMessage = "აირჩიეთ პროექტის დაწყების თარიღი თარიღი")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        //public DateTime StartDate { get; set; }
        public DateTime StartDate { get; set; }


        [DataType(DataType.Date)]
        [Required(ErrorMessage = "აირჩიეთ პროექტის დამთავრების თარიღი")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime EndDate { get; set; }
    }
}