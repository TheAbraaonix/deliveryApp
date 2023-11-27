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

        public IActionResult EditarUsuario(int id)
        {
            UsuarioModel usuario = _usuarioRepositorio.ListarPorId(id);
            return View(usuario);
        }

        public IActionResult DeletarUsuario(int id)
        {
            UsuarioModel usuario = _usuarioRepositorio.ListarPorId(id);
            return View(usuario);
        }

        public IActionResult DeletarUsuarioConfirmacao(int id)
        {
            try
            {
                bool apagado = _usuarioRepositorio.DeletarUsuario(id);

                if (apagado)
                {
                    TempData["MensagemSucesso"] = "Usuário apagado com sucesso.";
                }
                else
                {
                    TempData["MensagemErro"] = "Não foi possível deletar o usuário.";
                }

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["MensagemErro"] = $"Não foi possível apagar o usuário, tente novamente. Detalhe do erro: {ex.Message}";
                return RedirectToAction("Index");
            }
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

        [HttpPost]
        public IActionResult AtualizarUsuario(UsuarioSemSenhaModel usuarioSemSenha)
        {
            try
            {
                UsuarioModel usuario = null;
                if (ModelState.IsValid)
                {
                    usuario = new UsuarioModel()
                    {
                        Id = usuarioSemSenha.Id,
                        Nome = usuarioSemSenha.Nome,
                        Email = usuarioSemSenha.Email,
                        Perfil = (Enums.PerfilEnum)usuarioSemSenha.Perfil
                    };

                    usuario = _usuarioRepositorio.AtualizarUsuario(usuario);
                    TempData["MensagemSucesso"] = "Usuário alterado com sucesso.";
                    return RedirectToAction("Index");
                }

                return View("EditarUsuario", usuario);
            }
            catch (Exception ex)
            {
                TempData["MensagemErro"] = $"Não foi possível atualizar o usuário, tente novamente. Detalhe do erro: {ex.Message}";
                return RedirectToAction("Index");
            }
        }
    }
}