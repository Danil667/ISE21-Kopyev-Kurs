using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using Data.Interfaces;
using Web.Models;
using Data.Implements;

namespace Web.Controllers
{
	[Authorize]
	public class AccountController : Controller
	{

		private readonly IUserLogic user;
		public AccountController(IUserLogic user)
		{
			this.user = user;
		}
		[Authorize(Roles = "admin")]
		public ActionResult ChangePassword(string userName)
		{
			return View("ChangePassword",userName);
		}

		[Authorize(Roles = "admin")]
		public ActionResult ChangePassUser(string userLogin, string old, string newPass)
		{
			var users = this.user.Users;
			var user = users.FirstOrDefault(x => x.Login == userLogin);
			if (user != null)
			{
				if (user.Password == old)
					user.Password = newPass;
				else
					return RedirectToAction("ChangePassword", "Account",userLogin);
				this.user.AddUser(new User
				{
					Id = user.Id,
					BlockStatus = user.BlockStatus,
					Login = user.Login,
					Password = user.Password
				});
				return RedirectToAction("Blocking");
			}
			return RedirectToAction("ChangePassword", "Account", userLogin);
		}

		[Authorize(Roles = "admin,user")]
		public ActionResult Profile()
		{
			ClientModel model = new ClientModel();
			var user = this.user.Users.FirstOrDefault(x => x.Login == User.Identity.Name);
			model.Login = user.Login;
			return View(model);
		}

		[Authorize(Roles = "admin")]
		public ActionResult Block(string userName)
		{
			var user = this.user.Users.FirstOrDefault(x => x.Login == userName);
			user.BlockStatus = !user.BlockStatus;
			this.user.AddUser(user);
			return RedirectToAction("Blocking");
		}
		[Authorize(Roles = "admin")]
		public ActionResult Blocking()
		{
			var listusers = new List<ClientModel>();
			var users = user.Users.Where(x => x.Role == "user");
			foreach(var user in users)
				listusers.Add(new ClientModel() { BlockStatus = user.BlockStatus, Login = user.Login});
			
			return View(listusers);
		}
		[Authorize(Roles = "admin,user")]
		[HttpPost]
		public ActionResult Change(ClientModel model)
		{
			var users = this.user.Users;
			var user = users.FirstOrDefault(x => x.Login == User.Identity.Name);
			if (user != null)
			{
				if (user.Password == model.OldPassword)
					user.Password = model.Password;
				else
					ModelState.AddModelError("", "Неверный пароль");
				this.user.AddUser(new User
				{
					Id = user.Id,
					BlockStatus = user.BlockStatus,
					Login = user.Login,
					Password = user.Password
				});
			}


			return RedirectToAction("Profile",model);
		}
	}
}
