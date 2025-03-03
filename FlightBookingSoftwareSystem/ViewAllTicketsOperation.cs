using E_Ticket_System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flight_Booking_Software_System
{
    public class ViewAllTicketsOperation : IAdminOperation
    {
        public void Execute()
        {
            E_Ticket_Processor.View_All_Tickets();
        }
    }
}
