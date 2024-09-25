using System.ComponentModel.DataAnnotations;

namespace Events.Domain.Enums
{
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
