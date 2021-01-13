using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalScheduler.Entities.Enums
{
    public enum AppointmentStatus : int
    {
        Pending = 0,
        Confirmed = 1,
        Finished = 2
    }
}
