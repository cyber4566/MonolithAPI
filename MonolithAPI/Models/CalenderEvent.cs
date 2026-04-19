using System.ComponentModel.DataAnnotations;

namespace MonolithAPI.Models
{
    public class CalenderEvent
    {
        [Key]
        public int Id { get; set; }

        public string Title { get; set; } = "";

        public DateTime Start { get; set; } = DateTime.Now;

        public DateTime? End { get; set; }

        public bool AllDay { get; set; } = false;

        public User User { get; set; }


    }
}
