using DeliveryApp.Models;
using DeliveryApp.Repositorio;
using Microsoft.AspNetCore.Mvc;

namespace DeliveryApp.Controllers
{
    public class CardapioController : Controller
    {
        private readonly ICardapioRepositorio _cardapioRepositorio;
        
        public CardapioController(ICardapioRepositorio cardapioRepositorio)
        {
            _cardapioRepositorio = cardapioRepositorio;
        }

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

        [HttpPost]
        public IActionResult AdicionarItem(CardapioModel item)
        {
            _cardapioRepositorio.AdicionarItem(item);
            return RedirectToAction("Index");
        }
    }
}
