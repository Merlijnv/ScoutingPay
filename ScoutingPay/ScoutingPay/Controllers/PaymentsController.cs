using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ScoutingPay.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ScoutingPay.Controllers
{
    public class PaymentsController : Controller
    {
        private readonly ILogger<PaymentsController> _logger;

        public PaymentsController(ILogger<PaymentsController> logger)
        {
            _logger = logger;
        }


        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }


        // GET: /<controller>/Create
        public IActionResult Create()
        {
            Person person = new Person(1, "Merlijn Vermeer", "merlijnvermeer@gmail.com",1);
            PaymentRequest model = new PaymentRequest(person, new List<Product>());
            return View(model);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
