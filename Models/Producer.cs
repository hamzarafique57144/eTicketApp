using _eTicketSystem.Data.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _eTicketSystem.Models
{
    public class Producer:IEntityBase
    {
        [Key]
        public int id { get; set; }
        [Required(ErrorMessage = "Profile Picture is required")]
        [Display(Name ="Profile Picture")]    
        public string ProfilePictureUrl { get; set; }
        [Display(Name = "Full Name")]
        [Required(ErrorMessage = "Full name is required")]
        public string FullName { get; set; }
        [Display(Name = "Biography")]
        [Required(ErrorMessage = "Biography is required")]
        public string Bio { get; set; }

        //Relationships
        public List<Movie> Movies { get; set; } 
    }
}
