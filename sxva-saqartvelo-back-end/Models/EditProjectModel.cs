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

        [Required(ErrorMessage = "ჩაწერეთ პროექტის სახელი")]
        public string Name { get; set; }

        [Required(ErrorMessage = "ჩაწერეთ პროექტის აღწერა")]
        public string Description { get; set; }

        [DataType(DataType.Date)]
        [Required(ErrorMessage = "აირჩიეთ პროექტის დაწყების თარიღი")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        //public DateTime StartDate { get; set; }
        public Nullable<System.DateTime> StartDate { get; set; }


        [DataType(DataType.Date)]
        //[Required(ErrorMessage = "აირჩიეთ პროექტის დამთავრების თარიღი")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public Nullable<System.DateTime> EndDate { get; set; }


        [Required(ErrorMessage = "აირჩიეთ კომპანია")]
        public int CompanyID { get; set; }

        [Required(ErrorMessage = "აირჩიეთ ფრილანსერი")]
        public int FreelancerID { get; set; }


        [Required(ErrorMessage = "აირჩიეთ პროექტის სტატუსი")]
        public int StatusID { get; set; }



    }
}