using Data.Implements;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data
{
	public class Singleton
	{
		private static Singleton instance;

		public List<User> Users { get; set; }
		private Singleton()
		{
			Users = new List<User>();
			Users.Add(new User() { BlockStatus = false, Login = "Admin", Password = "123", Role="admin" });
		}
		public static Singleton getInstance()
		{
			if (instance == null)
				instance = new Singleton();
			return instance;
		}
	}
}
