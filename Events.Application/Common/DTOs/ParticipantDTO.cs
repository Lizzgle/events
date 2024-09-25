namespace Events.Application.Common.DTOs
{
    public class ParticipantDTO
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public DateTime DateOfRegistration { get; set; }
    }
}
