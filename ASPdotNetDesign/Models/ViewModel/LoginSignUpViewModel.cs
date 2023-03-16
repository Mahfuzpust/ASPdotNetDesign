using System.ComponentModel.DataAnnotations;

namespace ASPdotNetDesign.Models.ViewModel
{
    public class LoginSignUpViewModel
    {
        [Required(ErrorMessage = "Please enter username")]
        public string Username { get; set; }
        [Required(ErrorMessage = "please enter password")]
        public string Password { get; set; }
        [Display(Name = "Remember Me")]
        public bool IsRemember { get; set; }
    }
}
