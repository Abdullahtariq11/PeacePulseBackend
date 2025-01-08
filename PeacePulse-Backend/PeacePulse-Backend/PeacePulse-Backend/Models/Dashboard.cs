namespace PeacePulse_Backend.Models
{
    public class Dashboard
    {
        public int DashboardId { get; set; }
        public int PrayerID { get; set; }
        public int UserId { get; set; }
        public DateTime Date { get; set; }
        public int MissedPrayer { get; set; }
        public int CompletedPrayer { get; set; }
        public int TotalPrayers { get; set; }
        public int UnfilledPrayer { get; set; }

        public User User { get; set; } 
        public List<Prayer> Prayers { get; set; } 

    }
}
