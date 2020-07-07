using System.Collections.Generic;
using System.Data.Common;
using System.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using ScoutingPay.Common;
using ScoutingPay.Data.mssql;
using ScoutingPay.Data.repositories;
using ScoutingPay.Interfaces;
using ScoutingPay.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ScoutingPay.Controllers
{
    public class PaymentsController : Controller
    {
        private readonly ILogger<PaymentsController> _logger;
        private readonly IPersonRetrieveContext _iPersonRetContext;
        private readonly PersonRetRepository _personRetRepository;
        private readonly IProductRetrieveContext _iProductRetrieveContext;
        private readonly ProductRetRepository _productRetRepository;
        private readonly IPersonSaveContext _iPersonSaveContext;
        private readonly PersonSaveRepository _personSaveRepository;

        public PaymentsController(ILogger<PaymentsController> logger, IConfiguration configuration)
        {
            _logger = logger;
            string connectionString = configuration.GetConnectionString("DefaultConnection");
            _iProductRetrieveContext = new ProductMssqlContext(connectionString);
            _productRetRepository = new ProductRetRepository(_iProductRetrieveContext);
            _iPersonRetContext = new PersonMssqlContext(connectionString);
            _personRetRepository = new PersonRetRepository(_iPersonRetContext);
            _iPersonSaveContext = new PersonMssqlContext(connectionString);
            _personSaveRepository = new PersonSaveRepository(_iPersonSaveContext);
        }


        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }


        // GET: /<controller>/Create
        public IActionResult Create(PaymentRequestCreateViewmodel viewmodel)
        {
            List<Person> persons = _personRetRepository.GetAllActive();
            List<Product> products = new List<Product>(); 
            if (HttpContext.Session.GetComplexData<List<Product>>("productList") != null)
            {
                viewmodel.ProductOverview = HttpContext.Session.GetComplexData<List<Product>>("productList");
            }
            else
            {
                products = _productRetRepository.GetAll();
                HttpContext.Session.SetComplexData("productList",products);
            }

            int personenIndex;
            if (HttpContext.Session.GetInt32("personenIndex") == null)
            {
                HttpContext.Session.SetInt32("personenIndex",0);
                personenIndex = 0;
            }
            else
            {
                personenIndex = (int)HttpContext.Session.GetInt32("personenIndex");
            }
            
            if (viewmodel.ProductOverview.Count == 0)
            {
                viewmodel = new PaymentRequestCreateViewmodel(personenIndex,products,persons);
            }

            if (persons.Count > viewmodel.PersonIndex)
            {
                Person person = persons[viewmodel.PersonIndex];
                PaymentRequest model = new PaymentRequest(person, viewmodel.ProductOverview);
                viewmodel.SetModel(model);
                return View(viewmodel);
            }
            else
            {
                HttpContext.Session.Remove("personenIndex");
                HttpContext.Session.Remove("productList");
                return RedirectToAction("Index","Home");
            }
            
            
        }

        
        public IActionResult Next(PaymentRequestCreateViewmodel viewmodel) //Save and to next person
        {
            //save info
            if (HttpContext.Session.GetInt32("personenIndex") != null)
            {
                viewmodel.PersonIndex = (int) HttpContext.Session.GetInt32("personenIndex");
            }
            
            viewmodel.NextIndex();
            HttpContext.Session.SetInt32("personenIndex",viewmodel.PersonIndex);
            return RedirectToAction("Create", viewmodel);
        }

        public IActionResult Skip(PaymentRequestCreateViewmodel viewmodel) //Put person as Inactive and to next person
        {
            Person person = new Person();
            //Set to inactive
            if (HttpContext.Session.GetInt32("personenIndex") != null)
            {
                List<Person> persons = _personRetRepository.GetAllActive();
                viewmodel.PersonIndex = (int) HttpContext.Session.GetInt32("personenIndex");
                person = persons[viewmodel.PersonIndex];
            }

            if (person.BonNr != null)
            {
                person.changeActivity();
                _personSaveRepository.UpdatePerson(person);
            }


            viewmodel.NextIndex();
            HttpContext.Session.SetInt32("personenIndex",viewmodel.PersonIndex);

            return RedirectToAction("Create",viewmodel);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
        }
    }
}