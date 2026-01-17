using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace CourseWeb.Models
{
    public class UserRegisterViewModel
    {
        [Required(ErrorMessage = "請輸入帳號")]
        [Display(Name = "帳號")]
        [StringLength(50, ErrorMessage ="使用者名稱不可超過50個字")]
        public string? UserName { get; set; }
        //[Remote(action: "IsPasswordValid", controller: "Account", ErrorMessage = "Password is incorrect.")]
        [Required(ErrorMessage = "請輸入密碼")]
        [DataType(DataType.Password)]
        [Display(Name = "密碼")]
        [StringLength(20, MinimumLength =6, ErrorMessage = "密碼長度必須在6到20個字之間")]
        [RegularExpression(@"^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{6,20}$", ErrorMessage = "密碼必須包含至少一個字母和一個數字")]
        public string? Password { get; set; }

        [Required(ErrorMessage = "請再次輸入密碼")]
        [DataType(DataType.Password)]
        [Display(Name = "確認密碼")]
        [Compare("Password", ErrorMessage = "密碼與確認密碼不符")]
        public string? ConfirmPassword { get; set; }

        [Required(ErrorMessage = "請輸入電子郵件")]
        [DataType(DataType.Password)]
        [Display(Name = "確認密碼")]
        [EmailAddress(ErrorMessage ="請輸入有效的電子郵件格式")]
        public string? Email { get; set; }
    }
}
