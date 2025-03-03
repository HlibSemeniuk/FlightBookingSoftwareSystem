using Custom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flight_Booking_Software_System
{
    public class FlightCreationData
    {
        public int FlightNumber { get; set; }
        public DateTime DepartureDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public Cities Origin { get; set; }
        public Cities Destination { get; set; }
        public int NumberOfSeats { get; set; }
        public double BaseFare { get; set; }
        public Flight_Status FlightStatus { get; set; }
        public Flight_Type FlightType { get; set; }
    }
}
