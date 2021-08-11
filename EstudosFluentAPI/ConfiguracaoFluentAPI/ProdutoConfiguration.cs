using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using static EstudosFluentAPI.Entidades;

namespace EstudosFluentAPI
{
    public class ProdutoConfiguration: IEntityTypeConfiguration<Produto>
    {
        //Configuração desta forma poder ser feito para criar uma configuração Fluent API de modo organizado por entidades
        public void Configure(EntityTypeBuilder<Produto> modelBuilder)
        {
            modelBuilder
                .HasKey(p => new { p.CodigoProduto, p.Referencia }); //Criar uma chave composta na tabela

            modelBuilder
                .Property(p => p.DataCriacao)
                .ValueGeneratedOnAdd(); //Indica que o valor para a coluna selecionada vai ser gerado sempre que uma nova entidade for adicionada ao banco dados 

            modelBuilder
                .Property(p => p.DataAtualizado)
                .ValueGeneratedOnAdd(); // Espedifica que o valor para a coluna selecionada será gerado sempre que uma nova entidade for adicionada ou uma entidade existente for modificada

            modelBuilder
                .Property(p => p.Desativado)
                .IsConcurrencyToken(); // Define que a propriedade vai tomar parte no gerenciamento de concorrencia.
        }
    }
}
