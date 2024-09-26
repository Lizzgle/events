using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Events.Domain.Entities
{
    public class Category
    {
        public static Category Festival => new(1, "festival");
        public static Category Conference => new(2, "conference");
        public static Category Training => new(3, "training");
        public static Category Sports => new(4, "sports");
        public static Category Concert => new(5, "concert");


        public int Id { get; set; }
        public string Name { get; set; }

        public List<Event> Events { get; set; }

        protected Category(int id, string name)
        {
            Id = id;
            Name = name.ToLower();
            Events = new List<Event>();
        }


        public override string ToString() => Name;

        public static explicit operator int(Category category) => category.Id;
    }
}
