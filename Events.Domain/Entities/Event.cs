using System.ComponentModel.DataAnnotations;

namespace Events.Domain.Entities
{
    public class Event : Entity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime DateTime { get; set; }
        public string Location { get; set; }
        public Category Category { get; set; }
        public int MaxParticipants { get; set; }
        public List<Participant> Participants { get; set; } = new List<Participant>();
        public List<User> Users { get; set; } = new List<User>();
        public string UriImage { get; set; } 
    }

    public enum Category
    {
        [Display(Name = "Conference")]
        Conference,
        [Display(Name = "Festival")]
        Festival,
        [Display(Name = "Training")]
        Training,
        [Display(Name = "Sports")]
        Sports,
        [Display(Name = "Webinar")]
        Webinar,
        [Display(Name = "Concert")]
        Concert
    }
}
