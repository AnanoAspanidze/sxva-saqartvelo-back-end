﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace sxva_saqartvelo_back_end.Models
{
    public class CompanyEvaluationModel
    {
        //public Company company { get; set; }
        public int ID { get; set; }

        public string Name { get; set; }

        [Required(ErrorMessage = "ჩაწერეთ რეიტინგი")]
        [Range(0, 10, ErrorMessage = "ჩაწერეთ რეიტინგი, 0-დან 10-ის ჩათვლით")]
        public int CompanyRating { get; set; }

        [Required(ErrorMessage = "ჩაწერეთ შეფასება")]
        public string CompanyEvaluation { get; set; }
    }
}