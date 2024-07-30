using System.ComponentModel.DataAnnotations.Schema;

namespace CourseProject.DAL.Entity
{
    public class CustomBanner
    {
        public int CustomBannerId { get; set; }
        public string? CustomBannerUrl { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? Link { get; set; }
        public int? BannnerStatus { get; set; }
        [NotMapped]
        public IFormFile? File { get; set; }
    }
}

