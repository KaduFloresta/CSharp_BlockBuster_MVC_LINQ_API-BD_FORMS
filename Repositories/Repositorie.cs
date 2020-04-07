using Microsoft.EntityFrameworkCore;
using Models;

namespace DbRespositorie
{
    public class Context : DbContext
    {
        public DbSet<ClienteModels> Clientes { get; set; }
        public DbSet<FilmeModels> Filmes { get; set; }
        public DbSet<LocacaoModels> Locacoes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseMySql("Server=localhost;User Id=root;Database=locadorakadu");
        }
    }
}