using AM.ApplicationCore.Domain;
using AM.ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AM.UI.WEB.Controllers
{
    public class PassengerController : Controller
    {
        private readonly IServicePassenger _passengerService;
        // GET: PassengerController

        public PassengerController(IServicePassenger _passengerService)
        {
            this._passengerService = _passengerService;
        }
        public ActionResult Index()
        {
            return View(_passengerService.GetAll().ToList());
        }

        // GET: PassengerController/Details/5
        public ActionResult Details(int id)
        {
            var passanger = _passengerService.GetById((int)id);
            if (passanger == null)
            {
                return NotFound();
            }
            return View(passanger);
        }

        // GET: PassengerController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PassengerController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Passenger passanger)
        {
            try
            {
                _passengerService.Add(passanger);
                _passengerService.Commit();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PassengerController/Edit/5
        public ActionResult Edit(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var passanger = _passengerService.GetById((int)id);
            if (passanger == null)
            {
                return NotFound();
            }
            return View(passanger);
        }

        // POST: PassengerController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Passenger passanger)
        {
            try
            {
                _passengerService.Update(passanger);
                _passengerService.Commit();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PassengerController/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var passanger = _passengerService.GetById((int)id);
            if (passanger == null)
            {
                return NotFound();
            }
            return View(passanger);
        }

        // POST: PassengerController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            try
            {
                var passanger = _passengerService.GetById((int)id);
                _passengerService.Delete(passanger);
                _passengerService.Commit();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
