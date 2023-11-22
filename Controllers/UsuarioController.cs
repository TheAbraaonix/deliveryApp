using DeliveryApp.Models;
using DeliveryApp.Repositorio.Cardapio;
using DeliveryApp.Repositorio.Usuario;
using Microsoft.AspNetCore.Mvc;

namespace DeliveryApp.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;

        public UsuarioController(IUsuarioRepositorio usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
        }

        public IActionResult Index()
        {
            List<UsuarioModel> usuarios = _usuarioRepositorio.BuscarTodos();
            return View(usuarios);
        }

        public IActionResult AdicionarUsuario()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AdicionarUsuario(UsuarioModel usuario)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _usuarioRepositorio.AdicionarUsuario(usuario);
                    TempData["MensagemSucesso"] = "Usuário criado com sucesso.";
                    return RedirectToAction("Index");
                }

                return View(usuario);
            }
            catch (Exception ex)
            {
                TempData["MensagemErro"] = $"Não foi possível cadastar o usuário, tente novamente. Detalhe do erro: {ex.Message}";
                return RedirectToAction("Index");
            }
        }
    }
}