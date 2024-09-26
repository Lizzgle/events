namespace Events.Application.Common.DTOs
{
    public class EventDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime DateTime { get; set; }
        public string Location { get; set; }
        public string CategoryName { get; set; }
        public int MaxParticipants { get; set; }
        public string UriImage { get; set; }
    }
}
