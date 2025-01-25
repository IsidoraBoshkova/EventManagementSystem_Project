using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagamentSystem.Domain.Enums
{
    public enum EventType
    {
        [Display(Name = "Conference")]
        Conference,

        [Display(Name = "Workshop")]
        Workshop,

        [Display(Name = "Webinar")]
        Webinar,

        [Display(Name = "Seminar")]
        Seminar,

        [Display(Name = "Concert")]
        Concert
    }
}
