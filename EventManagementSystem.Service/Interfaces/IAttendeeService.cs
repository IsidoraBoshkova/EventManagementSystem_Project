using EventManagamentSystem.Domain.Identities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagementSystem.Service.Interfaces
{
    public interface IAttendeeService
    {
        List<Attendee> GetAllAttendees();
        Attendee GetAttendee(string id);
    }
}
