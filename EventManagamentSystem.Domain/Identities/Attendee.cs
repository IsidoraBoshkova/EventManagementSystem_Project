using EventManagamentSystem.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagamentSystem.Domain.Identities
{
    public class Attendee : IdentityUser
    {
        public string? Name { get; set; }
        public string? Address { get; set; }
        public DateTime RegistrationDate { get; set; }
        public virtual List<Ticket>? Tickets { get; set; }

    }
}
