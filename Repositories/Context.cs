using Microsoft.EntityFrameworkCore;
using Models;

namespace DbRespositorie
{
    //Derived class from DbContext
    public class Context : DbContext
    {
        // DbSet properties        
        /// <value> Get and Set properties of customers  </value>
        public DbSet<ClienteModels> Clientes { get; set; }
        /// <value> Get and Set properties of movies  </value>
        public DbSet<FilmeModels> Filmes { get; set; }
        /// <value> Get and Set properties of rentals  </value>
        public DbSet<LocacaoModels> Locacoes { get; set; }
        /// <value> Get and Set properties of class "FilmeLocacao" </value>
        public DbSet<LocacaoFilmeModels> LocacaoFilme { get; set; }


        /// <summary>
        /// Initializing DbContextOptions
        /// </summary>
        /// <param name="options"></param>
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseMySql("Server=localhost;User Id=root;Database=locadorakadu");
            // options.UseMySql("Server=database-kadu.cssevpc4pptb.us-east-1.rds.amazonaws.com;User Id=admin;Password=admin123;Database=innodb");
        }
    }
}