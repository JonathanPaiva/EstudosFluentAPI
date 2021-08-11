using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using static EstudosFluentAPI.Entidades;

namespace EstudosFluentAPI
{
    public class GrupoConfiguration: IEntityTypeConfiguration<Grupo>
    {
        //Configuração desta forma poder ser feito para criar uma configuração Fluent API de modo organizado por entidades
        public void Configure(EntityTypeBuilder<Grupo> modelBuilder)
        { 
            modelBuilder
                .HasIndex(g => g.NomeGrupo).IsUnique(); // HasIndex cria um índice para a columa / IsUnique cria um índice único para a coluna

            modelBuilder
                .HasAlternateKey(g => g.NomeGrupo); // Criar uma restrição exclusiva diferentes daquelas que foram a chave primária
        }
    }
}
