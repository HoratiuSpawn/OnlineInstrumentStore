using OnlineInstrumentStore.Models;
using OnlineInstrumentStore.Models.DBObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineInstrumentStore.Repository
{
    public class OrderRepository
    {
        private Models.DBObjects.OnlineInstrumentStoreDataContextDataContext dbContext;

        public OrderRepository()
        {
            dbContext = new Models.DBObjects.OnlineInstrumentStoreDataContextDataContext();
        }
        public OrderRepository(OnlineInstrumentStoreDataContextDataContext _dbContext)
        {
            dbContext = _dbContext;
        }
        public List<OrderModels> GetAllOrders()
        {
            List<OrderModels> orderList = new List<OrderModels>();
            foreach (Order dbOrder in dbContext.Orders)
            {
                orderList.Add(MapDbObjectToModel(dbOrder));
            }
            return orderList;
        }

        public OrderModels GetOrderById(Guid ID)
        {
            var order = dbContext.Orders.FirstOrDefault(x => x.IDOrder == ID);

            return MapDbObjectToModel(order);
        }
        public List<OrderModels> GetOrdersByDate(DateTime date)
        {
            List<OrderModels> orderList = new List<OrderModels>();

            foreach (Order dbOrder in dbContext.Orders.Where(x => x.Date == date))
            {
                AddDbObjectToModelcollection(orderList, dbOrder);
            }
            return orderList;
        }

        private void AddDbObjectToModelcollection(List<OrderModels> orderList, Order dbOrder)
        {
            orderList.Add(MapDbObjectToModel(dbOrder));
        }

        public void InsertOrder(OrderModels order)
        {
            order.IDOrder = Guid.NewGuid();

            dbContext.Orders.InsertOnSubmit(MapModelToDbObject(order));
            dbContext.SubmitChanges();
        }

        public void UpdateOrder(OrderModels order)
        {
            Order orderDb = dbContext.Orders.FirstOrDefault(x => x.IDOrder == order.IDOrder);
            if (orderDb != null)
            {
                orderDb.IDOrder = order.IDOrder;
                orderDb.IDCustomer = order.IDCustomer;
                orderDb.DeliveryAdress = order.DeliveryAddress;
                orderDb.IDInstrument = order.IDInstrument;
                orderDb.Quantity = order.Quantity;
                orderDb.Date = order.Date;
                orderDb.TotalPrice = order.TotalPrice;
                dbContext.SubmitChanges();
            }
        }

        public void DeleteOrder(Guid ID)
        {
            Order orderDb = dbContext.Orders.FirstOrDefault(x => x.IDOrder == ID);
            if (orderDb != null)
            {
                dbContext.Orders.DeleteOnSubmit(orderDb);
                dbContext.SubmitChanges();
            }
                
        }

        private Order MapModelToDbObject(OrderModels order)
        {
            Order orderDb = new Order();
            if (order != null)
            {
                orderDb.IDOrder = order.IDOrder;
                orderDb.IDCustomer = order.IDCustomer;
                orderDb.DeliveryAdress = order.DeliveryAddress;
                orderDb.IDInstrument = order.IDInstrument;
                orderDb.Quantity = order.Quantity;
                orderDb.Date = order.Date;
                orderDb.TotalPrice = order.TotalPrice;

                return orderDb;
            }
            return null;
        }

        private OrderModels MapDbObjectToModel(Order dbOrder)
        {
            OrderModels order = new OrderModels();
            if (dbOrder != null)
            {
                order.IDOrder = dbOrder.IDOrder;
                order.IDCustomer = dbOrder.IDCustomer;
                order.DeliveryAddress = dbOrder.DeliveryAdress;
                order.IDInstrument = dbOrder.IDInstrument;
                order.Quantity = dbOrder.Quantity;
                order.Date = dbOrder.Date;
                order.TotalPrice = dbOrder.TotalPrice;
                
                return order;
            }
            return null;
        }
    }
}