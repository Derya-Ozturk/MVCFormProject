using Entities.Entities;

namespace Entities.Dtos
{
    public class UserDto
    {
        public string? Username { get; set; }
        public string? Password { get; set; }
        public bool? LoginResult { get; set; }
        public virtual ICollection<Form> Forms { get; set; } = new List<Form>();
    }
}
