using Microsoft.AspNetCore.Mvc;

namespace LoginExample.Controllers
{
   
        public class Menu : ViewComponent
        {
            //public void InvokeAsync()
            //{

            //}

            public async Task<IViewComponentResult> InvokeAsync()
            {
                return View();
            }

        }
}
