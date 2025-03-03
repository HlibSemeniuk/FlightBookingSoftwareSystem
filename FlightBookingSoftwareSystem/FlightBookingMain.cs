using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

using Administrators_UI;
using Custom;
using Passenger_UI;

//Hash-tags can be used to improve File IO also caching can be used
namespace Flight_Booking_Software_System
{
    class Main_Class
    {
        static void Main(string[] args)
        {
            if (!File.Exists("Custom Data.data"))
            {
                File.Create("Custom Data.data");
                FileStream.Null.Close();
            }

            if (!File.Exists("Credit Cards.data"))
            {
                File.Create("Credit Cards.data");
                FileStream.Null.Close();
            }

            if (!File.Exists("E-Tickets.data"))
            {
                File.Create("E-Tickets.data");
                FileStream.Null.Close();
            }

            if (!File.Exists("Flights.data"))
            {
                File.Create("Flights.data");
                FileStream.Null.Close();
            }

            if (!File.Exists("Passengers.data"))
            {
                File.Create("Passengers.data");
                FileStream.Null.Close();
            }

            string ui_selector = "0";
            do
            {
                Console.Clear();

                Console.WriteLine("********************************");
                Console.WriteLine(" Flight Booking Software System ");
                Console.WriteLine("********************************");
                Console.WriteLine("1 - Administrator");
                Console.WriteLine("2 - Passengers");

                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine("");

                Console.WriteLine("********************************");
                Console.WriteLine("z - To close program");
                Console.WriteLine("********************************");
                Console.Write("Choice: ");

                ui_selector = Console.ReadLine();

                switch (ui_selector)
                {
                    case "1": Administrator_UI.Administrators_UI_Operation(); break;
                    case "2": Passengers_UI.Passengers_UI_Operation(); break;
                }

                if (ui_selector != "z" && ui_selector != "Z")
                {
                    Console.WriteLine("Press any key to continue . . . ");
                    Console.ReadKey(true);
                }

            } while (ui_selector != "z" && ui_selector != "Z");

            FileStream custom_data_stream = new FileStream("Custom Data.data", FileMode.Open, FileAccess.Write);
            BinaryFormatter bf = new BinaryFormatter();

            try
            {
                Custom_Data cd = new Custom_Data();

                cd.latest_data[0] = Custom_Data.Administrator_Name;
                cd.latest_data[1] = Custom_Data.Administrator_Password;
                cd.latest_data[2] = Convert.ToString(Custom_Data.Number_Of_Credit_Cards);
                cd.latest_data[3] = Convert.ToString(Custom_Data.Number_Of_E_Tickets);
                cd.latest_data[4] = Convert.ToString(Custom_Data.Number_Of_Flights);
                cd.latest_data[5] = Convert.ToString(Custom_Data.Number_Of_Passengers);

                bf.Serialize(custom_data_stream, cd);
            }

            finally
            {
                custom_data_stream.Close();
            }
        }
    }
}