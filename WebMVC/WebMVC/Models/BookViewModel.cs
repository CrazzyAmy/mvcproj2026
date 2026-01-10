using System.ComponentModel.DataAnnotations;

namespace WebMVC.Models
{
    public class BookViewModel
    {
        [Display(Name = "書本識別碼")]
        public int Id { get; set; }
        
        [Display(Name = "書本名稱")]
        [Required(ErrorMessage = "請輸入書本名稱")]
        public string Title { get; set; }

        [Display(Name = "書本價格")]
        [DataType(DataType.Currency)]
        [Required(ErrorMessage = "請輸入書本價格")]
        public int Price { get; set; }
    }
}
