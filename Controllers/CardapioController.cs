using Microsoft.AspNetCore.Mvc;

namespace DeliveryApp.Controllers
{
    public class CardapioController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AdicionarItem()
        {
            return View();
        }

        public IActionResult EditarItem()
        {
            return View();
        }

        public IActionResult DeletarItem()
        {
            return View();
        }
    }
}
