using DeliveryApp.Models;
using DeliveryApp.Repositorio.Cardapio;
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
            try
            {
                bool apagado = _cardapioRepositorio.DeletarItem(id);

                if(apagado)
                {
                    TempData["MensagemSucesso"] = "Item apagado com sucesso.";
                } 
                else
                {
                    TempData["MensagemErro"] = "Não foi possível deletar o item do cardápio.";
                }

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["MensagemErro"] = $"Não foi possível apagar seu item do cardápio, tente novamente. Detalhe do erro: {ex.Message}";
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public IActionResult AdicionarItem(CardapioModel item)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _cardapioRepositorio.AdicionarItem(item);
                    TempData["MensagemSucesso"] = "Item criado com sucesso.";
                    return RedirectToAction("Index");
                }

                return View(item);
            }
            catch (Exception ex)
            {
                TempData["MensagemErro"] = $"Não foi possível cadastar seu item ao cardápio, tente novamente. Detalhe do erro: {ex.Message}";
                return RedirectToAction("Index");
            }
        }
    }
}
