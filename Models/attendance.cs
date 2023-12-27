using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Stock_system.Models
{
    public class attendance
    {
        [Key]
        public int AttendanceId { get; set; }


        [Required]
        [DisplayName("Attendance Description  ")]
        public string Description { get; set; }

        [Required]
        [DisplayName("Child Care  ")]

        //quantity of children 
        public int children { get; set; }

        [DisplayName("  Date ")]
        public DateTime date { get; set; } = DateTime.Now;



    }
}
