using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace sxva_saqartvelo_back_end.Models
{
    public class IssueProject
    {
        public Project project { get; set; }
        public List<Issue> issue { get; set; }
    }
}