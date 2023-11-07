using LoginExample.Context;
using LoginExample.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

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

		[HttpPost]
		public IActionResult Detay(Kullanici model)
		{
			if (model == null)
			{
				return RedirectToAction(nameof(Index));
			}

			//bu arkadaslara dikkat etme
			ModelState.Remove("Bolum");
			ModelState.Remove("Departman");
			if (!ModelState.IsValid)
			{
				return View(model);	
			}

			var data = _dataContext.Kullanici.FirstOrDefault(t => t.Id == model.Id);


			if(data == null)
			{
				return RedirectToAction(nameof(Index));
			}

			//1.SEÇENEK
			//_dataContext.Kullanici.Update(model);

			//2.SEÇENEK : Kullanıcıdan model üzerindeki tüm property'leri almıyorsak/alamıyorsak
			data.KullaniciKodu = model.KullaniciKodu;
			data.KullaniciSifre = model.KullaniciSifre;
			data.AdSoyad = model.AdSoyad;
			data.EMail = model.EMail;
			data.DepartmanId = model.DepartmanId;	
			data.BolumId = model.BolumId;

			//data.GuncelleyenKullaniciId = model.GuncelleyenKullaniciId;
			_dataContext.Update(data);

			_dataContext.SaveChanges();


			return RedirectToAction(nameof(Index));
		}
	}
}
