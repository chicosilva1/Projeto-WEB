using Microsoft.EntityFrameworkCore;
using Projeto_WEB.Tabelas;
namespace Projeto_WEB
{
    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions<Contexto> opt) 
            :base(opt) { }

        public DbSet<Categorias> Produto { get; set; }
        public DbSet<Categorias> Categorias { get; set; }   
    }
}
