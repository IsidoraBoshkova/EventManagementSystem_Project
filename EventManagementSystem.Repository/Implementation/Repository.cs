using EventManagamentSystem.Domain.Entities;
using EventManagementSystem.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace EventManagementSystem.Repository.Implementation
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly ApplicationDbContext dbContext;
        private DbSet<T> entities;

        public Repository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
            entities = dbContext.Set<T>();
        }

        public T Delete(T entity)
        {
            if (entity == null) {
                throw new ArgumentNullException("entity");
            }

            entities.Remove(entity);
            dbContext.SaveChanges();
            return entity;
        }

        public T Get(Guid? id)
        {
            T entity = entity = entities
                    .First(x => x.Id == id);

            if (typeof(T).IsAssignableFrom(typeof(Schedule)))
            {
                entity = entities
                    .Include("Event")
                    .First(x => x.Id == id);
                return entity;
            }
            else if (typeof(T).IsAssignableFrom(typeof(Ticket)))
            {
                entity = entities
                    .Include("Event")
                    .Include("Attendee")
                    .First(x => x.Id == id);
                return entity;
            }

            return entity;
        }

        public IQueryable<T> GetAll()
        {
            if (typeof(T).IsAssignableFrom(typeof(Schedule)))
            {
                return entities
                    .Include("Event")
                    .AsQueryable();
            }
            else if (typeof(T).IsAssignableFrom(typeof(Ticket)))
            {
                return entities
                    .Include("Event")
                    .Include("Attendee")
                    .AsQueryable();
            }
            return entities.AsQueryable();
        }

        public T Insert(T entity)
        {
            if (entity == null) {
                throw new ArgumentNullException("entity");
            }
            entities.Add(entity);
            dbContext.SaveChanges();
            return entity;
        }

        public T Update(T entity)
        {
            if (entity == null) {
                throw new ArgumentNullException("entity");
            }

            entities.Update(entity);
            dbContext.SaveChanges();
            return entity;
        }
    }
}
