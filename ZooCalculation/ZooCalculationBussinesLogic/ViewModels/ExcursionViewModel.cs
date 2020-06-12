using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Text;
using ZooCalculationBussinesLogic.BindingModels;
using ZooCalculationBussinesLogic.Enums;

namespace ZooCalculationBussinesLogic.ViewModels
{
	[DataContract]
	public class ExcursionViewModel
	{
		[DataMember]
		public int Id { set; get; }
		[DataMember]
		public int ClientId { get; set; }
		[DataMember]
		[DisplayName("Клиент")]
		public string ClientFIO { get; set; }
		[DataMember]
		[DisplayName("Дата создания")]
		public DateTime ExcursionCreate { get; set; }
		[DataMember]
		[DisplayName("Статус")]
		public ExcursionStatus Status { get; set; }
		[DataMember]
		[DisplayName("Назване экскурсии")]
		public string Name_Excursion { set; get; }
		[DataMember]
		[DisplayName("Оплаченная сумма")]
		public decimal PaidSum { get; set; }
		[DataMember]
		[DisplayName("Оcтаток")]
		public decimal Remain { get; set; }
		[DataMember]
		public List<RouteForExcursionBindingModel> RouteForExcursions { get; set; }
	}
}
