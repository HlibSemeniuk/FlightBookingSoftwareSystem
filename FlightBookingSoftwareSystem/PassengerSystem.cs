﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

using Credit_Card_System;
using Custom;
using E_Ticket_System;
using Flight_System;
using System.Net;
using System.Xml.Linq;

namespace Passenger_System
{
    [Serializable]
    class Passenger
    {
        string name;
        string address;
        string passport_number;/*unique*/

        public string Name
        {
            get { return name; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be null or whitespace.", nameof(Name));
                }
                name = value;
            }
        }
        public string Address
        {
            get { return address; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Address cannot be null or whitespace.", nameof(Address));
                }
                address = value;
            }
        }
        public string Passport_Number
        {
            get { return passport_number; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Passport Number cannot be null or whitespace.", nameof(Passport_Number));
                }
                // Приклад простої валідації формату: лише літери та цифри, мінімальна довжина 6
                if (!System.Text.RegularExpressions.Regex.IsMatch(value, "^[a-zA-Z0-9]{6,}$"))
                {
                    throw new ArgumentException("Passport Number must be at least 6 characters long and contain only letters and digits.", nameof(Passport_Number));
                }
                passport_number = value;
            }
        }



        public Passenger(string arg1, string arg2, string arg3)
        {
            Name = arg1;
            Address = arg2;
            Passport_Number = arg3;
        }
        public override string ToString()
        {
            return " Name: " + Name + "\n Address: " + Address + "\n Passport Number: " + Passport_Number + "\n";
        }
    }

    class Passenger_Processor
    {
        static int number_of_passengers;
        private const string PassengersDataFile = "Passengers.data"; // Константа для імені файлу

        public static int Number_Of_Passengers
        {
            get { return number_of_passengers; }
            set { number_of_passengers = value; }
        }


        public static void Book_Flight()
        {
        }
        public static void List_Bookings()
        {
        }
        public static void List_Passengers()
        {
        }
        public static void Pay_A_Booking()
        {
        }

        public static void Save_Passenger(Passenger arg1)
        {
            BinaryFormatter bf = new BinaryFormatter();

            try
            {
                // Використовуємо using для надійного закриття файлового потоку
                using (FileStream passenger_stream = new FileStream(PassengersDataFile, FileMode.Append, FileAccess.Write))
                {
                    bf.Serialize(passenger_stream, arg1);
                }
            }
            finally
            {
                number_of_passengers++;
            } 
        }
        public static Passenger Load_Passenger()
        {
            BinaryFormatter bf = new BinaryFormatter();


            try
            {
                using (FileStream passenger_stream = new FileStream(PassengersDataFile, FileMode.Open, FileAccess.Read))
                {
                    Passenger p1 = (Passenger)bf.Deserialize(passenger_stream);
                    return p1;
                }    
            }
            catch (FileNotFoundException)
            {
                return null;
            }
        }

        public static void Add_Passenger(string name, string address, string passportNumber)//this is Register_Passenger // Змінюємо імена параметрів для кращої читабельності
        {
            try
            {
                Passenger p1 = new Passenger(name, address, passportNumber);
                Passenger_Processor.Save_Passenger(p1);
            }
            catch (ArgumentException ex) // Додаємо catch для ArgumentException, який може бути викинутий з конструктора Passenger або Save_Passenger
            {
                Console.WriteLine($"Error adding passenger: {ex.Message}"); // Обробка винятку
                                                                            // Можна розглянути повернення false або викидання власного виключення для індикації помилки.
            }
        }

        static Passenger_Processor()
        {
            number_of_passengers = Custom_Data.Number_Of_Passengers;
        }
    }
}
