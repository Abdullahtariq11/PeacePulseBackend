namespace PeacePulse_Backend.Data
{
    public class UserRegisterationDto
    {
     
       
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Email { get; set; }
            public string Password { get; set; }
            public Boolean EmailConfirmed { get; set; }
            public DateTime Createdt { get; set; }
        

    }
}
