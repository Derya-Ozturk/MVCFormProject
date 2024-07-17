using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Context;
using Entities.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete
{
    public class EfFormDal : EfEntityRepositoryBase<Form, MVCContext>, IFormDal
    {
        private readonly MVCContext _context;
        public EfFormDal()
        {
            _context = new MVCContext();
        }

        public async Task<List<Form>> GetFormList()
        {

            IQueryable<Form> formList = _context.Forms
                                        .Include(x => x.Fields)
                                        .Include(x => x.CreatedByNavigation).AsNoTracking();
              
            if (formList != null)
            {
                return formList.ToList();
            }
            return null;

        }
        public bool AddNewForm(Form form)
        {
            int result = Add(form);

            if (result != 0)
            {
                return true;
            }

            return false;
        }

        public Task<Form> GetById(int id)
        {
            IQueryable<Form> result = _context.Forms
                                        .Include(x => x.Fields)
                                        .Include(x => x.CreatedByNavigation).AsNoTracking().Where(x => x.Id == id);

            if (result != null)
            {
                return result.FirstOrDefaultAsync();
            }
            return null;
        }
    }
}
