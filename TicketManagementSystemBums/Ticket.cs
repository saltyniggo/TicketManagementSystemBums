﻿using System.Printing.IndexedProperties;

namespace TicketManagementSystemBums
{
    public class Ticket
    {
        private int ticketID;
        private string ticketName;
        private string ticketDescription;
        private TicketPriority priority;
        private TicketStatus status;
        private int ticketAssignedUser;
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
                return ticketID;
            }
            set
            {
                ticketID = value;
            }
        }
        public string TicketName
        {
            get
            {
                return ticketName;
            }
            set
            {
                ticketName = value;
            }
        }
        public string TicketDescription
        {
            get
            {
                return ticketDescription;
            }
            set
            {
                ticketDescription = value;
            }
        }
        public TicketPriority Priority
        {
            get
            {
                return priority;
            }
            set
            {
                priority = value;
            }
        }
        public TicketStatus Status
        {
            get
            {
                return status;
            }
            set
            {
                status = value;
            }
        }
        public int TicketAssignedUser
        {
            get
            {
                return ticketAssignedUser;
            }
            set
            {
                ticketAssignedUser = value;
            }
        }
        public DateTime TicketDate
        {
            get
            {
                return ticketDate;
            }
            set
            {
                ticketDate = value;
            }
        }

        public Ticket()
        {
        }

        public Ticket(int id, string name, DateTime date, TicketPriority priority, string description, TicketStatus status)
        {
            TicketID = id;
            TicketName = name;
            TicketDate = date;
            Priority = priority;
            TicketAssignedUser = 0;
            TicketDescription = description;
            Status = status;
        }

        public Ticket(int id, string name, DateTime date, TicketPriority priority, int assignedUser, string description, TicketStatus status)
        {
            TicketID = id;
            TicketName = name;
            TicketDate = date;
            Priority = priority;
            TicketAssignedUser = assignedUser;
            TicketDescription = description;
            Status = status;
        }


        public override string ToString()
        {
            return TicketName;
        }
    }
}
