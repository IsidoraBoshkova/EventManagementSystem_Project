using EventManagamentSystem.Domain.Identities;
using EventManagementSystem.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagementSystem.Repository.Implementation
{
    public class AttendeeRepository : IAttendeeRepository
    {
        private readonly ApplicationDbContext context;
        private readonly DbSet<Attendee> entities;

        public AttendeeRepository(ApplicationDbContext context)
        {
            this.context = context;
            entities = context.Set<Attendee>();
        }

        
        public Attendee Get(string id)
        {
            var attendee = entities.First(x => x.Id == id);
            return attendee;
        }

        public IQueryable<Attendee> GetAll()
        {
            var attendees = entities.AsQueryable();
            return attendees;
        }
    }
}
