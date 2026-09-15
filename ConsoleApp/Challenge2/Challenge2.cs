using System;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Transactions;
using static System.Runtime.InteropServices.JavaScript.JSType;
using static TheComeBackOfCsharpForLuis.Challenge2.Challenge2;

namespace TheComeBackOfCsharpForLuis.Challenge2
{
    internal class Challenge2
    {

        internal enum Status
        {
            Open, Assigned, InProgress, Completed, Cancelled
        }
        internal enum Priority
        {
            Low, Medium, Critical
        }

      
        public class InvalidTicketStateException: Exception
        {
            public InvalidTicketStateException(string message): base(message)
            {

            }
        }
        public abstract class MaintanceTicket
        {
            public Guid? Id { get; }
            public string ?Description { get; set; }

            public int? LaborHours { get => laborHours; set => laborHours = value; }
            public double? HourRate { get; set; }
            private Status Status { get; set; } = Status.Open;
            //readonly public DateTime CreationDate { get; set; } = DateTime.Now; // INVALID as readonly can not stay wiht set
            public readonly DateTime CreationDate = DateTime.Now; // readonly
            private int? laborHours;

            public Technician ?AssignedTechnician { get; set; } =  new Technician();

            public MaintanceTicket(int laborHours)
            {
                this.Id = Guid.NewGuid();
                this.laborHours = LaborHours;
                this.HourRate = HourRate;
                this.HourRate = HourRate;
            }
            public void Cancel()
            {
                this.Status = Status.Cancelled;
            }
            public void Completed()
            {
                this.Status = Status.Completed;
            }

            public void Start()
            {
                this.Status = Status.InProgress;
                Console.WriteLine("Processing Ticket");
            }
            public void AssignedTo(Technician technician)
            {
                if (technician.Available)
                {
                    throw new InvalidTicketStateException("Is not available");
                }

                this.AssignedTechnician = technician;
                // enforcing transfitions rules
                if (this.Status == Status.Open)
                    this.Status = Status.Assigned;
                else if (this.Status == Status.Assigned)
                {
                    //Enforce these transition rules: ????????? do not undestanig this,.
                }

            }
            public virtual double CostCalculation()
            {
                return Convert.ToDouble(this.HourRate * this.LaborHours);
            }
        }

        public class PreventiveMaintenanceTicket : MaintanceTicket
        {
            private Priority priority { get; set; } = Priority.Low;

            public PreventiveMaintenanceTicket() : base(0){

            }
            public override double CostCalculation()  
            {
                // Estimated hours × hourly rate
                return Convert.ToDouble(this.HourRate * this.LaborHours) ;
            }
        }

        public class CorrectiveMaintenanceTicket : MaintanceTicket
        {
            private Priority priority { get; set; } = Priority.Medium;
            private double replacementPartsCost { get; set; } = 0;

            public CorrectiveMaintenanceTicket() : base(0)
            {

            }
            public override double CostCalculation()
            {
                //Estimated hours × hourly rate +replacement parts cost
                // Estimated hours × hourly rate
                return Convert.ToDouble(this.HourRate * this.LaborHours ) + replacementPartsCost;
            }
        }


        public class EmergencyMaintenanceTicket : MaintanceTicket
        {
            private Priority priority { get; set; } = Priority.Critical;
            private double productionDownTimeCost { get; set; } = 0;
            private double emergencySurcharge { get; set; } = 0;

            public EmergencyMaintenanceTicket() : base(0)
            {

            }
            public override double CostCalculation()
            {
                return Convert.ToDouble(this.HourRate * this.LaborHours)
                    + productionDownTimeCost
                    + (emergencySurcharge * 0.25); 
            }
        }

       


        public class Technician
        {

            public  int Id { get; set; }
            public string Name { get; set; }
            //public string Name { get; set; } // Maximum supported priority
            public bool Available { get; set; } //Availability

        }

        // SERVICE
        public interface ITicketProcessor
        {
            public void process(MaintanceTicket maintanceTicket);
        }
        public class TicketProcessor: ITicketProcessor
        {
            public void process(MaintanceTicket maintanceTicket)
            {
              
                if(maintanceTicket.AssignedTechnician != null)
                {
                    Console.WriteLine("Ticket already assigned");

                }
                else
                {
                    maintanceTicket.Start();
                }

            }
        }

        static void execute()
        {
            // ask for a new ticket and start with the technician
            CorrectiveMaintenanceTicket correctiveMaintenanceTicket = new CorrectiveMaintenanceTicket();
            Technician technician = new();
            technician.Name = "luis";

            ITicketProcessor ticketProcessor = new TicketProcessor();
            ticketProcessor.process(correctiveMaintenanceTicket);

        }
        //        Ticket: CorrectiveMaintenanceTicket
        //2
        //Priority: Medium
        //3
        //Assigned to: Maria
        //4
        //Status: Assigned


    }
}
