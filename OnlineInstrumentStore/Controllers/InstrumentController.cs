using OnlineInstrumentStore.Models;
using OnlineInstrumentStore.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineInstrumentStore.Controllers
{
    public class InstrumentController : Controller
    {
        private InstrumentRepository instrumentRepository = new InstrumentRepository();

        [AllowAnonymous]

        // GET: Instrument
        public ActionResult Index()
        {
            List<InstrumentModels> instruments = instrumentRepository.GetAllInstruments();

            return View("Index", instruments);
        }

        // GET: Instrument/Details/5
        public ActionResult Details(Guid id)
        {
            InstrumentModels instrumentModels = instrumentRepository.GetInstrumentById(id);
            return View("InstrumentDetails", instrumentModels);
        }

        // GET: Instrument/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Instrument/Create
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

        // GET: Instrument/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Instrument/Edit/5
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

        // GET: Instrument/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Instrument/Delete/5
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
