using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Projeto_WEB.Models;
using Projeto_WEB.Tabelas;

namespace Projeto_WEB.Controllers
{
    public class ProdutoController : Controller
    {

        public static List<ProdutoModel> ndb = new List<ProdutoModel>();

        private Contexto db;

        public ProdutoController(Contexto contexto)
        {
            db = contexto;
        }

        public IActionResult Lista(string filtro, string busca)
        {
            if( string.IsNullOrEmpty(busca))
            {
                return View( db.Produto.ToList() );
            }
            else
            {
                switch (filtro)
                {
                    case "id":
                        return View(db.Produto.Include(a => a.Id.ToString() == busca).ToList());
                        break;
                    case "nome":
                        return View(db.Produto.Where(a => a.Descricao.Contains(busca)).ToList());
                        break;
                    case "qtd":
                        return View(db.Produto.Where(a => a.Valor.ToString() == busca).ToList());
                        break;
                    default:
                        return View(
                            db.Produto.Where(a => a.Id.ToString() == busca
                        ||
                            a.Descricao.Contains(busca)
                        ||
                            a.Valor.ToString() == busca).ToList()
                            );
                        break;
                }
            }
        }
        public IActionResult Cadastrar()
        {
            ProdutoModel model = new ProdutoModel();
            model.TodasCategorias = db.Categorias.ToList();
            return View(model);
        }
        [HttpPost]
        public IActionResult SalvarDados(ProdutoModel produto)
        {
            Produtos novoProduto = new Produtos();
            novoProduto.Descricao = produto.Nome;
            novoProduto.Valor = produto.QtdEstoque;
            novoProduto.Ativo = true;
            novoProduto.CategoriaId = produto.CategoriaId;

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
