using System.ComponentModel.DataAnnotations;

namespace deneme3.Areas.Admin.Models
{
    public class RolViewModel
    {

        public int rolid { get; set; }


        [StringLength(100, MinimumLength = 3, ErrorMessage = " Rol İsmi Kısmı en az 3 harf olmalıdır.")]
        [Required(ErrorMessage = "Lütfen Rol Adı Giriniz!")]
        public string rolname { get; set; }
    }
}
