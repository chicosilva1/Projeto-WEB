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
        public IActionResult Lista()
        {
            return View(db.Categorias.ToList() );
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
