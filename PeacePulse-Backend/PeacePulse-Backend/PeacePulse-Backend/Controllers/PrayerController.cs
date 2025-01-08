using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PeacePulse_Backend.Data;
using PeacePulse_Backend.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace PeacePulse_Backend.Controllers
{
    public class PrayerController : Controller
    {
        private readonly  PrayerDbContext _dbContext;
        public PrayerController(PrayerDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        //------------------------------------------------------------------------------------------------------------//
        [HttpPost]
        [Route("[controller]/PrayerSetStatus")]
        public IActionResult PrayerSetStatus([FromBody] PrayerDto prayer)
        {
           
            if (prayer == null)
            {
                return BadRequest("Invalid prayer data");
            }
            var PrayerAddedForDate=_dbContext.Prayers.Where(_=>_.UserId==prayer.UserId).Where(x=>x.Date==prayer.Date).SingleOrDefault(n=>n.PrayerName==prayer.PrayerName);
            //Console.WriteLine(PrayerAddedForDate);
            if (PrayerAddedForDate != null) 
            {
                PrayerAddedForDate.Status=prayer.Status;
            }
            else
            {

                var Prayer = new Prayer
                {
                    PrayerName = prayer.PrayerName,
                    DateTime = DateTime.SpecifyKind(prayer.DateTime, DateTimeKind.Utc),
                    Date = prayer.Date,
                    Status = prayer.Status,
                    CreatedAt = DateTime.UtcNow,
                    UserId = prayer.UserId, // Assign the UserId here
                    DashboardId = prayer.DashboardId
                };
                _dbContext.Prayers.Add(Prayer);
            }


            
            _dbContext.SaveChanges();

            
            return Ok("Action Completed");

        }

        //------------------------------------------------------------------------------------------------------------//
        [HttpGet]
        [Route("[controller]/Getprayers")]
        public IActionResult Getprayers()
        {
            var prayers=_dbContext.Prayers.ToList();
            List<PrayerDto> prayerDtos =new List<PrayerDto>();
            foreach(var prayer in prayers) 
            {
                var prayerDto = new PrayerDto
                {
                    UserId = prayer.UserId,
                    DashboardId = prayer.DashboardId,
                    PrayerName = prayer.PrayerName,
                    Date = prayer.Date,
                    Status = prayer.Status
                  
                };

                prayerDtos.Add(prayerDto);
            }
            return Ok(prayerDtos);
        }

        //------------------------------------------------------------------------------------------------------------//
        [HttpGet]
        [Route("[controller]/GetBydate/{date:DateTime}")]
        public IActionResult GetBydate([FromRoute] DateOnly date)
        {
            var prayers=_dbContext.Prayers.Where(x => x.Date == date);
            if(prayers == null)
            {
                return BadRequest("No prayer data found in this date");
            }
            List<PrayerDto> prayerDtos = new List<PrayerDto>();
            foreach(var prayer in prayers)
            {
                var prayerDto = new PrayerDto
                {
                    UserId = prayer.UserId,
                    DashboardId = prayer.DashboardId,
                    PrayerName = prayer.PrayerName,
                    Date = prayer.Date,
                    DateTime = prayer.DateTime,
                    Status = prayer.Status

                };
                prayerDtos.Add(prayerDto );
            }
            return Ok(prayerDtos);

        }
        //------------------------------------------------------------------------------------------------------------//
        [HttpGet]
        [Route("[controller]/GetByUser/{userId:int}")]
        public IActionResult GetByUserId([FromRoute] int userId) 
        { 
            var userPrayers=_dbContext.Prayers.Where(_ => _.UserId == userId).ToList();
            if(userPrayers.Count== 0)
            {
                return BadRequest("no data found for user");
            }
            List<PrayerDto> prayerDtos = new List<PrayerDto>();
            foreach (var prayer in userPrayers)
            {
                var prayerDto = new PrayerDto
                {

                    UserId = prayer.UserId,
                    DashboardId = prayer.DashboardId,
                    PrayerName = prayer.PrayerName,
                    Date = prayer.Date,
                    DateTime = prayer.DateTime,
                    Status = prayer.Status

                };
                prayerDtos.Add(prayerDto);
                
            }
            return Ok(prayerDtos);

        }



    }
}
