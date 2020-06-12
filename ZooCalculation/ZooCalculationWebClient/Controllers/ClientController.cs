using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ZooCalculationBussinesLogic.BindingModels;
using ZooCalculationBussinesLogic.Interfaces;
using ZooCalculationWebClient.Models;

namespace ZooCalculationWebClient.Controllers
{
    public class ClientController : Controller
    {
        private readonly IClientLogic client;
        public ClientController(IClientLogic client)
        {
           this.client = client;
        }
        public ActionResult Profile()
        {
            ViewBag.User = Program.Client;
            return View();
        }
        [HttpPost]
        public ActionResult Login(SignIn user)
        {
            var clientView = client.Read(new ClientBindingModel
            {
                Login = user.Login,
                Password = user.Password
            }).FirstOrDefault();
            if (clientView == null)
            {
                ModelState.AddModelError("", "Вы ввели неверный пароль, либо пользователь не найден");
                return View(user);
            }
            if (clientView.BlockStatus == true)
            {
                ModelState.AddModelError("", "Пользователь заблокирован");
                return View(user);
            }
            Program.Client = clientView;
            return RedirectToAction("Index", "Home");
        }
        public IActionResult Logout()
        {
            Program.Client = null;
            return RedirectToAction("Index", "Home");
        }
        public IActionResult Registration()
        {
            return View();
        }
        [HttpPost]
        public ViewResult Registration(RegistrationModel user)
        {
            if (ModelState.IsValid)
            {
                var existClient = client.Read(new ClientBindingModel
                {
                    Login = user.Login
                }).FirstOrDefault();
                if (existClient != null)
                {
                    ModelState.AddModelError("", "Данный логин уже занят");
                    return View(user);
                }
                client.CreateOrUpdate(new ClientBindingModel
                {
                    ClientFIO = user.ClientFIO,
                    Login = user.Login,
                    Password = user.Password,
                    BlockStatus = false
                });
                ModelState.AddModelError("", "Вы успешно зарегистрированы");
                return View("Registration", user);
            }
            return View(user);
        }
    }
}