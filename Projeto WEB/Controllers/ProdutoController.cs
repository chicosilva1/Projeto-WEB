using Microsoft.AspNetCore.Mvc;

namespace Projeto_WEB.Controllers
{
    public class ProdutoController : Controller
    {
        public IActionResult Lista()
        {
            return View();
        }

        public IActionResult Cadastrar() {
            return View();
        }
    }
}
