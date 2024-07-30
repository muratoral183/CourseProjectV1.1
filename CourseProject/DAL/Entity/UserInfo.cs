using Microsoft.AspNetCore.Identity;

namespace CourseProject.DAL.Entity
{
    public class UserInfo :IdentityUser
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
    }
}
