﻿using System;
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
            var viewModel = new CustomerFormViewModel
            {
                MembershipTypes = _context.MemberShipTypes
            };
           
            return View("CustomerForm", viewModel);
        }

        //Automatically map request data to this obj CustomerFormViewModel - Model binding example
        [HttpPost]
        public ActionResult Create(Customer customer)
        {
            //adds record as added modified or deleted, cache obj
            _context.Customers.Add(customer);
            //either all changes are persisted or none.
            _context.SaveChanges();
            return RedirectToAction("Index", "Customers");
        }



        public ActionResult Edit(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return HttpNotFound();

            var viewModel = new CustomerFormViewModel
            {
                Customer = customer,
                MembershipTypes = _context.MemberShipTypes.ToList()
            };
            //need specify viewname for returning New because it'll error trying to return Edit
            return View("CustomerForm", viewModel);
        }
    }
}