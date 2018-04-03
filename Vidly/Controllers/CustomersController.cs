using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using System.Data.Entity;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        private ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Customers
        public ViewResult Index()
        {
            
            var customer = _context.Customers.Include(c => c.MembershipType).ToList();

            return View(customer);
        }

        public ActionResult Details(int id)
        {
           // var customer = GetCustomers().SingleOrDefault(c => c.Id == id);
            var customer = _context.Customers.Include(c => c.MembershipType).SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return HttpNotFound();

            return View(customer);
        }

        public ActionResult New()
        {
            //create a viewmodel to get both customer and membership types
            var viewModel = new NewCustomerViewModel
            {
                MembershipTypes = _context.MemberShipTypes
            };
           
            return View(viewModel);
        }

        //Automatically map request data to this obj NewCustomerViewModel - Model binding example
        [HttpPost]
        public ActionResult Create(Customer customer)
        {
            //adds record as added modified or deleted, cache obj
            _context.Customers.Add(customer);
            //either all changes are persisted or none.
            _context.SaveChanges();
            return RedirectToAction("Index", "Customers");
        }
        //private IEnumerable<Customer> GetCustomers()
        //{
        //    return new List<Customer>
        //    {
        //        new Customer {Id = 1, Name = "John Smith"},
        //        new Customer {Id = 2, Name = "Mary Williams"}
        //    };
        //}
    }
}