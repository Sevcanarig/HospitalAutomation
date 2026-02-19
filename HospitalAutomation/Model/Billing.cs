namespace HospitalAutomation.Entities
{
    public class Billing
    {
        public int BillingId { get; set; }
        public int PatientId { get; set; }
        public int AppointmentId { get; set; }
        public Appointment Appointment { get; set; }

        public decimal TotalAmount { get; set; }
        public string PaymentStatus { get; set; } 
        public DateTime InvoiceDate { get; set; }
    }
}
