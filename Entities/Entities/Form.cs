namespace Entities.Entities
{
    public partial class Form
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public string? Description { get; set; }

        public string? CreatedAt { get; set; }

        public int? CreatedBy { get; set; }

        public virtual User? CreatedByNavigation { get; set; }

        public virtual ICollection<Field> Fields { get; set; } = new List<Field>();
    }
}
