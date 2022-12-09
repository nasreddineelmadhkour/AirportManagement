using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AM.ApplicationCore.Interfaces;
using AM.ApplicationCore.Domain;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Numerics;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Http;
using System.IO;

namespace AM.UI.WEB.Controllers
{
    public class FlightController : Controller
    {
        private readonly IServiceFlight _flighService;
        private readonly IServicePlane _planeService;
        // GET: FlightController
        public FlightController(IServiceFlight _flighService , IServicePlane _planeService)
        {
            this._planeService = _planeService;
            this._flighService = _flighService;
        }
        public ActionResult Index(DateTime? dateDepart)
        {
            if(dateDepart == null)
            return View(_flighService.GetAll().ToList());
            else
                return View(_flighService.GetFlightByDate((DateTime) dateDepart).ToList());
        }

        // GET: FlightController/Details/5
        public ActionResult Details(int id)
        {
            var flight = _flighService.GetById((int)id);
            if (flight == null)
            {
                return NotFound();
            }
            return View(flight);
        }

        // GET: FlightController/Create
        public ActionResult Create()
            
        {
            ViewBag.Planes = new SelectList(_planeService.GetAll().ToList(),"PlaneId","Information");
            return View();
        }

        // POST: FlightController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Flight flight ,IFormFile AirlineImage)
        {
            try
            {
                if(AirlineImage != null)
                {
                    var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads", AirlineImage.FileName);
                    Stream stream = new FileStream(path,FileMode.Create);
                    AirlineImage.CopyTo(stream);
                    flight.Airline = AirlineImage.FileName;
                }
                _flighService.Add(flight);
                _flighService.Commit();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: FlightController/Edit/5
        public ActionResult Edit(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var flight = _flighService.GetById((int)id);
            if (flight == null)
            {
                return NotFound();
            }
            ViewBag.Planes = new SelectList(_planeService.GetAll().ToList(), "PlaneId", "Information", flight.PlaneId);
            return View(flight);
        }

        // POST: FlightController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Flight flight)
        {
            try
            {
                _flighService.Update(flight);
                _flighService.Commit();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: FlightController/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var flight = _flighService.GetById((int)id);
            if (flight == null)
            {
                return NotFound();
            }
            return View(flight);
        }

        // POST: FlightController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            try
            {
                var flight = _flighService.GetById((int)id);
                _flighService.Delete(flight);
                _flighService.Commit();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
