using MonolithAPI.Models;

namespace MonolithAPI.Repository.Interface
{
    public interface ICalenderRepository
    {

        public List<CalenderEvent>? getCalenderEvents(string username);

        public Task saveCalenderEvents(CalenderEvent calenderEvent);

        public Task deleteCalenderEvent(int eventId);

    }
}
