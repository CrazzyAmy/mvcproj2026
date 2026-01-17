using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace CourseWeb.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "User Name is required.")]
        [Display(Name = "帳號")]
        public string? UserName { get; set; }
        //[Remote(action: "IsPasswordValid", controller: "Account", ErrorMessage = "Password is incorrect.")]
        [Required(ErrorMessage = "Password is required.")]
        [DataType(DataType.Password)]
        [Display(Name = "密碼")]
        public string? Password { get; set; }
    }
}
