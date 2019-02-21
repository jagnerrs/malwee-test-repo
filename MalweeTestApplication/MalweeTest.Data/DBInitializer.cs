using MalweeTest.Entities;
using System.Collections.Generic;
using System.Data.Entity;


namespace MalweeTest.Data
{
    public class DBInitializer : DropCreateDatabaseIfModelChanges<ApplicationDbContext>
    {
        protected override void Seed(ApplicationDbContext context)
        {
            SeedClientes(context);
            SeedFornecedores(context);

            context.SaveChanges();
            base.Seed(context);
        }

        protected void SeedClientes(ApplicationDbContext context)
        {
            IList<Cliente> lstClientes = new List<Cliente>();

            lstClientes.Add(new Cliente() { Nome = "João", Bairro = "Centro", Cidade = "Florianópolis", Estado = "SC" });
            lstClientes.Add(new Cliente() { Nome = "Maria", Bairro = "Vila Nova", Cidade = "Jaraguá do Sul", Estado = "SC" });
            lstClientes.Add(new Cliente() { Nome = "Pedro", Bairro = "Batel", Cidade = "Curitiba", Estado = "PR" });
            lstClientes.Add(new Cliente() { Nome = "Joana", Bairro = "Morumbi", Cidade = "São Paulo", Estado = "SP" });
            lstClientes.Add(new Cliente() { Nome = "Marcio", Bairro = "Mooca", Cidade = "São Paulo", Estado = "SP" });
            lstClientes.Add(new Cliente() { Nome = "Gabriela", Bairro = "Beira Rio", Cidade = "Porto Alegre", Estado = "RS" });


            context.Clientes.AddRange(lstClientes);
        }

        protected void SeedFornecedores(ApplicationDbContext context)
        {
            IList<Fornecedor> lstFornecedores = new List<Fornecedor>();

            lstFornecedores.Add(new Fornecedor() { Nome = "CWB Serviços Gerais" });
            lstFornecedores.Add(new Fornecedor() { Nome = "Brasil Paisagismo" });
            lstFornecedores.Add(new Fornecedor() { Nome = "Nova Consertos" });

            context.Fornecedores.AddRange(lstFornecedores);
        }
    }
}
