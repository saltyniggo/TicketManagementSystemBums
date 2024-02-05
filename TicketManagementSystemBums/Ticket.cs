using System.Printing.IndexedProperties;

namespace TicketManagementSystemBums
{
    public class Ticket
    {
        private int ticketID;
        private string ticketName;
        private string ticketDescription;
        private TicketPriority priority;
        private TicketStatus status;
        private string ticketAssignedUser;
        private DateTime ticketDate;


        public enum TicketStatus
        {
            Unassigned,
            Assigned,
            Completed
        }

        public enum TicketPriority
        {
            Low,
            Medium,
            High,
            Critical
        }

        public int TicketID { get; set; }
        public string TicketName { get; set; }
        public string TicketDescription { get; set; }
        public TicketPriority Priority { get; set; }
        public TicketStatus Status { get; set; }
        public string TicketAssignedUser { get; set; }
        public DateTime TicketDate { get; set; }

        public Ticket()
        {
            ticketName = "undefined";
            ticketDate = DateTime.Now;
            priority = TicketPriority.Low;
            ticketAssignedUser = "undefined";
            ticketDescription = "undefined";
            status = TicketStatus.Unassigned;
        }

        public Ticket(string name, DateTime date, TicketPriority priority, string assignedUser, string description, TicketStatus status)
        {
            ticketName = name;
            ticketDate = date;
            priority = priority;
            ticketAssignedUser = assignedUser;
            ticketDescription = description;
            status = status;
        }


        public override string ToString()
        {
            return TicketName;
        }
    }
}
