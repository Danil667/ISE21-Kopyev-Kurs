using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace ZooCalculationBussinesLogic.BindingModels
{
	[DataContract]
	public class RouteBindingModel
	{
		[DataMember]
		public int? Id { set; get; }
		[DataMember]
		public string RouteName { set; get; }
		[DataMember]
		public DateTime StartRoute { set; get; }
		[DataMember]
		public int Cost { set; get; }
	}
}
