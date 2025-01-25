using EventManagamentSystem.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagementSystem.Domain.ViewModels
{
    public class EventViewModel
    {
        [Required]
        public EventType EventType { get; set; }
    }
}
