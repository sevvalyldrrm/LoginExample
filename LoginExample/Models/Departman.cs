using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace LoginExample.Models
{
	public class Departman : BaseObject
	{
		[Required(ErrorMessage = "{0} boş geçilmez")]
		[StringLength(50, ErrorMessage = "{0} alanı en fazla {1} karakter olabilir")]
		[DisplayName("Departmant Tanim")]
		public string Tanim { get; set; }


		[StringLength(50, ErrorMessage = "{0} alanı en fazla {1} karakter olabilir")]
		[DisplayName("Aciklama")]
		public string Aciklama { get; set; }
	}
}
