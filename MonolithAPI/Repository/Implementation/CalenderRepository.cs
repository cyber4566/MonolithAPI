using Microsoft.EntityFrameworkCore;
using MonolithAPI.DBContext;
using MonolithAPI.Models;
using MonolithAPI.Repository.Interface;

namespace MonolithAPI.Repository.Implementation
{
    public class CalenderRepository : ICalenderRepository
    {
        private ApplicationDBContext _dbContext;

        public CalenderRepository(ApplicationDBContext dBContext) { 
        
            this._dbContext = dBContext;
        }



        public async Task deleteCalenderEvent(int eventId)
        {

              await _dbContext.CalenderEvents.Where(x=>x.Id == eventId).ExecuteDeleteAsync();

        }

        public List<CalenderEvent>? getCalenderEvents(string username)
        {
            List<CalenderEvent> calenderEvents = _dbContext.CalenderEvents.Where(x => x.User.Username == username).ToList();

            return calenderEvents;
        }

        public async Task saveCalenderEvents(CalenderEvent calenderEvent)
        {
            await _dbContext.CalenderEvents.AddAsync(calenderEvent);
            await _dbContext.SaveChangesAsync();
        }
    }
}
