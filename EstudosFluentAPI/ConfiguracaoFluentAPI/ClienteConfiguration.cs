using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using static EstudosFluentAPI.Entidades;

namespace EstudosFluentAPI
{
    public class ClienteConfiguration: IEntityTypeConfiguration<Cliente>
    {
        //Configuração desta forma poder ser feito para criar uma configuração Fluent API de modo organizado por entidades
        public void Configure(EntityTypeBuilder<Cliente> modelBuilder)
        {
            modelBuilder
                .ToTable("Pessoas") // Define o nome para a Entidade(Tabela) no BD
                .HasKey(t => t.Codigo); // Define qual será Primary Key da tabela

            modelBuilder
                .Property(c => c.Nome)
                .HasColumnName("NomeDoCliente") //Define o nome da Coluna na tabela
                .HasMaxLength(250) // Define o tamanho máximo do campo na tabela
                .IsRequired(); // Denife a coluna como não anulável - is not null

            modelBuilder
                .Property(c => c.Endereco)
                .HasColumnType("varchar(150)") //Define o tipo específico do campo na tabela
                .HasDefaultValue("Digite o Endereco Completo"); //Define um valor padrão para o campo na tabela.
        }
    }
}
