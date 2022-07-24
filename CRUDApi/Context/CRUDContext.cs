using CRUDApi.Mapping;
using CRUDApi.Model;
using Microsoft.EntityFrameworkCore;

namespace CRUDApi.Context
{
    public class CRUDContext : DbContext
    {
        public CRUDContext(DbContextOptions<CRUDContext> options) : base(options)
{
        }
        public virtual DbSet<Pessoa> Pessoa { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PessoaMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}