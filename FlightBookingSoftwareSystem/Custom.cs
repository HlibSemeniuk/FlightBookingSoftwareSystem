using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

//list of all custom types and classes
namespace Custom
{
    enum Cities { Amman, Aqaba, Riyadh /* list of available cities, can use file IO */};

    enum Flight_Status { Scheduled, Arrived, Cancelled/*Cancelled flights are not available for booking*/};

    enum Flight_Type { One_Way=1, Return=2 };

    enum Travel_Class { First=100, Business=50, Economy=0 };

    [Serializable]
    class Custom_Data
    {
        public string[] latest_data = new string[6];//to save and load the static members

        static string administrator_name;
        static string administrator_password;
        static int number_of_credit_cards;
        static int number_of_e_tickets;
        static int number_of_flights;
        static int number_of_passengers;

        public static string Administrator_Name
        {
            get
            {
                return administrator_name;
            }
        }
        public static string Administrator_Password
        {
            get
            {
                return administrator_password;
            }
        }
        public static int Number_Of_Credit_Cards
        {
            get { return number_of_credit_cards; }
            set { number_of_credit_cards = value; }
        }
        public static int Number_Of_E_Tickets
        {
            get { return number_of_e_tickets; }
            set { number_of_e_tickets = value; }
        }
        public static int Number_Of_Flights
        {
            get { return number_of_flights; }
            set { number_of_flights = value; }
        }
        public static int Number_Of_Passengers
        {
            get { return number_of_passengers; }
            set { number_of_passengers = value; }
        }

        static Custom_Data()
        {
            if (new FileInfo("Custom Data.data").Length != 0)
            {
                FileStream custom_data_stream = new FileStream("Custom Data.data", FileMode.Open, FileAccess.Read);
                BinaryFormatter bf = new BinaryFormatter();

                try
                {
                    Custom_Data cd = (Custom_Data)bf.Deserialize(custom_data_stream);

                    Custom_Data.administrator_name = cd.latest_data[0];
                    Custom_Data.administrator_password = cd.latest_data[1];
                    Custom_Data.number_of_credit_cards = Convert.ToInt32(cd.latest_data[2]);
                    Custom_Data.number_of_e_tickets = Convert.ToInt32(cd.latest_data[3]);
                    Custom_Data.number_of_flights = Convert.ToInt32(cd.latest_data[4]);
                    Custom_Data.number_of_passengers = Convert.ToInt32(cd.latest_data[5]);
                }

                finally
                {
                    custom_data_stream.Close();
                }
            }
            else
            {
                administrator_name = "admin";
                administrator_password = "pass";
                number_of_credit_cards = 0;
                number_of_e_tickets = 0;
                number_of_flights = 0;
                number_of_passengers = 0;
            }
        }
    }
}