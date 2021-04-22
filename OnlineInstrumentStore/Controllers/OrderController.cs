using OnlineInstrumentStore.Models;
using OnlineInstrumentStore.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineInstrumentStore.Controllers
{
    public class OrderController : Controller
    {
        private OrderRepository orderRepository = new OrderRepository();

        private InstrumentRepository InstrumentRepository = new InstrumentRepository();

        private CustomerRepository CustomerRepository = new CustomerRepository();
        

        // GET: Order
        public ActionResult Index()
        {
            List<OrderModels> orders = orderRepository.GetAllOrders();

            return View("IndexOrders", orders);
        }

        // GET: Order/Details/5
        public ActionResult Details(Guid id)
        {
            OrderModels orderModels = orderRepository.GetOrderById(id);

            return View("OrderDetails", orderModels);
        }

        // GET: Order/Create
        public ActionResult Create()
        {
            return View("CreateOrder");
        }

        // POST: Order/Create
        [HttpPost]
        public ActionResult Create(Guid IDInstrument, FormCollection collection)
        {


            try
            {
                OrderModels orderModels = new OrderModels();
                InstrumentModels instrument = new InstrumentModels();
                CustomerModels customer = new CustomerModels();
                string email = User.Identity.Name;
                instrument = InstrumentRepository.GetInstrumentById(IDInstrument);
                UpdateModel(orderModels);
                orderModels.IDInstrument = IDInstrument;
                orderModels.IDCustomer = CustomerRepository.GetCustomerByEmail(email).IdCustomer;
                orderModels.Date = DateTime.UtcNow;
                orderModels.TotalPrice = orderModels.Quantity * instrument.Price;


                orderRepository.InsertOrder(orderModels);

                return RedirectToAction("Index");
            }
            catch
            {
                return View("CreateOrder");
            }
        }

        // GET: Order/Edit/5
        public ActionResult Edit(Guid id)
        {
            OrderModels orderModels = orderRepository.GetOrderById(id);

            return View("EditOrder", orderModels);
        }

        // POST: Order/Edit/5
        [HttpPost]
        public ActionResult Edit(Guid id, FormCollection collection)
        {
            try
            {
                OrderModels orderModels = new OrderModels();

                UpdateModel(orderModels);

                orderRepository.UpdateOrder(orderModels);

                return RedirectToAction("Index");
            }
            catch
            {
                return View("EditOrder");
            }
        }

        // GET: Order/Delete/5
        public ActionResult Delete(Guid id)
        {
            OrderModels orderModels = orderRepository.GetOrderById(id);

            return View("DeleteOrder", orderModels);
        }

        // POST: Order/Delete/5
        [HttpPost]
        public ActionResult Delete(Guid id, FormCollection collection)
        {
            try
            {
                orderRepository.DeleteOrder(id);

                return RedirectToAction("Index");
            }
            catch
            {
                return View("DeleteOrder");
            }
        }
    }
}
