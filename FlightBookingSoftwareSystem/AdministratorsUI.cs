using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Administrators;
using E_Ticket_System;

namespace Administrators_UI
{
    class Administrator_UI
    {
        public static void Administrators_UI_Operation()
        {
            Console.Clear();

            Console.WriteLine("********************************");
            Console.WriteLine("Administrator Login here");

            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");

            Console.WriteLine("********************************");
            Console.Write("Administrator Name: ");
            string input_name = Console.ReadLine();
            Console.Write("Administrator Password: ");
            string input_password = Console.ReadLine();

            if (input_name == Administrator.Name && input_password == Administrator.Password)
            {
                string ui_selector = "0";
                do
                {
                    Console.Clear();

                    Console.WriteLine("********************************");
                    Console.WriteLine("Administrator UI here");

                    Console.WriteLine("1 - Add Ticket");
                    Console.WriteLine("2 - View All Tickets");
                    Console.WriteLine("");

                    Console.WriteLine("********************************");
                    Console.WriteLine("x - To return");
                    Console.WriteLine("********************************");
                    Console.Write("Choice: ");

                    ui_selector = Console.ReadLine();

                    switch (ui_selector)
                    {
                        case "1": Console.Write("Ticket #: "); E_Ticket_Processor.Add_Ticket(Console.ReadLine(), 0.022525); break;
                        case "2": E_Ticket_Processor.View_All_Tickets(); break;
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
}
