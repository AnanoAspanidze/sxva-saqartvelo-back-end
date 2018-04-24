using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace sxva_saqartvelo_back_end.Models
{
    public class EditProjectModel
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        [DataType(DataType.Date)]
        [Required(ErrorMessage = "აირჩიეთ თარიღი")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime StartDate { get; set; }


        [DataType(DataType.Date)]
        [Required(ErrorMessage = "აირჩიეთ თარიღი")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime EndDate { get; set; }


        public int CompanyID { get; set; }


        public int FreelancerID { get; set; }


    }
}