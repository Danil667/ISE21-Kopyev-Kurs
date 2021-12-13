using System.Collections.Generic;
using System.Linq;
using Data.Interfaces;

namespace Data.Implements
{
	public class UserLogic : IUserLogic
	{

		private Singleton source;
		public UserLogic()
		{
			source = Singleton.getInstance();
		}


		public IEnumerable<User> Users => source.Users;

		public void AddUser(User user)
		{
			if (user.Id == 0)
			{
				int id = 0;
				var users = source.Users;
				if (users.Count() > 0)
					id = users.Last().Id;
				user.Id = ++id;
				source.Users.Add(user);
			}
			else
			{
				User usr = source.Users.Find(x => x.Id == user.Id);
				if (usr != null)
				{
					usr.Login = user.Login;
					usr.Password = user.Password;
				}
			}
		}

		public void DeleteUser(int userId)
		{
			source.Users.RemoveAt(userId);
		}
	}
}