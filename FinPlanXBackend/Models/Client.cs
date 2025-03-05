
namespace FinPlanXBackend.Models
{
    public class Client
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Riskprofile { get; set; }
        public string Financialgoal { get; set; }
        public List<FinancialPlan> FinancialPlans { get; set; } = new List<FinancialPlan>();
    }
}
