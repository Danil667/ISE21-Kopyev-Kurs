using System;
using System.Collections.Generic;
using System.Text;

namespace ZooCalculationDAL.BindingModels
{
	public class OrderBindingModel
	{
		public int Id { get; set; }
		public int CustomerId { get; set; }
		public int ExcursionId { get; set; }
		public int Count { get; set; }
		public int Sum { get; set; }
	}
}
