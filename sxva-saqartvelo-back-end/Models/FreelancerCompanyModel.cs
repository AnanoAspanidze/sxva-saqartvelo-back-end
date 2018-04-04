using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace sxva_saqartvelo_back_end.Models
{
    public class FreelancerCompanyModel
    {
        [Required(ErrorMessage = "პეოექტის სახელი")]
        public string Name { get; set; }
        [Required(ErrorMessage = "პროექტის აღწერა")]
        public string Description { get; set; }


        public List<Freelancer> listFreelancer { get; set; }
        public List<Company> listCompany { get; set; }
    }
}