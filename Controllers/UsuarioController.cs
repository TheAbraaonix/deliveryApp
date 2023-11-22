using Microsoft.AspNetCore.Mvc;

namespace DeliveryApp.Controllers
{
    public class UsuarioController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
