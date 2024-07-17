using Business.Abstract;
using Entities.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MVCFormProject.Models;

namespace MVCFormProject.Controllers
{
    [Authorize]
    public class FormController : Controller
    {
        private readonly IFormService _formService;
        public FormController(IFormService formService)
        {
            _formService = formService;
        }

        public async Task<IActionResult> Index()
        {
            FooVM model = new FooVM()
            {
                FormModelList = new List<FormModel>()
            };


            var formList = await _formService.GetFormList();

            if (formList != null)
            {
                for (int i = 0; i < formList.Count; i++)
                {
                    var fields = formList[i].Fields.Select(f => new Models.Field
                    {
                        Id = f.Id,
                        Required = f.Required,
                        Name = f.Name,
                        DataType = f.DataType,
                        FormId = f.FormId
                        //Form = f.Form // Eğer Form nesnesi de dönüştürme gerektiriyorsa, bu alanı da uygun şekilde dönüştürün.
                    }).ToList();

                    var user = new UserModel
                    {
                        Username = formList[i].CreatedByNavigation.Username,
                        Password = formList[i].CreatedByNavigation.Password
                    };

                    model.FormModelList.Add(new FormModel
                    {
                        Id = formList[i].Id,
                        Name = formList[i].Name,
                        Description = formList[i].Description,
                        CreatedAt = formList[i].CreatedAt,
                        CreatedBy = formList[i].CreatedBy,
                        Fields = fields,
                        CreatedByNavigation = user
                    });
                }

                return View(model);
            }

            return null;

        }

        [HttpPost]
        public IActionResult Create([FromBody] FooVM combinedJson)
        {

            if (!ModelState.IsValid)
            {
                return View("Index");
            }


            var createdAt = DateTime.Now;

            FormDto formDto = new()
            {
                Name = combinedJson.FormModel.Name,
                Description = combinedJson.FormModel.Description,
                CreatedBy = combinedJson.FormModel.CreatedBy,
                CreatedAt = createdAt.ToString("yyyy-MM-dd")
            };

            var addForm = _formService.AddNewForm(formDto);

            if (addForm == true)
            {
                return Json("Form added successfully");
            }

            return Ok();
        }

        public async Task<ActionResult> FormDetail(int id)
        {
            FooVM model = new FooVM();

            var formById = await _formService.GetById(id);

            if (formById != null)
            {
                var fields = formById.Fields.Select(f => new Models.Field
                {
                    Id = f.Id,
                    Required = f.Required,
                    Name = f.Name,
                    DataType = f.DataType,
                    FormId = f.FormId
                }).ToList();

                var user = new UserModel
                {
                    Username = formById.CreatedByNavigation.Username,
                    Password = formById.CreatedByNavigation.Password
                };

                model.FormModel = new FormModel
                {
                    Id = formById.Id,
                    Name = formById.Name,
                    Description = formById.Description,
                    CreatedAt = formById.CreatedAt,
                    CreatedBy = formById.CreatedBy,
                    Fields = fields     ,
                    CreatedByNavigation = user
                };
            }
            return View(model);
        }
    }
}