namespace Events.Domain.Entities
{
    public class User : Entity
    {
        public string Name { get; set; } = string.Empty;
        public string Surname { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public DateTime DateOfBirth { get; set; }

        public string RefreshToken { get; set; } = string.Empty;
        public DateTime? RefreshTokenExpiry { get; set; }

        public List<Role> Roles { get; set; } = [];

        public List<Event> Events { get; set; } = new List<Event>();
        public List<Participant> Participants { get; set; } = new List<Participant>();
    }
}
