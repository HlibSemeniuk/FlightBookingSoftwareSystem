using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Custom;
using E_Ticket_System;
using Flight_Booking_Software_System;
using Flight_System;
using Passenger_System;


namespace Administrators
{
    static class Administrator
    {
        static string name;
        static string password;

        public static string Name
        {
            get { return name; }
        }
        public static string Password
        {
            get { return password; }
        }


        public static void Add_Flight(FlightCreationData flightData)
        {
            Flight f1 = new Flight(
             flightData.FlightNumber,
             flightData.DepartureDate,
             flightData.ReturnDate,
             flightData.Origin,
             flightData.Destination,
             flightData.NumberOfSeats,
             flightData.BaseFare,
             flightData.FlightStatus,
             flightData.FlightType);
            Flight_Processor.Save_Flight(f1);
        }


        public static void Delete_Flight(Flight arg1)
        {
            arg1.Flight_Status = Flight_Status.Cancelled;
        }


        static Administrator()
        {
            name = Custom_Data.Administrator_Name;
            password = Custom_Data.Administrator_Password;
        }
    }
}