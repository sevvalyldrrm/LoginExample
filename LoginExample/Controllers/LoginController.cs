using Microsoft.AspNetCore.Mvc;
using LoginExample.Dtos;
using LoginExample.Context;

namespace LoginExample.Controllers
{
    public class LOginController : Controller
    {
        private readonly DataContext dataContext;

        //controller tarafından çağırmamız gerekiyor. kontrol etmemiz gerekiyor. bu sebeple aşağıdakii işlemi yapmamız lazım.
        public LOginController(DataContext dataContext)
        {
            this.dataContext = dataContext;
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





            //if (string.IsNullOrWhiteSpace(loginDto.KullaniciKodu) || string.IsNullOrWhiteSpace(loginDto.KullaniciSifre))
            //{
            //    ModelState.AddModelError("KullaniciKodu", "Kullanici kod boş geçilemez.");
            //    return View(loginDto);
            //}
            return View();
        }
    }
}
