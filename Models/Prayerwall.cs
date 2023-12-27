using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Stock_system.Models
{
    public class Prayerwall
    {
        [Key]
        public int PrayerId { get; set; }

        [Required]
        [DisplayName(" Enter Name ")]
        public string Name { get; set; }

        [Required]
         [DisplayName("Topic")]
        public string PrayerTopic  { get; set; }

        [DisplayName("Prayer Details ")]
        public string  PrayerDetails{ get; set; }

        [DisplayName("Scripture references?")]
        public bool ScriptureRefs { get; set; }

        [DisplayName(" Date and Time ")]
        public DateTime DayRequested{ get; set; }= DateTime.Now;
       

    }
}
