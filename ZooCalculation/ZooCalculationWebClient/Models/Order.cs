using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ZooCalculationWebClient.Models
{
    public class Order
    {
        [Required]
        public decimal OrderSum { get; set; }
        public int ExcursionId { get; set; }
    }
}
