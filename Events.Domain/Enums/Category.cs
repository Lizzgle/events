using System.ComponentModel.DataAnnotations;

namespace Events.Domain.Enums
{
    public enum Category
    {
        [Display(Name = "Conference")]
        Conference = 1,
        [Display(Name = "Festival")]
        Festival = 2,
        [Display(Name = "Training")]
        Training = 3,
        [Display(Name = "Sports")]
        Sports = 4,
        [Display(Name = "Webinar")]
        Webinar = 5,
        [Display(Name = "Concert")]
        Concert = 6
    }
}
