using System.ComponentModel.DataAnnotations;

namespace deneme3.Models
{
    public class UserSignInViewModel
    {

        [Required(ErrorMessage = "Lütfen Kullanici Adınızı Giriniz!")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Lütfen Şifre Giriniz!")]
        public string Password { get; set; }

    }
}
