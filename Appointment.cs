using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoWash
{
    class Appointment
    {
        public string ClientFirstName { get; set; }
        public string ClientName { get; set; }
        public string PhoneNumber { get; set; }
        public string CarNumber { get; set; }
        public string WashType { get; set; }
        public double Cost { get; set; }
        public DateTime Date { get; set; }
        public DateTime Hour { get; set; }

        public Appointment()
        {

        }
        public Appointment(string firstName, string name, string phoneNumber, 
            string carNumber, string washType, DateTime date, DateTime hour)
        {
            ClientFirstName = firstName;
            ClientName = name;
            PhoneNumber = phoneNumber;
            CarNumber = carNumber;
            WashType = washType;
            Date = date;
            Hour = hour;
        }
    }
}
