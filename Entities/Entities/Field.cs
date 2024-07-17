namespace Entities.Entities
{
    public partial class Field
    {
        public int Id { get; set; }

        public bool? Required { get; set; }

        public string? Name { get; set; }

        public string? DataType { get; set; }

        public int? FormId { get; set; }

        public virtual Form? Form { get; set; }
    }
}
