using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace ZooCalculationBussinesLogic.BindingModels
{
	[DataContract]
	public class RouteForExcursionBindingModel
	{
		[DataMember]
		public int Id { get; set; }
		[DataMember]
		public int? ExcursionId { get; set; }
		[DataMember]
		public int RouteId { get; set; }
		[DataMember]
		public int Count { get; set; }
	}
}
