using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace sxva_saqartvelo_back_end.Models
{
    public class FreelancerEvaluationModel
    {
        public Freelancer freelancer { get; set; }
        
        public int FreelancerRating { get; set; }

        public string FreelancerEvaluation { get; set; }
    }
}