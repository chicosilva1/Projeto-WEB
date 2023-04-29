using Microsoft.AspNetCore.Mvc;
using Projeto_WEB.Models;

namespace Projeto_WEB.Controllers
{

    public class ProdutoController : Controller
    {
        public static List<ProdutoModel> nbd = new List<ProdutoModel>();
        public IActionResult Lista()
        {
            return View();
        }

        public IActionResult Cadastrar() {
            ProdutoModel model = new ProdutoModel();
            return View(model);
        }
    public IActionResult SalvarDados(ProdutoModel produto)
        {
            if (produto.Id == 0)
            {
                Random rand = new Random();

                produto.Id = rand.Next(1, 9999);
                nbd.Add(produto);
            }
            return RedirectToAction("Lista");

        }
    }
}
