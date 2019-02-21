using MalweeTest.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MalweeTest.Data.DAO
{
    public class ClienteDAO : AbstractDAO<Cliente, int>
    {
        public override bool Delete(Cliente entity)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteById(int id)
        {
            throw new NotImplementedException();
        }

        public override List<Cliente> GetAll()
        {
            try
            {
                using (var context = new ApplicationDbContext())
                {
                    return context.Clientes.ToList();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public override Cliente GetById(int id)
        {
            throw new NotImplementedException();
        }

        public override bool Save(Cliente entity)
        {
            throw new NotImplementedException();
        }

        public override void Update(Cliente entity)
        {
            throw new NotImplementedException();
        }
    }
}
