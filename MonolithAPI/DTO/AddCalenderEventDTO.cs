using MonolithAPI.Models;

namespace MonolithAPI.DTO
{
    public class AddCalenderEventDTO
    {
        public int Id { get; set; }

        public string Title { get; set; } = "";

        public DateTime Start { get; set; } = DateTime.Now;

        public DateTime? End { get; set; }

        public bool AllDay { get; set; } = false;

        public string username { get; set; }
    }
}
