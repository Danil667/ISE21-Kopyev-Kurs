﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Models
{
    public class ClientModel
    {
		public int Id { get; set; }
		public string ClientFIO { get; set; }
		public string Login { get; set; }
		public string OldPassword { get; set; }
		public string Password { get; set; }
		public bool BlockStatus { get; set; }
	}
}
