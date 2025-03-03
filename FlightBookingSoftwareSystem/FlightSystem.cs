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
        decimal base_flight_fare; // Змінюємо тип на decimal
        Flight_Status flight_status;
        Flight_Type flight_type;

        public int Flight_Number
        {
            get { return flight_number; }
            set
            {
                // Приклад валідації: Flight number має бути позитивним
                if (value <= 0)
                {
                    throw new ArgumentException("Flight number must be a positive integer.", nameof(Flight_Number));
                }
                flight_number = value;
            }
        }

        public DateTime Departure_Date
        {
            get { return departure_date; }
            set
            {
                // Валідація: Дата відправлення не може бути в минулому
                if (value < DateTime.Now.Date)
                {
                    throw new ArgumentException("Departure date cannot be in the past.", nameof(Departure_Date));
                }
                departure_date = value;
            }
        }

        public DateTime Return_Date
        {
            get { return return_date; }
            set
            {
                // Для зворотного рейсу дата повернення має бути пізніше дати відправлення
                if (Flight_Type == Flight_Type.Return && value <= Departure_Date)
                {
                    throw new ArgumentException("Return date must be after departure date for return flights.", nameof(Return_Date));
                }
                return_date = value;
            }
        }

        public Cities Origin
        {
            get { return origin; }
            set
            {
                if (!Enum.IsDefined(typeof(Cities), value)) // Валідація enum
                {
                    throw new ArgumentException("Invalid origin city.", nameof(Origin));
                }
                origin = value;
            }
        }

        public Cities Destination
        {
            get { return destination; }
            set
            {
                if (!Enum.IsDefined(typeof(Cities), value)) // Валідація enum
                {
                    throw new ArgumentException("Invalid destination city.", nameof(Destination));
                }
                destination = value;
            }
        }

        public int Number_Of_Available_Seats
        {
            get { return number_of_available_seats; }
            set
            {
                // Валідація: Кількість місць має бути невід'ємною
                if (value < 0)
                {
                    throw new ArgumentException("Number of available seats cannot be negative.", nameof(Number_Of_Available_Seats));
                }
                number_of_available_seats = value;
            }
        }

        public decimal Base_Flight_Fare // Змінюємо тип на decimal
        {
            get { return base_flight_fare; }
            set
            {
                // Валідація: Базова вартість не може бути від'ємною
                if (value < 0)
                {
                    throw new ArgumentException("Base flight fare cannot be negative.", nameof(Base_Flight_Fare));
                }
                base_flight_fare = value;
            }
        }
        public Flight_Status Flight_Status
        {
            get { return flight_status; }
            set
            {
                if (!Enum.IsDefined(typeof(Flight_Status), value)) // Валідація enum
                {
                    throw new ArgumentException("Invalid flight status.", nameof(Flight_Status));
                }
                flight_status = value;
            }
        }

        public Flight_Type Flight_Type
        {
            get { return flight_type; }
            set
            {
                if (!Enum.IsDefined(typeof(Flight_Type), value)) // Валідація enum
                {
                    throw new ArgumentException("Invalid flight type.", nameof(Flight_Type));
                }
                flight_type = value;
            }
        }


        public Flight(int arg1, DateTime arg2, DateTime arg3, Cities arg4, Cities arg5, int arg6, decimal arg7, Flight_Status arg8, Flight_Type arg9)
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
        private const string FlightsDataFile = "Flights.data"; // Константа для імені файлу

        public static int Number_Of_Flights
        {
            get { return number_of_flights; }
            set { number_of_flights = value; }
        }
        
        
        // flight number generator maybe uses latest_flight_number as a static member
        public static void Save_Flight(Flight arg1)
        {
            BinaryFormatter bf = new BinaryFormatter();
            
            using (FileStream flight_stream = new FileStream(FlightsDataFile, FileMode.Append, FileAccess.Write))
            {
                try
                {
                    bf.Serialize(flight_stream, arg1);
                }

                finally
                {
                    number_of_flights++;
                }
            }
               
        }
        public static Flight Load_Flight()
        {
            BinaryFormatter bf = new BinaryFormatter();

            try
            {
                using (FileStream flight_stream = new FileStream(FlightsDataFile, FileMode.Open, FileAccess.Read))
                {
                    Flight f1 = (Flight)bf.Deserialize(flight_stream);
                    return f1;
                }
                    
            }
            catch (FileNotFoundException)
            {
                return null;
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
