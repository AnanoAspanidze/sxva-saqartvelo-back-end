using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace sxva_saqartvelo_back_end.Models
{
    public class Freelancer_Project_Model
    {
        public Freelancer freelancer { get; set; }
        public List<Project> project { get; set; }
    }
}