using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZooCalculationModels
{
	public class Customer
	{
		public int Id { set; get; }
		[Required]
		public string Name { set; get; }
		[Required]
		public string Login { set; get; }
		[Required]
		public string Password { set; get; }
		[ForeignKey("CustomerId")]
		public virtual List<Order> Orders { get; set; }

	}
}
