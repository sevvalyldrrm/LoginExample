using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace LoginExample.Models
{
	public class Kullanici : BaseObject
	{

		[Required(ErrorMessage = "{0} boş geçilmez")]
		[StringLength(50, ErrorMessage = "{0} alanı en fazla {1} karakter olabilir")]
		[DisplayName("Ad Soyad")]
		public string AdSoyad { get; set; }


		[Required(ErrorMessage = "{0} boş geçilmez")]
		[StringLength(50, ErrorMessage = "{0} alanı en fazla {1} karakter olabilir")]
		[DisplayName("Email")]
		[DataType(DataType.EmailAddress)]
		[EmailAddress]
		public string EMail { get; set; }


		[Required(ErrorMessage = "{0} boş geçilmez")]
		[StringLength(50, ErrorMessage = "{0} alanı en fazla {1} karakter olabilir")]
		[DisplayName("Kullanıcı Kodu")]
		public string KullaniciKodu { get; set; }


		[Required(ErrorMessage = "{0} boş geçilmez")]
		[StringLength(50, ErrorMessage = "{0} alanı en fazla {1} karakter olabilir")]
		[DisplayName("Kullanıcı Şifre")]
		public string KullaniciSifre { get; set; }


		[Required(ErrorMessage = "{0} boş geçilmez")]
		[DisplayName("Departman")]
		public int DepartmanId { get; set; }


		[Required(ErrorMessage = "{0} boş geçilmez")]
		[DisplayName("Bölüm")]
		public int BolumId { get; set; }	


		public Departman Departman { get; set; }	


		public Bolum Bolum { get; set; }	
	}
}
