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
        double total_fare;

        public string Ticket_Code
        {
            get
            {
                return ticket_code;
            }
            set
            {
                ticket_code = value;
            }
        }
        public double Total_Fare
        {
            get
            {
                return total_fare;
            }
            set
            {
                total_fare = value;
            }
        }


        public E_Ticket(string arg1, double arg2)
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
            if (new FileInfo("E-Tickets.data").Length != 0)
            {
                FileStream E_Ticket_stream = new FileStream("E-Tickets.data", FileMode.Open, FileAccess.Read);
                BinaryFormatter bf = new BinaryFormatter();

                try
                {
                    while (E_Ticket_stream.Length > E_Ticket_stream.Position)
                        Console.Write(bf.Deserialize(E_Ticket_stream));
                }
                finally
                {
                    E_Ticket_stream.Close();
                }
            }
            else { Console.WriteLine("No Tickets"); }
            
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
            FileStream E_Ticket_stream = new FileStream("E-Tickets.data", FileMode.Append, FileAccess.Write);
            BinaryFormatter bf = new BinaryFormatter();

            try
            {
                bf.Serialize(E_Ticket_stream, arg1);
            }

            finally
            {
                E_Ticket_stream.Close();
                number_of_e_tickets++;
            }
        }
        public static E_Ticket Load_Ticket()
        {
            FileStream E_Ticket_stream = new FileStream("E-Tickets.data", FileMode.Open, FileAccess.Read);
            BinaryFormatter bf = new BinaryFormatter();

            try
            {
                E_Ticket e1 = (E_Ticket)bf.Deserialize(E_Ticket_stream);
                return e1;
            }

            finally
            {
                E_Ticket_stream.Close();
            }
        }
        public static void Add_Ticket(string arg1, double arg2)
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
