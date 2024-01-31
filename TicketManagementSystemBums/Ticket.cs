using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketManagementSystemBums
{
    public class Ticket
    {
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public int Priority { get; set; }
        public string AssignedUser { get; set; }
        public string Description { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
