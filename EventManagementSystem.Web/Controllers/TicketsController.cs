using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EventManagamentSystem.Domain.Entities;
using EventManagementSystem.Repository;
using EventManagementSystem.Service.Interfaces;

namespace EventManagementSystem.Web.Controllers
{
    public class TicketsController : Controller
    {
        private readonly ITicketService ticketService;
        private readonly IEventService eventService;
        private readonly IAttendeeService attendeeService;
        public TicketsController(ITicketService ticketService, IEventService eventService, IAttendeeService attendeeService)
        {
            this.ticketService = ticketService;
            this.eventService = eventService;
            this.attendeeService = attendeeService;
        }


        // GET: Tickets
        public IActionResult Index()
        {
            var tickets = ticketService.GetTickets();
            return View(tickets);
        }

        // GET: Tickets/Details/5
        public IActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ticket = ticketService.GetTicket(id);
            if (ticket == null)
            {
                return NotFound();
            }

            return View(ticket);
        }

        // GET: Tickets/Create
        public IActionResult Create()
        {
            var events = eventService.GetEvents();
            var attendees = attendeeService.GetAllAttendees();
            ViewData["EventId"] = new SelectList(events, "Id", "Title");
            ViewData["AttendeeId"] = new SelectList(attendees, "Id", "Name");
            return View();
        }

        // POST: Tickets/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("EventId,AttendeeId,Price,IssuedDate,Id")] Ticket ticket)
        {
            if (ModelState.IsValid)
            {
                ticket.Id = Guid.NewGuid();
                ticketService.InsertTicket(ticket);
                return RedirectToAction(nameof(Index));
            }
            var events = eventService.GetEvents();
            var attendees = attendeeService.GetAllAttendees();
            ViewData["EventId"] = new SelectList(events, "Id", "Title", ticket.EventId);
            ViewData["AttendeeId"] = new SelectList(attendees, "Id", "Name", ticket.AttendeeId);
            return View(ticket);
        }

        // GET: Tickets/Edit/5
        public IActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ticket = ticketService.GetTicket(id);
            if (ticket == null)
            {
                return NotFound();
            }
            var events = eventService.GetEvents();
            var attendees = attendeeService.GetAllAttendees();
            ViewData["EventId"] = new SelectList(events, "Id", "Title");
            ViewData["AttendeeId"] = new SelectList(attendees, "Id", "Name");
            return View(ticket);
        }

        // POST: Tickets/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Guid id, [Bind("EventId,AttendeeId,Price,IssuedDate,Id")] Ticket ticket)
        {
            if (id != ticket.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    ticketService.UpdateTicket(ticket);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TicketExists(ticket.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            var events = eventService.GetEvents();
            var attendees = attendeeService.GetAllAttendees();
            ViewData["EventId"] = new SelectList(events, "Id", "Title", ticket.EventId);
            ViewData["AttendeeId"] = new SelectList(attendees, "Id", "Name", ticket.AttendeeId);
            return View(ticket);
        }

        // GET: Tickets/Delete/5
        public IActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ticket = ticketService.GetTicket(id); 
            if (ticket == null)
            {
                return NotFound();
            }

            return View(ticket);
        }

        // POST: Tickets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(Guid id)
        {
            var ticket = ticketService.GetTicket(id);
            ticketService.DeleteTicket(ticket);
            return RedirectToAction(nameof(Index));
        }

        private bool TicketExists(Guid id)
        {
            var ticket = ticketService.GetTicket(id);
            return ticket is null;
        }
    }
}
