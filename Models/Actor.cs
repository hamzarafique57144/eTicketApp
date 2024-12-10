using _eTicketSystem.Data.Base;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;



namespace _eTicketSystem.Models
{
    public class Actor:IEntityBase
    {
        [Key]
        public int id { get; set; }
        
        [Required(ErrorMessage ="Profile Picture is required")]
        [Display(Name = "Profile Picture")]
        public string ProfilePictureUrl { get; set; }
        [Display(Name = "Full Name")]
        [Required(ErrorMessage = "Name is required")]
        public string FullName { get; set; }
        [StringLength(50,MinimumLength =3,ErrorMessage ="Full name must be between 3 and 50 characters")]
        [Required(ErrorMessage = "Biography is required")]
        [Display(Name = "Biography")]
        public string Bio { get; set; }

        //Relationships
        public List<Actor_Movie> Actor_Movies{ get; set; }
    }
}
