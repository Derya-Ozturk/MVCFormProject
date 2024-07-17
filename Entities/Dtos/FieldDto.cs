using Entities.Entities;

namespace Entities.Dtos
{
    public class FieldDto
    {
        public int Id { get; set; }

        public bool? Required { get; set; }

        public string? Name { get; set; }

        public string? DataType { get; set; }

        public int? FormId { get; set; }

        public virtual Form? Form { get; set; }
    }
}
