namespace Events.Domain.Entities
{
    public class User : Entity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public DateTime DateOfBirth { get; set; }

        public string? RefreshToken { get; set; }
        public DateTime? RefreshTokenExpiry { get; set; }

        public List<Role> Roles { get; set; }

        public List<Event> Events { get; set; } = new List<Event>();
        public List<Participant> Participants { get; set; } = new List<Participant>();
    }
}
