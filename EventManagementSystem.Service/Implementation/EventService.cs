using EventManagamentSystem.Domain.Entities;
using EventManagementSystem.Repository.Interfaces;
using EventManagementSystem.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagementSystem.Service.Implementation
{
    public class EventService : IEventService
    {
        private readonly IRepository<Event> eventRepository;
        public EventService(IRepository<Event> eventRepository)
        {
            this.eventRepository = eventRepository;
        }
        public Event DeleteEvent(Event entity)
        {
            return eventRepository.Delete(entity);
        }

        public Event GetEvent(Guid? id)
        {
            Event entity = eventRepository.Get(id);
            return entity;
        }

        public List<Event> GetEvents()
        {   
           List<Event> events = eventRepository.GetAll().ToList();
           return events;
        }

        public Event InsertEvent(Event entity)
        {
            return eventRepository.Insert(entity);
        }

        public Event UpdateEvent(Event entity)
        {
           return eventRepository.Update(entity);
        }
    }
}
