using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LoginExample.Models
{
	public class BaseObject
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]	
		public int Id { get; set; }

		public bool Aktif { get; set; } = true;

		[ScaffoldColumn(false)]

		[Browsable(false)]
		public string ActiveString => Aktif ? "Aktif" : "Pasif";

		//public int EkleyenKullaniciId { get; set; }	

		//public int GuncelleyenKullaniciId { get; set; }	
	}
}
