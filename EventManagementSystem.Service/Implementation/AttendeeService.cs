using EventManagamentSystem.Domain.Identities;
using EventManagementSystem.Repository.Interfaces;
using EventManagementSystem.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagementSystem.Service.Implementation
{
    public class AttendeeService : IAttendeeService
    {
        private readonly IAttendeeRepository attendeeRepository;

        public AttendeeService(IAttendeeRepository attendeeRepository)
        {
            this.attendeeRepository = attendeeRepository;
        }

        public List<Attendee> GetAllAttendees()
        {
          var attendees = attendeeRepository.GetAll().ToList();
          return attendees;
        }

        public Attendee GetAttendee(string id)
        {
            var attendee = attendeeRepository.Get(id);
            return attendee;
        }
    }
}
