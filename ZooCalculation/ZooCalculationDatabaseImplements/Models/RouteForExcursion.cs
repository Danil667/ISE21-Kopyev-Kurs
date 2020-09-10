using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ZooCalculationDatabaseImplements.Models
{
	public class RouteForExcursion
	{
		public int Id { get; set; }
		public int? ExcursionId { get; set; }
		public int RouteId { get; set; }
		public int Count { get; set; }
		public virtual Excursion Excursions { get; set; }
		public virtual Route Routes { get; set; }
	}
}
