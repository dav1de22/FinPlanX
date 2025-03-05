namespace FinPlanXBackend.Models
{
    public class FinancialPlan
    {
        public int Id { get; set; }
        public string PlanName { get; set; }
        public string PlanDetails { get; set; }
        public DateTime CreatedDate { get; set; }
        public int ClientId { get; set; }
        public Client Client { get; set; }
    }
}
