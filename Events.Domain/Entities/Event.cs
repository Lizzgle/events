namespace Events.Domain.Entities
{
    public class Event : Entity
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime DateTime { get; set; }
        public string Location { get; set; } = string.Empty;
        public int MaxParticipants { get; set; }


        public Category Category { get; set; }
        public int CategoryId { get; set; }
        public List<Participant> Participants { get; set; } = new List<Participant>();
        public List<User> Users { get; set; } = new List<User>();
        public string? UriImage { get; set; } 
    }
}
