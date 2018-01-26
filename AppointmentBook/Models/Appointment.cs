using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppointmentBook.Models
{
    public class Appointment
    {
        public int id { get; set; }
        public string FristName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public int ServiceId { get; set; }
        public DateTime AppointmentDate { get; set; }
        public int Cost { get; set; }
        public string EmailId { get; set; }
    }
}