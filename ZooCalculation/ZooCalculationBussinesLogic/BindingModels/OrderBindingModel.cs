using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace ZooCalculationBussinesLogic.BindingModels
{
	[DataContract]
	public class OrderBindingModel
	{
		[DataMember]
		public int? Id { get; set; }
		[DataMember]
		public int ClientId { get; set; }
		[DataMember]
		public int ExcursionId { get; set; }
		[DataMember]
		public int Sum { get; set; }
		[DataMember]
		public DateTime DateCreate { get; set; }
	}
}
