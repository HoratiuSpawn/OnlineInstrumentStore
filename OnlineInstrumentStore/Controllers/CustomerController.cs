using OnlineInstrumentStore.Models;
using OnlineInstrumentStore.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineInstrumentStore.Controllers
{
    public class CustomerController : Controller
    {
        private CustomerRepository customerRepository = new CustomerRepository();

        // GET: Customer
        public ActionResult Index()
        {
            List<CustomerModels> customers = customerRepository.GetAllCustomers();

            return View("Index", customers);
        }

        // GET: Customer/Details/5
        public ActionResult Details(Guid id)
        {
            CustomerModels customerModels = customerRepository.GetCustomerById(id);

            return View("CustomerDetails", customerModels);
        }

        // GET: Customer/Create
        public ActionResult Create()
        {
            return View("");
        }

        // POST: Customer/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Customer/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Customer/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Customer/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Customer/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
