using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LoginExample.Models
{
	public class Bolum : BaseObject
	{
		[Required(ErrorMessage = "{0} boş geçilmez")]
		[StringLength(50,ErrorMessage = "{0} alanı en fazla {1} karakter olabilir")]
		[DisplayName("Bolum Tanim")]
		public string Tanim { get; set; }



		[Required(ErrorMessage = "{0} boş geçilemez")]
		[StringLength(50, ErrorMessage = "{0} alanı en fazla {1} karakter olabilir")]
		[DisplayName("Bölüm Tanım2")]
		public string Tanim2 { get; set; }


		[StringLength(50, ErrorMessage = "{0} alanı en fazla {1} karakter olabilir")]
		[DisplayName("Aciklama")]
		public string Aciklama { get; set; }


		[Required(ErrorMessage = "{0} boş geçilmez")]
		[DisplayName("Departman")]
		//[ForeignKey("Bolum_DepartmentId")]
		public int DepartmanId { get; set; }

		public Departman Departman { get; set; }

	}
}
