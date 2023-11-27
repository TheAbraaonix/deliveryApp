using DeliveryApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace DeliveryApp.Controllers
{
    public class LoginController : Controller
    {
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
                    return RedirectToAction("Index", "Home");
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
