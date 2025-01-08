using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PeacePulse_Backend.Data;
using PeacePulse_Backend.Models;

namespace PeacePulse_Backend.Controllers
{
    public class DashboardController : Controller
    {
        private readonly PrayerDbContext _dbContext;
        public DashboardController(PrayerDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void updateData()
        {

        }

        //------------------------------------------------------------------------------------------------------------//
        [HttpPost]
        [Route("[controller]/resetData{id:int}")]
        public IActionResult Reset([FromRoute]int id)
        {
            var dashboardData=_dbContext.Dashboards.Include(d => d.Prayers).SingleOrDefault(_=>_.DashboardId == id);
            // Remove all associated prayers
            foreach (var prayer in dashboardData.Prayers.ToList())
            {
                _dbContext.Prayers.Remove(prayer);
            }
            dashboardData.MissedPrayer = 0;           
            dashboardData.TotalPrayers= 0;
            dashboardData.CompletedPrayer = 0;
            dashboardData.UnfilledPrayer = 0;
            dashboardData.Prayers = null;
            _dbContext.SaveChanges();
            return Ok(dashboardData);
        }

        [HttpGet]
        [Route("[controller]/GetDashboardData")]
        public IActionResult Get() 
        { 
            var dashboardDatas=_dbContext.Dashboards.ToList();
            
            List<DashboardDto> dashboards = new List<DashboardDto>();
            foreach (var dashboard in dashboardDatas)
            {
                var prayerdata = _dbContext.Prayers.Where(_ => _.UserId == dashboard.UserId).ToList();
                var completed = 0;
                var missed = 0;
                var unfilled = 0;
                foreach (var prayer in prayerdata)
                {
                    if (prayer.Status == "Completed")
                    {
                        completed++;
                    }
                    else if(prayer.Status == "Missed")
                    {
                        missed++;
                    }
                    else
                    {
                        unfilled++;
                    }
                }

                var dashboardDto = new DashboardDto
                {
                    UserId = dashboard.UserId,
                    MissedPrayer= missed,
                    CompletedPrayer= completed,
                    TotalPrayers= missed+ completed,
                    UnfilledPrayer = unfilled
                };
                dashboards.Add(dashboardDto);
            }
            return Ok(dashboards);
        }

        [HttpGet]
        [Route("[controller]/GetById/{userId:int}")]
        public IActionResult Get([FromRoute] int userId)
        {
            var dashboard = _dbContext.Dashboards.FirstOrDefault(_=>_.UserId== userId);

            var prayerdata = _dbContext.Prayers.Where(_ => _.UserId == dashboard.UserId).ToList();
            var completed = 0;
            var missed = 0;
            var unfilled = 0;
            foreach (var prayer in prayerdata)
            {
                if (prayer.Status == "Completed")
                {
                    completed++;
                }
                else if (prayer.Status == "Missed")
                {
                    missed++;
                }
                else
                {
                    unfilled++;
                }
            }
            var dashboardDto = new DashboardDto
            {

                UserId = dashboard.UserId,
                MissedPrayer = missed,
                CompletedPrayer = completed,
                TotalPrayers = missed + completed,
                UnfilledPrayer = unfilled
            };
               
            
            return Ok(dashboardDto);
        }

    }
}
