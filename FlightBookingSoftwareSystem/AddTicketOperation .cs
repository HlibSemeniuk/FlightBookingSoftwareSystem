using E_Ticket_System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flight_Booking_Software_System
{
    public class AddTicketOperation : IAdminOperation
    {
        public void Execute()
        {
            Console.Write("Ticket #: ");
            E_Ticket_Processor.Add_Ticket(Console.ReadLine(), 0.022525);
        }
    }
}
