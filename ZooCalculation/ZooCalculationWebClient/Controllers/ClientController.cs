using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Data.Interfaces;
using Data.Models;
using Web.Models;
using Data.Implements;

namespace Web.Controllers
{
    public class ClientController : Controller
    {
		private readonly IUserLogic user;
		private readonly int loginMinLength = 1;
		private readonly int loginMaxLength = 50;
		public ClientController(IUserLogic user)
		{
			this.user = user;
		}

		public IActionResult Login()
		{
			return View();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Login(SignIn user)
		{
			var clientView = this.user.Users.FirstOrDefault(x => x.Login == user.Login);
			if (clientView == null || !string.IsNullOrEmpty(clientView.Password) && clientView.Password != user.Password)
			{
				ModelState.AddModelError("", "Вы ввели неверный пароль, либо пользователь не найден");
				return View(user);
			}
			if (clientView.BlockStatus == true)
			{
				ModelState.AddModelError("", "Пользователь заблокирован");
				return View(user);
			}
			var usr = new User();
			usr.Login = clientView.Login;
			usr.BlockStatus = clientView.BlockStatus;
			if(usr.Login == "Admin")
				usr.Role = "admin";
			else
				usr.Role = "user";
			if (string.IsNullOrEmpty(clientView.Password))
			{
				clientView.Password = user.Password;
				this.user.AddUser(clientView);
			}
				
			await Authenticate(usr);
			return RedirectToAction("Profile", "Account");
		}

		private async Task Authenticate(User user)
		{
			// создаем один claim
			var claims = new List<Claim>
			{
				new Claim(ClaimsIdentity.DefaultNameClaimType, user.Login),
				new Claim(ClaimsIdentity.DefaultRoleClaimType, user.Role)
			};
			// создаем объект ClaimsIdentity
			ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
			// установка аутентификационных куки
			await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
		}

		public IActionResult Logout()
		{
			HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
			return RedirectToAction("Index", "Home");
		}
		public IActionResult Registration()
		{
			return View();
		}
		[HttpPost]
		public ActionResult Registration(RegistrationModel user)
		{
			if (String.IsNullOrEmpty(user.Login))
			{
				ModelState.AddModelError("", "Введите логин");
				return View(user);
			}
			if (user.Login.Length > loginMaxLength ||
		   user.Login.Length < loginMinLength)
			{
				ModelState.AddModelError("", $"Длина логина должна быть от {loginMinLength} до {loginMaxLength} символов");
				return View(user);
			}
			var existClient = this.user.Users.FirstOrDefault(x => x.Login == user.Login);
			if (existClient != null)
			{
				ModelState.AddModelError("", "Данный логин уже занят");
				return View(user);
			}
			
			this.user.AddUser(new User
			{
				Login = user.Login,
				BlockStatus = false,
				Role = "user"
			});
			ModelState.AddModelError("", "Пользователь успешно зарегистрирован");
			return RedirectToAction("Blocking","Account", user);
		}
	}
}