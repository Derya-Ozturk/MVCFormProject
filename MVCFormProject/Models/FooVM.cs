using Entities.Entities;
using System.ComponentModel.DataAnnotations;

namespace MVCFormProject.Models
{
    public class FooVM
    {
        public Field Field { get; set; }
        public FormModel FormModel { get; set; }
        public List<FormModel> FormModelList { get; set; }
    }

    public class Rootobject
    {
        public Formmodel FormModel { get; set; }
        public Field Field { get; set; }
    }

    public class Formmodel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string CreatedBy { get; set; }
    }

    public class Field
    {
        public int Id { get; set; }

        public bool? Required { get; set; }

        [Required(ErrorMessage = "Required")]
        public string? Name { get; set; }

        public string? DataType { get; set; }

        public int? FormId { get; set; }

        public virtual Form? Form { get; set; }
    }

}
