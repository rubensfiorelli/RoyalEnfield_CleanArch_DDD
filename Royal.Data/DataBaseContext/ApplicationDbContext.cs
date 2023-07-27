using Microsoft.EntityFrameworkCore;
using Royal.Domain.Entities.ClienteContext;
using Royal.Domain.Entities.ProdutoContext;

namespace Royal.Data.DataBaseContext
{
    public class ApplicationDbContext : DbContext
    {

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Motocicleta> Motocicletas { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<ProdutoOrder> Orders { get; set; }
        public DbSet<ProdutoOrderService> Services { get; set; }



        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            ChangeTracker.LazyLoadingEnabled = false;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder
                .LogTo(Console.WriteLine)
                .EnableSensitiveDataLogging(true);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        }

    }
}
