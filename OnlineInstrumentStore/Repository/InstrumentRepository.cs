using OnlineInstrumentStore.Models;
using OnlineInstrumentStore.Models.DBObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineInstrumentStore.Repository
{
    public class InstrumentRepository
    {
        private Models.DBObjects.OnlineInstrumentStoreDataContextDataContext dbContext;

        public InstrumentRepository()
        {
            dbContext = new Models.DBObjects.OnlineInstrumentStoreDataContextDataContext();
        }
        public InstrumentRepository(OnlineInstrumentStoreDataContextDataContext _dbContext)
        {
            dbContext = _dbContext;
        }
        public List<InstrumentModels> GetAllInstruments()
        {
            List<InstrumentModels> instrumentList = new List<InstrumentModels>();
            foreach (Instrument dbInstrument in dbContext.Instruments)
            {
                instrumentList.Add(MapDbObjectToModel(dbInstrument));
            }
            return instrumentList;
        }

        public InstrumentModels GetInstrumentById(Guid ID)
        {
            var instrument = dbContext.Instruments.FirstOrDefault(x => x.IDInstrument == ID);

            return MapDbObjectToModel(instrument);
        }

        public void InsertInstrument(InstrumentModels instrument)
        {
            instrument.IDInstrument = Guid.NewGuid();

            dbContext.Instruments.InsertOnSubmit(MapModelToDbObject(instrument));
            dbContext.SubmitChanges();
        }

        public void UpdateInstrument(InstrumentModels instrument)
        {
            Instrument instrumentDb = dbContext.Instruments.FirstOrDefault(x => x.IDInstrument == instrument.IDInstrument);
            if (instrumentDb != null)
            {
                instrumentDb.IDInstrument = instrument.IDInstrument;
                instrumentDb.IDManufacturer = instrument.IDManufacturer;
                instrumentDb.InstrumentName = instrument.InstrumentName;
                instrumentDb.InstrumentType = instrument.InstrumentType;
                instrumentDb.Description = instrument.Description;
                instrumentDb.Price = instrument.Price;
                dbContext.SubmitChanges();
            }
        }
        public void DeleteInstrument(Guid ID)
        {
            Instrument instrumentDb = dbContext.Instruments.FirstOrDefault(x => x.IDInstrument == ID);
            if (instrumentDb != null)
            {
                dbContext.Instruments.DeleteOnSubmit(instrumentDb);
                dbContext.SubmitChanges();
            }
        }

        private InstrumentModels MapDbObjectToModel(Instrument dbInstrument)
        {
            InstrumentModels instrument = new InstrumentModels();

            if (dbInstrument != null)
            {
                instrument.IDInstrument = dbInstrument.IDInstrument;
                instrument.IDManufacturer = dbInstrument.IDManufacturer;
                instrument.InstrumentName = dbInstrument.InstrumentName;
                instrument.InstrumentType = dbInstrument.InstrumentType;
                instrument.Description = dbInstrument.Description;
                instrument.Price = dbInstrument.Price;

                return instrument;
            }
            return null;
        }
        private Instrument MapModelToDbObject(InstrumentModels instrument)
        {
            Instrument instrumentDb = new Instrument();
            if (instrument != null)
            {
                instrumentDb.IDInstrument = instrument.IDInstrument;
                instrumentDb.IDManufacturer = instrument.IDManufacturer;
                instrumentDb.InstrumentName = instrument.InstrumentName;
                instrumentDb.InstrumentType = instrument.InstrumentType;
                instrumentDb.Description = instrument.Description;
                instrumentDb.Price = instrument.Price;

                return instrumentDb;
            }
            return null;
        }



    }
}