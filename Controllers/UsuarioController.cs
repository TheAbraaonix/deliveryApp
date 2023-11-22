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
    }
}