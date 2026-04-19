using MonolithAPI.DTO;

namespace MonolithAPI.Services.Interface
{
    public interface ICalenderService
    {

        public Task addCalenderEvent(AddCalenderEventDTO addCalenderEventDTO);

    }
}
