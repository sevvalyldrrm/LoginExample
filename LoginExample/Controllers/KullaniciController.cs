using LoginExample.Context;
using LoginExample.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using static System.Runtime.InteropServices.JavaScript.JSType;

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

		public IActionResult Ekle()
		{
			return View();
		}

		[HttpPost]
		public IActionResult Ekle(Kullanici model)
		{

			if (model == null)
			{
				return RedirectToAction(nameof(Index));
			}

			//bu arkadaslara dikkat etme
			ModelState.Remove("Bolum");
			ModelState.Remove("Departman");

			//model içerisindeki property lerde hata var mı kontrolü 
			if (!ModelState.IsValid)
			{
				return View(model);
			}

			#region Aynı kayıt var mı kontrolünü yapar
			var data = _dataContext.Kullanici.FirstOrDefault(t=> t.KullaniciKodu == model.KullaniciKodu);	
			if (data != null)
			{
				ModelState.AddModelError("KullaniciKodu", "Bu kullanıcı zaten var.");
				return View(data);
			}
			#endregion

			_dataContext.Kullanici.Add(model);
			_dataContext.SaveChanges();

			return RedirectToAction(nameof(Index));
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
				return Ok(ex.StackTrace);
			}
			finally
			{

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


		public IActionResult Sil(int? id)
		{

			if (id == null)
		      return RedirectToAction(nameof(Index));

			//DAL 

			var data = _dataContext.Kullanici.Find(id);

			if (data == null)
				return RedirectToAction(nameof(Index));

			//Penetrasyon
			//Ddos
			//Embeded Atak

			return View(data);
		}

		//Id'yi aldık. kesin bizim kullandığımız data olmuş oldu. 
		//burada direkt ilgili Id'yi silme işlemi yapıcak
		[HttpPost]
		public IActionResult Sil2(int? Id)
		{
			if (Id == null)
				return RedirectToAction(nameof(Index));

			var data = _dataContext.Kullanici.FirstOrDefault(t => t.Id == Id);

			if (data != null)
			{
				_dataContext.Kullanici.Remove(data);
				_dataContext.SaveChanges();
			}
			return RedirectToAction(nameof(Index));


		}

		//Burada ise model bekleyecek. İlerde buna IFromFile parametresi ekleyeceğiz. Kullanıcının resimleri varsa bunlara da erişmek için kullanırız model yanında.
		[HttpPost]
		public IActionResult Sil(Kullanici model)
			{

			if (model == null)
				RedirectToAction(nameof(Index));

			//var data = _dataContext.Kullanici.Where(t => t.Id == model.Id && t.KullaniciKodu == model.KullaniciKodu).FirstOrDefault();
			var data = _dataContext.Kullanici.FirstOrDefault(t => t.Id == model.Id);

			if (data != null)
			{
				_dataContext.Kullanici.Remove(data);
				_dataContext.SaveChanges();
			}
			return RedirectToAction(nameof(Index));
		}
	}
}
