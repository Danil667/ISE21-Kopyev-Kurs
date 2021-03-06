﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ZooCalculationModels
{
	public class Route
	{
		public int Id { set; get; }
		[Required]
		public string RouteName { set; get; }
		[Required]
		public int Cost { set; get; }
		public bool IsCredit { set; get; }
		[ForeignKey("ExcursionId")]
		public virtual List<RouteForExcursion> RouteForExcursion { set; get; }
	}
}
