using System.ComponentModel.DataAnnotations;

namespace thewall.Models
{
    public class User : BaseEntity
    {
        [Required(ErrorMessage = "First Name is required.")]
        [StringLength(255, ErrorMessage = "First Name must be betwen 5 and 255 characters", MinimumLength = 2)]
        public string FirstName { get; set; }
        
        [Required(ErrorMessage = "Last Name is required.")]
        [StringLength(255, ErrorMessage = "Last Name must be betwen 5 and 255 characters", MinimumLength = 2)]
        public string LastName { get; set; }
        
        [Required(ErrorMessage = "Email Address is required")]
        [EmailAddress(ErrorMessage = "You must use a vaild email address format, this will be your login")]
        public string Email { get; set; }
        
        [Required(ErrorMessage = "Username is required, this will be your display name.")]
        [StringLength(255, ErrorMessage = "UserName must be between 2 and 255 characters", MinimumLength = 2)]
        public string UserName { get; set; }
        
        [Required(ErrorMessage = "Password is required.")]
        [StringLength(70, ErrorMessage = "Password must be between 8 and 70 characters.", MinimumLength = 8)]
        public string Password { get; set; }
        
        [Required(ErrorMessage = "You must also confirm your password and they must match.")]
        [Compare("Password", ErrorMessage = "Passwords must match.")]
        public string cPassword { get; set; }
    }
}