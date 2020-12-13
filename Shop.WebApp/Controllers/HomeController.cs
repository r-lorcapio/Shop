using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Shop.AzureQueueLibrary.Messages;
using Shop.AzureQueueLibrary.QueueConnection;
using Shop.WebApp.Models;

namespace Shop.WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IQueueCommunicator communicator;

        public HomeController(IQueueCommunicator communicator)
        {
            this.communicator = communicator;
        }


        public async Task<IActionResult>  Index()
        {
            var thk = new SendEmailCommand
            {
                To = "r_lorcapiote",
                Body = "teste",
                Subject = "ddd"
            };

            await communicator.SendAsync(thk);

            ViewBag.Message = "Valeu";
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public async Task<IActionResult>  ContactUs()
        {

            var thk = new SendEmailCommand
            {
                To = "r_lorcapiote",
                Body = "teste",
                Subject = "ddd"
            };

            await communicator.SendAsync(thk);
            
            ViewBag.Message = "Valeu";
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
