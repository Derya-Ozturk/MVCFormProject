using Entities.Dtos;

namespace Business.Abstract
{
    public interface IFormService
    {
        Task<List<FormDto>> GetFormList();
        bool AddNewForm(FormDto formDto);
        Task<FormDto> GetById(int id);
    }
}
