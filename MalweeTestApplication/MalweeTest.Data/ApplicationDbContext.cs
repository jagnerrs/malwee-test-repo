using MalweeTest.Entities;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace MalweeTest.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }
        public static ApplicationDbContext Create()
        {
            ApplicationDbContext context = new ApplicationDbContext();
            Database.SetInitializer(new DBInitializer());
            context.Database.Initialize(false);

            return context;
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Cliente> Clientes { get; set; }

        public DbSet<Fornecedor> Fornecedores { get; set; }
        public DbSet<ServicoPrestado> ServicosPrestados { get; set; }
    }
}
