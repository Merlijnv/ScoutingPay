using System.Collections.Generic;
using System.Data.Common;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using ScoutingPay.Data.mssql;
using ScoutingPay.Data.repositories;
using ScoutingPay.Interfaces;
using ScoutingPay.Models;

namespace ScoutingPay.Controllers
{
    public class PersonController : Controller
    {
        private readonly ILogger<PersonController> _logger;
        private readonly IPersonRetrieveContext _iPersonRetContext;
        private readonly PersonRetRepository _personRetRepository;

        public PersonController(ILogger<PersonController> logger, IConfiguration configuration)
        {
            string connectionString = configuration.GetConnectionString("DefaultConnection");
            _iPersonRetContext = new PersonMssqlContext(connectionString);
            _personRetRepository = new PersonRetRepository(_iPersonRetContext);
            _logger = logger;
        }


        // GET: /<controller>/
        public IActionResult Index()
        {
            var viewModel = new PersonListViewModel();
            viewModel.Persons = _personRetRepository.GetAllActive();
            
            return View(viewModel);
        }
    }
}