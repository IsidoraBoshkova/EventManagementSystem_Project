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
    public class ScheduleService : IScheduleService
    {
        private readonly IRepository<Schedule> scheduleRepository;
        public ScheduleService(IRepository<Schedule> scheduleRepository)
        {
            this.scheduleRepository = scheduleRepository;
        }
        public Schedule DeleteSchedule(Schedule entity)
        {
            return this.scheduleRepository.Delete(entity);
        }

        public Schedule GetSchedule(Guid? id)
        {
           Schedule schedule = scheduleRepository.Get(id);
            return schedule;
        }

        public List<Schedule> GetSchedules()
        {
            List<Schedule> schedules = scheduleRepository.GetAll().ToList();
            return schedules;
        }

        public Schedule InsertSchedule(Schedule entity)
        {
            return scheduleRepository.Insert(entity);
        }

        public Schedule UpdateSchedule(Schedule entity)
        {
            return scheduleRepository.Update(entity);
        }
    }
}
