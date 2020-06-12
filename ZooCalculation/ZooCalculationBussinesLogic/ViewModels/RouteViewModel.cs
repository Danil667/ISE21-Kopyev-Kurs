using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Text;

namespace ZooCalculationBussinesLogic.ViewModels
{
	[DataContract]
	public class RouteViewModel
	{
		[DataMember]
		public int Id { set; get; }
		[DataMember]
		[DisplayName("Название маршрута")]
		public string RouteName { set; get; }
		[DataMember]
		[DisplayName("Дата начала")]
		public DateTime StartRoute { set; get; }		
		[DataMember]
		[DisplayName("Цена")]
		public int Cost { set; get; }
	}
}
