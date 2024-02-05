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

        public int TicketID
        {
            get
            {
                return this.ticketID;
            }
            set
            {
                this.ticketID = value;
            }
        }
        public string TicketName
        {
            get
            {
                return this.ticketName;
            }
            set
            {
                this.ticketName = value;
            }
        }
        public string TicketDescription
        {
            get
            {
                return this.ticketDescription;
            }
            set
            {
                this.ticketDescription = value;
            }
        }
        public TicketPriority Priority
        {
            get
            {
                return this.priority;
            }
            set
            {
                this.priority = value;
            }
        }
        public TicketStatus Status
        {
            get
            {
                return this.status;
            }
            set
            {
                this.status = value;
            }
        }
        public string TicketAssignedUser
        {
            get
            {
                return this.ticketAssignedUser;
            }
            set
            {
                this.ticketAssignedUser = value;
            }
        }
        public DateTime TicketDate
        {
            get
            {
                return this.ticketDate;
            }
            set
            {
                this.ticketDate = value;
            }
        }

        public Ticket()
        {
            this.TicketName = "undefined";
            this.TicketDate = DateTime.Now;
            this.Priority = TicketPriority.Low;
            this.TicketAssignedUser = "undefined";
            this.TicketDescription = "undefined";
            this.Status = TicketStatus.Unassigned;
        }

        public Ticket(string name, DateTime date, TicketPriority priority, string assignedUser, string description, TicketStatus status)
        {
            this.TicketName = name;
            this.TicketDate = date;
            this.Priority = priority;
            this.TicketAssignedUser = assignedUser;
            this.TicketDescription = description;
            this.Status = status;
        }


        public override string ToString()
        {
            return this.TicketName;
        }
    }
}
