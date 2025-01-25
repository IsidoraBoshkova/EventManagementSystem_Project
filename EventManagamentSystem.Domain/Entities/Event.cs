using EventManagamentSystem.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagamentSystem.Domain.Entities
{
    public class Event : BaseEntity
    {
        public string? Title { get; set; }
        public string? Venue { get; set; }
        public int Capacity { get; set; }
        public string? Description { get; set; }
        public string? Organizer { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string? PriceRange { get; set; }
        public string? EventType { get; set; }
        public virtual List<Ticket>? Tickets { get; set; }
        public virtual List<Schedule>? Schedules { get; set; }
    }
}
