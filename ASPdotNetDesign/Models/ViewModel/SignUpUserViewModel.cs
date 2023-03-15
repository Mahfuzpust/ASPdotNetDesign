using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace ASPdotNetDesign.Models.ViewModel
{
    public class SignUpUserViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please enter username")]
        [Remote(action:"UserNameisExit", controller:"Account")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Please enter email")]
        [Remote(action: "EmailisExit", controller: "Account")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please enter mobile number")]
        public long Mobile { get; set; }

        [Required(ErrorMessage = "please enter password")]
        public string Password { get; set; }

        [Required(ErrorMessage = "please enter Confirmpassword")]
        [Compare("Password", ErrorMessage = ("confirm password can not match"))]
        public string ConfirmPassword { get; set; }
        public bool IsActive { get; set; }
    }
}
