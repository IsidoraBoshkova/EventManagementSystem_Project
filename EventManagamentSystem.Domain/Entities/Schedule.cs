using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagamentSystem.Domain.Entities
{
    public class Schedule : BaseEntity
    {
        public Guid EventId { get; set; }
        public Event? Event { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string? Location { get; set; }
        public string? Host { get; set; }
    }
}
