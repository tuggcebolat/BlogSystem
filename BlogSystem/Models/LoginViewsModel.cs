using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BlogSystem.Models
{
    public class LoginViewsModel
    {
        [Display(Name ="Kullanıcı Adı",Prompt="johndoe")] 
        [Required (ErrorMessage="Username is required")]
        [StringLength(50, ErrorMessage ="Username can be max 30 character.")]
        public string? Username { get; set; }
        [DataType(DataType.Password)]   
        [Required(ErrorMessage = "Password is required")]
        [MinLength(6 , ErrorMessage = "Password can be min 6 character.")]
        [MaxLength(16, ErrorMessage = "Password can be max 16 character.")]
        public string? Password { get; set; }
    }
}
