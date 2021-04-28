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

        [Authorize(Roles = "User, Admin")]
        // GET: Order
        public ActionResult Index()
        {
            List<OrderModels> orders = orderRepository.GetAllOrdersByCustomer(CustomerRepository.GetCustomerByEmail(User.Identity.Name).IdCustomer);
            List<OrderViewModel> orderViewModels = new List<OrderViewModel>();

            foreach (OrderModels item in orders)
            {
                OrderViewModel orderViewModel= new OrderViewModel();
                orderViewModel.IDOrder = item.IDOrder;
                orderViewModel.Data = item.Date;
                orderViewModel.DeliveryAddress = item.DeliveryAddress;
                orderViewModel.IDInstrumentName = InstrumentRepository.GetInstrumentById(item.IDInstrument).InstrumentName;
                orderViewModel.Quantity = item.Quantity;
                orderViewModel.TotalPrice = item.TotalPrice;
                orderViewModels.Add(orderViewModel);
            }

            return View("IndexOrders", orderViewModels);
        }
        [Authorize(Roles = "User, Admin")]
        // GET: Order/Details/5
        public ActionResult Details(Guid id)
        {
            OrderModels orderModels = orderRepository.GetOrderById(id);

            return View("OrderDetails", orderModels);
        }
        [Authorize(Roles = "User, Admin")]
        // GET: Order/Create
        public ActionResult Create()
        {
            return View("CreateOrder");
        }
        [Authorize(Roles = "User, Admin")]
        // POST: Order/Create
        [HttpPost]
        public ActionResult Create(Guid ID, FormCollection collection)
        {


            try
            {
                OrderModels orderModels = new OrderModels();
                InstrumentModels instrument = new InstrumentModels();
                CustomerModels customer = new CustomerModels();
                string email = User.Identity.Name;
                instrument = InstrumentRepository.GetInstrumentById(ID);
                UpdateModel(orderModels);
                orderModels.IDInstrument = ID;
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
        [Authorize(Roles = "User, Admin")]
        // GET: Order/Edit/5
        public ActionResult Edit(Guid id)
        {
            OrderModels orderModels = orderRepository.GetOrderById(id);

            return View("EditOrder", orderModels);
        }
        [Authorize(Roles = "User, Admin")]
        // POST: Order/Edit/5
        [HttpPost]
        public ActionResult Edit(Guid id, FormCollection collection)
        {
            try
            {
                InstrumentModels instrument = new InstrumentModels();
                OrderModels orderModels = new OrderModels();
                orderModels= orderRepository.GetOrderById(id);
                instrument = InstrumentRepository.GetInstrumentById(orderModels.IDInstrument);
                UpdateModel(orderModels);
                orderModels.TotalPrice = orderModels.Quantity * instrument.Price;

                orderRepository.UpdateOrder(orderModels);

                return RedirectToAction("Index");
            }
            catch
            {
                return View("EditOrder");
            }
        }
        [Authorize(Roles = "User, Admin")]
        // GET: Order/Delete/5
        public ActionResult Delete(Guid id)
        {
            OrderModels orderModels = orderRepository.GetOrderById(id);

            return View("DeleteOrder", orderModels);
        }
        [Authorize(Roles = "User, Admin")]
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
