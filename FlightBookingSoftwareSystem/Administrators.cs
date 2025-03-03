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


        public static void Add_Flight(int arg1, DateTime arg2, DateTime arg3, Cities arg4, Cities arg5, int arg6, int arg7, Flight_Status arg8, Flight_Type arg9)
        {
            try
            {
                Flight f1 = new Flight(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9);
                Flight_Processor.Save_Flight(f1);
            }

            finally
            {
                //return " Flight Added (success indication)"
            }

            //f.flight_number = /*latest_flight_number+1*/;
            //latest_flight_number = flight_number;

            // f.flight_status = Flight_Status.Scheduled;
        }
        public static void Update_Flight(Flight arg1)
        {
        }
        public static void Delete_Flight(Flight arg1)/*if no bookings made on the flight*/
        {
            arg1.Flight_Status = Flight_Status.Cancelled;
        }
        public static void View_Flight_Schedule()
        {
        }
        public static void View_Booking_Records()
        {
        }
        public static void Generate_Report(DateTime arg1_start_date, DateTime arg2_end_date)/*state valuable statistics about the company transactions.*/
        {
            /*contains the total revenue, the number of flights scheduled, and the number of bookings.*/
        }
        public static void Choose_Sale_Dates()
        {
            /*The Airline company offers tickets with lower fares during specific dates and occasions.
             * It is the privilege of the administrator to choose these dates.*/
        }
        public static void View_A_Passenger_Bookings(Passenger arg1)
        {
            //
        }
        public static void View_A_Flight_Economy_Bookings(Flight arg1)
        {

        }

        static Administrator()
        {
            name = Custom_Data.Administrator_Name;
            password = Custom_Data.Administrator_Password;
        }
    }
}
