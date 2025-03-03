using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Administrators;
using E_Ticket_System;
using Flight_Booking_Software_System;

namespace Administrators_UI
{
    class Administrator_UI
    {
        private static Dictionary<string, IAdminOperation> _adminOperations;

        static Administrator_UI() // Статичний конструктор для ініціалізації словника
        {
            _adminOperations = new Dictionary<string, IAdminOperation>()
            {
                {"1", new AddTicketOperation()},
                {"2", new ViewAllTicketsOperation()},
                {"x", new ReturnToPreviousMenuOperation()},
                {"X", new ReturnToPreviousMenuOperation()}
            };
        }

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

                    // Замінюємо switch на виклик операції зі словника
                    if (_adminOperations.ContainsKey(ui_selector))
                    {
                        _adminOperations[ui_selector].Execute();
                    }
                    else
                    {
                        _adminOperations["unknown"] = new UnknownOperation(); // Додаємо обробку невідомих операцій
                        _adminOperations["unknown"].Execute();
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
