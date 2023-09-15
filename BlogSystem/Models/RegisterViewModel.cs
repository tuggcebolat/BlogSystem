using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace BlogSystem.Models
{
    public class RegisterViewModel
    {

       // [Display(Name = "Kullanıcı Adı", Prompt = "johndoe")]
        [Required(ErrorMessage = "Username is required")]
        [StringLength(30, ErrorMessage = "Username can be max 30 character.")]
        public string? Username { get; set; }
       // [DataType(DataType.Password)]
        [Required(ErrorMessage = "Password is required")]
        [MinLength(6, ErrorMessage = "Password can be min 6 character.")]
        [MaxLength(30, ErrorMessage = "Password can be max 16 character.")]
        public string? Password { get; set; }
        [Required(ErrorMessage = "Re-Password is required")]
        [MinLength(6, ErrorMessage = "Re-Password can be min 6 character.")]
        [MaxLength(30, ErrorMessage = "Re-Password can be max 16 character.")]
        [Compare(nameof(Password))]
        public string? RePassword { get; set; }



    }
}
