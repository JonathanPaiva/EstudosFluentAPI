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

        public DbSet<Entidades.Aluno> Alunos { get; set; }
        public DbSet<Entidades.AlunoEndereco> Alunos_Enderecos { get; set; }

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

            //  Configurações padrões de Fluent API - Modelos, Entidades e Propriedades
            modelBuilder.HasDefaultSchema("Admin"); //Define o Schema utilizado nas tabelas do Banco de Dados

            modelBuilder.Ignore<Entidades.Fabricante>();  //Define se a Tabela vai ser encaminhado para a migration para ser criada no BD

            /*
            //Configuração das entidades via Fluent API pode ser feito separadamente por entidades da seguinte forma abaixo: 
                modelBuilder.ApplyConfiguration(new ClienteConfiguration());
                modelBuilder.ApplyConfiguration(new FabricanteConfiguration());
                modelBuilder.ApplyConfiguration(new GrupoConfiguration());
                modelBuilder.ApplyConfiguration(new ProdutoConfiguration());
                //Uma vez utilizado esses métodos enxuga mais o código do OnMoedlCreating()
                //---------------------------------------------------------
            /**/

            /*
            //Métodos aplicados nas propriedades
            modelBuilder.Entity<Entidades.Produto>()
                .HasKey(p => new { p.CodigoProduto, p.Referencia }); //Criar uma chave composta na tabela

            modelBuilder.Entity<Entidades.Grupo>()
                .HasIndex(g => g.NomeGrupo).IsUnique(); // HasIndex cria um índice para a columa / IsUnique cria um índice único para a coluna

            modelBuilder.Entity<Entidades.Grupo>()
                .HasAlternateKey(g => g.NomeGrupo); // Criar uma restrição exclusiva diferentes daquelas que foram a chave primária.

            modelBuilder.Entity<Entidades.Cliente>()
                .ToTable("Pessoas") // Define o nome para a Entidade(Tabela) no BD
                .HasKey(t => t.Codigo); // Define qual será Primary Key da tabela

            modelBuilder.Entity<Entidades.Cliente>()
                .Property(c => c.Nome)
                .HasColumnName("NomeDoCliente") //Define o nome da Coluna na tabela
                .HasMaxLength(250) // Define o tamanho máximo do campo na tabela
                .IsRequired(); // Denife a coluna como não anulável - is not null

            modelBuilder.Entity<Entidades.Cliente>()
                .Property(c => c.Endereco)
                .HasColumnType("varchar(150)") //Define o tipo específico do campo na tabela
                .HasDefaultValue("Digite o Endereco Completo"); //Define um valor padrão para o campo na tabela.

            //Apenas para nível de conhecimento do faz cada propriedade.
            //-----------------------------------------------------
            modelBuilder.Entity<Entidades.Fabricante>()
                .Property(f => f.ID)
                .ValueGeneratedNever(); //Especifica que o valor para a coluna selecionada nunca será gerado automáticamente pelo banco de dados.

            modelBuilder.Entity<Entidades.Produto>()
                .Property(p => p.DataCriacao)
                .ValueGeneratedOnAdd(); //Indica que o valor para a coluna selecionada vai ser gerado sempre que uma nova entidade for adicionada ao banco dados 

            modelBuilder.Entity<Entidades.Produto>()
                .Property(p => p.DataAtualizado)
                .ValueGeneratedOnAdd(); // Espedifica que o valor para a coluna selecionada será gerado sempre que uma nova entidade for adicionada ou uma entidade existente for modificada

            modelBuilder.Entity<Entidades.Produto>()
                .Property(p => p.Desativado)
                .IsConcurrencyToken(); // Define que a propriedade vai tomar parte no gerenciamento de concorrencia.
            //-----------------------------------------------------
            /**/

            // Configurações de Fluent API - Relacionamentos
            
            //Tipo de relacionamento um-para-um
            modelBuilder.Entity<Entidades.Aluno>()                              //Definie a Entidade na qual vai aplicar a configuração do relacionamento              
                .HasOne<Entidades.AlunoEndereco>(e => e.Endereco)               //Define a primeira estremidade do relacionamento 
                .WithOne(a => a.Aluno)                                          //Define a segunda estremidade do relacionamento
                .HasForeignKey<Entidades.AlunoEndereco>(a => a.AlunoID);        //Define a chave estrangeira na estreminada dependente
            //*********************************

            //Tipo de relacionamento um-para-muitos




            /**/
        }
    }
}
