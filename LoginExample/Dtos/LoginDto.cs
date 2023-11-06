using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace LoginExample.Dtos
{
    public class LoginDto
    {
        [Required(ErrorMessage = "{0} boş geçilemez")]
        [StringLength(50, ErrorMessage = "{0} alanı en fazla {1} karakter olabilir")]
        [DisplayName("Kullanıcı Kodu")]
        public string KullaniciKodu { get; set; }

        [Required(ErrorMessage = "{0} boş geçilemez")]
        [StringLength(50, ErrorMessage = "{0} alanı en fazla {1} karakter olabilir")]
        [DisplayName("Kullanıcı Şifre")]
        public string KullaniciSifre { get; set; }
    }
}
