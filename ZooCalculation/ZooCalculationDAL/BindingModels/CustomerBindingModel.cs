using System;
using System.Collections.Generic;
using System.Text;

namespace ZooCalculationDAL.BindingModels
{
	public class CustomerBindingModel
	{
		public int Id { set; get; }
		public string Name { set; get; }
		public string Login { set; get; }
		public string Password { set; get; }
	}
}
