using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MeuTrabalho.Models;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using MeuTrabalho.Repositories.Interface;

namespace MeuTrabalho.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountRepository _accountRepository;
        public AccountController(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(LoginViewModel model)
        {
            try
            {
                var username = _accountRepository.Login(model.Email, model.Password);

                return Redirect($"/Home/Dashboard?name={username}");
            }
            catch(Exception ex)
            {
                return View(model);
            }
        }
    }
}
