using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Text;

namespace ZooCalculationBussinesLogic.ViewModels
{
	[DataContract]
	public class OrderViewModel
	{
		[DataMember]
		public int Id { get; set; }
		[DataMember]
		public int? ClientId { get; set; }
		[DataMember]
		public int ExcursionId { get; set; }
		[DataMember]
		[DisplayName("Сумма оплаты")]
		public decimal Sum { get; set; }
		[DataMember]
		[DisplayName("Дата оплаты")]
		public DateTime DateCreate { get; set; }
	}
}
