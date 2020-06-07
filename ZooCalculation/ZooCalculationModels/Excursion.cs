using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ZooCalculationModels
{
	public class Excursion
	{
		public int Id { set; get; }
		[Required]
		public string Name_Excursion { set; get; }
		[Required]
		public int Final_Cost { set; get; }
		[ForeignKey("ExcursionId")]
		public virtual List<RouteForExcursion> RouteForExcursions { get; set; }
		[ForeignKey("ExcursionId")]
		public virtual List<Order> Orders { get; set; }
	}

}
