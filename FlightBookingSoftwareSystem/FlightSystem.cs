using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

using Custom;

namespace Flight_System
{
    [Serializable]
    class Flight
    {
        int flight_number;/*(unique)*/
        DateTime departure_date;
        DateTime return_date;/*return date only if flight type _return*/
        Cities origin;
        Cities destination;
        int number_of_available_seats;
        double base_flight_fare;
        Flight_Status flight_status;
        Flight_Type flight_type;

        public int Flight_Number
        {
            get
            {
                return flight_number;
            }
            set
            {
                flight_number = value;
            }
        }
        public DateTime Departure_Date
        {
            get
            {
                return departure_date;
            }
            set
            {
                departure_date = value;
            }
        }
        public DateTime Return_Date
        {
            get
            {
                return return_date;
            }
            set
            {
                return_date = value;
            }
        }
        public Cities Origin
        {
            get
            {
                return origin;
            }
            set
            {
                origin = value;
            }
        }
        public Cities Destination
        {
            get
            {
                return destination;
            }
            set
            {
                destination = value;
            }
        }
        public int Number_Of_Available_Seats
        {
            get
            {
                return number_of_available_seats;
            }
            set
            {
                number_of_available_seats = value;
            }
        }
        public double Base_Flight_Fare
        {
            get
            {
                return base_flight_fare;
            }
            set
            {
                base_flight_fare = value;
            }
        }
        public Flight_Status Flight_Status
        {
            get
            {
                return flight_status;
            }
            set
            {
                flight_status = value;
            }
        }
        public Flight_Type Flight_Type
        {
            get
            {
                return flight_type;
            }
            set
            {
                flight_type = value;
            }
        }


        public Flight(int arg1, DateTime arg2, DateTime arg3, Cities arg4, Cities arg5, int arg6, double arg7, Flight_Status arg8, Flight_Type arg9)
        {
            Flight_Number = arg1;
            Departure_Date = arg2;
            Return_Date = arg3;
            Origin = arg4;
            Destination = arg5;
            Number_Of_Available_Seats = arg6;
            Base_Flight_Fare = arg7;
            Flight_Status = arg8;
            Flight_Type = arg9;
        }
        public override string ToString()
        {
            return (" Flight Number: " + Flight_Number + "\n Departure Date: " + Departure_Date
                 + "\n Return Date: " + Return_Date + "\n Origin: " + Origin
                  + "\n Destination: " + Destination + "\n Number Of Available Seats: " + Number_Of_Available_Seats
                   + "\n Base Flight Fare: " + Base_Flight_Fare + "\n Flight Status: " + Flight_Status
                    + "\n Flight Type: " + Flight_Type + "\n");
        }
    }        

    class Flight_Processor
    {
        static int number_of_flights;

        public static int Number_Of_Flights
        {
            get { return number_of_flights; }
            set { number_of_flights = value; }
        }
        
        
        // flight number generator maybe uses latest_flight_number as a static member
        public static void Save_Flight(Flight arg1)
        {
            FileStream flight_stream = new FileStream("Flights.data", FileMode.Append, FileAccess.Write);
            BinaryFormatter bf = new BinaryFormatter();

            try
            {
                bf.Serialize(flight_stream, arg1);
            }

            finally
            {
                flight_stream.Close();
                number_of_flights++;
            }
        }
        public static Flight Load_Flight()
        {
            FileStream flight_stream = new FileStream("Flights.data", FileMode.Open, FileAccess.Read);
            BinaryFormatter bf = new BinaryFormatter();

            try
            {
                Flight f1 = (Flight)bf.Deserialize(flight_stream);
                return f1;
            }

            finally
            {
                flight_stream.Close();
            }
        }

        public void View_Arrived_Flights()
        {
            for (int count = 0; count < number_of_flights; count++)
            {
                Flight[] Arrived = new Flight[number_of_flights];
                if (Load_Flight().Flight_Status == Flight_Status.Arrived)
                    Arrived[count] = Load_Flight();
            }
        }

        static Flight_Processor()
        {
            number_of_flights = Custom_Data.Number_Of_Flights;
        }
    }
}
