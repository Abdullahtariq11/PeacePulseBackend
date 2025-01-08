namespace PeacePulse_Backend.Models
{
    public class User
    {
        public int UserId { get; set; } 
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string Email { get; set; }
        public string Password { get; set; } 
        public Boolean EmailConfirmed { get; set; } 

        public DateTime Createdt { get; set; }
        public List<Prayer> Prayers { get; set; } 
        public Dashboard Dashboard { get; set; } 

    }
}
