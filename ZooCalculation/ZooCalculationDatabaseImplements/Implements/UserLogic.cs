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
	/*public void CreateOrUpdate(ClientBindingModel model)
	{
		using (var context = new Database())
		{
			Client elem = context.Clients.FirstOrDefault(rec => rec.Login == model.Login && rec.Id != model.Id);
			if (elem != null)
			{
				//throw new Exception("Уже есть клиент с таким логином");
			}
			if (model.Id.HasValue)
			{
				elem = context.Clients.FirstOrDefault(rec => rec.Id == model.Id);
				if (elem == null)
				{
					throw new Exception("Элемент не найден");
				}
			}
			else
			{
				elem = new Client();
				context.Clients.Add(elem);
			}               
			elem.Login = model.Login;
			elem.ClientFIO = model.ClientFIO;
			elem.Password = model.Password;
			elem.BlockStatus = model.BlockStatus;
			elem.Role = "user";
			context.SaveChanges();
		}
	}
	public void Delete(ClientBindingModel model)
	{
		using (var context = new Database())
		{
			Client elem = context.Clients.FirstOrDefault(rec => rec.Id == model.Id);

			if (elem != null)
			{
				context.Clients.Remove(elem);
				context.SaveChanges();
			}
			else
			{
				throw new Exception("Элемент не найден");
			}
		}
	}
	public List<ClientViewModel> Read(string Login)
	{
		using (var context = new Database())
		{
			return context.Clients
			.Where(
				rec => string.IsNullOrEmpty(Login)
				|| rec.Login == Login
			)
			.Select(rec => new ClientViewModel
			{
				Id = rec.Id,
				Login = rec.Login,
				ClientFIO = rec.ClientFIO,
				Password = rec.Password,
				BlockStatus = rec.BlockStatus,
				Role = rec.Role
			})
			.ToList();
		}
	}*/
}