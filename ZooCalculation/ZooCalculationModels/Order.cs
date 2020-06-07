using System;

namespace ZooCalculationModels
{
	public class Order
	{
		public int Id { get; set; }
		public int CustomerId { get; set; }
		public int ExcursionId { get; set; }
		public int Count { get; set; }
		public decimal Sum { get; set; }
		public ExcursionStatus Status { get; set; }
		public DateTime DateCreate { get; set; }
		public DateTime? DateImplement { get; set; }
		public virtual Customer Customer { get; set; }
		public virtual Excursion Excursions { get; set; }
	}

}