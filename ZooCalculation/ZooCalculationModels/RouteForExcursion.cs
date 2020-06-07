using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ZooCalculationModels
{
	public class RouteForExcursion
	{
		public int Id { get; set; }
		public int ExcursionId { get; set; }
		public int RouteId { get; set; }
		[Required]
		public int Count { get; set; }
		[Required]
		public virtual Excursion Excursions { get; set; }
		public virtual Route Routes { get; set; }
	}

}

