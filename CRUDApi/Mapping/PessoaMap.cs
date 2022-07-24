using CRUDApi.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CRUDApi.Mapping
{
    public class PessoaMap : IEntityTypeConfiguration<Pessoa>
    {
        public void Configure(EntityTypeBuilder<Pessoa> builder)
        {
            builder.ConfigureBase();

            builder.Property(c => c.Nome)
                .HasColumnType("varchar(50)")
                .IsRequired();
            builder.Property(c => c.DataNascimento)
                .HasColumnType("datetime")
                .IsRequired();
        }
    }
}