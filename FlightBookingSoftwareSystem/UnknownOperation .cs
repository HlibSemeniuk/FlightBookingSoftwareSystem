using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flight_Booking_Software_System
{
    public class UnknownOperation : IAdminOperation // Операція для невідомого вибору
    {
        public void Execute()
        {
            Console.WriteLine("Unknown operation. Please try again.");
        }
    }
}
