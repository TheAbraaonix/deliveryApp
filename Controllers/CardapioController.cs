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
            List<CardapioModel> itens = _cardapioRepositorio.BuscarTodos();
            return View(itens);
        }

        public IActionResult AdicionarItem()
        {
            return View();
        }

        public IActionResult EditarItem(int id)
        {
            CardapioModel item = _cardapioRepositorio.ListarPorId(id);
            return View(item);
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

        [HttpPost]
        public IActionResult AtualizarItem(CardapioModel item)
        {
            _cardapioRepositorio.AtualizarItem(item);
            return RedirectToAction("Index");
        }
    }
}
