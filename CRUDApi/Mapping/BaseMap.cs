using CRUDApi.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CRUDApi.Mapping
{
    public static class BaseMapping
    {
        public static void ConfigureBase<T>(this EntityTypeBuilder<T> builder)
            where T : Base
        {
            var tipo = typeof(T);

            builder.ToTable(tipo.Name);

            builder.Property(c => c.Id)
                .HasColumnType("bigint")
                .IsRequired();
            builder.Property(c => c.Status)
                .HasColumnType("bit");
        }
    }
}
