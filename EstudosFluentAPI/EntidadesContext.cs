using Microsoft.EntityFrameworkCore;
using System;

namespace EstudosFluentAPI
{
    class EntidadesContext: DbContext
    {
        public DbSet<Entidades.Produto> Produtos { get; set; }

        public DbSet<Entidades.Grupo> Grupos { get; set; }

        public DbSet<Entidades.Fabricante> Fabricantes { get; set; }

        public DbSet<Entidades.Cliente  > Clientes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source = localhost\\sqlexpress; Initial Catalog = " +
                                        "EstudosDBFluentAPI;Persist Security Info=True;User ID=sa;Password=qaz@123");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Configurações sobre Fluent API

            /*modelBuilder.Entity(typeof("Nome da Entidade"))... // Configuração não genérica */
            /*modelBuilder.Entity("Nome da Entidade")... // Configuração não genérica */
            /*modelBuilder.Entity<Nome da Entidade>()... // Configuração genérica */

            modelBuilder.HasDefaultSchema("Admin"); //Define o Schema utilizado nas tabelas do Banco de Dados
            modelBuilder.Ignore<Entidades.Fabricante>();  //Define se a Tabela vai ser encaminhado para a migration para ser criada no BD

            modelBuilder.Entity<Entidades.Cliente>()
                .ToTable("Pessoas") // Define o nome para a Entidade(Tabela) no BD
                .HasKey(t => t.Codigo); // Define qual será Primary Key da tabela

            //Métodos aplicados nas propriedades
            modelBuilder.Entity<Entidades.Produto>()
                .HasKey(p => new { p.CodigoProduto, p.Referencia }); //Criar uma chave composta na tabela

            modelBuilder.Entity<Entidades.Grupo>()
                .HasIndex(g => g.NomeGrupo).IsUnique(); // HasIndex cria um índice para a columa / IsUnique cria um índice único para a coluna

            modelBuilder.Entity<Entidades.Grupo>()
                .HasAlternateKey(g => g.NomeGrupo); // Criar uma restrição exclusiva diferentes daquelas que foram a chave primária.

            modelBuilder.Entity<Entidades.Cliente>()
                .Property(c => c.Nome)
                .HasColumnName("NomeDoCliente") //Define o nome da Coluna na tabela
                .HasMaxLength(250) // Define o tamanho máximo do campo na tabela
                .IsRequired(); // Denife a coluna como não anulável - is not null

            modelBuilder.Entity<Entidades.Cliente>()
                .Property(c => c.Endereco)
                .HasColumnType("varchar(150)") //Define o tipo específico do campo na tabela
                .HasDefaultValue("Digite o Endereco Completo"); //Define um valor padrão para o campo na tabela.

        }
    }
}
