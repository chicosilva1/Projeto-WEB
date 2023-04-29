using Microsoft.AspNetCore.Mvc;
using Projeto_WEB.Models;

namespace Projeto_WEB.Controllers
{
    public class ProdutoController : Controller
    {

        public static List<ProdutoModel> ndb = new List<ProdutoModel>();
        public IActionResult Lista()
        {
            return View(ndb);
        }
        public IActionResult Cadastrar()
        {
            ProdutoModel model = new ProdutoModel();
            return View(model);
        }
        [HttpPost]
        public IActionResult SalvarDados(ProdutoModel produto)
        {
            if (produto.Id == 0)
            {
                Random rand = new Random();

                produto.Id = rand.Next(1, 9999);
                ndb.Add(produto);
            }
            else
            {
                int indice = ndb.FindIndex(a => a.Id == produto.Id);
                ndb[indice] = produto;
            }
            return RedirectToAction("Lista");
        }

        public IActionResult Excluir(int id)
        {
            ProdutoModel item = ndb.Find(a => a.Id == id);
            if (item!= null)
            {
                ndb.Remove(item);
            }
            return RedirectToAction("Lista");
        }

        public IActionResult Editar(int id)
        {
            ProdutoModel item = ndb.Find(produto => produto.Id == id);
            if (item != null)
            {
                return View(item);
            }
            else
            {
                return RedirectToAction("Lista");
            }
        }
    }
}
