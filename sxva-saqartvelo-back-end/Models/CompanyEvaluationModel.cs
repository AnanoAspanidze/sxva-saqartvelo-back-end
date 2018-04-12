using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace sxva_saqartvelo_back_end.Models
{
    public class CompanyEvaluationModel
    {
        public Company company { get; set; }

        public int CompanyRating { get; set; }

        public string CompanyEvaluation { get; set; }
    }
}