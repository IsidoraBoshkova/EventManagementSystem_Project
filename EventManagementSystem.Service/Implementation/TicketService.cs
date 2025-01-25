using EventManagamentSystem.Domain.Entities;
using EventManagementSystem.Repository.Interfaces;
using EventManagementSystem.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagementSystem.Service.Implementation
{
    public class TicketService : ITicketService
    {
        private readonly IRepository<Ticket> ticketRepository;
        public TicketService(IRepository<Ticket> ticketRepository)
        {
           this.ticketRepository = ticketRepository;
        }
        public Ticket DeleteTicket(Ticket entity)
        {
            return ticketRepository.Delete(entity);
        }

        public Ticket GetTicket(Guid? id)
        {
            Ticket ticket = ticketRepository.Get(id);
            return ticket;
        }

        public List<Ticket> GetTickets()
        {
            List<Ticket> ticketList = ticketRepository.GetAll().ToList();
            return ticketList;
        }

        public Ticket InsertTicket(Ticket entity)
        {
            return ticketRepository.Insert(entity);
        }

        public Ticket UpdateTicket(Ticket entity)
        {
            return ticketRepository.Update(entity);
        }
    }
}
