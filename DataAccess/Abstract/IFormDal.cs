using Entities.Entities;

namespace DataAccess.Abstract
{
    public interface IFormDal
    {
        Task<List<Form>> GetFormList();
        bool AddNewForm(Form form);
        Task<Form> GetById(int id);
    }
}
