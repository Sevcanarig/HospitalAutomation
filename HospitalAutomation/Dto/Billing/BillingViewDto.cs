namespace HospitalAutomation.Dto.Billing
{
    public class BillingViewDto
    {
        public int BillingId { get; set; }
        public decimal TotalAmount { get; set; }
        public string PaymentStatus { get; set; }
    }
}
