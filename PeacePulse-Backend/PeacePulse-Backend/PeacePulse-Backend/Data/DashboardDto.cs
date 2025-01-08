namespace PeacePulse_Backend.Data
{
    public class DashboardDto
    {
        public int UserId { get; set; }
        public int MissedPrayer { get; set; }
        public int CompletedPrayer { get; set; }
        public int TotalPrayers { get; set; }
        public int UnfilledPrayer { get; set; }
        public decimal failedPercentage { get; set; }
    }
}
