using OnlineInstrumentStore.Models;
using OnlineInstrumentStore.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineInstrumentStore.Controllers
{
    public class ManufacturerController : Controller
    {
        private ManufacturerRepository manufacturerRepository = new ManufacturerRepository();

        // GET: Manufacturer
        public ActionResult Index()
        {
            List<ManufacturerModels> manufacturers = manufacturerRepository.GetAllManufacturers();

            return View("IndexManufacturer", manufacturers);
        }

        // GET: Manufacturer/Details/5
        public ActionResult Details(Guid id)
        {
            ManufacturerModels manufacturerModels = manufacturerRepository.GetManufacturerById(id);

            return View("ManufacturerDetails", manufacturerModels);
        }

        // GET: Manufacturer/Create
        public ActionResult Create()
        {
            return View("CreateManufacturer");
        }

        // POST: Manufacturer/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                ManufacturerModels manufacturerModels = new ManufacturerModels();
                UpdateModel(manufacturerModels);

                manufacturerRepository.InsertManufacturer(manufacturerModels);

                return RedirectToAction("Index");
            }
            catch
            {
                return View("CreateManufacturer");
            }
        }

        // GET: Manufacturer/Edit/5
        public ActionResult Edit(Guid id)
        {
            ManufacturerModels manufacturerModels = manufacturerRepository.GetManufacturerById(id);

            return View("EditManufacurer", manufacturerModels);
        }

        // POST: Manufacturer/Edit/5
        [HttpPost]
        public ActionResult Edit(Guid id, FormCollection collection)
        {
            try
            {
                ManufacturerModels manufacturerModels = new ManufacturerModels();

                UpdateModel(manufacturerModels);

                manufacturerRepository.UpdateManufacturer(manufacturerModels);

                return RedirectToAction("Index");
            }
            catch
            {
                return View("EditManufacurer");
            }
        }

        // GET: Manufacturer/Delete/5
        public ActionResult Delete(Guid id)
        {
            ManufacturerModels manufacturerModels = manufacturerRepository.GetManufacturerById(id);

            return View("DeleteManufacturer", manufacturerModels);
        }

        // POST: Manufacturer/Delete/5
        [HttpPost]
        public ActionResult Delete(Guid id, FormCollection collection)
        {
            try
            {
                manufacturerRepository.DeleteManufacturer(id);

                return RedirectToAction("Index");
            }
            catch
            {
                return View("DeleteManufacturer");
            }
        }
    }
}
