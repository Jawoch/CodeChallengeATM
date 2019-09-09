using System;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using CodeChallengeATM.Models;
using CodeChallengeATM.Services;

namespace CodeChallengeATM.Controllers
{
    public class HomeController : Controller
    {
        private readonly IAtmService _atmService;
        public HomeController(IAtmService atmService)
        {
            _atmService = atmService;
        }
        [HttpPost]
        public IActionResult Index(InputForm form)
        {
            if (!ModelState.IsValid)
                return View();

            try
            {
                form.Results = _atmService.GetNotes(form);
            }
            catch (Exception e)
            {
                form.ExceptionMessage = e.Message;
            }
            return View(form);
        }
        public IActionResult Index()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
