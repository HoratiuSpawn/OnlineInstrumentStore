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
        [Authorize(Roles = "Admin, User")]
        // GET: Customer
        public ActionResult Index()
        {
            List<CustomerModels> customers = customerRepository.GetAllCustomers();

            return View("IndexCustomer", customers);
        }
        [Authorize(Roles = "Admin, User")]
        // GET: Customer/Details/5
        public ActionResult Details(Guid id)
        {
            CustomerModels customerModels = customerRepository.GetCustomerById(id);

            return View("CustomerDetails", customerModels);
        }
        [Authorize(Roles = "Admin, User")]
        // GET: Customer/Create
        public ActionResult Create()
        {
            return View("CreateCustomer");
        }
        [Authorize(Roles = "Admin, User")]
        // POST: Customer/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                CustomerModels customerModels = new CustomerModels();
                UpdateModel(customerModels);

                customerRepository.InsertCustomer(customerModels);

                return RedirectToAction("Index");
            }
            catch
            {
                return View("CreateCustomer");
            }
        }
        [Authorize(Roles = "Admin, User")]
        // GET: Customer/Edit/5
        public ActionResult Edit(Guid id)
        {
            CustomerModels customerModels = customerRepository.GetCustomerById(id);

            return View("EditCustomer", customerModels);
        }
        [Authorize(Roles = "Admin, User")]
        // POST: Customer/Edit/5
        [HttpPost]
        public ActionResult Edit(Guid id, FormCollection collection)
        {
            try
            {
                CustomerModels customerModels = new CustomerModels();

                UpdateModel(customerModels);
                customerModels.IdCustomer = id;

                customerRepository.UpdateCustomer(customerModels);

                return RedirectToAction("Index");
            }
            catch
            {
                return View("EditCustomer");
            }
        }
        [Authorize(Roles = "Admin")]
        // GET: Customer/Delete/5
        public ActionResult Delete(Guid id)
        {
            CustomerModels customerModels = customerRepository.GetCustomerById(id);

            return View("DeleteCustomer", customerModels);
        }
        [Authorize(Roles = "Admin")]
        // POST: Customer/Delete/5
        [HttpPost]
        public ActionResult Delete(Guid id, FormCollection collection)
        {
            try
            {
                customerRepository.DeleteCustomer(id);

                return RedirectToAction("Index");
            }
            catch
            {
                return View("DeleteCustomer");
            }
        }
    }
}
