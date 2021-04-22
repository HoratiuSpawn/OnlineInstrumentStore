using OnlineInstrumentStore.Models;
using OnlineInstrumentStore.Models.DBObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineInstrumentStore.Repository
{
    public class CustomerRepository
    {
        private Models.DBObjects.OnlineInstrumentStoreDataContextDataContext dbContext;

        public CustomerRepository()
        {
            dbContext = new Models.DBObjects.OnlineInstrumentStoreDataContextDataContext();
        }

        public CustomerRepository(OnlineInstrumentStoreDataContextDataContext _dbContext)
        {
            dbContext = _dbContext;
        }

        public List<CustomerModels> GetAllCustomers()
        {
            List<CustomerModels> customerList = new List<CustomerModels>();
            foreach (Customer dbCustomer in dbContext.Customers)
            {
                customerList.Add(MapDbObjectToModel(dbCustomer));
            }
            return customerList;
        }

        public CustomerModels GetCustomerById(Guid ID)
        {
            Customer customer = dbContext.Customers.FirstOrDefault(x => x.IDCustomer == ID);

            return MapDbObjectToModel(customer);
        }
        public CustomerModels GetCustomerByEmail(string email)
        {
            Customer customer = dbContext.Customers.FirstOrDefault(x => x.Email == email);

            return MapDbObjectToModel(customer);
        }

        public void InsertCustomer(CustomerModels customer)
        {
            customer.IdCustomer = Guid.NewGuid();

            dbContext.Customers.InsertOnSubmit(MapModelToDbObject(customer));
            dbContext.SubmitChanges();
        }

        public void UpdateCustomer(CustomerModels customer)
        {
            Customer customerDb = dbContext.Customers.FirstOrDefault(x => x.IDCustomer == customer.IdCustomer);
            if (customerDb != null)
            {
                customerDb.IDCustomer = customer.IdCustomer;
                customerDb.CustomerName = customer.CustomerName;
                customerDb.Email = customer.Email;
                customerDb.Address = customer.Address;
                customerDb.Phone = customer.Phone;
                dbContext.SubmitChanges();
            }
        }

        public void DeleteCustomer(Guid ID)
        {
            Customer customerDb = dbContext.Customers.FirstOrDefault(x => x.IDCustomer == ID);
            if (customerDb != null)
            {
                dbContext.Customers.DeleteOnSubmit(customerDb);
                dbContext.SubmitChanges();
            }
        }



        private Customer MapModelToDbObject(CustomerModels customer)
        {
            Customer customerDb = new Customer();

            if (customer != null)
            {
                customerDb.IDCustomer = customer.IdCustomer;
                customerDb.CustomerName = customer.CustomerName;
                customerDb.Email = customer.Email;
                customerDb.Address = customer.Address;
                customerDb.Phone = customer.Phone;

                return customerDb;
            }
            return null;
        }

        private CustomerModels MapDbObjectToModel(Customer dbCustomer)
        {
            CustomerModels customer = new CustomerModels();
            if (dbCustomer != null)
            {
                customer.IdCustomer = dbCustomer.IDCustomer;
                customer.CustomerName = dbCustomer.CustomerName;
                customer.Email = dbCustomer.Email;
                customer.Address = dbCustomer.Address;
                customer.Phone = dbCustomer.Phone;

                return customer;
            }
            return null;
        }
    }
}