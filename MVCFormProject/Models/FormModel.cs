namespace MVCFormProject.Models
{
    public class FormModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }              
        public int? CreatedBy { get; set; }
        public string? CreatedAt { get; set; }
        public virtual UserModel? CreatedByNavigation { get; set; }
        public virtual ICollection<Field> Fields { get; set; } = new List<Field>();
    }
}
