namespace Entities.Dtos
{
    public class FormDto
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public string? Description { get; set; }

        public string? CreatedAt { get; set; }

        public int? CreatedBy { get; set; }

        public virtual UserDto? CreatedByNavigation { get; set; }

        public virtual ICollection<FieldDto> Fields { get; set; } = new List<FieldDto>();

    }
}
