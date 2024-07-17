using System.ComponentModel.DataAnnotations;

namespace MVCFormProject.Models
{
    public class UserModel
    {
        public string? Username { get; set; }
        public string? Password { get; set; }
        public bool? LoginResult { get; set; }

    }
}
