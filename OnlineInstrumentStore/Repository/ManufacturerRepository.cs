using OnlineInstrumentStore.Models;
using OnlineInstrumentStore.Models.DBObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineInstrumentStore.Repository
{
    public class ManufacturerRepository
    {
        private Models.DBObjects.OnlineInstrumentStoreDataContextDataContext dbContext;

        public ManufacturerRepository()
        {
            dbContext = new Models.DBObjects.OnlineInstrumentStoreDataContextDataContext();
        }
        public ManufacturerRepository(OnlineInstrumentStoreDataContextDataContext _dbContext)
        {
            dbContext = _dbContext;
        }

        public List<ManufacturerModels> GetAllManufacturers()
        {
            List<ManufacturerModels> manufacturerList = new List<ManufacturerModels>();
            foreach (Manufacturer dbManufacturer in dbContext.Manufacturers)
            {
                manufacturerList.Add(MapDbObjectToModel(dbManufacturer));
            }
            return manufacturerList;
        }

        public ManufacturerModels GetManufacturerById(Guid ID)
        {
            var manufacturer = dbContext.Manufacturers.FirstOrDefault(x => x.IDManufacturer == ID);

            return MapDbObjectToModel(manufacturer);
        }

        public void InsertManufacturer(ManufacturerModels manufacturer)
        {
            manufacturer.IDManufacturer = Guid.NewGuid();

            dbContext.Manufacturers.InsertOnSubmit(MapModelToDbObject(manufacturer));
            dbContext.SubmitChanges();
        }

        public void UpdateManufacturer(ManufacturerModels manufacturer)
        {
            Manufacturer manufacturerDb = dbContext.Manufacturers.FirstOrDefault(x => x.IDManufacturer == manufacturer.IDManufacturer);
            if (manufacturerDb != null)
            {
                manufacturerDb.IDManufacturer = manufacturer.IDManufacturer;
                manufacturerDb.ManufacturerName = manufacturer.ManufacturerName;
                dbContext.SubmitChanges();
            }
        }
        public void DeleteManufacturer(Guid ID)
        {
            Manufacturer manufacturerDb = dbContext.Manufacturers.FirstOrDefault(x => x.IDManufacturer == ID);
            if (manufacturerDb != null)
            {
                dbContext.Manufacturers.DeleteOnSubmit(manufacturerDb);
                dbContext.SubmitChanges();
            }
        }

        private Manufacturer MapModelToDbObject(ManufacturerModels manufacturer)
        {
            Manufacturer manufacturerDb = new Manufacturer();
            if (manufacturer != null)
            {
                manufacturerDb.IDManufacturer = manufacturer.IDManufacturer;
                manufacturerDb.ManufacturerName = manufacturer.ManufacturerName;

                return manufacturerDb;
            }
            return null;
        }

        private ManufacturerModels MapDbObjectToModel(Manufacturer dbManufacturer)
        {
            ManufacturerModels manufacturer = new ManufacturerModels();

            if (dbManufacturer != null)
            {
                manufacturer.IDManufacturer = dbManufacturer.IDManufacturer;
                manufacturer.ManufacturerName = dbManufacturer.ManufacturerName;
                
                return manufacturer;
            }
            return null;
        }
    }
}