using OnlineInstrumentStore.Models;
using OnlineInstrumentStore.Repository;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineInstrumentStore.Controllers
{
    public class InstrumentController : Controller
    {
        private InstrumentRepository instrumentRepository = new InstrumentRepository();

        private ManufacturerRepository manufacturerRepository = new ManufacturerRepository();


        [Authorize(Roles = "User, Admin")]
        // GET: Instrument
        public ActionResult Index(string sortOrder)
        {

            ViewBag.NameSortParam = string.IsNullOrEmpty(sortOrder) ? "InstrumentName" : "";
            ViewBag.TypeSortParam = sortOrder == "InstrumentType" ? "InstrumentType_desc" : "InstrumentType";
            List<InstrumentModels> instrument = instrumentRepository.GetAllInstruments();

            switch (sortOrder)
            {
                case "InstrumentName":
                    instrument = instrument.OrderByDescending(s => s.InstrumentName).ToList();
                    break;
                case "InstrumentType":
                    instrument = instrument.OrderBy(s => s.InstrumentType).ToList();
                    break;
                case "InstrumentType_desc":
                    instrument = instrument.OrderByDescending(s => s.InstrumentType).ToList();
                    break;
                default:
                    instrument = instrument.OrderBy(s => s.InstrumentName).ToList();
                    break;

            }


            List<InstrumentModels> instruments = instrumentRepository.GetAllInstruments();



            return View("IndexInstrument", instrument);
        }

        [Authorize(Roles = "User, Admin")]
        // GET: Instrument/Details/5
        public ActionResult Details(Guid id)
        {
            InstrumentModels instrumentModels = instrumentRepository.GetInstrumentById(id);
            return View("InstrumentDetails", instrumentModels);
        }
        [Authorize(Roles = "Admin")]
        // GET: Instrument/Create
        public ActionResult Create()
        {
            //List<Guid> ManufacturerID = new List<Guid>();
            //foreach (var item in manufacturerRepository.GetManufacturerById())
            //{
            //    ManufacturerID.Add(item.IDManufacturer);
            //}
            //ViewBag.ManufacturerName = ManufacturerID;
            return View("Create");
        }
        [Authorize(Roles = "Admin")]
        // POST: Instrument/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                InstrumentModels instrumentModels = new InstrumentModels();
                UpdateModel(instrumentModels);


                instrumentRepository.InsertInstrument(instrumentModels);

                return RedirectToAction("Index");
            }
            catch
            {
                return View("Create");
            }
        }
        [Authorize(Roles = "Admin")]
        // GET: Instrument/Edit/5
        public ActionResult Edit(Guid id)
        {
            InstrumentModels instrumentModels = instrumentRepository.GetInstrumentById(id);

            return View("EditInstrument", instrumentModels);
        }
        [Authorize(Roles = "Admin")]
        // POST: Instrument/Edit/5
        [HttpPost]
        public ActionResult Edit(Guid id, FormCollection collection)
        {
            try
            {
                InstrumentModels instrumentModels = new InstrumentModels();
                UpdateModel(instrumentModels);
                instrumentRepository.UpdateInstrument(instrumentModels);

                return RedirectToAction("Index");
            }
            catch
            {
                return View("EditInstrument");
            }
        }
        [Authorize(Roles = "Admin")]
        // GET: Instrument/Delete/5
        public ActionResult Delete(Guid id)
        {
            InstrumentModels instrumentModels = instrumentRepository.GetInstrumentById(id);

            return View("DeleteInstrument", instrumentModels);
        }
        [Authorize(Roles = "Admin")]
        // POST: Instrument/Delete/5
        [HttpPost]
        public ActionResult Delete(Guid id, FormCollection collection)
        {
            try
            {
                instrumentRepository.DeleteInstrument(id);

                return RedirectToAction("Index");
            }
            catch
            {
                return View("DeleteInstrument");
            }
        }

        public ActionResult AddToCart(Guid id)
        {
            InstrumentModels instrumentModels = instrumentRepository.GetInstrumentById(id);

            return View("AddToCart", instrumentModels);

        }

    }
}
