using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Text;

namespace ZooCalculationBussinesLogic.ViewModels
{
	[DataContract]
	class RouteForExcursionViewModel
	{
		[DataMember]
		public int Id { get; set; }
		[DataMember]
		public int? ExcursionId { get; set; }
		[DataMember]
		public int RouteId { get; set; }
		[DataMember]
		[DisplayName("Количество")]
		public int Count { get; set; }
	}
}
