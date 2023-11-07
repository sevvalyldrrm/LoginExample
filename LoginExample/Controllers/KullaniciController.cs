using LoginExample.Context;
using Microsoft.AspNetCore.Mvc;

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

        public IActionResult Detay()
        {
            return View();
        }
    }
}
