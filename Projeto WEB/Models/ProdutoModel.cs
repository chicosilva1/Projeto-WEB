using Projeto_WEB.Tabelas;

namespace Projeto_WEB.Models
{
    public class ProdutoModel
    {
        public int Id { get; set; }

        public string Nome { get; set; }
        public int QtdEstoque { get; set; }

        public int CategoriaId { get; set; }

        public List<Categorias> TodasCategorias { get; set; }
    }
}
