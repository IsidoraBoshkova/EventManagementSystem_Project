using EventManagamentSystem.Domain.Identities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagamentSystem.Domain.Entities
{
    public class Ticket : BaseEntity
    {
        public Guid EventId { get; set; }
        public Event? Event { get; set; }
        public string? AttendeeId { get; set; }
        public Attendee? Attendee { get; set; }
        public double Price { get; set; }
        public DateTime IssuedDate { get; set; }

    }
}
