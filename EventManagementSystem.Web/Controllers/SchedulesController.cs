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
    public class SchedulesController : Controller
    {
        private readonly IScheduleService scheduleService;
        private readonly IEventService eventService;

        public SchedulesController(IScheduleService scheduleService, IEventService eventService)
        {
            this.scheduleService = scheduleService;
            this.eventService = eventService;
        }

        // GET: Schedules
        public IActionResult Index()
        {
            var schedules = scheduleService.GetSchedules();
            return View(schedules);
        }

        // GET: Schedules/Details/5
        public IActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var schedule = scheduleService.GetSchedule(id);
            if (schedule == null)
            {
                return NotFound();
            }

            return View(schedule);
        }

        // GET: Schedules/Create
        public IActionResult Create()
        {
            var events = eventService.GetEvents();
            ViewData["EventId"] = new SelectList(events, "Id", "Title");
            return View();
        }

        // POST: Schedules/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("EventId,StartTime,EndTime,Location,Host,Id")] Schedule schedule)
        {
            if (ModelState.IsValid)
            {
                schedule.Id = Guid.NewGuid();
                scheduleService.InsertSchedule(schedule);
                return RedirectToAction(nameof(Index));
            }
            var events = eventService.GetEvents();
            ViewData["EventId"] = new SelectList(events, "Id", "Title", schedule.EventId);
            return View(schedule);
        }

        // GET: Schedules/Edit/5
        public IActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var schedule = scheduleService.GetSchedule(id);
            if (schedule == null)
            {
                return NotFound();
            }
            var events = eventService.GetEvents();
            ViewData["EventId"] = new SelectList(events, "Id", "Title", schedule.EventId);
            return View(schedule);
        }

        // POST: Schedules/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Guid id, [Bind("EventId,StartTime,EndTime,Location,Host,Id")] Schedule schedule)
        {
            if (id != schedule.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    scheduleService.UpdateSchedule(schedule);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ScheduleExists(schedule.Id))
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
            ViewData["EventId"] = new SelectList(events, "Id", "Title", schedule.EventId);
            return View(schedule);
        }

        // GET: Schedules/Delete/5
        public IActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var schedule = scheduleService.GetSchedule(id);
            if (schedule == null)
            {
                return NotFound();
            }

            return View(schedule);
        }

        // POST: Schedules/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(Guid id)
        {
            var schedule = scheduleService.GetSchedule(id);
            scheduleService.DeleteSchedule(schedule);
            return RedirectToAction(nameof(Index));
        }

        private bool ScheduleExists(Guid id)
        {
            var schedule = scheduleService.GetSchedule(id);
            return schedule is null;
        }
    }
}
