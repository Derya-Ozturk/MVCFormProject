using AutoMapper;
using Business.Abstract;
using DataAccess.Abstract;
using Entities.Dtos;
using Entities.Entities;

namespace Business.Concrete
{
    public class FormManager : IFormService
    {
        IFormDal _formDal;
        private readonly IMapper _mapper;
        public FormManager(IFormDal formDal, IMapper mapper)
        {
            _formDal = formDal;
            _mapper = mapper;
        }

        public async Task<List<FormDto>> GetFormList()
        {
            var formList = await _formDal.GetFormList();

            List<FormDto> formDtoList = new();

            var dtoList = _mapper.Map<List<FormDto>>(formList);

            return dtoList;
        }
        public bool AddNewForm(FormDto formDto)
        {
            var form = _mapper.Map<Form>(formDto);

            var result = _formDal.AddNewForm(form);

            if (result == true)
                return true;
            return false;
        }

        public async Task<FormDto> GetById(int id)
        {
            var result = await _formDal.GetById(id);

            var formDtoList = _mapper.Map<FormDto>(result);

            return formDtoList;
        }
     
}
}
