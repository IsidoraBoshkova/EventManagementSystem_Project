using EventManagamentSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagementSystem.Service.Interfaces
{
    public interface ITicketService
    {
        List<Ticket> GetTickets();
        Ticket GetTicket(Guid? id);
        Ticket UpdateTicket(Ticket entity);
        Ticket DeleteTicket(Ticket entity);
        Ticket InsertTicket(Ticket entity);
    }
}
