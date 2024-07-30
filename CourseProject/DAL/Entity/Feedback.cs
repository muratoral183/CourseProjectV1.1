using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CourseProject.DAL.Entity
{
    public class Feedback
    {
        [Key]
        public int FeedbackId { get; set; }
        public string? FeedbackUrl { get; set; }
        public int? StartNumber { get; set; }
        public string? FeedbackText { get; set; }
        public string? NameSurname { get; set; }
        [NotMapped]
        public IFormFile? File { get; set; }
    }
}
