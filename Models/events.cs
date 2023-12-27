using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace Stock_system.Models { 
    public class events
    {
        [Key]
        public int eventID { get; set; }

         [Required]
         [DisplayName("The Event ")]
        public string  eventName { get; set; }

        [DisplayName("Event Description")]
        public string  Description { get; set; }

      

        [DisplayName("Event Date and Time ")]
        public DateTime eventTime { get; set; }= DateTime.Now;
       

    }
}
