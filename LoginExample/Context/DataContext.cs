using LoginExample.Models;
using Microsoft.EntityFrameworkCore;

namespace LoginExample.Context

{
	public class DataContext : DbContext
	{
		//bir tane base olabilir. constractor bir parametre ister(options). DbContextOptions bir parametre ile çalışır. datacontect nerede çağırılırsa çağrılsın bu base ayağa kalkacaktır. constractor içerisinde nesne çağıramayız
		public DataContext(DbContextOptions<DataContext> options) : base(options) { 
			
		}


		//her dbset veri tabanındaki bir tabloya karşılık gelmek zorunda. hangi modelleri veri tabanında oluşturmak istersem onları dbset ile yazacağım
		DbSet<Kullanici> Kullanici { get; set; }
		DbSet<Bolum> Bolum { get; set; }	
		DbSet<Departman> Departman { get; set; }
	}
}
