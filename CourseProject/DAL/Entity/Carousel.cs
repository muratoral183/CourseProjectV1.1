using System.ComponentModel.DataAnnotations.Schema;

namespace CourseProject.DAL.Entity
{
    public class Carousel
    {
        public int CarouselId { get; set; }
        public string? CarouselUrl { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public double? Price { get; set; }
        public string? Qnit { get; set; }
        [NotMapped]
        public IFormFile? File { get; set; }
    }
}
