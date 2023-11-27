using DeliveryApp.Models;
using DeliveryApp.Repositorio.Usuario;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography.X509Certificates;

namespace DeliveryApp.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;

        public LoginController(IUsuarioRepositorio usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Entrar(LoginModel loginModel)
        {
            try
            {
                if(ModelState.IsValid) 
                {
                    UsuarioModel usuario = _usuarioRepositorio.BuscarPorEmail(loginModel.Email);

                    if (usuario != null)
                    {
                        if (usuario.SenhaValida(loginModel.Senha))
                        {
                            return RedirectToAction("Index", "Home");
                        }

                        TempData["MensagemErro"] = $"A senha é inválida. Por favor, tente novamente.";
                    }
                    TempData["MensagemErro"] = $"Email e/ou senha inválido(s). Por favor, tente novamente.";
                }

                return View("Index");
            }
            catch(Exception ex)
            {
                TempData["MensagemErro"] = $"Não foi possível realizar seu login, tente novamente. Detalhe do erro: {ex.Message}";
                return RedirectToAction("Index");
            }
        }
    }
}
