using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ZooCalculationWebClient.Models
{
    public class ReportModel
    {
        public int YearFrom { get; set; }
        public int RouteTo { get; set; }
        public bool SendMail { get; set; }
    }
}
