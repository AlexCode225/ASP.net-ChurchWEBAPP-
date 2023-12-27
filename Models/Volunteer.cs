using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Stock_system.Models
{
    public class Volunteer
    {
        [Key]
        public int VolunteerId { get; set; }

         [Required]
         [DisplayName(" Volunteer Name")]
        public string  VolunteerName { get; set; }



       
        [DisplayName(" Volunteer Surname")]
        public string VolunteerSurname { get; set; }




        //allow members to select multiple descriptions if they want
        [DisplayName("Task to Complete")]
        public string TaskDescription { get; set; }


    }
}
