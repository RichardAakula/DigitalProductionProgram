using System;

namespace DigitalProductionProgram.Monitor.GET
{
    public class TimeRecording
    {
        internal class AttendanceChart : DTO
        {
            public override string URL => "TimeRecording/AttendanceChart";

            public int EmployeeId { get; set; } 
            public string EmployeeNumber { get; set; } 
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string AbsenceDescription { get; set; }
            public DateTime IntervalStart { get; set; }
            public DateTime IntervalEnd { get; set; }
            public bool IsClosedInterval { get; set; }
        }

       
    }
}