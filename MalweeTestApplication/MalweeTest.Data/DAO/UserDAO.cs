using MalweeTest.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace MalweeTest.Data.DAO
{
    public class UserDAO : AbstractDAO<ApplicationUser, int>
    {
        public override bool Delete(ApplicationUser entity)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteById(int id)
        {
            throw new NotImplementedException();
        }

        public override List<ApplicationUser> GetAll()
        {
            throw new NotImplementedException();
        }

        public override ApplicationUser GetById(int id)
        {
            throw new NotImplementedException();
        }

        public override bool Save(ApplicationUser entity)
        {
            throw new NotImplementedException();
        }

        public override void Update(ApplicationUser entity)
        {
            using (var context = new ApplicationDbContext())
            {
                context.Users.Attach(entity);
                context.Entry(entity).State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
