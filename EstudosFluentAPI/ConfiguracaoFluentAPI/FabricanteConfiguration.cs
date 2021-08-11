using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using static EstudosFluentAPI.Entidades;

namespace EstudosFluentAPI
{
    public class FabricanteConfiguration: IEntityTypeConfiguration<Fabricante>
    {
        //Configuração desta forma poder ser feito para criar uma configuração Fluent API de modo organizado por entidades
        public void Configure(EntityTypeBuilder<Fabricante> modelBuilder)
        {
            modelBuilder
                .Property(f => f.ID)
                .ValueGeneratedNever(); //Especifica que o valor para a coluna selecionada nunca será gerado automáticamente pelo banco de dados.
        }
    }
}
