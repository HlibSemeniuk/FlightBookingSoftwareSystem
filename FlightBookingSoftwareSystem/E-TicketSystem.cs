using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

using Credit_Card_System;
using Custom;
using Flight_System;
using Passenger_System;

namespace E_Ticket_System
{
    [Serializable]
    class E_Ticket
    {
        string ticket_code;
        decimal total_fare; // Змінюємо тип на decimal

        public string Ticket_Code
        {
            get { return ticket_code; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Ticket code cannot be empty.", nameof(Ticket_Code));
                }
                ticket_code = value;
            }
        }
        public decimal Total_Fare // Змінюємо тип на decimal
        {

            get { return total_fare; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Total fare cannot be negative.", nameof(Total_Fare));
                }
                total_fare = value;
            }
        }


        public E_Ticket(string arg1, decimal arg2) // Змінюємо тип на decimal
        {
            Ticket_Code = arg1;
            Total_Fare = arg2;
        }
        public override string ToString()
        {
            return " Ticket Code: " + Ticket_Code + "\n Total Fare: " + Total_Fare + "$\n";
        }
    }

    class E_Ticket_Processor
    {
        static int number_of_e_tickets;
        private const string ETicketsDataFile = "ETickets.data"; // Константа для імені файлу

        public static int Number_Of_E_Tickets
        {
            get { return number_of_e_tickets; }
            set { number_of_e_tickets = value; }
        }


        public void Process_Payment()/*for validation purpose during payment process. Validation process includes checking if the available balance covers the ticket fare.*/
        {
        }

        public static void View_All_Tickets()
        {
            if (new FileInfo(ETicketsDataFile).Length != 0)
            {
                BinaryFormatter bf = new BinaryFormatter();

                try
                {
                    using (FileStream E_Ticket_stream = new FileStream(ETicketsDataFile, FileMode.Open, FileAccess.Read)) // Блок using гарантує закриття файлу
                    {
                        while (E_Ticket_stream.Length > E_Ticket_stream.Position)
                            Console.Write(bf.Deserialize(E_Ticket_stream));
                    }
                }
                catch (FileNotFoundException)
                {
                    Console.WriteLine("No Tickets");
                }
            }  
        }

        public string Create_Ticket_Code()
        {
            return " ";//
        }
        public double Calculate_Total_Fare(Flight arg1, Travel_Class arg2)
        {
            return (arg1.Base_Flight_Fare*(double)arg1.Flight_Type+(double)arg2);
        }

        public static void Save_Ticket(E_Ticket arg1)
        {
            BinaryFormatter bf = new BinaryFormatter();

            using (FileStream E_Ticket_stream = new FileStream(ETicketsDataFile, FileMode.Append, FileAccess.Write)) // Блок using гарантує закриття файлу
            {
                bf.Serialize(E_Ticket_stream, arg1);
            }
        }

        public static E_Ticket Load_Ticket()
        {
            BinaryFormatter bf = new BinaryFormatter();

            try
            {
                using (FileStream E_Ticket_stream = new FileStream(ETicketsDataFile, FileMode.Open, FileAccess.Read)) // Блок using гарантує закриття файлу
                {
                    E_Ticket e1 = (E_Ticket)bf.Deserialize(E_Ticket_stream);
                    return e1;
                }    
                    
            }
            catch (FileNotFoundException)
            {
                return null;
            }
        }

        public static void Add_Ticket(string arg1, decimal arg2)
        {
            try
            {
                E_Ticket e1 = new E_Ticket(arg1, arg2);
                E_Ticket_Processor.Save_Ticket(e1);
            }

            finally
            {
                //return " E-Ticket Added (success indication)"
            }
        }

        static E_Ticket_Processor()
        {
            number_of_e_tickets = Custom_Data.Number_Of_E_Tickets;
        }
    }
}
