using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ZooCalculationDatabaseImplements.Models
{
	public class RouteForExcursion
	{
		public int Id { get; set; }
		[Required]
		public int? ExcursionId { get; set; }
		[Required]
		public int RouteId { get; set; }
		[Required]
		public int Count { get; set; }
		[Required]
		public virtual Excursion Excursions { get; set; }
		public virtual Route Routes { get; set; }
	}
}
