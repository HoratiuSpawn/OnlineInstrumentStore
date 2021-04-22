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

            return View("IndexCustomer", customers);
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
            return View("CreateCustomer");
        }

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

        // GET: Customer/Edit/5
        public ActionResult Edit(Guid id)
        {
            CustomerModels customerModels = customerRepository.GetCustomerById(id);

            return View("EditCustomer", customerModels);
        }

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

        // GET: Customer/Delete/5
        public ActionResult Delete(Guid id)
        {
            CustomerModels customerModels = customerRepository.GetCustomerById(id);

            return View("DeleteCustomer", customerModels);
        }

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
