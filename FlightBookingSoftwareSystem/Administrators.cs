using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Custom;
using E_Ticket_System;
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


        public static void Add_Flight(int flightNumber, DateTime departureDate, DateTime returnDate, Cities origin, Cities destination, int numberOfSeats, double baseFare, Flight_Status flightStatus, Flight_Type flightType)
        {
            Flight f1 = new Flight(flightNumber, departureDate, returnDate, origin, destination, numberOfSeats, baseFare, flightStatus, flightType);
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