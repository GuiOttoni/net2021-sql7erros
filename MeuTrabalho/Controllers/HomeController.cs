using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MeuTrabalho.Models;
using System.Data.SqlClient;
using MeuTrabalho.Repositories;
using MeuTrabalho.Repositories.Interface;
using Microsoft.Extensions.Configuration;

namespace MeuTrabalho.Controllers
{
    public class HomeController : Controller, IDisposable
    {
        private readonly ILogRepository _logRepository;

        public HomeController(ILogRepository logRepository)
        {
            _logRepository = logRepository;
        }

        public IActionResult Index()
        {
            return RedirectToActionPermanent("Index", "Account");
        }

        public IActionResult Dashboard(string name)
        {
            if( name == null )
            {
                throw new ArgumentNullException(name);
            }

            ViewBag.Name = name;
            return View();
        }

        public IActionResult About([FromQuery]string teste = "")
        {
            try
            {
                if (teste == "")
                {
                    teste = _logRepository.TotalRegistros().ToString();
                }

                ViewData["Message"] = "Total de acessos: " + teste;

                _logRepository.InsereLog("about");
            }
            catch(Exception ex)
            {
                throw ex;
            }

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            try
            {
                _logRepository.InsereLog("contact");
            }
            catch(Exception ex)
            {
                throw ex;
            }

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
