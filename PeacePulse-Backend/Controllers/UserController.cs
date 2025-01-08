using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PeacePulse_Backend.Data;
using PeacePulse_Backend.Models;


namespace PeacePulse_Backend.Controllers
{
    public class UserController : Controller
    {
       private readonly PrayerDbContext _dbContext;
        public UserController(PrayerDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        //.......................................................................................................//

        [HttpPost]
        [Route("[controller]/signup")]
        public IActionResult SignupUser([FromBody] UserRegisterationDto Newuser)
        {

            if (Newuser == null)
            {
                return BadRequest("Invalid request body. User object is null.");
            }
            //check if user with same email exists
            var existingUser = _dbContext.Users.SingleOrDefault(u => u.Email == Newuser.Email);
              if (existingUser != null)
              {
                  return BadRequest("Username or email already exists.");
              }
            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(Newuser.Password);

            User user = new User
                {
                   
                    FirstName = Newuser.FirstName,
                    LastName = Newuser.LastName,
                    Email = Newuser.Email,
                    Password = hashedPassword,
                    EmailConfirmed = Newuser.EmailConfirmed,
                    Createdt = Newuser.Createdt,
                    Prayers=new List<Prayer> { },
                    Dashboard=new Dashboard()

                };
                _dbContext.Users.Add(user);
                _dbContext.SaveChanges();
            return Ok("Registeration Successfull");

        }

        //--------------------------------------------------------------------------------------------------------//
        [HttpGet]
        [Route("[controller]/GetUsers")]
        public IActionResult GetUsers()
        {


            var users = _dbContext.Users.ToList();
            List<UserDto> userDtos= new List<UserDto>();
            foreach (var user in users)
            {
                var userDto = new UserDto
                {
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Email = user.Email,
                    Createdt = user.Createdt
                };
                userDtos.Add(userDto);
            }
           
            return Ok(userDtos);

           
        }
        //------------------------------------------------------------------------------------------------------------//

        [HttpGet]
        [Route("[controller]/userById/{id:int}")]
        public IActionResult GetById([FromRoute] int id)
        {
            var user = _dbContext.Users.SingleOrDefault(u => u.UserId == id);
            if(user == null)
            {
                return BadRequest("usernot found");
            }
            var userDto = new UserDto
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Createdt = user.Createdt
            };
            return Ok(userDto);
        }
        //------------------------------------------------------------------------------------------------------------//
        [HttpPost]
        [Route("[controller]/login")]
        public IActionResult LoginUser([FromBody] LoginDto loginInfo)
        { 
            if(loginInfo == null)
            {
                return BadRequest("Invalid username or password");
            }
            var user = _dbContext.Users.SingleOrDefault(u => u.Email == loginInfo.username);
            if(user == null)
            {
                return BadRequest("Invalid username or password");
            }
            bool isPasswordCorrect = BCrypt.Net.BCrypt.Verify(loginInfo.password, user.Password);
            if (!isPasswordCorrect)
            {
                return BadRequest("Invalid username or password");
            }
            return Ok($"{user.UserId}");


        }
    }
}
