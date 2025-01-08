namespace PeacePulse_Backend.Data
{
    public class PrayerDto
    {
        public int UserId { get; set; }
        public int DashboardId { get; set; }
        public String PrayerName { get; set; }
        public DateOnly Date { get; set; }
        public DateTime DateTime { get; set; }
        public string Status { get; set; }
       
    }
}
