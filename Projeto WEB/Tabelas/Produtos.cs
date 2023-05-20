using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Projeto_WEB.Tabelas
{
    public class Produtos
    {
        public int CategoriaId { get; set; }

        public int Id { get; set; }

        public string Descricao { get; set; }

        public decimal Valor { get; set; }

        public bool Ativo {get; set; }

        public Categorias Categoria { get; set; }
    }

}
