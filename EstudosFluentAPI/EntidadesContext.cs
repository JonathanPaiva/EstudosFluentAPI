using Microsoft.EntityFrameworkCore;

namespace EstudosFluentAPI
{
    class EntidadesContext: DbContext
    {
        public DbSet<Entidades.Produto> Produtos { get; set; }

        public DbSet<Entidades.Grupo> Grupos { get; set; }

        public DbSet<Entidades.Fabricante> Fabricantes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source = localhost\\sqlexpress; Initial Catalog = " +
                                        "EstudosDBFluentAPI;Persist Security Info=True;User ID=sa;Password=qaz@123");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Configurações sobre Fluent API
            modelBuilder.HasDefaultSchema("Admin");
            modelBuilder.Ignore<Entidades.Fabricante>();
        }
    }
}
