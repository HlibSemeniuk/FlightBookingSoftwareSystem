using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Credit_Card_System;
using Passenger_System;

namespace Passenger_UI
{
    class Passengers_UI
    {
        public static void Passengers_UI_Operation()
        {
            string ui_selector = "0";
            do
            {
                Console.Clear();

                Console.WriteLine("********************************");
                Console.WriteLine("Passengers UI here");

                Console.WriteLine("1 - Add Credit Card");
                Console.WriteLine("2 - View First Card");
                Console.WriteLine("3 - View # of cards");
                Console.WriteLine("");

                Console.WriteLine("********************************");
                Console.WriteLine("x - To return");
                Console.WriteLine("********************************");
                Console.Write("Choice: ");

                ui_selector = Console.ReadLine();

                switch (ui_selector)
                {
                    case "1": Console.Write("card#: "); ; Credit_Card_Processor.Add_Card(Console.ReadLine(), DateTime.Now, 0); break;
                    case "2": Console.Write(Credit_Card_Processor.Load_Card()); break;
                    case "3": Console.Write(Credit_Card_Processor.Number_Of_Credit_Cards); break;
                }

                if (ui_selector != "x" && ui_selector != "X")
                {
                    Console.WriteLine("Press any key to continue . . . ");
                    Console.ReadKey(true);
                }

            } while (ui_selector != "x" && ui_selector != "X");
        }
    }
}
