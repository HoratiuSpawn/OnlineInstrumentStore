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
        [Authorize(Roles = "User, Admin")]
        // GET: Manufacturer
        public ActionResult Index(string sortOrder)
        {
            ViewBag.NameSortParam = string.IsNullOrEmpty(sortOrder) ? "ManufacturerName" : "";
            List<ManufacturerModels> manufacturers = manufacturerRepository.GetAllManufacturers();

            switch (sortOrder)
            {
                case "ManufacturerName":
                    manufacturers = manufacturers.OrderByDescending(m => m.ManufacturerName).ToList();
                    break;
                default:
                    manufacturers = manufacturers.OrderBy(m => m.ManufacturerName).ToList();
                    break;
            }

            return View("IndexManufacturer", manufacturers);
        }
        [Authorize(Roles = "User, Admin")]
        // GET: Manufacturer/Details/5
        public ActionResult Details(Guid id)
        {
            ManufacturerModels manufacturerModels = manufacturerRepository.GetManufacturerById(id);

            return View("ManufacturerDetails", manufacturerModels);
        }
        [Authorize(Roles = "Admin")]
        // GET: Manufacturer/Create
        public ActionResult Create()
        {
            return View("CreateManufacturer");
        }
        [Authorize(Roles = "Admin")]
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
        [Authorize(Roles = "Admin")]
        // GET: Manufacturer/Edit/5
        public ActionResult Edit(Guid id)
        {
            ManufacturerModels manufacturerModels = manufacturerRepository.GetManufacturerById(id);

            return View("EditManufacturer", manufacturerModels);
        }
        [Authorize(Roles = "Admin")]
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
                return View("EditManufacturer");
            }
        }
        [Authorize(Roles = "Admin")]
        // GET: Manufacturer/Delete/5
        public ActionResult Delete(Guid id)
        {
            ManufacturerModels manufacturerModels = manufacturerRepository.GetManufacturerById(id);

            return View("DeleteManufacturer", manufacturerModels);
        }
        [Authorize(Roles = "Admin")]
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
