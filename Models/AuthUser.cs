using Microsoft.AspNetCore.Identity;
using Microsoft.Build.Framework;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using RequiredAttribute = Microsoft.Build.Framework.RequiredAttribute;

namespace Stock_system.Models
{

    //login details class
    public class AuthUser : IdentityUser
    {
        [Key]
        [Required]
        [DisplayName("Username")]
        public string UserName  { get; set; }



        [Required]
        [DisplayName("Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }



        
    }
}
