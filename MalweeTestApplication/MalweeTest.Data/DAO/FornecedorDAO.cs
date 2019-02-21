using MalweeTest.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MalweeTest.Data.DAO
{
    public class FornecedorDAO : AbstractDAO<Fornecedor, int>
    {
        public override bool Delete(Fornecedor entity)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteById(int id)
        {
            throw new NotImplementedException();
        }

        public override List<Fornecedor> GetAll()
        {
            try
            {
                using (var context = new ApplicationDbContext())
                {
                    return context.Fornecedores.ToList();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public override Fornecedor GetById(int id)
        {
            throw new NotImplementedException();
        }

        public override bool Save(Fornecedor entity)
        {
            throw new NotImplementedException();
        }

        public override void Update(Fornecedor entity)
        {
            throw new NotImplementedException();
        }
    }
}
