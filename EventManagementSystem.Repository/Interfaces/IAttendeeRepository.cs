using EventManagamentSystem.Domain.Identities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagementSystem.Repository.Interfaces
{
    public interface IAttendeeRepository
    {
        IQueryable<Attendee> GetAll();
        Attendee Get(string id);
    }
}
