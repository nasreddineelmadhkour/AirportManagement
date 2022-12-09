using AM.ApplicationCore.Domain;
using AM.ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Net.Sockets;

namespace AM.UI.WEB.Controllers
{
    public class TicketController : Controller
    {
        private readonly IServiceTicket _ticketService;
        private readonly IServicePassenger _passengerService;
        private readonly IServiceFlight _flighService;


        // GET: TicketController
        public TicketController(IServiceTicket _ticketService, IServiceFlight _flighService, IServicePassenger _passengerService)
        {
            this._passengerService = _passengerService;
            this._flighService = _flighService;
            this._ticketService=_ticketService;
        }
        public ActionResult Index()
        {
            return View(_ticketService.GetAll().ToList());
        }

        // GET: TicketController/Details/5
        public ActionResult Details(int? PassengerFK, int? FlightFK, int? TicketNbre)
        {
            var ticket = _ticketService.GetAll().FirstOrDefault(m => m.PassengerFK == PassengerFK && m.FlightFK == FlightFK
            && m.TicketNbre == TicketNbre);
            if (ticket == null)
            {
                return NotFound();
            }
            return View(ticket);
        }

        // GET: TicketController/Create
        public ActionResult Create()
        {
            ViewBag.PassengerFk = new SelectList(_passengerService.GetAll().ToList(), "Id", "FullName.FirstName");
            ViewBag.FlightFk = new SelectList(_flighService.GetAll().ToList(), "FlightId", "Destination");

            return View();
        }

        // POST: TicketController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Ticket ticket)
        {
            try
            {
                _ticketService.Add(ticket);
                _ticketService.Commit();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TicketController/Edit/5
        public ActionResult Edit(int? PassengerFK,int? FlightFK,int? TicketNbre)
        {
            if (TicketNbre == null || PassengerFK == null || FlightFK==null )
            {
                return NotFound();
            }

            var ticket = _ticketService.GetAll().FirstOrDefault(m=>m.PassengerFK==PassengerFK && m.FlightFK== FlightFK
            && m.TicketNbre==TicketNbre);
            if (ticket == null)
            {
                return NotFound();
            }
            return View(ticket);
        }

        // POST: TicketController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Ticket ticket)
        {
            try
            {
                _ticketService.Update(ticket);
                _ticketService.Commit();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TicketController/Delete/5
        public ActionResult Delete(int? PassengerFK, int? FlightFK, int? TicketNbre)
        {
            if (TicketNbre == null || PassengerFK == null || FlightFK == null)
            {
                return NotFound();
            }

            var ticket = _ticketService.GetAll().FirstOrDefault(m => m.PassengerFK == PassengerFK && m.FlightFK == FlightFK
            && m.TicketNbre == TicketNbre);
            if (ticket == null)
            {
                return NotFound();
            }
            return View(ticket);
        }

        // POST: TicketController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int PassengerFK, int FlightFK, int TicketNbre)
        {
            try
            {
                var ticket = _ticketService.GetAll()
                    .FirstOrDefault(m => m.PassengerFK == PassengerFK && m.FlightFK == FlightFK && m.TicketNbre == TicketNbre);
                _ticketService.Delete(ticket);
                _ticketService.Commit();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
