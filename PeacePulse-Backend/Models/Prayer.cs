using System.Globalization;

namespace PeacePulse_Backend.Models
{
    public class Prayer
    {
        public int PrayerID { get; set; }
        public int DashboardId { get; set; }
        public int UserId { get; set; }
        public String PrayerName { get; set; } 
        public DateTime DateTime { get; set; }
        public DateOnly Date { get; set; }
        public string Status { get; set; }
        public DateTime CreatedAt { get; set; }


        public User User { get; set; } 
        public Dashboard Dashboard { get; set; } 

    }
}
