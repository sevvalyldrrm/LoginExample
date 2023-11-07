using Microsoft.AspNetCore.Mvc;
using LoginExample.Dtos;
using LoginExample.Context;
using Microsoft.EntityFrameworkCore;

namespace LoginExample.Controllers
{
    public class LoginController : Controller
    {
        private readonly DataContext _dataContext;

        //controller tarafından çağırmamız gerekiyor. kontrol etmemiz gerekiyor. bu sebeple aşağıdakii işlemi yapmamız lazım.
        public LoginController(DataContext dataContext)
        {
            this._dataContext = dataContext;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(LoginDto loginDto)
        {

            if (loginDto == null)
            {
                return RedirectToAction(nameof(Index));
            }

            if (ModelState.IsValid == false)
            {
                return View(loginDto);
            }

            //db den kullanıcı bilgisi sorgulanacak

            //model döndürdük Kullanici o sebeple where kullandık. sorgulama yapılan datanın türünden veri döner. 
            //FirstOrDefault dediğimiz için modeli dolduracak satırları dönüyor.
            var data = _dataContext.Kullanici.Include(t=> t .Departman).Where(t => t.KullaniciKodu == loginDto.KullaniciKodu && t.KullaniciSifre == loginDto.KullaniciSifre).FirstOrDefault();

            if (data == null)
            {
                ModelState.AddModelError("KullaniciSifre", "Kullanici kodu veya şifre hatalı..");
                return View(loginDto);
            }



            //if (string.IsNullOrWhiteSpace(loginDto.KullaniciKodu) || string.IsNullOrWhiteSpace(loginDto.KullaniciSifre))
            //{
            //    ModelState.AddModelError("KullaniciKodu", "Kullanici kod boş geçilemez.");
            //    return View(loginDto);
            //}
            return RedirectToAction(nameof(Index) , "Kullanici");
        }
    }
}
