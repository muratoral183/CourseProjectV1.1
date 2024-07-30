using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CourseProject.DAL.Entity
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        public int? Status { get; set; }
        public string? CategoryName { get; set; }
        public string? CategoryUrl { get; set; }
        public int IsProductType { get; set; }
        [NotMapped]
        public int? AmbSayisi { get; set; }
        [NotMapped]
        public IFormFile? File { get; set; }

    }
}
