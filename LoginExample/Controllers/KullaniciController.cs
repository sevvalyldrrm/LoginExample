using LoginExample.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LoginExample.Controllers
{
	public class KullaniciController : Controller
	{
		private readonly DataContext _dataContext;

		public KullaniciController(DataContext dataContext)
		{
			_dataContext = dataContext;
		}

		public IActionResult Index()
		{
			var data = _dataContext.Kullanici.ToList();
			return View(data);
		}

		public IActionResult Detay(int id)
		{
			var data = new Models.Kullanici();

			try
			{
				data = _dataContext.Kullanici.Include(t => t.Departman).Include(t => t.Bolum).FirstOrDefault(t => t.Id == id);
				return View(data);
			}
			catch (Exception ex)
			{
				return Ok(data);
			}
			//Find() sadece id ile çalışır
		}
	}
}
