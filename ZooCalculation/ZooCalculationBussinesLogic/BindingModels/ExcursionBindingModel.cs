using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using ZooCalculationBussinesLogic.Enums;

namespace ZooCalculationBussinesLogic.BindingModels
{
	[DataContract]
	public class ExcursionBindingModel
	{
		[DataMember]
		public int? Id { set; get; }
		[DataMember]
		public int ClientId { get; set; }
		[DataMember]
		public DateTime ExcursionCreate { get; set; }
		[DataMember]
		public ExcursionStatus Status { get; set; }
		[DataMember]
		public string Name_Excursion { set; get; }
		[DataMember]
		public decimal PaidSum { get; set; }
		[DataMember]
		public decimal Remain { get; set; }
		[DataMember]
		public List<RouteForExcursionBindingModel> RouteForExcursions { get; set; }
		public decimal Final_Cost { get; set; }
	}
}
