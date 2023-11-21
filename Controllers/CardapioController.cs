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

        public IActionResult DeletarItem(int id)
        {
            CardapioModel item = _cardapioRepositorio.ListarPorId(id);
            return View(item);
        }

        public IActionResult DeletarItemConfirmacao(int id)
        {
            _cardapioRepositorio.DeletarItem(id);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult AdicionarItem(CardapioModel item)
        {
            if(ModelState.IsValid)
            {
                _cardapioRepositorio.AdicionarItem(item);
                return RedirectToAction("Index");
            }
            
            return View(item);
        }

        [HttpPost]
        public IActionResult AtualizarItem(CardapioModel item)
        {
            if(ModelState.IsValid)
            {
                _cardapioRepositorio.AtualizarItem(item);
                return RedirectToAction("Index");
            }

            return View("EditarItem", item);
        }
    }
}
