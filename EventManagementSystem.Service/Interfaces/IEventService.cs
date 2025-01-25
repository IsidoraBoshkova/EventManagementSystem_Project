using EventManagamentSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagementSystem.Service.Interfaces
{
    public interface IEventService
    {
        List<Event> GetEvents();
        Event GetEvent(Guid? id);
        Event UpdateEvent(Event entity);
        Event DeleteEvent(Event entity);
        Event InsertEvent(Event entity);
    }
}
