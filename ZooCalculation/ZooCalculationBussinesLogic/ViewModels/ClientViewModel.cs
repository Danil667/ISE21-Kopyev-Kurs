using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Text;

namespace ZooCalculationBussinesLogic.ViewModels
{
	[DataContract]
	public class ClientViewModel
	{
		[DataMember]
		public int? Id { get; set; }
		[DataMember]
		[DisplayName("ФИО")]
		public string ClientFIO { get; set; }
		[DataMember]
		[DisplayName("Email")]
		public string Login { get; set; }
		[DataMember]
		[DisplayName("Паролб")]
		public string Password { get; set; }
		[DataMember]
		[DisplayName("Блокировка")]
		public bool BlockStatus { get; set; }
	}
}
