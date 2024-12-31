using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace deneme3.Models
{
    public class UserUpdateViewModel
    {
        [Display(Name = "Ad Soyad")]
        [Required(ErrorMessage = "Lütfen Ad Soyad Giriniz!")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = " Ad Soyad Kısmı en az 3 harf olmalıdır.")]
        public string namesurname { get; set; }

		public string ımageurl { get; set; }

        [Display(Name = "Kullanıcı Adı")]
        [Required(ErrorMessage = "Lütfen Kullanıcı Adı Giriniz!")]
        public string username { get; set; }

		public string normalizedusername { get; set; }

        [Display(Name = "Mail Adresi")]
        [Required(ErrorMessage = "Lütfen Mail Giriniz!")]
        public string email { get; set; }

		public string normalizedemail { get; set; }

        [Display(Name = "Şifre")]
        [Required(ErrorMessage = "Lütfen Şifre Giriniz!")]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "Şifre en az 6 karakter olmalıdır.")]
        public string passwordhash { get; set; }


        [Display(Name = "Telefon Numarası")]
        [Required(ErrorMessage = "Lütfen Numaranızı Giriniz!")]
        [StringLength(11, MinimumLength = 11, ErrorMessage = "Telefon numarası 11 haneli olmalıdır.")]
        [RegularExpression(@"^\d{11}$", ErrorMessage = "Telefon numarası yalnızca rakamlardan oluşmalıdır.")]
        public string phonenumber { get; set; }

        [Display(Name = "Hakkımda")]
        [Required(ErrorMessage = "Lütfen Bilgi  Giriniz!")]
        [StringLength(int.MaxValue, MinimumLength = 20, ErrorMessage = "Hakkımda alanı en az 20 karakter olmalıdır.")]
        public string userabout { get; set; }

        public IFormFile? UserImageLocation { get; set; }

        public bool changePasswordCheckbox {  get; set; }
    }
}

