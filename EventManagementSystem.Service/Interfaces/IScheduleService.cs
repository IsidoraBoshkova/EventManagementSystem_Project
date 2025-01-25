using EventManagamentSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagementSystem.Service.Interfaces
{
    public interface IScheduleService
    {
        List<Schedule> GetSchedules();
        Schedule GetSchedule(Guid? id);
        Schedule UpdateSchedule(Schedule entity);
        Schedule DeleteSchedule(Schedule entity);
        Schedule InsertSchedule(Schedule entity);
    }
}
