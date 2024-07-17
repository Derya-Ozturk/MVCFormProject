using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Context;
using Entities.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete
{
    public class EfLoginDal : EfEntityRepositoryBase<User, MVCContext>, ILoginDal
    {
        private readonly MVCContext _context;

        public EfLoginDal()
        {
            _context = new MVCContext();
        }
        public async Task<User> Authenticate(string mail, string password)
        {
            var user = await Get(x => x.Username == mail &&  x.Password == password);
        
            return user;

        }
    }
}
