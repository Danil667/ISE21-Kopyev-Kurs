using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using Data.Interfaces;
using Web.Models;
using Data.Implements;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Mvc.RazorPages;

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
				ModelState.AddModelError("error","error");
				if (user.LimitPassword && !CheckPasswordLimited(newPass))
					return View("ChangePassword", userLogin);
				if (user.Password == old)
					user.Password = newPass;
				else
					return View("ChangePassword", userLogin);
				this.user.AddUser(new User
				{
					Id = user.Id,
					BlockStatus = user.BlockStatus,
					LimitPassword = user.LimitPassword,
					Login = user.Login,
					Password = user.Password
				});
				SaveData.Save(this.user.Users.ToList());
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
		public ActionResult Limit(string userName)
		{
			var user = this.user.Users.FirstOrDefault(x => x.Login == userName);
			user.LimitPassword = !user.LimitPassword;
			this.user.AddUser(user);
			SaveData.Save(this.user.Users.ToList());
			return RedirectToAction("Blocking");
		}

		[Authorize(Roles = "admin")]
		public ActionResult Block(string userName)
		{
			var user = this.user.Users.FirstOrDefault(x => x.Login == userName);
			user.BlockStatus = !user.BlockStatus;
			this.user.AddUser(user);
			SaveData.Save(this.user.Users.ToList());
			return RedirectToAction("Blocking");
		}
		[Authorize(Roles = "admin")]
		public ActionResult Blocking()
		{
			var listusers = new List<ClientModel>();
			var users = user.Users.Where(x => x.Role == "user");
			foreach(var user in users)
				listusers.Add(new ClientModel() { BlockStatus = user.BlockStatus, Login = user.Login, LimitPassword = user.LimitPassword});
			
			return View(listusers);
		}

		public bool CheckPasswordLimited(string password)
		{
			if (!Regex.IsMatch(password, @"[\d]"))
				return false;
			if (!Regex.IsMatch(password, @"[.,!?;:]"))
				return false;
			if (!Regex.IsMatch(password, @"[a-zа-яё]"))
				return false;
			return true;
		}

		[Authorize(Roles = "admin,user")]
		[HttpPost]
		public ActionResult Change(ClientModel model)
		{
			var users = this.user.Users;
			var user = users.FirstOrDefault(x => x.Login == User.Identity.Name);
			if (user != null)
			{
				ModelState.AddModelError("error","error");
				if(user.LimitPassword && !CheckPasswordLimited(model.Password))
					return View("Profile", model);
				if (user.Password == model.OldPassword)
					user.Password = model.Password;
				else
					ModelState.AddModelError("", "Неверный пароль");
				this.user.AddUser(new User
				{
					Id = user.Id,
					BlockStatus = user.BlockStatus,
					Login = user.Login,
					Password = user.Password,
					LimitPassword = user.LimitPassword
				});
				SaveData.Save(this.user.Users.ToList());
			}


			return View("Profile",model);
		}
	}
}
