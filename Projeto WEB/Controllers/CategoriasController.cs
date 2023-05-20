using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Projeto_WEB.Tabelas;

namespace Projeto_WEB.Controllers
{
    public class CategoriasController : Controller
    {
        private Contexto db;
        public CategoriasController(Contexto contexto) 
        {
            db = contexto;


        }
        public IActionResult Lista(string Busca)
        {
            if (string.IsNullOrEmpty(Busca))
            {
                return View(db.Categorias.ToList());
            }
            else
            {
                List<Categorias> dados = new List<Categorias>();
                dados = db.Categorias.Where(a => a.Nome.Contains(Busca)).ToList();
                return View(dados);
            }
        }
        public IActionResult Cadastro() 
        {
            return View(new Categorias());
        }

        [HttpPost]
        public IActionResult SalvarDados(Categorias dados)
        {
            db.Categorias.Add(dados);
            db.SaveChanges();
            return RedirectToAction("Lista");
        }
    }
}
